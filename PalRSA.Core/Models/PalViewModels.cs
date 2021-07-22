using System;
using System.Web;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using PalRSA.Core.DataAccess;

namespace PalRSA.Core.Models
{
    class PalViewModels
    {

    }

    public class AssetAllocationJson
    {
        public int asset_allocation_id { get; set; }
        public string date_created { get; set; }
        public double? equity { get; set; }
        public double? fixed_income { get; set; }
        public double? money_market { get; set; }
        public double? others { get; set; }
        public int? asset_allocation_type { get; set; }
    }
    public class Mailer
    {
        public string Email { get; set; }
        public string ApplicationType { get; set; }
        public string Name { get; set; }

        public string Status { get; set; }
    }

    public class AdminProfile
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string RoleId { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        public string AdminName { get; set; }
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string NewPassword { get; set; }
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("NewPassword", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public class ChangePasswordViewModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Old Password")]
        public string OldPassword { get; set; }


        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {6} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public class DashboardValues
    {
        public double TotalAmountContributed { get; set; }
        public double TotalIncomeOnContribution { get; set; }
        public double BalanceBeforeWithdrawal { get; set; }
        public double Withdrawal { get; set; }
        public double CurrentBalance { get; set; }
        public double UnitsHeld { get; set; }
        public double UnitPrice { get; set; }
    }

    public sealed class Enbloc_Old
    {
        public string User { get; set; }
        public int? BenefitClass { get; set; }
        public int? BenefitSubClass { get; set; }
        [Display(Name = "Exit letter issued by your employer which must state the effective date of exit")]
        //[Required]
        public HttpPostedFileBase ExitLetter { get; set; }
        [Display(Name = "Recent passport photograph")]
        [Required]
        public HttpPostedFileBase PassportPhoto { get; set; }
        [Display(Name = "Birth certificate OR sworn declaration of age (The date of birth on the document must be same as on our records)")]
        [Required]
        public HttpPostedFileBase BirthCertificate { get; set; }
        [Display(Name = "Retiree detail form")]
        [Required]
        public HttpPostedFileBase RetireeDetailForm { get; set; }
        [Display(Name = "Means of identification. ANY of National Identity Card, Valid International Passport, Valid Drivers’ License, Letter of confirmation of identity from the bank or a Notary Public (stamped passport photograph must be affixed). ")]
        [Required]
        public HttpPostedFileBase MeansOfId { get; set; }
        [Display(Name = "Bank details (Personal bank account statement showing NUBAN details only OR a duly signed bankers’ confirmation from the client’s bank showing account details)")]
        [Required]
        public HttpPostedFileBase BankDetails { get; set; }
        [Display(Name = "Retirement benefit bond slip (Public Sector)")]
        [Required]
        public HttpPostedFileBase BondSlip { get; set; }
        [Display(Name = "PENCOM Indemnity Form (Public Sector)")]
        [Required]
        public HttpPostedFileBase PencomForm { get; set; }
        [Display(Name = "Payslip. ANY of last three months before month of exit")]
        [Required]
        public HttpPostedFileBase Payslip { get; set; }
        [Display(Name = "Signed request letter for 25% of RSA balance")]
        [Required]
        public HttpPostedFileBase RequestLetter { get; set; }
        [Display(Name = "A signed request letter for AVC")]
        [Required]
        public HttpPostedFileBase AvcRequestLetter { get; set; }
        [Display(Name = "Indemnity Form and Programmed Withdrawal Agreement. The programmed withdrawal agreement must be signed by the applicant and witnessed by an independent party. It is applicable to retirees whose RSA balance is N550,000.00 and above.")]
        [Required]
        public HttpPostedFileBase IndemnityFormAndPrgrammedAgreement { get; set; }
        [Display(Name = "Provisional Life Annuity Agreement/Request for An-nuity Payment Option. The annuity document is to be provided by any of the ap-proved Life Insurance Companies. A signed request letter indicating the retiree’s option for lump sum and annuity payment should also accompany the annuity document.")]
        [Required]
        public HttpPostedFileBase ProvisionalLifeAnnuityAgreement { get; set; }
        [Display(Name = "Pal Death Notification Form")]
        public HttpPostedFileBase PalDeathNotificationForm { get; set; }
        [Display(Name = "Public Sector Deceased clients without Accrued benefit For a public sector deceased clients whose accrued benefits have not been remitted into the RSA, the NOK will be required to submit the following:")]
        public HttpPostedFileBase PublicSectorDeceasedClientsWithoutAccruedBenefit { get; set; }
        [Display(Name = "Letter of first appointment")]
        public HttpPostedFileBase LetterOfFirstAppointment { get; set; }
        [Display(Name = "Deceased age declaration/birth certificate")]
        public HttpPostedFileBase DeseasedAgeDeclarationBirthCertificate { get; set; }
        [Display(Name = "Last pay slip before demise")]
        public HttpPostedFileBase LastPaySlipBeforeDemise { get; set; }
        [Display(Name = "Pay slip as at June 2004")]
        public HttpPostedFileBase PaySlipAsAtJune2004 { get; set; }
        [Display(Name = "Letter of introduction from employer stating deceased date of first appointment, date of birth, date of death, grade level & step as at June 2004 and grade level and step as the month of demise")]
        public HttpPostedFileBase LetterOfIntroducttion { get; set; }
        [Display(Name = "Attached PENCOM death notification form")]
        public HttpPostedFileBase AttachedPencom { get; set; }
        [Display(Name = "Death certificate or evidence of death These documents will be sent to PENCOM to facilitate the re - mittance of the deceased accrued benefit.")]
        public HttpPostedFileBase DeathCertificate { get; set; }
        [Display(Name = "Attached NOK indemnity form")]
        public HttpPostedFileBase AttachedNok { get; set; }
        [Display(Name = "Declaration of NOK by deceased employer")]
        public HttpPostedFileBase DeclarationOfNok { get; set; }
        [Display(Name = "Letter from employer stating the status of the deceased benefit.")]
        public HttpPostedFileBase LetterFromEmployer { get; set; }
        [Display(Name = "The NOK/beneficiary must provide his/her personal bank account statement showing NUBAN details. PAL will not pay into a 3rd party account.")]
        public HttpPostedFileBase PersonalAccount { get; set; }
        [Display(Name = "A duly signed bankers’ confirmation letter from the NOK’s bank showing account details is required in the absence of (A).")]
        public HttpPostedFileBase BankersConfirmation { get; set; }
        [Display(Name = "NOK/Administrator(s) means of identification: This can be ANY of National Identity Card, Valid Interna-tional Passport or Letter of confirmation of identity from the bank or a Notary Public which must have a stamped passport photograph. NOTE: Where the NOK is a minor, one passport photograph and birth certificate are required.")]
        public HttpPostedFileBase NokAdministratorsId { get; set; }
        [Display(Name = "Private Sector Clients without Life Insurance Benefit PAL will request for the remittance of the deceased Life Insurance Proceeds from the employer.")]
        public HttpPostedFileBase PrivateSectoreInsurance { get; set; }
        [Display(Name = "Death Certificate or Registration of death A copy of the deceased death certificate / registration of death is required.")]
        public HttpPostedFileBase DeathCertification { get; set; }
        [Display(Name = "A deceased’s NOK is required to obtain a letter of admin-istration from a high court or jurisdictional customary court in cases where the deceased client died interstate i.e. without a valid will. Where there is more than one administrator, a con-sent letter and sworn affidavit of consent is required. In the course of obtaining the LA, it is not necessary to present the deceased RSA as part of the assets of the deceased.")]
        public HttpPostedFileBase LetterOrWill { get; set; }
        [Display(Name = "Tax Identification number and employer TIN: A tax clearance document will suffice")]
        public HttpPostedFileBase TaxIdentificationNumber { get; set; }
        [Display(Name = "Bank Statement")]
        public HttpPostedFileBase BankStatement { get; set; }
        [Display(Name = "NSITF Statement")]
        public HttpPostedFileBase NsitfStatement { get; set; }
        [Display(Name = "Pal NSITF Form")]

        public HttpPostedFileBase PalNsitfForm { get; set; }

    }

    public sealed class Enbloc
    {
        public string User { get; set; }
        public int? BenefitClass { get; set; }
        public int? BenefitSubClass { get; set; }
        [Display(Name = "Exit letter issued by your employer which must state the effective date of exit")]
        //[Required]
        public HttpPostedFileBase ExitLetter { get; set; }
        [Display(Name = "Recent passport photograph")]
        [Required]
        public HttpPostedFileBase PassportPhoto { get; set; }
        [Display(Name = "Birth certificate OR sworn declaration of age (The date of birth on the document must be same as on our records)")]
        [Required]
        public HttpPostedFileBase BirthCertificate { get; set; }
        [Display(Name = "Retiree detail form")]
        [Required]
        public HttpPostedFileBase RetireeDetailForm { get; set; }
        [Display(Name = "Means of identification. ANY of National Identity Card, Valid International Passport, Valid Drivers’ License, Letter of confirmation of identity from the bank or a Notary Public (stamped passport photograph must be affixed). ")]
        [Required]
        public HttpPostedFileBase MeansOfId { get; set; }
        [Display(Name = "Bank details (Personal bank account statement showing NUBAN details only OR a duly signed bankers’ confirmation from the client’s bank showing account details)")]
        [Required]
        public HttpPostedFileBase BankDetails { get; set; }
        [Display(Name = "Retirement benefit bond slip (Public Sector)")]
        [Required]
        public HttpPostedFileBase BondSlip { get; set; }
        [Display(Name = "PENCOM Indemnity Form (Public Sector)")]
        [Required]
        public HttpPostedFileBase PencomForm { get; set; }
        [Display(Name = "Payslip. ANY of last three months before month of exit")]
        [Required]
        public HttpPostedFileBase Payslip { get; set; }
        [Display(Name = "Signed request letter for 25% of RSA balance")]
        [Required]
        public HttpPostedFileBase RequestLetter { get; set; }
        [Display(Name = "A signed request letter for AVC")]
        [Required]
        public HttpPostedFileBase AvcRequestLetter { get; set; }
        [Display(Name = "Indemnity Form and Programmed Withdrawal Agreement. The programmed withdrawal agreement must be signed by the applicant and witnessed by an independent party. It is applicable to retirees whose RSA balance is N550,000.00 and above.")]
        [Required]
        public HttpPostedFileBase IndemnityFormAndPrgrammedAgreement { get; set; }
        [Display(Name = "Provisional Life Annuity Agreement/Request for An-nuity Payment Option. The annuity document is to be provided by any of the ap-proved Life Insurance Companies. A signed request letter indicating the retiree’s option for lump sum and annuity payment should also accompany the annuity document.")]
        [Required]
        public HttpPostedFileBase ProvisionalLifeAnnuityAgreement { get; set; }
        [Display(Name = "Pal Death Notification Form")]
        public HttpPostedFileBase PalDeathNotificationForm { get; set; }
        [Display(Name = "Public Sector Deceased clients without Accrued benefit For a public sector deceased clients whose accrued benefits have not been remitted into the RSA, the NOK will be required to submit the following:")]
        public HttpPostedFileBase PublicSectorDeceasedClientsWithoutAccruedBenefit { get; set; }
        [Display(Name = "Letter of first appointment")]
        public HttpPostedFileBase LetterOfFirstAppointment { get; set; }
        [Display(Name = "Deceased age declaration/birth certificate")]
        public HttpPostedFileBase DeseasedAgeDeclarationBirthCertificate { get; set; }
        [Display(Name = "Last pay slip before demise")]
        public HttpPostedFileBase LastPaySlipBeforeDemise { get; set; }
        [Display(Name = "Pay slip as at June 2004")]
        public HttpPostedFileBase PaySlipAsAtJune2004 { get; set; }
        [Display(Name = "Letter of introduction from employer stating deceased date of first appointment, date of birth, date of death, grade level & step as at June 2004 and grade level and step as the month of demise")]
        public HttpPostedFileBase LetterOfIntroducttion { get; set; }
        [Display(Name = "Attached PENCOM death notification form")]
        public HttpPostedFileBase AttachedPencom { get; set; }
        [Display(Name = "Death certificate or evidence of death These documents will be sent to PENCOM to facilitate the re - mittance of the deceased accrued benefit.")]
        public HttpPostedFileBase DeathCertificate { get; set; }
        [Display(Name = "Attached NOK indemnity form")]
        public HttpPostedFileBase AttachedNok { get; set; }
        [Display(Name = "Declaration of NOK by deceased employer")]
        public HttpPostedFileBase DeclarationOfNok { get; set; }
        [Display(Name = "Letter from employer stating the status of the deceased benefit.")]
        public HttpPostedFileBase LetterFromEmployer { get; set; }
        [Display(Name = "The NOK/beneficiary must provide his/her personal bank account statement showing NUBAN details. PAL will not pay into a 3rd party account.")]
        public HttpPostedFileBase PersonalAccount { get; set; }
        [Display(Name = "A duly signed bankers’ confirmation letter from the NOK’s bank showing account details is required in the absence of (A).")]
        public HttpPostedFileBase BankersConfirmation { get; set; }
        [Display(Name = "NOK/Administrator(s) means of identification: This can be ANY of National Identity Card, Valid Interna-tional Passport or Letter of confirmation of identity from the bank or a Notary Public which must have a stamped passport photograph. NOTE: Where the NOK is a minor, one passport photograph and birth certificate are required.")]
        public HttpPostedFileBase NokAdministratorsId { get; set; }
        [Display(Name = "Private Sector Clients without Life Insurance Benefit PAL will request for the remittance of the deceased Life Insurance Proceeds from the employer.")]
        public HttpPostedFileBase PrivateSectoreInsurance { get; set; }
        [Display(Name = "Death Certificate or Registration of death A copy of the deceased death certificate / registration of death is required.")]
        public HttpPostedFileBase DeathCertification { get; set; }
        [Display(Name = "A deceased’s NOK is required to obtain a letter of admin-istration from a high court or jurisdictional customary court in cases where the deceased client died interstate i.e. without a valid will. Where there is more than one administrator, a con-sent letter and sworn affidavit of consent is required. In the course of obtaining the LA, it is not necessary to present the deceased RSA as part of the assets of the deceased.")]
        public HttpPostedFileBase LetterOrWill { get; set; }
        [Display(Name = "Tax Identification number and employer TIN: A tax clearance document will suffice")]
        public HttpPostedFileBase TaxIdentificationNumber { get; set; }
        [Display(Name = "Bank Statement")]
        public HttpPostedFileBase BankStatement { get; set; }
        [Display(Name = "NSITF Statement")]
        public HttpPostedFileBase NsitfStatement { get; set; }
        [Display(Name = "Pal NSITF Form")]

        public HttpPostedFileBase PalNsitfForm { get; set; }

        public List<BenefitDocument> BenefitDoc { get; set; }
        public BenefitFile BenefitFile { get; set; }
        public BenefitProcess BenefitProcess { get; set; }
        public List<Int32> SelectedChoices { get; set; }
    }

    public class UploadPublications
    {
        public int PubId { get; set; }
        public HttpPostedFileBase Doc { get; set; }
        public DateTime DateUploaded { get; set; }
        public int UploadType { get; set; }
        public string DocName { get; set; }
    }

    public class CompleteRegistration
    {
        public string Username { get; set; }
        [Required]
        public int QuestionId { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "A question answer is needed", MinimumLength = 6)]
        public string QuestionAnswer { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "Your old password is required", MinimumLength = 6)]
        public string OldPassword { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string NewPassword { get; set; }
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("NewPassword", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public class ChangeOfName
    {
        public string Pin { get; set; }
        public HttpPostedFileBase Doc1 { get; set; }
        public HttpPostedFileBase Doc2 { get; set; }
        public string OldName { get; set; }
        public string NewName { get; set; }
        public string OldFirstName { get; set; }
        public string NewFirstName { get; set; }
        public string OldMiddleName { get; set; }
        public string NewMiddleName { get; set; }
        public string Sex { get; set; }
        public string Description { get; set; }
    }

    public class ChangeOfAddress
    {
        public string Pin { get; set; }
        public HttpPostedFileBase UtilityBill { get; set; }
        public string OldAddress { get; set; }
        public string NewAddress { get; set; }
    }

    public class Support
    {
        public string Pin { get; set; }
        public int Category { get; set; }
        public string Summary { get; set; }
        public string Explanation { get; set; }
    }

    public class AccountSummary
    {
        public decimal TotalUnitsR { get; set; }
        public decimal TotalUnitsV { get; set; }
        public decimal TotalUnits { get; set; }
        public double TotalMandatory { get; set; }
        public double TotalMandatoryStr { get; set; }
        public double TotalAvc { get; set; }
        public double TotalFee { get; set; }
        public double TotalAvcFee { get; set; }
        public decimal TotalVat { get; set; }
        public decimal TotalAvcvat { get; set; }
        public double? TotalAvcWithdrawal { get; set; }
        public double? TotalWithdrawal { get; set; }
        public double Eecont { get; set; }
        public double Ercont { get; set; }
        public double TotalAvcStr { get; set; }
        public double TotalWithdrawalStr { get; set; }
        public double TotalAmountContributedStr { get; set; }
        public double? UnitPrice { get; set; }
        public double UnitPriceStr { get; set; }
        public double UnitPriceAvcStr { get; set; }
        public double CurrentValueRsaStr { get; set; }
        public double CurrentValueAvcStr { get; set; }
        public double CurrentValueStr { get; set; }
        public double BalBeforeWithdrawalRsaStr { get; set; }
        public double BalBeforeWithdrawalAvcStr { get; set; }
        public double BalBeforeWithdrawalStr { get; set; }
        public double IncomeRsaStr { get; set; }
        public double IncomeAvcStr { get; set; }
        public double IncomeStr { get; set; }
        public double RetireeUnitPrice { get; set; }

    }

    public class RsaRetiree
    {
        public string Type { get; set; }
        public string Value { get; set; }
        public string Date { get; set; }
    }

    public class RsaHistory
    {
        public string Value { get; set; }
        public string Date { get; set; }
    }

    public class SummaryModel
    {
        public string Description { get; set; }
        public  double Rsa { get; set; }
        public double Avc { get; set; }
        public double Total { get; set; }
    }

    public class AdminDashboard
    {
        public string FullName { get; set; }
        public string Pin { get; set; }
        public DateTime LastLogin { get; set; }
        public string Email { get; set; }
        public string Employer { get; set; }
    }

    public class StatementGeneration
    {
        public DateTime ValueDate { get; set; }
        public string Description { get; set; }
        public double Employee { get; set; }
        public double Employer { get; set; }
        public double Fees { get; set; }
        public double Vat { get; set; }
        public double NetContribution { get; set; }
        public double Withdrawal { get; set; }
        public decimal Price { get; set; }
        public double Units { get; set; }
    }

    public class GenerateReport
    {

        public GenerateReport()
        {
            Records = Records ?? new List<StatementGeneration>();
            VoluntaryContribution = VoluntaryContribution ?? new List<StatementGeneration>();
        }

        public Employee Details { get; set; }
        public IEnumerable<StatementGeneration> Records { get; set; }
        public IEnumerable<StatementGeneration> VoluntaryContribution { get; set; }

        public ReportSummation RegularContributionClosing { get; set; }
        public ReportSummation VoluntaryContributionClosing { get; set; }
        public FinalComputation Rsa { get; set; }
        public FinalComputation Voluntary { get; set; }
    }

    public class ReportSummation
    {
        public decimal SumEmployee { get; set; }
        public decimal SumEmployer { get; set; }
        public decimal SumFees { get; set; }
        public decimal SumVat { get; set; }
        public decimal SumNetContribution { get; set; }
        public decimal SumWithdrawal { get; set; }
        public decimal SumPrice { get; set; }
        public decimal SumUnits { get; set; }
        public decimal CurrentUnitPrice { get; set; }
        //added this column to hold avc withdrawal
        public decimal SumWithdrawalVc { get; set; }
    }

    public class EmployeeReportSummation
    {

        public EmployeeReportSummation()
        {
            Contributions = Contributions ?? new List<Contribution>();
        }

        public IEnumerable<Contribution> Contributions { get; set; }
        public AccountManager Manager { get; set; }
        public decimal SumEmployee { get; set; }
        public decimal SumEmployer { get; set; }

        public decimal SumAvc { get; set; }

        public decimal TotalFees { get; set; }
        public decimal TotalVat { get; set; }
        public decimal AvcVat { get; set; }
        public decimal OtherFee { get; set; }

        public decimal NetContributionRsa { get; set; }
        public decimal NetContributionVc { get; set; }
        public decimal RsaWithdrawal { get; set; }
        public decimal VcWithdrawal { get; set; }
        public decimal TotalWithdrawal { get; set; }

        public decimal rsaBeforeWithdrawal { get; set; }
        public decimal vcBeforeWithdrawal { get; set; }
        public decimal totalBeforeWithdrawal { get; set; }

        public decimal rsaBalance { get; set; }
        public decimal vcBalance { get; set; }
        public decimal totalBalance { get; set; }

        public decimal SumPrice { get; set; }

        public decimal RsaIncome { get; set; }
        public decimal VcIncome { get; set; }
        public decimal TotalIncome { get; set; }

        public decimal SumUnitsRsa { get; set; }
        public decimal SumUnitsVc { get; set; }
        public decimal TotalUnits { get; set; }

        public decimal CurrentUnitPrice { get; set; }
        //added this column to hold avc withdrawal
        public double SumWithdrawalVc { get; set; }
        public double unitPrice { get; set; }

        public decimal totalContribution { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public string Pin { get; set; }
        public string EmployerDetail { get; set; }

        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }
        public DateTime LastValueDate { get; set; }
    }


    public class Constants
    {
        public const string Rsa= "Retirement Savings Account Summary";
        public const string Emenite = "Emenite Gratuity Account Summary";
        public const string Guiness = "Guiness Gratuity Account Summary";
    }

    public class FinalComputation
    {
        public decimal ContributionsFromInception { get; set; }
        public decimal TotalDeduction { get; set; }
        public decimal TotalWithdrawalFromInception { get; set; }
        public decimal NetContribution { get; set; }
        public decimal GainLossFromInception { get; set; }
        public decimal CurrentValue { get; set; }
        public decimal NumOfUnitsHeld { get; set; }
        public decimal UnitPrice { get; set; }
    }

    public class AssetAllocationsUpload
    {
        public HttpPostedFileBase AssetAllocation { get; set; }
        public int AssetType { get; set; }
    }

    public sealed class CreateCustomerView
    {
        [Display(Name = "Pin")]
        [Required]
        public string Pin { get; set; }
        [Display(Name = "Registration Code")]
        [Required]
        public string RegistrationCode { get; set; }
        [Display(Name = "First Name")]
        [Required]
        public string FirstName { get; set; }
        [Display(Name = "Surname")]
        [Required]
        public string Surname { get; set; }
        [Display(Name = "OtherNames")]
        public string OtherNames { get; set; }
        [Display(Name = "Gender")]
        [Required]
        public string Gender { get; set; }
        [Display(Name = "Date Of Birth")]
        [Required]
        public string DateOfBirth { get; set; }
        [Display(Name = "Mobile Number")]
        [Required]
        public string MobileNumber { get; set; }
        [Display(Name = "Mobile Number 2")]
        public string MobileNumber2 { get; set; }
        [Display(Name = "Email")]
        [Required]
        public string Email { get; set; }
        [Display(Name = "Employer Recno")]
        [Required]
        public string EmployerRecno { get; set; }
        [Display(Name = "Home Address")]
        [Required]
        public string HomeAddress { get; set; }
        [Display(Name = "Permanent Address")]
        public string PermanentAddress { get; set; }
        public ICollection<NextOfKinView> NextOfKins { get; set; }
        public UserView User { get; set; }
    }

    public abstract class UserView
    {
        public int? UserId { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string SecretQuestion { get; set; }
        [Required]
        public string SecretQuestionAnswer { get; set; }
        public string VerificationCode { get; set; }
        public string EmployeePin { get; set; }
        [Required]
        public string Password { get; set; }
        public DateTime? LastLogin { get; set; }
    }

    
    public abstract class NextOfKinView
    {
        public int? Id { get; set; }
        public string EmployeePin { get; set; }
        public string FirstName { get; set; }
        public string Gender { get; set; }
        public string Surname { get; set; }
        public string OtherNames { get; set; }
        public string Relation { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public virtual Employee Employee { get; set; }
    }
    

    public class EmployeeViewModel
    {
        public string Pin { get; set; }
        public string RegistrationCode { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string OtherNames { get; set; }
        public string Gender { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string MobileNumber { get; set; }
        public string MobileNumber2 { get; set; }
        public string Email { get; set; }
        public string Employer_Recno { get; set; }
        public string HomeAddress { get; set; }
        public string StreetName { get; set; }
        public string PermanentAddress { get; set; }
        public string FullName { get; set; }
        public bool IsNigerian { get; set; }
        public string HouseNo { get; set; }
        public string City { get; set; }
        public string StateCode { get; set; }
        public string lgaCode { get; set; }
        public string CountryCode { get; set; }
        //public int CountryOfResidanceId { get; set; }
        public string Account_Officer { get; set; }

        public string Account_Officer_Mobile { get; set; }

        public string Account_Officer_Email { get; set; }
        public string Createdby { get; set; }

        public string Portal { get; set; }



        public virtual EmployerDetail EmployerDetail { get; set; }
        public virtual IList<NextOfKin> NextOfKins { get; set; } = new List<NextOfKin>();
        public virtual IList<BenefitApplication> BenefitApplications { get; set; } = new List<BenefitApplication>();
        public virtual IList<Contribution> Contributions { get; set; } = new List<Contribution>();
    }    


    #region added by Tunde
    public class BenefitProcessViewModel
    {
        public long EmployeeId { get; set; }
        public string Pin { get; set; }
        public string RegistrationCode { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string OtherNames { get; set; }
        public string Gender { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string MobileNumber { get; set; }
        public string MobileNumber2 { get; set; }
        public string Email { get; set; }
        public string Employer_Recno { get; set; }
        public string HomeAddress { get; set; }
        public string PermanentAddress { get; set; }

        public virtual EmployerDetail EmployerDetail { get; set; }
        public virtual IList<NextOfKin> NextOfKins { get; set; } = new List<NextOfKin>();
        public virtual IList<BenefitApplication> BenefitApplications { get; set; } = new List<BenefitApplication>();
        public virtual IList<Contribution> Contributions { get; set; } = new List<Contribution>();
        public virtual BenefitClass BenefitClass { get; set; }


        public List<BenefitDocument> BenefitDoc { get; set; }
        public BenefitFile BenefitFile { get; set; }
        public BenefitProcess BenefitProcess { get; set; }
        public List<Int32> SelectedChoices { get; set; }

        public string User { get; set; }
        public int? BenefitSubClass { get; set; }

        [Display(Name = "Exit letter issued by your employer which must state the effective date of exit")]
        //[Required]
        public HttpPostedFileBase ExitLetter { get; set; }
        [Display(Name = "Recent passport photograph")]
        [Required]
        public HttpPostedFileBase PassportPhoto { get; set; }
        [Display(Name = "Birth certificate OR sworn declaration of age (The date of birth on the document must be same as on our records)")]
        [Required]
        public HttpPostedFileBase BirthCertificate { get; set; }
        [Display(Name = "Retiree detail form")]
        [Required]
        public HttpPostedFileBase RetireeDetailForm { get; set; }
        [Display(Name = "Means of identification. ANY of National Identity Card, Valid International Passport, Valid Drivers’ License, Letter of confirmation of identity from the bank or a Notary Public (stamped passport photograph must be affixed). ")]
        [Required]
        public HttpPostedFileBase MeansOfId { get; set; }
        [Display(Name = "Bank details (Personal bank account statement showing NUBAN details only OR a duly signed bankers’ confirmation from the client’s bank showing account details)")]
        [Required]
        public HttpPostedFileBase BankDetails { get; set; }
        [Display(Name = "Retirement benefit bond slip (Public Sector)")]
        [Required]
        public HttpPostedFileBase BondSlip { get; set; }
        [Display(Name = "PENCOM Indemnity Form (Public Sector)")]
        [Required]
        public HttpPostedFileBase PencomForm { get; set; }
        [Display(Name = "Payslip. ANY of last three months before month of exit")]
        [Required]
        public HttpPostedFileBase Payslip { get; set; }
        [Display(Name = "Signed request letter for 25% of RSA balance")]
        [Required]
        public HttpPostedFileBase RequestLetter { get; set; }
        [Display(Name = "A signed request letter for AVC")]
        [Required]
        public HttpPostedFileBase AvcRequestLetter { get; set; }
        [Display(Name = "Indemnity Form and Programmed Withdrawal Agreement. The programmed withdrawal agreement must be signed by the applicant and witnessed by an independent party. It is applicable to retirees whose RSA balance is N550,000.00 and above.")]
        [Required]
        public HttpPostedFileBase IndemnityFormAndPrgrammedAgreement { get; set; }
        [Display(Name = "Provisional Life Annuity Agreement/Request for An-nuity Payment Option. The annuity document is to be provided by any of the ap-proved Life Insurance Companies. A signed request letter indicating the retiree’s option for lump sum and annuity payment should also accompany the annuity document.")]
        // [Required]
        public HttpPostedFileBase ProvisionalLifeAnnuityAgreement { get; set; }
        [Display(Name = "Pal Death Notification Form")]
        public HttpPostedFileBase PalDeathNotificationForm { get; set; }
        [Display(Name = "Public Sector Deceased clients without Accrued benefit For a public sector deceased clients whose accrued benefits have not been remitted into the RSA, the NOK will be required to submit the following:")]
        public HttpPostedFileBase PublicSectorDeceasedClientsWithoutAccruedBenefit { get; set; }
        [Display(Name = "Letter of first appointment")]
        public HttpPostedFileBase LetterOfFirstAppointment { get; set; }
        [Display(Name = "Deceased age declaration/birth certificate")]
        public HttpPostedFileBase DeseasedAgeDeclarationBirthCertificate { get; set; }
        [Display(Name = "Last pay slip before demise")]
        public HttpPostedFileBase LastPaySlipBeforeDemise { get; set; }
        [Display(Name = "Pay slip as at June 2004")]
        public HttpPostedFileBase PaySlipAsAtJune2004 { get; set; }
        [Display(Name = "Letter of introduction from employer stating deceased date of first appointment, date of birth, date of death, grade level & step as at June 2004 and grade level and step as the month of demise")]
        public HttpPostedFileBase LetterOfIntroducttion { get; set; }
        [Display(Name = "Attached PENCOM death notification form")]
        public HttpPostedFileBase AttachedPencom { get; set; }
        [Display(Name = "Death certificate or evidence of death These documents will be sent to PENCOM to facilitate the re - mittance of the deceased accrued benefit.")]
        public HttpPostedFileBase DeathCertificate { get; set; }
        [Display(Name = "Attached NOK indemnity form")]
        public HttpPostedFileBase AttachedNok { get; set; }
        [Display(Name = "Declaration of NOK by deceased employer")]
        public HttpPostedFileBase DeclarationOfNok { get; set; }
        [Display(Name = "Letter from employer stating the status of the deceased benefit.")]
        public HttpPostedFileBase LetterFromEmployer { get; set; }
        [Display(Name = "The NOK/beneficiary must provide his/her personal bank account statement showing NUBAN details. PAL will not pay into a 3rd party account.")]
        public HttpPostedFileBase PersonalAccount { get; set; }
        [Display(Name = "A duly signed bankers’ confirmation letter from the NOK’s bank showing account details is required in the absence of (A).")]
        public HttpPostedFileBase BankersConfirmation { get; set; }
        [Display(Name = "NOK/Administrator(s) means of identification: This can be ANY of National Identity Card, Valid Interna-tional Passport or Letter of confirmation of identity from the bank or a Notary Public which must have a stamped passport photograph. NOTE: Where the NOK is a minor, one passport photograph and birth certificate are required.")]
        public HttpPostedFileBase NokAdministratorsId { get; set; }
        [Display(Name = "Private Sector Clients without Life Insurance Benefit PAL will request for the remittance of the deceased Life Insurance Proceeds from the employer.")]
        public HttpPostedFileBase PrivateSectoreInsurance { get; set; }
        [Display(Name = "Death Certificate or Registration of death A copy of the deceased death certificate / registration of death is required.")]
        public HttpPostedFileBase DeathCertification { get; set; }
        [Display(Name = "A deceased’s NOK is required to obtain a letter of admin-istration from a high court or jurisdictional customary court in cases where the deceased client died interstate i.e. without a valid will. Where there is more than one administrator, a con-sent letter and sworn affidavit of consent is required. In the course of obtaining the LA, it is not necessary to present the deceased RSA as part of the assets of the deceased.")]
        public HttpPostedFileBase LetterOrWill { get; set; }
        [Display(Name = "Tax Identification number and employer TIN: A tax clearance document will suffice")]
        public HttpPostedFileBase TaxIdentificationNumber { get; set; }
        [Display(Name = "Bank Statement")]
        public HttpPostedFileBase BankStatement { get; set; }
        [Display(Name = "NSITF Statement")]
        public HttpPostedFileBase NsitfStatement { get; set; }
        [Display(Name = "Pal NSITF Form")]
        public HttpPostedFileBase PalNsitfForm { get; set; }
    }


    #endregion

    public class SearchValues
    {
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
