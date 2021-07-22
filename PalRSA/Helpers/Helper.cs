using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlTypes;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using PalRSA.Core;
using PalRSA.Core.Models;
using Postal;
using Microsoft.AspNet.Identity;
using PalRSA.Core.DataAccess;

namespace PalRSA.Helpers
{
    public static class Helper
    {
        private static readonly PalManager _manager = new PalManager();

        public static string GetApplicationTypeName(int appSubClassId)
        {
            return _manager.GetSubClassName(appSubClassId);
        }

        public static void SendMail(string email, string body, string subject, string applicationType)
        {
            if (email == null) return;
            var smtpEmail = ConfigurationManager.AppSettings["SmtpEmail"];

            var smtpClient = new SmtpClient();
            var mail = new MailMessage { From = new MailAddress(smtpEmail, "PAL Pensions") };

            //Setting From , To and CC
            mail.To.Add(new MailAddress(email));
            mail.Subject = $"Update on {applicationType} Application";
            mail.Body = body;
            
            smtpClient.Send(mail);
        }

        public static UserProfile GetAdminProfile(string user)
        {
            return _manager.GetAdminProfile(user);
        }

        internal static string GetHeader(decimal? fundId)
        {

            if (fundId == null | fundId == 0) return @"Unknown Account Summary <span class='text-danger'>
(It's seems your account has not been funded. Please contact us for further clarification.</span>)";
            string header = null;

            var intVersion = Convert.ToInt32(fundId);

            switch (intVersion)
            {
                case 1:
                    header = "PAL RSA Fund II Account Summary";
                    break;
                case 10000175:
                    header = "PAL RSA Fund I Account Summary";
                    break;
                case 10000176:
                    header = "PAL RSA Fund III Account Summary";
                    break;
                case 10000053:
                    header = "PAL RSA Fund IV (Retiree) Account Summary";
                    break;
                case 10000073:
                    header = "Emenite Gratuity Account Summary";
                    break;
                case 10000093:
                    header = "Guiness Gratuity Account Summary";
                    break;
            }

            return header;
        }

        public static string GetLabel(string label)
        {
            var info = "";
            switch (label)
            {
                case "ExitLetter":
                    info = "Exit letter issued by your employer which must state the effective date of exitChoose File";
                    break;
                case "PassportPhoto":
                    info = "Recent passport photograph";
                    break;
                case "BirthCertificate":
                    info = "Birth certificate OR sworn declaration of age (The date of birth on the document must be same as on our records)";
                    break;
                case "RetireeDetailForm":
                    info = "Retiree detail form";
                    break;
                case "MeansOfId":
                    info = "Means of identification. ANY of National Identity Card, Valid International Passport, Valid Drivers’ License, Letter of confirmation of identity from the bank or a Notary Public (stamped passport photograph must be affixed).";
                    break;
                case "BankDetails":
                    info = "Bank details (Personal bank account statement showing NUBAN details only OR a duly signed bankers’ confirmation from the client’s bank showing account details)";
                    break;
                case "BondSlip":
                    info = "Retirement benefit bond slip (Public Sector)";
                    break;
                case "PencomForm":
                    info = "PENCOM Indemnity Form (Public Sector)";
                    break;
                case "Payslip":
                    info = "Payslip";
                    break;
                case "RequestLetter":
                    info = "Signed request letter for 25% of RSA balance";
                    break;
                case "AvcRequestLetter":
                    info = "A signed request letter for AVC";
                    break;
                case "IndemnityFormAndPrgrammedAgreement":
                    info = "Indemnity Form and Programmed Withdrawal Agreement. The programmed withdrawal agreement must be signed by the applicant and witnessed by an independent party. It is applicable to retirees whose RSA balance is N550,000.00 and above.";
                    break;
                case "ProvisionalLifeAnnuityAgreement":
                    info = "Provisional Life Annuity Agreement/Request for An-nuity Payment Option. The annuity document is to be provided by any of the ap-proved Life Insurance Companies. A signed request letter indicating the retiree’s option for lump sum and annuity payment should also accompany the annuity document.";
                    break;
                case "PalDeathNotificationForm":
                    info = "Pal Death Notification Form";
                    break;
                case "PublicSectorDeceasedClientsWithoutAccruedBenefit":
                    info = "Public Sector Deceased clients without Accrued benefit For a public sector deceased clients whose accrued benefits have not been remitted into the RSA, the NOK will be required to submit the following:";
                    break;
                case "LetterOfFirstAppointment":
                    info = "Letter of first appointment";
                    break;
                case "DeseasedAgeDeclarationBirthCertificate":
                    info = "Deceased age declaration/birth certificate";
                    break;
                case "LastPaySlipBeforeDemise":
                    info = "Last pay slip before demise";
                    break;
                case "PaySlipAsAtJune2004":
                    info = "Pay slip as at June 2004";
                    break;
                case "LetterOfIntroducttion":
                    info = "Letter of introduction from employer stating deceased date of first appointment, date of birth, date of death, grade level & step as at June 2004 and grade level and step as the month of demise";
                    break;
                case "AttachedPENCOM":
                    info = "Attached PENCOM death notification form";
                    break;
                case "DeathCertificate":
                    info = "Death certificate or evidence of death These documents will be sent to PENCOM to facilitate the re - mittance of the deceased accrued benefit.";
                    break;
                case "AttachedNok":
                    info = "Attached NOK indemnity form";
                    break;
                case "DeclarationOfNok":
                    info = "Declaration of NOK by deceased employer";
                    break;
                case "LetterFromEmployer":
                    info = "Letter from employer stating the status of the deceased ben-efit";
                    break;
                case "PersonalAccount":
                    info = "The NOK/beneficiary must provide his/her personal bank account statement showing NUBAN details. PAL will not pay into a 3rd party account.";
                    break;
                case "BankersConfirmation":
                    info = "A duly signed bankers’ confirmation letter from the NOK’s bank showing account details is required in the absence of (A).";
                    break;
                case "NOKAdministratorsID":
                    info = "NOK/Administrator(s) means of identification: This can be ANY of National Identity Card, Valid Interna-tional Passport or Letter of confirmation of identity from the bank or a Notary Public which must have a stamped passport photograph. NOTE: Where the NOK is a minor, one passport photograph and birth certificate are required.";
                    break;
                case "PrivateSectoreInsurance":
                    info = "Private Sector Clients without Life Insurance Benefit PAL will request for the remittance of the deceased Life Insurance Proceeds from the employer.";
                    break;
                case "DeathCertification":
                    info = "Death Certificate or Registration of death A copy of the deceased death certificate / registration of death is required.";
                    break;
                case "LetterOrWill":
                    info = "A deceased’s NOK is required to obtain a letter of admin-istration from a high court or jurisdictional customary court in cases where the deceased client died interstate i.e. without a valid will. Where there is more than one administrator, a con-sent letter and sworn affidavit of consent is required. In the course of obtaining the LA, it is not necessary to present the deceased RSA as part of the assets of the deceased.";
                    break;
                case "TaxIdentificationNumber":
                    info = "Tax Identification number and employer TIN: A tax clearance document will suffice";
                    break;
                case "BankStatement":
                    info = "Bank Statement";
                    break;
                case "NsitfStatement":
                    info = "NSITF Statement";
                    break;
                case "PalNsitfForm":
                    info = "Pal NSITF Form";
                    break;
            }
            return info;
        }

        public static string GetStatusValue(int? status)
        {
            return _manager.GetStatusValue(status);
        }

        public static SearchValues BuildSearchModel(DateTime? startDate, DateTime? endDate)
        {
            return new SearchValues
            {
                StartDate = startDate,
                EndDate = endDate
            };
        }

        public static bool CheckStatus(int? status)
        {
            return _manager.CheckStatus(status);
        }

        public static string SplitCamelCase(string source)
        {
            var builder = new StringBuilder();
            foreach (char c in source)
            {
                if (char.IsUpper(c) && builder.Length > 0) builder.Append(' ');
                builder.Append(c);
            }

            return builder.ToString();

        }

        public static void SendUpdateMail(Mailer info, string template)
        {
            dynamic email = new Email(template);
            email.To = info.Email;
            email.Name = info.Name;
            email.AppType = info.ApplicationType;
            email.Status = info.Status;
            email.Send();
        }

        public static int GetTotalUnreadNotifications(string name)
        {
            return _manager.GetTotalUnread(_manager.GetEmployeePin(name));
        }

        public static bool IsRead(string name, int publicationsId)
        {
            return _manager.HasBeenRead(_manager.GetEmployeePin(name), publicationsId);
        }

        public static int GetTotalUnApprovedChanges()
        {
            return _manager.TotalUnApprovedChanges();
        }

        public static string FormatMoney(double value, int points)
        {
            return string.Format(new System.Globalization.CultureInfo("yo-NG"), "{0:C}", @Math.Round((decimal) value, points));
        }

        public static string FormatDouble(double value, int points)
        {
            return $"{@Math.Round((decimal) value):C}";
        }

        public static string GetFullName(string pin)
        {
            return _manager.GetEmploteeFullName(pin);
        }
    }

    public class AllowCrossSiteJsonAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
           // filterContext.RequestContext.HttpContext.Response.AddHeader("Access-Control-Allow-Origin", "*");
            base.OnActionExecuting(filterContext);
        }
    }

    public class SessionExpireAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            HttpContext ctx = HttpContext.Current;
            // check  sessions here
            if (HttpContext.Current.User.Identity.Name == null)
            {
                filterContext.Result = new RedirectResult("~/Account/Login");
                return;
            }
            base.OnActionExecuting(filterContext);
        }
    }

    public class NoCache : ActionFilterAttribute
    {
        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            filterContext.HttpContext.Response.Cache.SetExpires(DateTime.UtcNow.AddDays(-1));
            filterContext.HttpContext.Response.Cache.SetValidUntilExpires(false);
            filterContext.HttpContext.Response.Cache.SetRevalidation(HttpCacheRevalidation.AllCaches);
            filterContext.HttpContext.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            filterContext.HttpContext.Response.Cache.SetNoStore();

            base.OnResultExecuting(filterContext);
        }
    }
}