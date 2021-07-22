using System;
using System.Configuration;
using System.Linq;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Security;
using PalRSA.Core;
using PalRSA.Core.Models;
using PalRSA.Models;
using Postal;
using WebMatrix.WebData;
using ChangePasswordViewModel = PalRSA.Models.ChangePasswordViewModel;
using PalRSA.Helpers;
using PalRSA.Core.DataAccess;
using System.Data.Entity;
using PalRSA.Constants;

namespace PalRSA.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly PalManager _manager = new PalManager();
        private PALSiteDBEntities _db = new PALSiteDBEntities();
        //
        // GET: /Account/Login
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [AllowAnonymous]
        public ActionResult AdminLogin(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [AllowAnonymous]
        public ActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult ForgotPassword(ForgotViewModel model)
        {
            //if (!_manager.EmailExistsInDb(model.Email))
            //{
            //    TempData["Status"] = "nill";
            //    return View();
            //}
            string messageId;
            string error;
            var randomPassword = UtilityHelper.GenerateRandomResetPassword();

            var userDetail = _manager.GetUserDetails(model.Username);
            bool emailIsValid = UtilityHelper.IsEmailValid(userDetail.Email);
            var token = WebSecurity.GeneratePasswordResetToken(userDetail.Pin);

            _manager.EnableAccount(userDetail.Pin);

            if (emailIsValid)
            {
                // var token = WebSecurity.GeneratePasswordResetToken(_manager.GetUserName(model.Email));


                dynamic email = new Email("ResetPassword");
                email.Link = ConfigurationManager.AppSettings["reset-password"] + token;
                email.To = userDetail.Email;
                email.Name = userDetail.FirstName; //_manager.GetUserName(model.Email)

                var link = ConfigurationManager.AppSettings["reset-password"] + token;
                try
                {
                    var msg = PalLibrary.Messaging.SendEmail(userDetail.Email, "info@palpensions.com", "PAL Account Password Reset",
                         $@"<p>Hello {userDetail.FirstName},</p>

<p>You have requested to reset your password.
Click on the link below to change your password. </p>
<p>
{link} </p>
<p>
Regards <br/>
</p>

PAL Pensions", "PAL Pensions <palcustomercare.airmail@palpensions.com>");
                    if (msg.Status == "S")
                    {
                        TempData["success"] = "Password reset link has been sent to your registered email.";
                    }
                    else // send SMS to mobile 
                    {
                        WebSecurity.ResetPassword(token, randomPassword);
                        PalLibrary.Messaging.SendSMS(userDetail.MobileNumber, $"You requested password reset on your account. Your new password is {randomPassword}", out messageId, out error);
                        TempData["success"] = "New password has been sent to your registered mobile number.";
                    }
                    return RedirectToAction("Login");
                }
                catch (Exception ex)
                {
                    // TempData["Status"] = "Opps!! " + ex.Message;
                    WebSecurity.ResetPassword(token, randomPassword);
                    PalLibrary.Messaging.SendSMS(userDetail.MobileNumber, $"You requested password reset on your account. Your new password is {randomPassword}", out messageId, out error);
                    TempData["success"] = "New password has been sent to your registered mobile number.";
                    return RedirectToAction("Login");
                }
            }
            else
            {

                WebSecurity.ResetPassword(token, randomPassword);
                PalLibrary.Messaging.SendSMS(userDetail.MobileNumber, $"You requested password reset on your account. Your new password is {randomPassword}", out messageId, out error);
                TempData["success"] = "New password has been sent to your registered mobile number.";
                return RedirectToAction("Login");
            }



            TempData["Status"] = "success";

            return View();
        }


        [HttpGet]
        [AllowAnonymous]
        public ActionResult ActivateAccount()
        {
            return View();
        }


        [HttpPost]
        [AllowAnonymous]
        // [ValidateAntiForgeryToken]
        public ActionResult ActivateAccount(ActivateAccountViewModel model)
        {
            string messageId = ""; string error = "";
            var password = UtilityHelper.GenerateRandomResetPassword();

            // var userDetail = _manager.GetUserDetails(model.Pin);  
            // var token = WebSecurity.GeneratePasswordResetToken(userDetail.Pin);

            try
            {
                if (model.Mobile == null)
                {
                    TempData["error"] = "Supplied value/data does not exist in our database";
                }

                if (String.IsNullOrEmpty(model.Pin))
                {
                    TempData["error"] = "Supplied value/data does not exist in our database";
                }
                //var emp = _db.Employees.FirstOrDefault(d => d.Pin == model.Pin);
                var emp = _db.Employees.Where(x => x.Pin == model.Pin).FirstOrDefault();

                if (emp == null)
                {
                    TempData["error"] = "User details is not found. Please check and try again later";
                }

                var mobileInput1 = model.Mobile.Substring(model.Mobile.Length - 10, 10);
                var mobile1 = emp.MobileNumber.Substring(model.Mobile.Length - 10, 10);

                // Check DOB and mobile
                if (emp.DateOfBirth.Value.Date != model.DateOfBirth.Date || mobileInput1 != mobile1)
                {
                    TempData["error"] = "Provided DOB or Mobile does not match with our record";
                }

                // Get user data
                var userModel = new UserModel();
                var user = _manager.Employee(model.Pin);
                if (user == null)
                {
                    TempData["error"] = "Pin not found";
                }
                var statement = new ClientStatement();
                var fundId = Convert.ToInt32(user.FundId);
                var clientStatement = statement.GetClientStatement(model.Pin, user.ClientStatus, fundId);

                userModel.Pin = user.Pin;
                userModel.FirstName = user.FirstName;
                userModel.Surname = user.Surname;
                userModel.OtherNames = user.OtherNames;
                userModel.DateOfBirth = user.DateOfBirth;
                userModel.MobileNumber = user.MobileNumber;
                userModel.TotalCountributionCount = clientStatement.TotalCountributionCount;
                userModel.Email = user.Email;
                userModel.RSABalance = clientStatement.CurrentBalance;
                userModel.AVC = clientStatement.CurrentBalanceVc;
                userModel.TotalBalance = clientStatement.TotalBalance;
                userModel.Address = user.HomeAddress;
                userModel.Gender = user.Gender;
                userModel.Employer_Recno = emp.Employer_Recno;
                userModel.EmployerName = emp.Employer_name;
                userModel.ResponseCode = "0";
                userModel.ResponseMessage = "Success";


                //Send sms
                PalLibrary.Messaging.SendSMS(user.MobileNumber, $"Dear {emp.Surname} {emp.FirstName}, your PAL a/c activation password has been reset. Your new password is: {password}", out messageId, out error);

                // Send Email 
                var msg = PalLibrary.Messaging.SendEmail(user.Email, "helpdesk@palpensions.com", $"PAL RSA Account Activation Reset  - {emp.Surname} {emp.FirstName}", $@"
                                    <p>Hello {emp.FirstName},<br/>

                                    <p>Your password account activation detail is as follow: <br />
                                <p> 
                                    First Name:  <strong> {emp.FirstName}   <br/>
                                    Surname: <strong> {emp.Surname}   <br/>        
                                   <b> Password: <strong> {password}  </b> <br/>

                            <p>         Regards<br/>

                                    PAL Pensions</p>", "PAL Pensions <palcustomercare@airmail.palpensions.com>");


                // Check the user exists
                var user1 = _db.UserProfiles.FirstOrDefault(d => d.Employee_Pin == model.Pin);

                if (user1 != null)
                {
                    // Reset password
                    string token = WebSecurity.GeneratePasswordResetToken(model.Pin);
                    WebSecurity.ResetPassword(token, password);

                    TempData["error"] = "User already exists. New password has been applied";
                }

                WebSecurity.CreateUserAndAccount(model.Pin, password,
                            new { emp.Email, Employee_Pin = model.Pin, FirstSignOn = true, IsDisabled = false });

                Roles.AddUserToRole(model.Pin, "Customer");
                //TempData["success"] = "Account activation was successful. Please login.";                   
                //return RedirectToAction("Login");
            }
            catch (Exception ex)
            {
                // TempData["error"] = "Account activation failed";
            }

            //return View(model);
            TempData["success"] = "Account activation was successful. Please login.";
            return RedirectToAction("Login");
        }



        [AllowAnonymous]
        public ActionResult PasswordReset(string token)
        {
            var x = new ResetPasswordViewModel { Token = token };
            return View(x);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult PasswordReset(ResetPasswordViewModel model)
        {
            if (!ModelState.IsValid) return View();
            var status = WebSecurity.ResetPassword(model.Token, model.Password);
            TempData["Status"] = status ? "success" : "nah";
            if (status)
            {
                TempData["success"] = "Your password was changed successfully. Please login below.";
                return RedirectToAction("Login");
            }
            else
            {
                TempData["error"] = "The request is no more valid. Please reset your password again.";
                return RedirectToAction("ForgotPassword");
            }
            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        //[ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {

            if (ModelState.IsValid && _manager.IsAccountDisabled(model.Username.ToUpper()))
            {
                ModelState.AddModelError("", "Your account has been disabled. Contact PAL");
                return View(model);
            }
            bool sec = WebSecurity.Login(model.Username.ToUpper(), model.Password);
            if (ModelState.IsValid && sec )
            {
                _manager.LogDate(model.Username.ToUpper());

                if (this.Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/")
                           && !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\"))
                {
                    // Response.Redirect(FormsAuthentication.GetRedirectUrl(username, true));
                    return Redirect(returnUrl);
                }

                if (_manager.FirstSignOn(model.Username))
                    return RedirectToAction("CompleteRegistration", new { username = model.Username });
                //return Roles.GetRolesForUser(model.Username).Single() == "Customer"
                //    ? RedirectToAction("Dashboard", "Customer")
                //    : RedirectToAction("Dashboard", "Admin");

                try
                {
                    //if (Roles.GetRolesForUser(model.Username.ToUpper()).Single() != "Customer" && model.Username.ToUpper().StartsWith("PEN"))
                    //{
                    if (model.Username.ToUpper().StartsWith("PEN"))
                    {
                        Roles.AddUserToRole(model.Username.ToUpper(), "Customer");
                    }

                    //}
                }
                catch (Exception ex)
                {
                    // return RedirectToAction("Home", "Customer");
                    // Don't catch
                    //TempData["error"] = "Error - " + ex.Message;
                    //ModelState.AddModelError("", ex.Message);
                }
                if (User.IsInRole("Customer") || Array.IndexOf(Roles.GetRolesForUser(model.Username), "Employee") > 0 ||
                    Array.IndexOf(Roles.GetRolesForUser(model.Username), "Customer") > 0 || Array.IndexOf(Roles.GetRolesForUser(model.Username), "Client") > 0)   // (.Single() == "Customer"
                {
                    return RedirectToAction("Home", "Customer");
                }
                else if (User.IsInRole("Administrator") || Roles.GetRolesForUser(model.Username).Single() == "Administrator"
                    || User.IsInRole("SuperAdministrator") || Roles.GetRolesForUser(model.Username).Single() == "SuperAdministrator")
                {
                    return RedirectToAction("Dashboard", "Admin");
                }
                //return Roles.GetRolesForUser(model.Username).Single() == "Customer"
                //? RedirectToAction("Home", "Customer")
                //: RedirectToAction("Dashboard", "Admin");
            }

            // If we got this far, something failed, redisplay form
            if (WebSecurity.IsAccountLockedOut(model.Username, 5, 1800) && _manager.IsNotAdmin(model.Username))
            {
                if (!_manager.UsernameExists(model.Username))
                {
                    ModelState.AddModelError("", "This Username does not exist");
                }
                else
                {
                    _manager.DisableAccount(model.Username);
                    var mails = ConfigurationManager.AppSettings["lockout-mails"].Split(';');
                    dynamic email = new Email("LockOut");
                    email.To = mails[0];
                    email.Cc = mails[1];
                    email.Pin = model.Username;
                    email.User = _manager.GetEmploteeFullName(model.Username);
                    try
                    {
                        email.Send();
                    }
                    catch (Exception ex)
                    {
                        // ModelState.AddModelError("", "Your account has been disabled. Contact PAL");
                    }

                    ModelState.AddModelError("", "Your account has been disabled. Contact PAL");
                }
            }
            else
            {
                ModelState.AddModelError("", "The user name or password provided is incorrect.");
            }
            return View(model);
        }

        [HttpGet]
        //[HttpPost]
        public ActionResult welcome(string token)
        {
            byte[] b;
            string decrypted;
            try
            {
                b = Convert.FromBase64String(token);
                decrypted = System.Text.ASCIIEncoding.ASCII.GetString(b);
            }
            catch (FormatException fe)
            {
                decrypted = "";
            }

            var userMail = _db.EmailRepositories.FirstOrDefault(d => d.Pin == decrypted);   //token=decrypted

            if (userMail == null)
            {
                TempData["failure"] = "PIN does not exist";
                return RedirectToAction("Login", "Account");
            }

            //EmailRepository emailrep = new EmailRepository();
            //emailrep.Pin = userMail.Pin;
            //emailrep.Id = userMail.Id;
            //emailrep.email = userMail.email;
            //emailrep.IsSent = userMail.IsSent;
            //emailrep.DateCreated = userMail.DateCreated;
            userMail.ValidationStatus = "success";
            userMail.Token = token;
            userMail.IsValidated = true;
            userMail.DateValidated = DateTime.Now;

            try
            {
                //  _db.Entry(emailrep).State = EntityState.Modified;
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                // return View(emailrep);
            }


            TempData["success"] = "Email verified successfully";
            return RedirectToAction("Login", "Account");       //Home
            // return View();
        }

        [AllowAnonymous]
        public ActionResult CompleteRegistration(string username)
        {
            ViewData["Questions"] = new SelectList(_manager.GetQuestions().OrderBy(s => s.Value).ToList(), "Id", "Value");
            var x = new CompleteRegistration { Username = username };
            return View(x);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult CompleteRegistration(CompleteRegistration x)
        {
            ViewData["Questions"] = new SelectList(_manager.GetQuestions().OrderBy(s => s.Value).ToList(), "Id", "Value");
            if (User.Identity.Name == "")
            {
                TempData["Status"] = "notLogged";
                return View(x);
            }

            var change = WebSecurity.ChangePassword(x.Username, x.OldPassword, x.NewPassword);
            _manager.SaveQuestionInformation(x.QuestionId, x.QuestionAnswer, WebSecurity.GetUserId(x.Username));
            _manager.SetFirstLogonToFalse(WebSecurity.GetUserId(x.Username));

            return Roles.GetRolesForUser(x.Username).Single() == "Customer"
                    ? RedirectToAction("Home", "Customer")
                    : RedirectToAction("Dashboard", "Admin");
        }

        [HttpPost]
        public JsonResult ChangePassword(ChangePasswordViewModel x)
        {
            if (!ModelState.IsValid) return Json("check");
            var change = WebSecurity.ChangePassword(User.Identity.Name, x.OldPassword, x.NewPassword);
            return Json(change ? "success" : "failed");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            WebSecurity.Logout();

            return RedirectToAction("Login", "Account");
        }

        [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
        public class ValidateJsonAntiForgeryTokenAttribute : FilterAttribute, IAuthorizationFilter
        {
            public void OnAuthorization(AuthorizationContext filterContext)
            {
                if (filterContext == null)
                {
                    throw new ArgumentNullException("filterContext");
                }

                var httpContext = filterContext.HttpContext;
                var cookie = httpContext.Request.Cookies[AntiForgeryConfig.CookieName];
                AntiForgery.Validate(cookie != null ? cookie.Value : null, httpContext.Request.Headers["__RequestVerificationToken"]);
            }
        }



        public ActionResult PrivacPolicy()
        {

            return View();
        }


    }
}