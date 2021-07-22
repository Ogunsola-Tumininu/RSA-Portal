using System;
using System.Configuration;
using System.Linq;
using System.Web.Mvc;
using System.Web.WebPages;
using Ionic.Zip;
using PalRSA.Core;
using PalRSA.Core.DataAccess;
using PalRSA.Core.Models;
using PalRSA.Helpers;
using System.Net;
using Postal;
using WebMatrix.WebData;
using System.IO;
using System.Web.Security;
using Newtonsoft.Json;
using System.Web;
using Excel;
using System.Data;

namespace PalRSA.Controllers
{
    [Authorize]
    [SessionExpire]
    [Authorize(Roles = "Administrator,SuperAdministrator")]
    public class AdminController : Controller
    {
        private readonly PalManager _manager = new PalManager();

        // GET: Admin
        public ActionResult Dashboard()
        {
            TempData["OneWeekLogin"] = _manager.GetLoginsForLastSevenDays();
            TempData["TotalNumberOfApplications"] = _manager.GetTotalNumberOfApplications();
            TempData["TotalNumberOfCompletedApplications"] = _manager.GetTotalNumberOfCompletedApplications();
            TempData["ProfileChanges"] = _manager.GetTotalNumberOfProfileChanges();
            return View();
        }

        public ActionResult CreateCustomer()
        {
            return View();
        }

        public ActionResult ViewAdmins()
        {
            ///TempData["admins"] = Roles.GetUsersInRole("Administrator");
            // 
            int totalRec = 0;
            // var users2 = Membership.GetAllUsers();

            // var users = new SimpleMembershipProvider().GetAllUsers(0, 5, out totalRec);
            var user = Roles.GetUsersInRole("Administrator");
            TempData["admins"] = Roles.GetUsersInRole("Administrator");
            TempData["super-admins"] = Roles.GetUsersInRole("SuperAdministrator");
            return View();
        }

