using System;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;
using PalRSA.Core;
using PalRSA.Core.DataAccess;
using PalRSA.Core.Models;
using PalRSA.Helpers;
using Postal;
using Rotativa;
using WebMatrix.WebData;
// using PalRSA.DAL;
using System.Data.Entity;
using System.Collections.Generic;
using Ionic.Zip;
using PalLibrary;

namespace PalRSA.Controllers
{
    [Authorize]
    [HandleError]
    [SessionExpire]
    public class CustomerController : Controller
    {
        private readonly PalManager _manager = new PalManager();
        // private readonly PalRSA.Models.WebsiteEntities _db = new Models.WebsiteEntities();
        private PALSiteDBEntities _db = new PALSiteDBEntities();
        private List<int> selected;

        public ActionResult Home()
        {
            var pin = User.Identity.Name;
            // pin = "PEN100618856423 ";
            try
            {
                var fundId = _manager.GetFunId(pin);
                // if (fundId == null | fundId == 0) return View("ContactPal");
                TempData["isRetirementToo"] = _manager.CheckRetirement(pin);
                var emp = _manager.GetEmployeeDetails(pin);
                ViewBag.contributions = _manager.GetContributions(pin, fundId);

                ViewBag.Header = Helpers.Helper.GetHeader(fundId);
                var report = _manager.EmployeeReportSummationMethod(pin, fundId, null);
               

                return View(report);
            }
            catch (Exception ex)
            {
                Library.WriteErrorLog(ex, "Home: " + User.Identity.Name);
                return View();
            }
        }

        public ActionResult Acknowledge()
        {
            string pin = User.Identity.Name;

            var emp = _db.Employees.Where(d => d.Pin == pin).FirstOrDefault();
            return View(emp);
        }

        [HttpPost]
        public PartialViewResult GetSummaryReport(string type)
        {
            var x = new EmployeeReportSummation();
            var pin = User.Identity.Name;
            var emp = _manager.GetEmployeeDetails(pin);
            switch (type)
            {
                case "value":
                    x = _manager.EmployeeReportSummationMethod(pin, 1, null);
                    break;
                case "retire":
                    x = _manager.EmployeeReportSummationMethod(pin, 10000053, null);
                    break;
            }
            return PartialView("Partials/_value_fund", x);
        }

        // GET: Customer
        public ActionResult Dashboard()
        {
            TempData["Employees"] = _manager.GetEmployeeTransactions(_manager.GetEmployeePin(User.Identity.Name));
            TempData["Summary"] = _manager.GenerateStatement(_manager.GetEmployeePin(User.Identity.Name));
            //TempData["Summary"] = _manager.GetDashboardValues(_manager.GetEmployeePin(User.Identity.Name));
            //_manager.GetEmployeeDetails(User.Identity.Name);
            return View();
        }

        public ActionResult ApplyBenefits()
        {
            ViewBag.BenefitClass =
                _manager.GetBenefitClasses().OrderBy(x => x.BenefitName).Select(x => new SelectListItem()
                {
                    Text = x.BenefitName,
                    Value = x.Id.ToString()
                });

            var userPin = User.Identity.Name;
            ViewBag.UserDetail = _db.BenefitFiles.Where(d => d.PIN == userPin).ToList();


            return View();
        }

        [HttpGet]
        public ActionResult BenefitApplication()
        {
            ViewBag.BenefitClass =
               _manager.GetBenefitClasses().OrderBy(x => x.BenefitName).Select(x => new SelectListItem()
               {
                   Text = x.BenefitName,
                   Value = x.Id.ToString()
               });

            var y = _manager.GetBenefit(_manager.GetEmployeePin(User.Identity.Name));
            return View(y);
        }
        
