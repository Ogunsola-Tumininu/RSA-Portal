using PalRSA.Core.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PalRSA.Core.Models
{
    public partial class CFIUpdateViewModel
    {
        public Employee Employee { get; set; }
        #region List for Dropdown
        public List<MartialStatu> MaritialStatusList { get; set; }
        public List<Title> TitleList { get; set; }
        public List<Sex> SexList { get; set; }
        public List<StateOfOrigin> StateOfOriginsList { get; set; }
        public List<Country> NationalitiesList { get; set; }
        public List<LGArea> LgasList { get; set; }
        public List<State> StatesList { get; set; }
       // public List<City> CityList { get; set; }
        public List<StateOfPosting> StateOfPostingsList { get; set; }
        public List<Sector> SectorList { get; set; }
        public List<EmployeeStatu> EmployeeStatusList { get; set; }
        public List<Relationship> RelationshipList { get; set; }
        public List<Country> CountryList { get; set; }
        #endregion

        #region RSA Holder
        [Required(ErrorMessage = "RSA PIN is required.")]
        public string Pin	 { get; set; }
        [Required(ErrorMessage = "PFA is required.")]
        public string PFAName { get; set; }

        [Required(ErrorMessage = "RSA Status is required.")]
        public int EmployeeStatusId { get; set; }
        #endregion

        #region Personal Detail
        public int? UserId { get; set; }

        [Required(ErrorMessage = "Title is required.")]
        public int? TitleId { get; set; }

        [StringLength(60, ErrorMessage = "Surname exceeds Maximum allowed length.")]
        [Required(ErrorMessage = "Surname is required.")]
        public string Surname { get; set; }

        [StringLength(60, ErrorMessage = "First Name exceeds Maximum allowed length.")]
        [Required(ErrorMessage = "First Name is required.")]
        public string FirstName { get; set; }

        [StringLength(60, ErrorMessage = "Middle Name exceeds Maximum allowed length.")]
        // [Required(ErrorMessage = "Middle Name is required.")]
        public string MiddleName { get; set; }

        [StringLength(60, ErrorMessage = "Mother's Maiden Name exceeds Maximum allowed length.")]
        [Required(ErrorMessage = "Mother's Maiden Name is required.")]
        public string MotherName { get; set; }

        [Required(ErrorMessage = "Gender is required.")]
        public int? GenderId { get; set; }

        [Required(ErrorMessage = "Maritial Status is required.")]
        public int? MaritalStatusId { get; set; }
        public string NIN { get; set; }
        public string BVN { get; set; }
        public string IPN { get; set; }

       // [StringLength(60, ErrorMessage = "Date of Birth exceeds Maximum allowed length.")]
        [Required(ErrorMessage = "Date of Birth is required.")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? DateOfBirth { get; set; }

        [Required(ErrorMessage = "Nationality is required.")]
        public int? NationalityId { get; set; }

        [Required(ErrorMessage = "Place of Birth is required.")]
        public string PlaceOfBirth { get; set; }
        public int? PersonalStateOfOriginId { get; set; }
        public int? LGAId { get; set; }

        [Required(ErrorMessage = "It is required.")]
        public bool? IsNigerian { get; set; }

        [Required(ErrorMessage = "House No is required.")]
        public string HouseNo { get; set; }

        [Required(ErrorMessage = "Street is required.")]
        public string StreetName { get; set; }
        
        public string City { get; set; }
        public string LGACode { get; set; }
        public string StateCode { get; set; }
        public string CountryCode { get; set; }

        [Required(ErrorMessage = "Country Of Residance is required.")]
        public int? CountryOfResidanceId { get; set; }
        public string ZIP { get; set; }
        public string POBox { get; set; }

        [RegularExpression(@"[A-Za-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[A-Za-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[A-Za-z0-9](?:[A-Za-z0-9-]*[A-Za-z0-9])?\.)+[A-Za-z0-9](?:[A-Za-z0-9-]*[A-Za-z0-9])?", ErrorMessage = "Email Id is not in proper format")]
        public string Email { get; set; }

        [StringLength(11, ErrorMessage = "Home Phone number exceeds Maximum allowed length.")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Home Phone Number should contain only numbers")]
        [Required(ErrorMessage = "Phone No is required.")]
        public string HomePhone { get; set; }

        [StringLength(11, ErrorMessage = "Mobile Phone number exceeds Maximum allowed length.")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Mobile Phone number should contain only numbers")]
        public string MobilePhone { get; set; }

        #endregion

        #region Employment Record
        public int? EmploymentDetailId { get; set; }

        [Required(ErrorMessage = "Sector is required.")]
        public int? SectorId { get; set; }
        public bool? IsEmployerIPPIS { get; set; }

        [StringLength(200, ErrorMessage = "Employer Name exceeds Maximum allowed length.")]
        public string EmployerName { get; set; }

        [Required(ErrorMessage = "It is required.")]
        public bool? IsNigerianEmployer { get; set; }

        [Required(ErrorMessage = "Building is required.")]
        public string Building { get; set; }

        [Required(ErrorMessage = "Street  is required.")]
        public string EmployerStreetName { get; set; }
        public string EmployerCity { get; set; }
        public string LocalGovernmentCode { get; set; }
        public string EmployerStateCode { get; set; }
        public string EmployerCountryCode { get; set; }
        public string EmployerZIP { get; set; }
        public string EmployerPOBox { get; set; }

        [Required(ErrorMessage = "Phone No is required.")]
        [StringLength(11, ErrorMessage = "Home Phone number exceeds Maximum allowed length.")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Home Phone Number should contain only numbers")]
        public string EmployerPhoneNo { get; set; }

        [StringLength(11, ErrorMessage = "Mobile Phone number exceeds Maximum allowed length.")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Mobile Phone number should contain only numbers")]
        public string EmployerMobileNo { get; set; }

        [RegularExpression("^[0-9]*$", ErrorMessage = "EmployeeId should be a numbers only")]
        public string EmployeeId { get; set; }

        [RegularExpression("^[0-9]*$", ErrorMessage = "Service /ID No. should be a numbers only")]
        public int? ServiceIdNo { get; set; }

        [StringLength(200, ErrorMessage = "Designation exceeds Maximum allowed length.")]
        public string Designation { get; set; }
        public string DateOfFirstAppointment { get; set; }
        public string DateOfCurrentAppointment { get; set; }
        public string DateOfEmployment { get; set; }


        #endregion

        #region Salary Structure
        public int SalaryId { get; set; }
        [RegularExpression("^[0-9]*$", ErrorMessage = "It should be a number only")]
        public int? HarmonisedSalary { get; set; }

        [RegularExpression("^[0-9]*$", ErrorMessage = "It should be a number only")]
        public int? ConsolidatedSalary2007 { get; set; }

        [RegularExpression("^[0-9]*$", ErrorMessage = "It should be a number only")]
        public int? ConsolidatedSalary2010 { get; set; }

        [RegularExpression("^[0-9]*$", ErrorMessage = "It should be a number only")]
        public int? GL2004 { get; set; }

        [RegularExpression("^[0-9]*$", ErrorMessage = "It should be a number only")]
        public int? Step2004 { get; set; }

        [RegularExpression("^[0-9]*$", ErrorMessage = "It should be a number only")]
        public int? GL2007 { get; set; }

        [RegularExpression("^[0-9]*$", ErrorMessage = "It should be a number only")]
        public int? Step2007 { get; set; }

        [RegularExpression("^[0-9]*$", ErrorMessage = "It should be a number only")]
        public int? GL2010 { get; set; }

        [RegularExpression("^[0-9]*$", ErrorMessage = "It should be a number only")]
        public int? Step2010 { get; set; }

        [RegularExpression("^[0-9]*$", ErrorMessage = "It should be a number only")]
        public int? CurrentSalary { get; set; }

        [RegularExpression("^[0-9]*$", ErrorMessage = "It should be a number only")]
        public int? CurrentGL { get; set; }

        [RegularExpression("^[0-9]*$", ErrorMessage = "It should be a number only")]
        public int? CurrentStep { get; set; }
        #endregion

        #region Next Of Kin
        public int? NextOfKinId { get; set; }

        [StringLength(60, ErrorMessage = "Surname exceeds Maximum allowed length.")]

        [Required(ErrorMessage = "Surname is required.")]
        public string KinSurname { get; set; }

        [Required(ErrorMessage = "Gender is required.")]
        public int? KinGenderId { get; set; }

        [Required(ErrorMessage = "Title is required.")]
        public int? KinTitleId { get; set; }

        [StringLength(60, ErrorMessage = "First Name exceeds Maximum allowed length.")]
        [Required(ErrorMessage = " First Name is required.")]
        public string KinFirstName { get; set; }

        // [Required(ErrorMessage = "Middle Name is required.")]

        [StringLength(60, ErrorMessage = "Middle Name exceeds Maximum allowed length.")]
        public string KinMiddleName { get; set; }


        [Required(ErrorMessage = "Relationship is required.")]
        public int? KinRelationshipId { get; set; }

        [Required(ErrorMessage = "It is required.")]
        public bool? IsNigerianKin { get; set; }

        [Required(ErrorMessage = "House No is required.")]
        public string KinHouseNo { get; set; }

        [Required(ErrorMessage = "Street is required.")]
        public string KinStreetName { get; set; }

        [StringLength(25, ErrorMessage = "City exceeds Maximum allowed length.")]
        public string KinCity { get; set; }
        //public int KinLGAId { get; set; }
        public int? KinLGAId1 { get; set; }
        public int? KinStateId { get; set; }
        public int? KinCountryId { get; set; }
        public string KinZip { get; set; }
        public string KinPOBox { get; set; }

        [StringLength(28, ErrorMessage = "Email exceeds Maximum allowed length.")]
        [RegularExpression(@"[A-Za-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[A-Za-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[A-Za-z0-9](?:[A-Za-z0-9-]*[A-Za-z0-9])?\.)+[A-Za-z0-9](?:[A-Za-z0-9-]*[A-Za-z0-9])?", ErrorMessage = "Email Id is not in proper format")]
        public string KinEmail { get; set; }

        [StringLength(11, ErrorMessage = "Phone number exceeds Maximum allowed length.")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Phone Number should contain only numbers")]
        [Required(ErrorMessage = "Phone No is required.")]
        public string KinPhoneNo { get; set; }

        [StringLength(11, ErrorMessage = "Mobile number exceeds Maximum allowed length.")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Mobile Number should contain only numbers")]
        public string KinMobile { get; set; }
        #endregion

        #region Other
        public int? OtherId { get; set; }

        [Required(ErrorMessage = "Date is required.")]
        public string ContributorDate { get; set; }

       // [Required(ErrorMessage = "Fingerprint Challenge is required.")]
        public bool IsFingerprintChallenge { get; set; }

       // [Required(ErrorMessage = "Please select anyone Challenge Type.")]
        public string ChallengeType { get; set; }

       // [Required(ErrorMessage = "Designation is required.")]
        public string DesignationPFA { get; set; }
        #endregion

        #region Biometric
        public int? CFIBiometricId { get; set; }
        public string Passport { get; set; }
        public string ContributorSignature { get; set; }
        public string PFASignature { get; set; }

        [StringLength(60, ErrorMessage = "Date exceeds Maximum allowed length.")]
        [Required(ErrorMessage = "Date is required.")]
        public string PFADate { get; set; }
        #endregion

    }
}