        public ActionResult CreateAdmin()
        {
            ViewData["Roles"] = new SelectList(_manager.GetRoles().OrderBy(s => s.RoleName).ToList(), "RoleName", "RoleName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateAdmin(AdminProfile profile)
        {
            ViewData["Roles"] = new SelectList(_manager.GetRoles().OrderBy(s => s.RoleName).ToList(), "RoleName", "RoleName");
            if (!ModelState.IsValid) return View(profile);

            if (WebSecurity.UserExists(profile.Username))
            {
                TempData["Status"] = "exists";
                return View(profile);
            }

            WebSecurity.CreateUserAndAccount(profile.Username, profile.NewPassword,
                new { Email = profile.Email, AdminName = profile.AdminName });
            Roles.AddUserToRole(profile.Username, profile.RoleId);
            TempData["Status"] = "success";
            return View(profile);
        }

        public ActionResult EditAdmin(string username)
        {
            var admin = _manager.GetAdminProfileForEdit(username);
            admin.RoleId = Roles.GetRolesForUser(username)[0];
            ViewData["Roles"] = new SelectList(_manager.GetRoles().OrderBy(s => s.RoleName).ToList(), "RoleName", "RoleName");
            return View(admin);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditAdmin(AdminProfile profile)
        {
            ViewData["Roles"] = new SelectList(_manager.GetRoles().OrderBy(s => s.RoleName).ToList(), "RoleId", "RoleName");
            if (!ModelState.IsValid) return View(profile);
            _manager.UpdateAdminInfo(profile, WebSecurity.GetUserId(profile.Username));
            ManageRole(profile.RoleId, profile.Username);
            if (profile.NewPassword != null)
            {
                var token = WebSecurity.GeneratePasswordResetToken(profile.Username);
                var status = WebSecurity.ResetPassword(token, profile.NewPassword);
            }

            TempData["Status"] = "success";
            return View(profile);
        }

        private void ManageRole(string roleId, string username)
        {
            var roles = Roles.GetRolesForUser(username);
            if (roles[0] == roleId) return;
            Roles.RemoveUserFromRole(username, roles[0]);
            Roles.AddUserToRole(username, roleId);
        }

        public ActionResult ViewClientProfile(string pin)
        {
            var x = _manager.GetFullProfile(pin);
            return View(x);
        }

        public ActionResult ViewChanges()
        {
            var x = _manager.GetAllUpdates();
            return View(x);
        }

        public ActionResult ListChangeOfName()
        {
            var x = _manager.GetAllChangeOfName();
            return View(x);
        }

        public ActionResult ApproveNameChange(int id)
        {
            var x = _manager.GetChangeOfNameDetails(id);
            return View(x);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ApproveNameChange(ChangeOfNameProfile model)
        {
            _manager.ChangeOfNameApproved(model);
            _manager.NameChangeStatus(model.Id, "Approved");

            TempData["Status"] = "success";

            dynamic email = new Email("ChangeOfNameApproved");
            email.To = _manager.GetEmployeeEmail(model.Pin);
            email.Name = _manager.GetEmploteeFullName(model.Pin);
            email.Send();
            return View(model);
        }

        [HttpPost]
        public JsonResult RejectNameChange(int id, string reason, string pin)
        {
            _manager.NameChangeStatus(id, "Rejected");
            _manager.RejectedNameReasonUpdate(id, reason);

            dynamic email = new Email("ChangeOfNameRejected");
            email.To = _manager.GetEmployeeEmail(pin);
            email.Name = _manager.GetEmploteeFullName(pin);
            email.Reason = reason;
            email.Send();
            return Json("success");
        }

        public ActionResult ListChangeOfAddress()
        {
            var x = _manager.GetAllChangeOfAddress();
            return View(x);
        }

        public ActionResult ApproveAddressChange(int id)
        {
            var x = _manager.GetChangeOfAddressDetails(id);
            return View(x);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ApproveAddressChange(ChangeOfAddressProfile model)
        {
            _manager.ChangeOfAddressApproved(model);
            _manager.AddressChangeStatus(model.Id, "Approved");

            TempData["Status"] = "success";

            dynamic email = new Email("ChangeOfAddressApproved");
            email.To = _manager.GetEmployeeEmail(model.Pin);
            email.Name = _manager.GetEmploteeFullName(model.Pin);
            email.Send();
            return View(model);
        }

        [HttpPost]
        public JsonResult RejectAddressChange(int id, string reason, string pin)
        {
            _manager.AddressChangeStatus(id, "Rejected");
            _manager.RejectedAddressReasonUpdate(id, reason);

            dynamic email = new Email("ChangeOfAddressRejected");
            email.To = _manager.GetEmployeeEmail(pin);
            email.Name = _manager.GetEmploteeFullName(pin);
            email.Reason = reason;
            email.Send();
            return Json("success");
        }

        public ActionResult Approve(int id)
        {
            var x = _manager.GetUpdateInformation(id);
            return View(x);
        }

        [HttpPost]
        public ActionResult Approve(TempCustomerInformation model)
        {
            TempData["Status"] = _manager.UpdateEmployeeProfile(model);
            _manager.UpdateTempStatus("Approved", model.id);

            SendMail(model.email, model.name, "NameUpdateApproved");

            return View(model);
        }

        [NonAction]
        public void SendMail(string to, string name, string view)
        {
            dynamic email = new Email(view);
            email.To = to;
            email.Name = name;
            email.Send();
        }

        public ActionResult ViewApplications()
        {
            var x = _manager.GetAllSubmittedApplications();
            return View(x);
        }

        public ActionResult InterestExpression()
        {
            var x = _manager.GetAllInterests();
            return View(x);
        }

        public PartialViewResult ViewExpression(int id)
        {
            return PartialView("_ViewExpression", _manager.GetExpressionDetails(id));
        }

        public ActionResult ViewTreatedApplications()
        {
            var x = _manager.GetAllSubmittedApplications();
            return View(x);
        }

        public ActionResult ViewBenefitApplication(int id)
        {
            var x = _manager.GetApplicationInformation(id);
            ViewData["Status"] = new SelectList(_manager.GetStatus().OrderBy(s => s.StatusValue).ToList(), "StatusId", "StatusValue", x.Status1.StatusId);
            return View(x);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ViewBenefitApplication(int statusId, int benefitId, string description, string pin)
        {
            var result = _manager.UpdateStatus(statusId, benefitId, description);
            var x = _manager.GetApplicationInformation(benefitId);
            var info = _manager.CreateEmailVariablesForStatusUpdate(benefitId, pin, statusId);

            var stat = (description.IsEmpty() | description == "invalid") ? SendUpdateMail(info) : SendUpdateMail(info, description);

            TempData["Done"] = result;
            ViewData["Status"] = new SelectList(_manager.GetStatus().OrderBy(s => s.StatusValue).ToList(), "StatusId", "StatusValue", x.Status1.StatusId);
            return View(x);
        }

        [NonAction]
        private static bool SendUpdateMail(Mailer info)
        {
            var body = string.Format(System.IO.File.ReadAllText(System.Web.Hosting.HostingEnvironment.MapPath(ConfigurationManager.AppSettings["update-mail"]))
                            , info.Name, info.Status);
            Helpers.Helper.SendMail(info.Email, body, "Application Update", info.ApplicationType);
            return true;
        }

        [NonAction]
        private static bool SendUpdateMail(Mailer info, string description)
        {
            var body = string.Format(System.IO.File.ReadAllText(System.Web.Hosting.HostingEnvironment.MapPath(ConfigurationManager.AppSettings["update-mail-reject"]))
                            , info.Name, description);
            Helpers.Helper.SendMail(info.Email, body, "Application Update", info.ApplicationType);
            return true;
        }

        [AllowAnonymous]
        [AllowCrossSiteJson]
        public JsonResult GetPriceForWeb()
        {
            var fund = _manager.FundForWeb();
            return Json(fund, JsonRequestBehavior.AllowGet);
        }

        [AllowAnonymous]
        [AllowCrossSiteJson]
        [HttpGet]
        public JsonResult GetAssetAllocationForWeb(int type)
        {
            var assets = _manager.JsonAssetAllocationWeb(type);
            return Json(assets, JsonRequestBehavior.AllowGet);
        }

        [AllowAnonymous]
        [AllowCrossSiteJson]
        [HttpGet]
        public JsonResult FilterPriceForWeb(DateTime from, DateTime to, int schemeId)
        {

            var fund = _manager.JsonFilterPriceForWeb(from, to, Convert.ToDouble(schemeId));
            return Json(fund, JsonRequestBehavior.AllowGet);
        }

        [AllowAnonymous]
        [AllowCrossSiteJson]
        [HttpGet]
        public JsonResult GetPriceForWebForSeven(int schemeId)
        {
            var fund = _manager.JsonPriceForWebType(Convert.ToDouble(schemeId));
            return Json(fund, JsonRequestBehavior.AllowGet);
        }

        [AllowAnonymous]
        [AllowCrossSiteJson]
        public JsonResult GetRetireePriceForWeb(int month, int year)
        {
            var fund = _manager.JsonRetireePriceForWeb(month, year);
            return Json(fund, JsonRequestBehavior.AllowGet);
        }

        [AllowAnonymous]
        [AllowCrossSiteJson]
        public JsonResult SaveInterestToDb(string obj)
        {
            _manager.SaveExpressionToDb(JsonConvert.DeserializeObject<ExpressionOfInterest>(obj));

            return Json("success", JsonRequestBehavior.AllowGet);
        }

        [AllowAnonymous]
        [AllowCrossSiteJson]
        public JsonResult SaveNewInterestToDb(string obj)
        {
            var rs = _manager.SaveNewExpressionToDb(JsonConvert.DeserializeObject<NewExpressionOfInterest>(obj));
            //if (rs.Equals("S", StringComparison.CurrentCultureIgnoreCase))
            //{

            //}
            return Json("success", JsonRequestBehavior.AllowGet);
        }
        [AllowAnonymous]
        [AllowCrossSiteJson]
        public ActionResult GetPFAs()
        {
            var items = _manager.GetPFA();
            return Json(items.ToList(), JsonRequestBehavior.AllowGet);
        }

        [AllowAnonymous]
        [AllowCrossSiteJson]
        public JsonResult SaveFeedbackToDb(string obj)
        {
            _manager.SaveFeedbackToDb(JsonConvert.DeserializeObject<Feedback>(obj));
            return Json("success", JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public void DownloadZip(string folderId, string type)
        {
            var path = type == "application"
                ? ConfigurationManager.AppSettings["document-folder"]
                : ConfigurationManager.AppSettings["profile-change"];
            Response.Clear();
            Response.BufferOutput = false;  // for large files
            var filename = folderId + ".zip";
            Response.ContentType = "application/zip";
            Response.AddHeader("content-disposition", "filename=" + filename);

            using (ZipFile zip = new ZipFile())
            {
                zip.AddDirectory(Server.MapPath(path + folderId), "");
                zip.Save(Response.OutputStream);
            }

            Response.Close();
        }

        public ActionResult ViewPublications()
        {
            var x = _manager.GetAllPublications();
            return View(x);
        }

        public ActionResult UploadPublications()
        {
            ViewData["UploadType"] = new SelectList(_manager.GetUploadType().OrderBy(s => s.UploadTypeValue).ToList(), "UploadTypeID", "UploadTypeValue");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UploadPublications(UploadPublications model)
        {
            ViewData["UploadType"] = new SelectList(_manager.GetUploadType().OrderBy(s => s.UploadTypeValue).ToList(), "UploadTypeID", "UploadTypeValue");
            if (_manager.NameAlreadyExists(model.DocName))
            {
                TempData["Status"] = "exists";
                return View();
            }

            _manager.SavePublicationInformation(model);
            _manager.UploadPublicationDocument(model);
            TempData["Status"] = "success";
            return View();
        }

        public ActionResult ViewManagers()
        {
            var x = _manager.GetAllManager();
            return View(x);
        }

        public ActionResult CreateManager()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateManager(AccountManager model)
        {
            if (!ModelState.IsValid) return View(model);

            if (_manager.CreateManager(model) == "exists")
            {
                TempData["Status"] = "exists";
                return View(model);
            }

            TempData["Status"] = "success";
            dynamic email = new Email("NewManagerCreated");
            email.To = model.EMAIL;
            email.Name = model.AccountManagers;
            email.Send();
            return View(model);
        }

        public ActionResult EditManager(int id)
        {
            var x = _manager.GetManagerInfo(id);
            TempData["Status"] = " ";
            return View(x);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditManager(AccountManager model)
        {
            TempData["Status"] = _manager.UpdateManagerInfo(model);
            return View(model);
        }

        public ActionResult ViewAllEmployeesByManager(int id)
        {
            var x = _manager.GetManagerInfo(id);
            return View(x);
        }

        public ActionResult ChangeManager(string pin)
        {
            ViewData["Managers"] = new SelectList(_manager.GetAllManager().OrderBy(s => s.AccountManagers).ToList(), "ManagerId", "AccountManagers");
            var x = _manager.GetEmployeeTransactions(pin);
            TempData["Status"] = false;
            return View(x);
        }

        [HttpPost]
        public ActionResult ChangeManager(Employee model)
        {
            ViewData["Managers"] = new SelectList(_manager.GetAllManager().OrderBy(s => s.AccountManagers).ToList(), "ManagerId", "AccountManagers");
            TempData["Status"] = _manager.UpdateEmployeeManager(model.Pin, model.AccountManager.ManagerId);
            var manager = _manager.GetManagerInfo(model.AccountManager.ManagerId);

            dynamic email = new Email("ManagerChanged");
            email.To = model.Email;
            email.Name = model.Surname + " " + model.FirstName;
            email.ManagerName = manager.AccountManagers;
            email.ManagerPhone = manager.Phonenumber;
            email.ManagerEmail = manager.EMAIL;
            email.Send();

            dynamic adminEmail = new Email("NewClientAssigned");
            adminEmail.To = manager.EMAIL;
            adminEmail.Name = manager.AccountManagers;
            adminEmail.ClientName = model.FirstName + " " + model.Surname;
            adminEmail.ClientPhone = model.MobileNumber;
            adminEmail.ClientEmail = model.Email;
            adminEmail.Send();
            return View(_manager.GetEmployeeTransactions(model.Pin));
        }
        public ActionResult UploadAssetAllocations()
        {
            ViewData["Type"] = new SelectList(_manager.GetAssetTypes().OrderBy(s => s.value).ToList(), "id", "value");
            TempData["Status"] = false;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UploadAssetAllocations(AssetAllocationsUpload doc)
        {
            //try
            //{
            var path = _manager.SaveExcelInTempDir(doc);
            TempData["Status"] = _manager.SaveFileToDb(path, doc.AssetType);
            ViewData["Type"] = new SelectList(_manager.GetAssetTypes().OrderBy(s => s.value).ToList(), "id", "value");
            //}
            //catch (Exception ex)
            //{

            //    throw ex;
            //}



            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UploadAssetAllocation(FormCollection fc, HttpPostedFileBase inputFile)
        {

            if (inputFile != null && inputFile.ContentLength > 0)
            {
                Stream stream = inputFile.InputStream;

                // We return the interface, so that
                IExcelDataReader reader = null;
                if (inputFile.FileName.EndsWith(".xls", StringComparison.OrdinalIgnoreCase))
                {
                    reader = ExcelReaderFactory.CreateBinaryReader(stream);
                }
                else if (inputFile.FileName.EndsWith(".xlsx", StringComparison.OrdinalIgnoreCase))
                {
                    reader = ExcelReaderFactory.CreateOpenXmlReader(stream);
                }

                reader.IsFirstRowAsColumnNames = true;
                DataSet result = reader.AsDataSet();
                var t = result.Tables[0];
                try
                {
                    using (var ctxt = new PALSiteDBEntities())
                    {
                        foreach (DataRow row in t.Rows)
                        {

                            var asset = new AssetAllocation();
                            if (row[0].ToString() != "")
                            {
                                asset.date_created = Convert.ToDateTime(row[0].ToString());
                            }
                            if (row[1].ToString() != "")
                            {
                                asset.equity = Convert.ToDouble(row[1].ToString());
                            }
                            if (row[2].ToString() != "")
                            {
                                asset.fixed_income = Convert.ToDouble(row[2].ToString());
                            }
                            if (row[3].ToString() != "")
                            {
                                asset.money_market = Convert.ToDouble(row[3].ToString());
                            }
                            if (row[4].ToString() != "")
                            {
                                asset.others = Convert.ToDouble(row[4].ToString());
                            }
                            asset.asset_allocation_type = Convert.ToInt32(fc["AssetType"]);

                            ctxt.AssetAllocations.Add(asset);

                        }
                        ctxt.SaveChanges();
                        TempData["success"] = " Saved succesfully";
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {

                    TempData["error"] = "Error occured  " + ex.Message;
                }


            }
            ViewData["Type"] = new SelectList(_manager.GetAssetTypes().OrderBy(s => s.value).ToList(), "id", "value");
            return View("UploadAssetAllocations");
        }


        public ActionResult ViewAssetAllocations()
        {
            var x = _manager.GetAssetAllocations();
            return View(x);
        }
    }
}