        // GET: BenefitProcess/Create
        public ActionResult CreateBenefitRequest()
        {            
            //ViewBag.PaymentTypeId = new SelectList(_db.BenefitClasses, "Id", "BenefitName");
            ViewBag.PaymentTypeId = new SelectList(_db.BenefitClasses.Where(d => d.Id == 2 || d.Id == 3), "Id", "BenefitName");
            ViewBag.StateId = new SelectList(_db.States, "StateId", "Name");
           // ViewBag.StatusId = new SelectList(_db.BenefitStatus, "StatusId", "StatusValue");
            ViewBag.TitleId = new SelectList(_db.Titles, "TitleId", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateBenefitRequest([Bind(Include = "Id,TitleId,PaymentTypeId,File,FileNo,PIN,EmployeeName,DateReceived,DateDisengaged,EmployerCode,EmployerName,EmployeeAddress,EmployeeAddress2,StateId,MobilePhone,Email,StatusId")] BenefitProcess benefitProcess)
        {
            if (ModelState.IsValid)
            {
                benefitProcess.CreatedOn = DateTime.Now;
                benefitProcess.CreatedBy = User.Identity.Name;
                
                _db.BenefitProcesses.Add(benefitProcess);
                _db.SaveChanges();


                _db.BenefitStatusLogs.Add(new BenefitStatusLog
                {
                    Comment = "",
                    StatusId = benefitProcess.StatusId,
                    BenefitProcessId = benefitProcess.Id,
                    CreatedBy = User.Identity.Name,
                    CreatedOn = DateTime.Now
                });
               _db.SaveChanges();

                return RedirectToAction("upload", new { id = benefitProcess.Id });
            }

            ViewBag.PaymentTypeId = new SelectList(_db.BenefitClasses.Where(d => d.Id == 2 || d.Id == 3), "Id", "BenefitName");
            //ViewBag.PaymentTypeId = new SelectList(_db.BenefitClasses, "Id", "BenefitName", benefitProcess.PaymentTypeId);
            ViewBag.StateId = new SelectList(_db.States, "Id", "Name", benefitProcess.StateId);
            ViewBag.TitleId = new SelectList(_db.Titles, "TitleId", "Name", benefitProcess.TitleId);
            return View(benefitProcess);
        }




        [HttpGet]
        //FeedbackRequest
        public ActionResult Feedback()
        {
            ViewBag.Pin = User.Identity.Name;
             //ViewData["SupportType"] = new SelectList(_manager.GetSupportType().OrderBy(s => s.Value).ToList(), "Id", "Value");
            ViewBag.SupportType = new SelectList(_db.SupportTypes.ToList(), "Id", "SupportType1");
            return View();
        }

        [HttpPost]
        public ActionResult Feedback([Bind(Include = "Id,Pin,CategoryId,Summary,Explanation,PALComment,CategoryName")] SupportLog feedlog)
        {
            ViewData["SupportType"] = new SelectList(_manager.GetSupportType().OrderBy(s => s.Id).ToList(), "Id", "SupportType1");
            if (ModelState.IsValid)
            {

                feedlog.DateSubmitted = DateTime.Now;

                _db.SupportLogs.Add(feedlog);
                _db.SaveChanges();

                try
                {
                    var emp = _db.Employees.FirstOrDefault(d => d.Pin == feedlog.Pin);
                    // Send Email 
                    var msg = PalLibrary.Messaging.SendEmail("info@palpensions.com", "helpdesk@palpensions.com", $"Feedback ({feedlog.CategoryId}) Notification - {emp.Surname} {emp.FirstName}", $@"
                    <p>Hello Info, 

                    <p>Your client ({feedlog.Pin}) wrote at {DateTime.Now.ToString("MMM dd yyyy hh:mm:ss tt")}: <br />
                     
                    <strong>Title:</strong> {feedlog.Summary}<br/>
                    <strong>Details:</strong> {feedlog.Explanation}<br/></p>
                   
                <hr />    
                     
                <p>For a list of feedback,request or complaints, please visit https://pallite.palpensions.com/Staff/SupportLogs </p>  
  
 
            <p>         Regards<br/>

                    PAL Pensions</p>");

                }
                catch (Exception ex)
                {

                }

                // return RedirectToAction("Home");
            }
            return RedirectToAction("Home");
            //return View();
        }


        public ActionResult Benefits()
        {            
            var x = _manager.GetAllUserBenefitApplications(_manager.GetEmployeePin(User.Identity.Name));
            return View(x);
        }

        public ActionResult CheckProfileStatus()
        {
            TempData["NameChange"] = _manager.GetAllChangeOfName(User.Identity.Name);
            TempData["AddressChange"] = _manager.GetAllChangeOfAddress(User.Identity.Name);
            return View();
        }

        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public ActionResult ViewNameChange(int id)
        {
            var x = _manager.GetChangeOfNameDetails(id);
            TempData["Sex"] = x.Employee.Gender;
            return View(x);
        }

        [HttpPost]
        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        [ValidateAntiForgeryToken]
        public ActionResult ViewNameChange(ChangeOfNameProfile model, HttpPostedFileBase doc1, HttpPostedFileBase doc2, string sex)
        {
            if (!ModelState.IsValid)
            {
                TempData["Status"] = "invalid";
                return View();
            }

            var uploadName = sex == "M" ? "Court Affidavit" : "Marriage Certificate";

            if (doc1 != null)
            {
                _manager.SaveToFolder(model.DocumentId, uploadName, ConfigurationManager.AppSettings["profile-change"], doc1, ConfigurationManager.AppSettings["profile-change-thumb"]);
            }

            if (doc2 != null)
            {
                _manager.SaveToFolder(model.DocumentId, "Newspaper Publication", ConfigurationManager.AppSettings["profile-change"], doc2, ConfigurationManager.AppSettings["profile-change-thumb"]);
            }

            _manager.UpdateChangeOfNameDetails(model, model.DocumentId);
            _manager.NameChangeStatus(model.Id, "Pending");

            dynamic email = new Email("ChangeOfAddress");
            email.To = _manager.ReturnAdminEmail();
            email.Name = "Admin";
            email.ClientName = _manager.GetEmploteeFullName(model.Pin);
            email.Send();

            TempData["Status"] = "success";
            return View(model);
        }

        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public ActionResult ViewAddressChange(int id)
        {
            var x = _manager.GetChangeOfAddressDetails(id);
            return View(x);
        }

        [HttpPost]
        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        [ValidateAntiForgeryToken]
        public ActionResult ViewAddressChange(ChangeOfAddressProfile model, HttpPostedFileBase utility)
        {
            if (!ModelState.IsValid)
            {
                TempData["Status"] = "invalid";
                return View();
            }

            if (utility != null)
            {
                _manager.SaveToFolder(model.DocumentId, "Utility Bill", ConfigurationManager.AppSettings["profile-change"], utility, ConfigurationManager.AppSettings["profile-change-thumb"]);
            }

            _manager.UpdateChangeOfAddressDetails(model, model.DocumentId);
            _manager.AddressChangeStatus(model.Id, "Pending");

            dynamic email = new Email("ChangeOfAddress");
            email.To = _manager.ReturnAdminEmail();
            email.Name = "Admin";
            email.ClientName = _manager.GetEmploteeFullName(model.Pin);
            email.Send();

            TempData["Status"] = "success";
            return View(model);
        }

        public ActionResult ViewProfile()
        {
            var x = _manager.GetProfile(_manager.GetEmployeePin(User.Identity.Name));
            return View(x);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ViewProfile(EmployeeViewModel model)
        {
            TempData["Status"] = _manager.UploadProfileChangeForConfirmation(model);

            dynamic email = new Email("UpdateNotification");
            email.To = _manager.ReturnAdminEmail();
            email.Name = "Admin";
            email.ClientName = model.FirstName + " " + model.Surname;
            email.Send();

            var x = _manager.GetProfile(_manager.GetEmployeePin(User.Identity.Name));
            return View(x);
        }

        public ActionResult ChangeName()
        {
            var x = _manager.GetProfileForChangeOfName(_manager.GetEmployeePin(User.Identity.Name));
            return View(x);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChangeName(ChangeOfName model)
        {
            if (!ModelState.IsValid)
            {
                TempData["Status"] = "invalid";
                return View();
            }

            var documentId = _manager.CreateNewDocumentId();
            _manager.CreateFolder(documentId, ConfigurationManager.AppSettings["profile-change"], ConfigurationManager.AppSettings["profile-change-thumb"]);

            var uploadName = model.Sex == "M" ? "Court Affidavit" : "Marriage Certificate";

            _manager.SaveToFolder(documentId, uploadName, ConfigurationManager.AppSettings["profile-change"], model.Doc1, ConfigurationManager.AppSettings["profile-change-thumb"]);
            _manager.SaveToFolder(documentId, "Newspaper Publication", ConfigurationManager.AppSettings["profile-change"], model.Doc2, ConfigurationManager.AppSettings["profile-change-thumb"]);

            _manager.SaveChangeOfNameDetails(model, documentId);

            dynamic email = new Email("ChangeOfName");
            email.To = _manager.ReturnAdminEmail();
            email.Name = "Admin";
            email.ClientName = model.OldName;
            email.Send();

            TempData["Status"] = "success";
            return View(model);
        }

        public ActionResult ChangeAddress()
        {
            var x = _manager.GetProfileForChangeOfAddress(_manager.GetEmployeePin(User.Identity.Name));
            return View(x);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChangeAddress(ChangeOfAddress model)
        {
            if (!ModelState.IsValid)
            {
                TempData["Status"] = "invalid";
                return View();
            }

            var documentId = _manager.CreateNewDocumentId();
            _manager.CreateFolder(documentId, ConfigurationManager.AppSettings["profile-change"], ConfigurationManager.AppSettings["profile-change-thumb"]);

            _manager.SaveToFolder(documentId, "Utility Bill", ConfigurationManager.AppSettings["profile-change"], model.UtilityBill, ConfigurationManager.AppSettings["profile-change-thumb"]);

            _manager.SaveChangeOfAddressDetails(model, documentId);

            dynamic email = new Email("ChangeOfAddress");
            email.To = _manager.ReturnAdminEmail();
            email.Name = "Admin";
            email.ClientName = _manager.GetEmploteeFullName(model.Pin);
            email.Send();

            TempData["Status"] = "success";
            return View(model);
        }



        public ActionResult ShowPassport(int id)
        {
            var image = _db.CFIBiometrics.FirstOrDefault(d => d.UserId == id);

            var file = GetImageAdministrationPassportStorePath() + "\\" + image.Passport;
            //var file = "E:\Recapture\BiometricProjectUpload" + image.Passport;
            var ext = file.Split('.').Last();
            return File(file, "image/" + ext, Path.GetFileName(file));
        }

        public ActionResult ShowSignature(int id)
        {
            var image = _db.CFIBiometrics.FirstOrDefault(d => d.UserId == id);
            var file = GetImageAdministrationSignaturePath() + "\\" + image.ContributorSignature;
            var ext = file.Split('.').Last();
            return File(file, "image/" + ext, Path.GetFileName(file));
        }

        private string GetImageAdministrationPassportStorePath()
        {
            return _db.ImageAdministrations.Select(d => d.PassportPhotograph).First();
        }

        private string GetImageAdministrationSignaturePath()
        {
            return _db.ImageAdministrations.Select(d => d.Signature).First();
        }

        //[HttpGet]
        //public ActionResult ClientUpdate()
        //{
        //    return View();
        //}

        [HttpGet]
        public ActionResult ClientUpdate()        
        {
            GetList();
            var x = _manager.GetProfile(_manager.GetEmployeePin(User.Identity.Name));
            return View(x);
        }

        public ActionResult ClientUpdate_Old(TempCustomerInformation clientUpdate)
        {

            clientUpdate.date_created = DateTime.Now;
            clientUpdate.DateProcessed = DateTime.Now;

            _db.TempCustomerInformations.Add(clientUpdate);
            _db.SaveChanges();

            return RedirectToAction("Home", clientUpdate);
        }

        [HttpPost]
        public ActionResult ClientUpdate(EmployeeViewModel model)
        {
            GetList(model);
            TempData["Status"] = _manager.UploadProfileChangeForConfirmation(model);

            try
            {
                var emp = _db.Employees.FirstOrDefault(d => d.Pin == model.Pin);

                var nokInfo = emp.NextOfKins.FirstOrDefault(n => n.Employee_Pin == model.Pin);

                emp.Employer_Recno = model.EmployerDetail.Recno ;
                emp.Employer_name = model.EmployerDetail.EmployerName;
                emp.MobileNumber = model.MobileNumber;
                emp.MobileNumber2 = model.MobileNumber2;
                emp.Email = model.Email;
                emp.IsNigerian = model.IsNigerian;
                emp.StreetName = model.StreetName;
                emp.HouseNo = model.HouseNo;
                emp.StateCode = model.StateCode;
                emp.CountryCode = Convert.ToString(model.CountryOfResidanceId);
                emp.LGACode = model.lgaCode;

                _db.SaveChanges();
                
                //// Send Email 
                //var msg = PalLibrary.Messaging.SendEmail("info@palpensions.com", "helpdesk@palpensions.com", $"Client Update ({model.Pin}) Notification - {model.FullName}", $@"
                //    <p>Hello Info, 

                //    <p>Your client ({model.Pin}) made request for update of his/her details at {DateTime.Now.ToString("MMM dd yyyy hh:mm:ss tt")}: <br />
                     
                //    <strong>Name:</strong> {model.FullName}<br/>
                //    <strong>Mobile:</strong> {model.MobileNumber}<br/>
                //    <strong>Email:</strong> {model.Email}<br/></p>
                   
                //<hr />    
                //<p>         Regards<br/>

                //    PAL Pensions</p>");

                TempData["Success"] = "Your Update has been Submitted successfully!";
                RedirectToAction("Home");

            }
            catch (Exception ex)
            {
                TempData["err"] = "Error Updating!" + ex.Message;
            }

            var x = _manager.GetProfile(_manager.GetEmployeePin(User.Identity.Name));
   
            
            return View(x);

        }

        [HttpGet]
        public ActionResult NOKUpdate()
        {
            GetList();
            return View();
        }

        [HttpPost]
        public ActionResult NOKUpdate(NOKViewModel nok)
        {
            var userPin = User.Identity.Name;
            
            TempNOKInformation nokInfo = new TempNOKInformation();

            nokInfo.pin = nok.Pin;
            nokInfo.Surname = nok.Surname;
            nokInfo.FirstName = nok.FirstName;
            nokInfo.OtherNames = nok.OtherNames;
            nokInfo.Gender = nok.Gender;
            nokInfo.Relation = nok.Relation;
            nokInfo.Address =nok.Address;
            nokInfo.PhoneNumber = nok.PhoneNumber;
            nokInfo.Email = nok.Email;
            nokInfo.StateCode = nok.StateCode;
            nokInfo.CountryCode = nok.CountryOfResidanceId;
            nokInfo.KinTitle = nok.TitleName;
            nokInfo.City = nok.City;
            nokInfo.LGACode = nok.LGACode;
            nokInfo.StreetName = nok.StreetName;
            nokInfo.HouseNo = nok.HouseNo;
            nokInfo.DatetimeCreated = DateTime.Now;
            nokInfo.Createdby = nok.Pin;
            nokInfo.status = "Pending";


            _db.TempNOKInformations.Add(nokInfo);
            _db.SaveChanges();

            // Send Email 
            var msg = PalLibrary.Messaging.SendEmail("info@palpensions.com", "helpdesk@palpensions.com", $"Client Update ({nok.Pin}) Notification - {nok.Surname}", $@"
                <p>Hello Info, 

                <p>Your client with Pin: {nok.Pin} made a request for update of his/her NOK details at {DateTime.Now.ToString("MMM dd yyyy hh:mm:ss tt")}: <br />

                <strong>Surname:</strong> {nok.Surname}<br/>
                <strong>First Name:</strong> {nok.FirstName}<br/>
                <strong>Mobile:</strong> {nok.PhoneNumber}<br/>
                <strong>Email:</strong> {nok.Email}<br/></p>

            <hr />    
            <p>         Regards<br/>

                PAL Pensions</p>");

            GetList(nok);
            return RedirectToAction("Home", nokInfo);

        }

        public ActionResult Autocomplete(string term)
        {
            string names = term;
            var items = _db.EmployerDetails.Where(
             (item => item.EmployerName.ToUpper().Contains(term.ToUpper())
               ||
                (item.Recno.ToUpper().Contains(term.ToUpper()))
            )
            ).
            Select(e => new { e.Recno, e.EmployerName, })
            .Distinct().Take(25).ToList();
            return Json(items, JsonRequestBehavior.AllowGet);
        }

        public ActionResult DeleteApplyBenfitDoc(int id)
        {
            string path = GetImageApplyBenDocPath();
            var doc = _db.BenefitFiles.FirstOrDefault(d => d.FileId == id);
            var fileName = path + "\\" + doc.FileName;
            if (System.IO.File.Exists(fileName))
            {
                System.IO.File.Delete(fileName);
            }
            var deleteddoc = _db.BenefitFiles.Where(o => o.FileId == id).FirstOrDefault();
            _db.BenefitFiles.Remove(deleteddoc);
            _db.SaveChanges();
            return RedirectToAction("ApplyBenefits", "Customer", new { id = deleteddoc.FileId });
        }


        public ActionResult ShowBenefitFile(int id)
        {
            var image = _db.BenefitFiles.FirstOrDefault(d => d.FileId == id);
            var file = GetImageApplyBenDocPath() + "\\" + image.FileName;
            var ext = file.Split('.').Last();

            String[] imageExtensions = { "gif", "png", "jpeg", "jpg" };

            if (ext.ToLower() == "pdf")
            {
                return File(file, "application/" + ext, Path.GetFileName(file));
            }
            else if (imageExtensions.Contains(ext.ToLower()))
            {
                return File(file, "image/" + ext, Path.GetFileName(file));
            }
            else
            {
                return File(file, "application/" + ext, Path.GetFileName(file));
            }
        }

        private string GetImageApplyBenDocPath()
        {
            return _db.ImageAdministrations.Select(d => d.SupportDocument).First();
        }


        //[AllowAnonymous]
        //public JsonResult GetBenefitSubClass(int id)
        //{
        //    var x = _manager.GetSubClasses(id);
        //    return Json(x);
        //}

        [AllowAnonymous]
        public JsonResult GetBenefitSubClass(int id, int id1)
        {
            var x = _manager.GetSubClasses(id, id1);
            return Json(x);
        }

        [AllowAnonymous]
        public JsonResult CheckStatus(int id)
        {
            return Json(_manager.CheckIfApplicationHasAlreadyStarted(_manager.GetEmployeePin(User.Identity.Name), id));
        }

        [HttpPost]
        public JsonResult UploadImage()
        {
            var pic = System.Web.HttpContext.Current.Request.Files["Doc"];
            var firstPost = System.Web.HttpContext.Current.Request.Form["first"] != "undefined" && Convert.ToBoolean(System.Web.HttpContext.Current.Request.Form["first"]);
            var fileName = System.Web.HttpContext.Current.Request.Form["filename"];
            var benefitId = System.Web.HttpContext.Current.Request.Form["benefitid"] != "undefined" ? Convert.ToInt32(System.Web.HttpContext.Current.Request.Form["benefitid"]) : 0;
            var applicationId = System.Web.HttpContext.Current.Request.Form["appid"] != "" ? Convert.ToInt32(System.Web.HttpContext.Current.Request.Form["appid"]) : 0;
            var documentInfoId = System.Web.HttpContext.Current.Request.Form["docid"] != "undefined" ? Convert.ToInt32(System.Web.HttpContext.Current.Request.Form["docid"]) : 0;

            if (firstPost && applicationId == 0)
            {
                var documentId = _manager.CreateNewDocumentId();
                _manager.CreateFolder(documentId);
                applicationId = _manager.CreateNewBenefitApplication(User.Identity.Name, benefitId, _manager.GetStatusId("Not Complete"), DateTime.Now, documentId);
                _manager.DeclareVariables(applicationId, benefitId);
            }

            _manager.SaveImageToFolder(applicationId, pic, fileName, ConfigurationManager.AppSettings["document-folder-thumb"]);


            if (pic != null)
            {
                _manager.UpdateDocumentInformation(fileName, Path.GetExtension(pic.FileName), applicationId);
            }

            return new JsonResult
            {
                JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                Data = new
                {
                    appId = applicationId,
                    docInfoId = documentInfoId
                }
            };
        }

        public JsonResult ReUploadImage()
        {
            var pic = System.Web.HttpContext.Current.Request.Files["Doc"];
            var applicationId = System.Web.HttpContext.Current.Request.Form["appid"] != "" ? Convert.ToInt32(System.Web.HttpContext.Current.Request.Form["appid"]) : 0;
            var fileName = System.Web.HttpContext.Current.Request.Form["filename"];

            _manager.SaveImageToFolder(applicationId, pic, fileName, ConfigurationManager.AppSettings["document-folder-thumb"]);

            if (!_manager.ApplicationIsSubmitted(applicationId)) return Json("success");

            _manager.UpdateDateModified(applicationId);

            dynamic email = new Email("UpdateOnApplication");
            email.To = _manager.ReturnAdminEmail();
            email.Name = "Admin";
            email.ClientName = _manager.GetEmploteeFullName(_manager.GetEmployeePin(User.Identity.Name));
            email.Filename = Helpers.Helper.SplitCamelCase(fileName);
            email.ApplicationId = applicationId;
            email.ApplicationName = _manager.GetSubClassName(_manager.GetAppSubClass(applicationId));
            email.Send();

            return Json("success");
        }

        public ActionResult EditBenefitApplication_Old(int id)
        {
            var x = _manager.GetApplicationInformation(id);
            return View(x);
        }

        public ActionResult BenefitProcess()
        {
            var benefitProcesses = _db.BenefitProcesses.Where(b => b.PIN == User.Identity.Name).ToList();
            return View(benefitProcesses);
        }

        public ActionResult upload(int? id)
        {
            ViewBag.BenefitDocument = new SelectList(_db.BenefitDocuments.Where(d => d.BenefitTypeId != null).OrderBy(d => d.DocumentName), "DocumentName", "DocumentName");
            ViewBag.Id = id;
            return View();
        }



        // GET: BenefitProcess/Edit/5
        public ActionResult EditBenefitApplication()
        {
           
            BenefitProcess benefitProcess = _db.BenefitProcesses.Where(d => d.PIN == User.Identity.Name).OrderByDescending(f => f.DateReceived).FirstOrDefault();
           
            return View(benefitProcess);
        }


        // GET: BenefitProcess/Edit/5Upload(
        public ActionResult Edit()      //long? id
        {
            var id = _db.BenefitProcesses.Where(d => d.PIN == User.Identity.Name).FirstOrDefault().Id;
            BenefitProcess benefitProcess = _db.BenefitProcesses.Find(id);
            if (benefitProcess == null)
            {
                return View();
            }

            ViewBag.PaymentTypeId = new SelectList(_db.BenefitClasses.Where(d => d.Id == 2 || d.Id == 3), "Id", "BenefitName", benefitProcess.PaymentTypeId);
            ViewBag.StateId = new SelectList(_db.States, "Id", "Name", benefitProcess.StateId);
            ViewBag.TitleId = new SelectList(_db.Titles, "TitleId", "Name", benefitProcess.TitleId);
            return View(benefitProcess);
        }


        // POST: BenefitProcess/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = @"Id,TitleId,PaymentTypeId,File,FileNo,PIN,EmployeeName,DateReceived,DateDisengaged,EmployerCode,EmployerName,EmployeeAddress,EmployeeAddress2,StateId,MobilePhone,Email,StatusId,CreatedOn,CreatedBy,ModifiedOn,ModifiedBy,DateEmployerRespond,DateToBPDTempCompute,DateTempReturnToPSC,DateMovedToBPDForPencom,ApprovedBPDReceivedDate,DateMovedToPencom,DateSentToBank")] BenefitProcess benefitProcess)
        {
            if (ModelState.IsValid)
            {
                // Fetch benefit details from NAV
                // int benefitId = benefitProcess.PaymentTypeId.Value;
                // var navCode = _db.BenefitClasses.Find(benefitId).NavCode;

                benefitProcess.ModifiedBy = User.Identity.Name;
                benefitProcess.ModifiedOn = DateTime.Now;
                _db.Entry(benefitProcess).State = EntityState.Modified;

                _db.SaveChanges();              

                //Send email to BPD Department
                if (benefitProcess.StatusId == 5)
                {
                    var benefittype = _db.BenefitClasses.FirstOrDefault();

                    var msg = PalLibrary.Messaging.SendEmail("bpd@palpensions.com", "info@palpensions.com", $"{benefittype.BenefitName} : {benefitProcess.PIN} - {benefitProcess.EmployeeName}", $@"

                    <p>Dear BPD,  <br/>

                    A payment request has been lodged was updated for your action.   <br/>
                    on { DateTime.Now.ToString("MMM dd yyyy hh:mm:ss tt")}: <br />
                    Thank you

                    <hr />   

                    <p>Regards<br/>

                    PAL Pensions</p>");
                }


                _db.BenefitStatusLogs.Add(new BenefitStatusLog
                {
                    Comment = "",
                    StatusId = benefitProcess.StatusId,
                    BenefitProcessId = benefitProcess.Id,
                    CreatedBy = User.Identity.Name,
                    ModifiedOn = DateTime.Now,

                    CreatedOn = DateTime.Now
                });
                _db.SaveChanges();
               
                return RedirectToAction("Home");
            }

            ViewBag.PaymentTypeId = new SelectList(_db.BenefitClasses.Where(d => d.Id == 2 || d.Id == 3), "Id", "BenefitName");
            //ViewBag.PaymentTypeId = new SelectList(_db.BenefitClasses, "Id", "BenefitName", benefitProcess.PaymentTypeId);
            ViewBag.StateId = new SelectList(_db.States, "Id", "Name", benefitProcess.StateId);
            ViewBag.StatusId = new SelectList(_db.BenefitStatus, "StatusId", "StatusValue", benefitProcess.StatusId);
            ViewBag.TitleId = new SelectList(_db.Titles, "TitleId", "Name", benefitProcess.TitleId);
            return View(benefitProcess);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Enbloc_old(Enbloc en)
        {
            if (!ModelState.IsValid)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                TempData["PostBack"] = "from the failure";
                //return PartialView("Partials/_enbloc", en);
                return new JsonResult()
                {
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                    Data = new { result = "failure nikka" }
                };
            }

            if (_manager.CheckIfApplicationHasAlreadyStarted(_manager.GetEmployeePin(User.Identity.Name), en.BenefitSubClass))
            {
                return new JsonResult()
                {
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                    Data = new { result = "exist" }
                };
            }

            return new JsonResult()
            {
                JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                Data = new { result = "modafoka" }
            };
        }

        //for file upload controls

        //This method is used to extract upload/attach the files to pass to Enbloc method for insertion
        private FileContentViewModel ExtractFileContents(HttpPostedFileBase hpf, string propertyName, string pin)
        {
            string msg = "";

            FileContentViewModel fileContentViewModel = new FileContentViewModel();

            bool fileOK = false;

            String[] allowedExtensions = { ".gif", ".png", ".jpeg", ".jpg", ".pdf" };

            //file contents
            if (hpf.ContentLength == 0)
            {
                if (propertyName.ToUpper() != "Payslip".ToUpper())
                {
                    msg += "Please, attach a document for " + propertyName + "\n";
                }
            }

            //file extension                
            fileOK = allowedExtensions.Contains(Path.GetExtension(hpf.FileName.ToLower()));

            if (!fileOK)
            {
                if (propertyName.ToUpper() != "Payslip".ToUpper())
                {
                    msg += "The document/file you uploaded for " + propertyName + " is of invalid file extension. ";
                    msg += "The allowable file extensions are: .gif, .png, .jpeg, .jpg, .pdf" + "\n";
                }
            }

            //get the file extension
            string fileExtension = Path.GetExtension(hpf.FileName);

            //file name
            string filename = Path.GetFileNameWithoutExtension(hpf.FileName);

            //generate a random
            int randomNo = 0;

            //file type
            string fileType = "";

            if (propertyName.ToUpper() == "ExitLetter".ToUpper())
                fileType = "Exit Letter from Employer";
            else if (propertyName.ToUpper() == "PassportPhoto".ToUpper())
                fileType = "Passport Photograph";
            else if (propertyName.ToUpper() == "MeansOfId".ToUpper())
                fileType = "Identification";

            else if (propertyName.ToUpper() == "BirthCertificate".ToUpper())
                fileType = "Birth Certificate";

            else if (propertyName.ToUpper() == "BankDetails".ToUpper())
                fileType = "Bank Account Details";
            else if (propertyName.ToUpper() == "AvcRequestLetter".ToUpper())
                fileType = "Request Letter";
            else if (propertyName.ToUpper() == "IndemnityFormAndPrgrammedAgreement".ToUpper())
                fileType = "Indemnity Form and Programmed Withdrawal Agreement";
            else if (propertyName.ToUpper() == "DeathCertification".ToUpper())
                fileType = "Death Notification";
            else if (propertyName.ToUpper() == "BondSlip".ToUpper())
                fileType = "Bond Slip";
            else if (propertyName.ToUpper() == "RetireeDetailForm".ToUpper())
                fileType = "Retiree Detail Form";
            else if (propertyName.ToUpper() == "Payslip".ToUpper())
                fileType = "Pay Slip";
            else if (propertyName.ToUpper() == "RequestLetter".ToUpper())
                fileType = "A signed request letter for AVC";
            else if (propertyName.ToUpper() == "LetterOfFirstAppointment".ToUpper())
                fileType = "Letter of first appointment";
            else if (propertyName.ToUpper() == "AttachedPencom".ToUpper())
                fileType = "Attached PENCOM death notification form";
            else if (propertyName.ToUpper() == "LetterOrWill".ToUpper())
                fileType = "Letter of Administration OR Will";
            else if (propertyName.ToUpper() == "NsitfStatement".ToUpper())
                fileType = "NSITF Statement";



            //rename the file
            FileInfo fileInfo = new FileInfo(hpf.FileName);

            //rename a file here

            string renamedFileName = pin + "_" + fileType + randomNo.ToString() + "." + fileExtension;



            fileContentViewModel.RenamedFileName = renamedFileName;
            fileContentViewModel.FileExtension = fileExtension;
            fileContentViewModel.FilePropertyName = propertyName;
            fileContentViewModel.ErrorMsg = msg;

            return fileContentViewModel;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Enbloc(BenefitProcessViewModel en)
        {
            if (!ModelState.IsValid)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                TempData["PostBack"] = "from the failure";
                //return PartialView("Partials/_enbloc", en);
                return new JsonResult()
                {
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                    Data = new { result = "failure nikka" }
                };
            }

            //extract the contents of the file upload controls
            List<FileContentViewModel> listFileContentFileViewModel = new List<FileContentViewModel>();

            FileContentViewModel fileContent = null;

            //ExitLetter
            fileContent = ExtractFileContents(en.ExitLetter, "ExitLetter", en.Pin);         // FROM ExtractFileContents to extract file in the private method above
            listFileContentFileViewModel.Add(fileContent);

            //PassportPhoto
            fileContent = ExtractFileContents(en.PassportPhoto, "PassportPhoto", en.Pin);
            listFileContentFileViewModel.Add(fileContent);

            //PassportPhoto
            fileContent = ExtractFileContents(en.PassportPhoto, "PassportPhoto", en.Pin);
            listFileContentFileViewModel.Add(fileContent);

            //BirthCertificate
            fileContent = ExtractFileContents(en.BirthCertificate, "BirthCertificate", en.Pin);
            listFileContentFileViewModel.Add(fileContent);

            //MeansOfId
            fileContent = ExtractFileContents(en.MeansOfId, "MeansOfId", en.Pin);
            listFileContentFileViewModel.Add(fileContent);

            //BankDetails
            fileContent = ExtractFileContents(en.BankDetails, "BankDetails", en.Pin);
            listFileContentFileViewModel.Add(fileContent);

            //RequestLetter
            fileContent = ExtractFileContents(en.RequestLetter, "RequestLetter", en.Pin);
            listFileContentFileViewModel.Add(fileContent);

            //BondSlip
            fileContent = ExtractFileContents(en.BondSlip, "BondSlip", en.Pin);
            listFileContentFileViewModel.Add(fileContent);

            //Payslip
            fileContent = ExtractFileContents(en.Payslip, "Payslip", en.Pin);
            listFileContentFileViewModel.Add(fileContent);

            //AvcRequestLetter
            fileContent = ExtractFileContents(en.AvcRequestLetter, "AvcRequestLetter", en.Pin);
            listFileContentFileViewModel.Add(fileContent);

            //LetterOrWill
            fileContent = ExtractFileContents(en.LetterOrWill, "LetterOrWill", en.Pin);
            listFileContentFileViewModel.Add(fileContent);

            //TaxIdentificationNumber
            fileContent = ExtractFileContents(en.TaxIdentificationNumber, "TaxIdentificationNumber", en.Pin);
            listFileContentFileViewModel.Add(fileContent);

            //IndemnityFormAndPrgrammedAgreement
            fileContent = ExtractFileContents(en.IndemnityFormAndPrgrammedAgreement, "IndemnityFormAndPrgrammedAgreement", en.Pin);
            listFileContentFileViewModel.Add(fileContent);



            //check if all file controls except payslip have passed validation
            var errorMsg = listFileContentFileViewModel.Where(m => m.ErrorMsg != "").Where(n => n.ErrorMsg != null);

            if (errorMsg.Any())
            {
                string errorMsgs = null;

                foreach (var item in errorMsg)
                {
                    errorMsgs += item + "\n";
                }

                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                TempData["PostBack"] = "from the failure";
                //return PartialView("Partials/_enbloc", en);
                return new JsonResult()
                {
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                    Data = new { result = errorMsgs }
                };
            }

            //from here, extract the contents of listFileContentFileViewModel and insert into the db.
            List<BenefitFile> listBenefitFile = new List<BenefitFile>();

            foreach (var item in listFileContentFileViewModel)
            {
                listBenefitFile.Add(new BenefitFile
                {
                    BenefitProcessId = 0,
                    CreatedBy = User.Identity.Name,
                    CreatedOn = DateTime.Now,
                    FileName = item.RenamedFileName,
                    FilePath = "",
                    PIN = en.Pin
                });
            }

            _db.BenefitFiles.AddRange(listBenefitFile);

            if (_manager.CheckIfApplicationHasAlreadyStarted(_manager.GetEmployeePin(User.Identity.Name), en.BenefitSubClass))
            {
                return new JsonResult()
                {
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                    Data = new { result = "exist" }
                };
            }

            return new JsonResult()
            {
                JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                Data = new { result = "modafoka" }
            };

            //insert into db table for benefit process
            BenefitProcess benefits = new BenefitProcess();

            benefits.PIN = en.Pin;
            benefits.EmployeeName = en.Surname + " " + en.FirstName;
            benefits.Email = en.Email;
            benefits.MobilePhone = en.MobileNumber;
            benefits.EmployerName = en.EmployerDetail.OldEmployerCode;
            benefits.EmployerName = en.EmployerDetail.EmployerName;
            //benefits.BenefitClass.BenefitName =

            //_db.Entry(benefits).State = EntityState.Modified;
            ////db.BenefitProcesses.Add(benefits);
            //_db.SaveChanges();

        }

            [HttpPost]
        public ActionResult UploadAPI(FormCollection formdata)
        {
            var userPin = User.Identity.Name;
            var benProcessId =Convert.ToInt64(Request.Form["BenefitProcessId"]);
            var documentName = Request.Form["BenefitDocument"];

            String[] allowedExtensions = { ".gif", ".png", ".jpeg", ".jpg", ".pdf" };

                bool fileOK = false;
                string fileName = "";
                try
                {

                    foreach (string file in Request.Files)
                    {
                        //create object that provide access to uploaded files

                        HttpPostedFileBase hpf = Request.Files[file] as HttpPostedFileBase;
                        if (hpf.ContentLength == 0)
                        {
                            continue;
                        }

                        //Test file extension
                        fileOK = allowedExtensions.Contains(Path.GetExtension(hpf.FileName.ToLower()));

                        //  string path = AppDomain.CurrentDomain.BaseDirectory + "uploads";

                        string path = "E:\\vhost\\Pallite\\uploads\\";

                        //Create Directory if not exist
                        if (!Directory.Exists(path))
                        {
                            Directory.CreateDirectory(path);
                        }

                        if (fileOK)
                        {
                            //fileName = Path.GetFileName(checklistVM.BenefitProcess.PIN + "_" + documentName
                            //    + "_" + DateTime.Now.Ticks.ToString()) + Path.GetExtension(hpf.FileName); 

                            fileName = Path.GetFileName(userPin + "_" + documentName
                             + "_" + DateTime.Now.Ticks.ToString()) + Path.GetExtension(hpf.FileName);

                            string fullFileName = Path.Combine(path, fileName); //

                            hpf.SaveAs(fullFileName);

                            try
                            {
                                BenefitFile benFiles = new BenefitFile();
                                //checklistVM.BenefitFile.BenefitProcessId = checklistVM.BenefitProcess.Id;  
                                benFiles.BenefitProcessId = benProcessId;           
                                                                                     // checklistVM.BenefitFile.PIN = checklistVM.BenefitProcess.PIN;
                                benFiles.PIN = userPin;
                                benFiles.FileName = documentName;
                                benFiles.FilePath = fileName;
                                benFiles.CreatedOn = DateTime.Now;
                                benFiles.CreatedBy = User.Identity.Name;

                                _db.BenefitFiles.Add(benFiles);          // _db.BenefitFiles.Add(checklistVM.BenefitFile);
                                _db.SaveChanges();

                                ViewBag.Message = "<label class='label label-success'>Upload successful. You can upload more document</label>";
                                ViewBag.BenefitDocument = new SelectList(_db.BenefitDocuments.OrderBy(d => d.DocumentName), "DocumentName", "DocumentName");
                           
                            //return RedirectToAction("ReturnForm", "Customer");
                            return Json(new { success= true, message= "uploaded successfully",fileId = benFiles.FileId, filepath= fullFileName, benefit = benFiles  }, JsonRequestBehavior.AllowGet);
                            }
                            catch (Exception ex)
                            {
                                ViewBag.Message = "<label class='label label-warning'>Upload failed: " + ex.Message + "</label>";
                                return Json(new { success = false, message = "Error uploading document" }, JsonRequestBehavior.AllowGet);
                            //return View(checklistVM);
                        }


                        }
                        else
                        {
                            fileOK = false;
                            ViewBag.Message = "<label class='label label-warning'>Oops!!! Invalid file found</label>";
                          return Json(new { success = false, message = "Oops!!! Invalid file found" }, JsonRequestBehavior.AllowGet);
                    }

                    }
                }
                catch (Exception ex)
                {
                    ViewBag.Message = "<label class='label label-warning'>Upload failed: " + ex.Message + "</label>";
                    return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
                }

            //ViewBag.BenefitDocument = new SelectList(_db.BenefitDocuments.OrderBy(d => d.DocumentName), "DocumentName", "DocumentName", "Complete Document");


            //return View(checklistVM);
            return Json(new { success = false, message ="Oop!!!, Document could not be uploaded. Please try again" }, JsonRequestBehavior.AllowGet);             

        }

        public ActionResult ShowSupportFile(int id)
        {
            var image = _db.BenefitFiles.FirstOrDefault(d => d.FileId == id);
         
            var file = "E:\\vhost\\Pallite\\uploads\\" + "\\" + image.FilePath;
            var ext = file.Split('.').Last();

            String[] imageExtensions = { "gif", "png", "jpeg", "jpg" };

            if (ext.ToLower() == "pdf")
            {
                return File(file, "application/" + ext, Path.GetFileName(file));
            }
            else if (imageExtensions.Contains(ext.ToLower()))
            {
                return File(file, "image/" + ext, Path.GetFileName(file));
            }
            else
            {
                return File(file, "application/" + ext, Path.GetFileName(file));
            }
        }

        [HttpPost]
        public JsonResult DeleteBenefitFile(int id)
        {
            //string path = GetImageSupportDocPath();
            string path = "E:\\vhost\\Pallite\\uploads\\";
            var doc = _db.BenefitFiles.FirstOrDefault(d => d.FileId == id);
            var fileName = path + "\\" + doc.FilePath;
            if (System.IO.File.Exists(fileName))
            {
                System.IO.File.Delete(fileName);
            }
            try
            {
                //var deleteddoc = _db.BenefitFiles.Where(o => o.BenefitProcessId == id).FirstOrDefault();
                _db.BenefitFiles.Remove(doc);
                _db.SaveChanges();
                return Json(new { success = true, message="Benefit file deleted successfully." }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
            
        }



        [HttpPost]
        public JsonResult FinalizeApplication(int id)
        {
            if (id == 0) return Json("failed");
            _manager.FinializeApplication(id);
            var info = _manager.CreateEmailVariables(id, WebSecurity.GetUserId(User.Identity.Name));
            SendMail(info, "SubmittedApplication");
            return Json("passed");
        }

        [NonAction]
        public void SendMail(Mailer info, string template)
        {
            dynamic email = new Email(template);
            email.To = info.Email;
            email.Name = info.Name;
            email.AppType = info.ApplicationType;
            email.Send();
        }

        public ActionResult Report(DateTime? StartDate, DateTime? EndDate, int? fundId)
        {
            DateTime startDate = StartDate == null ? DateTime.Parse("01/01/2000") : StartDate.Value;
            DateTime endDate = EndDate == null ? DateTime.Now.Date : EndDate.Value;

            TempData["Statement"] = null;
            TempData["isRetirementToo"] = _manager.CheckRetirement(User.Identity.Name);
            var emp = _manager.GetEmployeeDetails(User.Identity.Name, startDate, endDate);
            fundId = _manager.GetFunId(emp.Pin);
            var x = fundId != null ? _manager.EmployeeReportSummationMethod(emp, fundId.Value, EndDate) : _manager.EmployeeReportSummationMethod(emp, emp.FundId, EndDate);
            x.FullName = emp.FirstName + " " + emp.Surname;
            x.Address = emp.PermanentAddress;
            x.Pin = emp.Pin;
            x.StartDate = startDate; x.EndDate = endDate;
            x.EmployerDetail = emp.EmployerDetail.EmployerName;
            x.Contributions = emp.Contributions;
            TempData["StartDate"] = startDate;
            TempData["EndDate"] = endDate;
            TempData["fundId"] = _manager.GetFunId(emp.Pin); // fundId ?? emp.FundId;
            TempData["Statement"] = x;

            ViewBag.StartDate = startDate.Date;
            ViewBag.EndDate = endDate.Date;
            return View(x);
            //TempData["isRetirementToo"] = _manager.CheckRetirement(User.Identity.Name);
            //ViewBag.StartDate = DateTime.Parse("01/01/2000").ToString("MM/dd/yyyy");
            //ViewBag.EndDate = DateTime.Now.ToString("MM/dd/yyyy");
            //return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Report(DateTime StartDate, DateTime EndDate, int? fundId)
        {
            DateTime startDate = StartDate == null ? DateTime.Parse("01/01/2000") : StartDate;
            DateTime endDate = EndDate == null ? DateTime.Now.Date : EndDate;

            TempData["Statement"] = null;
            TempData["isRetirementToo"] = _manager.CheckRetirement(User.Identity.Name);
            var emp = _manager.GetEmployeeDetails(User.Identity.Name, startDate, endDate);
            fundId = _manager.GetFunId(emp.Pin);
            var x = fundId != null ? _manager.EmployeeReportSummationMethod(emp, fundId.Value, EndDate) : _manager.EmployeeReportSummationMethod(emp, emp.FundId, EndDate);
            x.FullName = emp.FirstName + " " + emp.Surname;
            x.Address = emp.PermanentAddress;
            x.Pin = emp.Pin;
            x.StartDate = startDate; x.EndDate = endDate;
            x.EmployerDetail = emp.EmployerDetail.EmployerName;
            x.Contributions = emp.Contributions;
            TempData["StartDate"] = startDate;
            TempData["EndDate"] = endDate;
            TempData["fundId"] = _manager.GetFunId(emp.Pin); // fundId ?? emp.FundId;
            TempData["Statement"] = x;

            ViewBag.StartDate = startDate.Date.ToString("MM/dd/yyyy");
            ViewBag.EndDate = endDate.Date.ToString("MM/dd/yyyy");
            return View(x);
        }


        public ActionResult ReportPdf(DateTime? startDate, DateTime? endDate, int? fundId)
        {
            TempData["StartDate"] = startDate;
            TempData["EndDate"] = endDate;
            TempData["fundId"] = fundId;
            var x = TempData["Statement"] as EmployeeReportSummation;
            return new ViewAsPdf("ReportPDF", x) { FileName = "Statement " + DateTime.Now.ToString("MMMM dd, yyyy") + ".pdf" };
        }

        public ActionResult ExportAsExl(DateTime? startDate, DateTime? endDate, int? bank, int? paymentType, int? status, int? branch)
        {
            var x = _manager.GetReportObject(_manager.GetEmployeePin(User.Identity.Name));
            x = _manager.GetReportQuery(x, startDate, endDate);

            HttpContext.Response.AddHeader("content-disposition", "attachment; filename=PALRSAReport_" + DateTime.Now.ToString(CultureInfo.CurrentCulture) + ".xls");

            Response.ContentType = "application/vnd.ms-excel";

            return View(x);
        }

        public ActionResult ViewAllNotifications()
        {
            var x = _manager.GetAllPublications();
            return View(x);
        }

        public ActionResult Support()
        {
            ViewData["SupportType"] = new SelectList(_manager.GetSupportType().OrderBy(s => s.Id).ToList(), "Id", "SupportType1");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Support(Support model)
        {
            ViewData["SupportType"] = new SelectList(_manager.GetSupportType().OrderBy(s => s.Id).ToList(), "Id", "SupportType1");
            model.Pin = _manager.GetEmployeePin(User.Identity.Name);
            _manager.SaveSupportDetails(model);

            dynamic email = new Email("SupportMessage");
            email.To = _manager.ReturnAdminEmail();
            email.Name = "Admin";
            email.ClientName = _manager.GetEmploteeFullName(model.Pin);
            email.Category = _manager.GetcategoryValue(model.Category);
            email.Summary = model.Summary;
            email.Explanation = model.Explanation;
            //email.Send();

            try
            {
                var emp = _db.Employees.FirstOrDefault(d => d.Pin == model.Pin);
                // Send Email 
                var msg = PalLibrary.Messaging.SendEmail("info@palpensions.com", "helpdesk@palpensions.com", $"Support Notification - {emp.Surname} {emp.FirstName}", $@"
                    <p>Hello Info, 

                    <p>Your client ({model.Pin}) wrote at {DateTime.Now.ToString("MMM dd yyyy hh:mm:ss tt")}: <br />
                     
                    <strong>Title:</strong> {model.Summary}<br/>
                    <strong>Details:</strong> {model.Explanation}<br/></p>
                   
                <hr />                                        
  
 
            <p>         Regards<br/>

                    PAL Pensions</p>");

            }
            catch (Exception ex)
            {

            }

            TempData["Status"] = "success";

            // return View();
            return RedirectToAction("Home");
        }


        public FileResult DownloadPublication(string fileName, int pubId)
        {
            var filepath = HostingEnvironment.MapPath(ConfigurationManager.AppSettings["publications"] + fileName);
            var filedata = System.IO.File.ReadAllBytes(filepath);
            var contentType = MimeMapping.GetMimeMapping(filepath);

            var cd = new System.Net.Mime.ContentDisposition
            {
                FileName = fileName,
                Inline = true
            };

            if (_manager.HasBeenRead(_manager.GetEmployeePin(User.Identity.Name), pubId)) _manager.SetAsRead(_manager.GetEmployeePin(User.Identity.Name), pubId);

            Response.AppendHeader("Content-Disposition", cd.ToString());

            return File(filedata, contentType);
        }

        [AllowAnonymous]
        public PartialViewResult ReturnForm(int id)
        {
            var pin = _manager.GetEmployeePin(User.Identity.Name);
            var benefitClass = _manager.GetBenefitClasses(id);
            TempData["id"] = id;
            var x = new Enbloc { User = pin, BenefitClass = benefitClass, BenefitSubClass = id };
            var view = "";

            switch (id)
            {
                case 1:
                    view = "Partials/_lumpsum-programmed";
                    break;
                case 2:
                    view = "Partials/_lumpsum-annuity";
                    break;
                case 3:
                    view = "Partials/_enbloc";
                    break;
                case 4:
                    view = "Partials/_nsitf";
                    break;
                case 5:
                    view = "Partials/_legacy";
                    break;
                case 6:
                    view = "Partials/_avc";
                    break;
                case 7:
                    view = "Partials/_death";
                    break;
                case 8:
                    view = "Partials/_temp-access";
                    break;
            }
            return PartialView(view, x);
        }


        [HttpGet]
        [AllowAnonymous]
        public string GetLGACode()
        {
            string stateid = Convert.ToString(Request.Params["StateCode"]);
            // var selectedState = _db.States.FirstOrDefault(d => d.StateCode == stateid);
            string l = "<option value=\"\"> </option>";
            var lgas = _db.LGAreas.Where(x => x.StateCode == stateid && x.Active == true).OrderBy(d => d.Name).ToList();


            foreach (var item in lgas)
            {
                l += "<option value='" + item.LGACode + "'>" + item.Name + "</option>";
            }
            //  System.Threading.Thread.Sleep(200);
            return l;
        }

        private void GetList()
        {
            var countries = _db.Countries.ToList();
            var states = _db.States.OrderBy(x => x.Name).ToList();

            ViewBag.CountryOfResidanceId = new SelectList(countries, "CountryId", "Name", 160);
            ViewBag.LGAId = new SelectList(_db.LGAreas.Take(10).ToList(), "LGAId", "Name");
            ViewBag.Gender = new SelectList(_db.Sexes, "SexId", "Name");
            ViewBag.TitleName = new SelectList(_db.Titles.Where(d => d.Active == true), "TitleId", "Name");
            ViewBag.Relation = new SelectList(_db.Relationships, "RelationshipId", "Name");

            //ViewBag.CountryCode = new SelectList(countries, "CountryId", "Name", 160);
            ViewBag.StateCode = new SelectList(states, "StateCode", "Name");
            ViewBag.LGACode = new SelectList(_db.LGAreas.Take(10).ToList(), "LGACode", "Name");
           

        }

        private void GetList(EmployeeViewModel tempCust)
        {

            var countries = _db.Countries.ToList();
            var states = _db.States.OrderBy(x => x.Name).ToList();

            var state = _db.States.FirstOrDefault(d => d.StateCode == tempCust.StateCode);
          

            if (tempCust.StateCode != null)
            {
                ViewBag.LGAId = new SelectList(_db.LGAreas.Where(d => d.StateCode == state.StateCode).ToList(), "LGAId", "Name", tempCust.lgaCode);
            }
            else
            {
                ViewBag.LGAId = new SelectList(_db.LGAreas.Take(20), "LGAId", "Name");
            }
            ViewBag.CountryOfResidanceId = new SelectList(countries, "CountryId", "Name", tempCust.CountryOfResidanceId);
            ViewBag.StateCode = new SelectList(states, "StateCode", "Name", tempCust.StateCode);
            if (!String.IsNullOrEmpty(tempCust.StateCode))
            {
                
                ViewBag.LGACode = new SelectList(_db.LGAreas.Where(d => d.StateCode == tempCust.StateCode && d.Active == true).ToList(), "LGACode", "Name", tempCust.lgaCode);
            }
            else
            {
                ViewBag.LGACode = new SelectList(_db.LGAreas.Take(0), "LGACode", "Name", tempCust.lgaCode);
            }
        }

        private void GetList(NOKViewModel nok)
        {

            var countries = _db.Countries.ToList();
            var states = _db.States.OrderBy(x => x.Name).ToList();
            ViewBag.Gender = new SelectList(_db.Sexes, "SexId", "Name", nok.Gender);
            ViewBag.TitleName = new SelectList(_db.Titles.Where(d => d.Active == true), "TitleId", "Name", nok.TitleName);
            ViewBag.Relation = new SelectList(_db.Relationships, "RelationshipId", "Name", nok.Relation);

            var state = _db.States.FirstOrDefault(d => d.StateCode == nok.StateCode);


            if (nok.StateCode != null)
            {
                ViewBag.LGAId = new SelectList(_db.LGAreas.Where(d => d.StateCode == state.StateCode).ToList(), "LGAId", "Name", nok.LGACode);
            }
            else
            {
                ViewBag.LGAId = new SelectList(_db.LGAreas.Take(20), "LGAId", "Name");
            }
            ViewBag.CountryOfResidanceId = new SelectList(countries, "CountryId", "Name", nok.CountryOfResidanceId);
            ViewBag.StateCode = new SelectList(states, "StateCode", "Name", nok.StateCode);
            if (!String.IsNullOrEmpty(nok.StateCode))
            {

                ViewBag.LGACode = new SelectList(_db.LGAreas.Where(d => d.StateCode == nok.StateCode && d.Active == true).ToList(), "LGACode", "Name", nok.LGACode);
            }
            else
            {
                ViewBag.LGACode = new SelectList(_db.LGAreas.Take(0), "LGACode", "Name", nok.LGACode);
            }
        }

    }
}