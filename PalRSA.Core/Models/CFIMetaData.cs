using System;
using System.ComponentModel.DataAnnotations;

namespace PalRSA.Core.DataAccess
{
    public class CFIMetadata
    {
    }
    public class CFIRegisterUserMetadata
    {
        // [Display(Name = "RSA Holder", Description = "RSA Holder")]
        public int UserId { get; set; }
        public string Pin { get; set; }
        [Display(Name = "PFA Name")]
        public string PFAName { get; set; }

        public string BVN { get; set; }
        [Required(ErrorMessage = "NIN field is required")]
        [MinLength(11, ErrorMessage = "NIN is 11 digits ")]
        public string NIN { get; set; }
        public string IPN { get; set; }
        [Required(ErrorMessage = " Title is required")]
        public Nullable<int> TitleId { get; set; }
        [Required(ErrorMessage = " Surname is required")]
        [StringLength(60, ErrorMessage = "Surname must not exceed 60 characters ")]
        public string Surname { get; set; }
        [Required(ErrorMessage = " FirstName is required")]
        [StringLength(60, ErrorMessage = "FirstName must not exceed 60 characters ")]
        public string FirstName { get; set; }
        public string MiddleName { get; set; }

        [Required(ErrorMessage = "RSA Status is required")]
        public Nullable<int> EmployeeStatusId { get; set; }
        [Required(ErrorMessage = " MaritalStatus is required")]
        public Nullable<int> MaritalStatusId { get; set; }
        [Required(ErrorMessage = "DateOfBirth is required")]
        [DataType(DataType.Date, ErrorMessage = "DOB must be a date")]
        public Nullable<System.DateTime> DateOfBirth { get; set; }

        [Required(ErrorMessage = " Gender is required")]
        public Nullable<int> GenderId { get; set; }
        [Required(ErrorMessage = " Nationality is required")]
        public Nullable<int> NationalityId { get; set; }
        public Nullable<int> PersonalStateOfOriginId { get; set; }
        public Nullable<int> LGAId { get; set; }
        public string City { get; set; }
        [Required(ErrorMessage = "Mobile field is required")]
        [StringLength(11, ErrorMessage = "Mobile 11 characters")]
        [MaxLength(11, ErrorMessage = "The field Mobile must be a numeric/numbers with a maxmium length of 11")]
        [MinLength(11, ErrorMessage = "The field Mobile must be a numeric/numbers with a minimum length of 11")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "MobileNo must be numeric")]
        public string Mobile { get; set; }

        [StringLength(11, ErrorMessage = "Phone 11 characters")]
        [MaxLength(11, ErrorMessage = "The field PhoneNo must be a numeric/numbers with a maxmium length of 11")]
        [MinLength(11, ErrorMessage = "The field PhoneNo must be a numeric/numbers with a minimum length of 11")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Phone must be numeric")]
        public string Phone { get; set; }
       // [Required(ErrorMessage = "Email address field is required")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Email address entered is not valid")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        public string Email { get; set; }
        [DataType(DataType.EmailAddress, ErrorMessage = "Email address entered is not valid")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        [Display(Name = "Alternative Email")]
        public string Email2 { get; set; }
        public string MotherMaidenName { get; set; }
        [Required(ErrorMessage = "PlaceOfBirth is required")]
        public string PlaceOfBirth { get; set; }
        // [Required(ErrorMessage = "Location is required")]
        public Nullable<bool> IsNigerian { get; set; }
        public string HouseNo { get; set; }
        public string StreetName { get; set; }
        public string LGACode { get; set; }
        public string StateCode { get; set; }

        public string CountryCode { get; set; }
        public Nullable<int> CountryOfResidanceId { get; set; }
        public string ZIP { get; set; }
        public string POBox { get; set; }
        public Nullable<System.DateTime> DatetimeCreated { get; set; }
        public Nullable<System.DateTime> DatetimeUpdated { get; set; }
        public bool Active { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public string Workstation { get; set; }

        public string FormRefNo { get; set; }
        public string RecaptureStatus { get; set; }
        public Nullable<System.DateTime> UploadDate { get; set; }
        public string DataSrc { get; set; }
    }

    [MetadataType(typeof(CFIRegisterUserMetadata))]
    public partial class CFIRegisterUser
    {
        //public string Fullname
        //{
        //    get
        //    {
        //        return String.Format("{0} {1} {2}", Lastname, this.Firstname, OtherName);
        //    }
        //    set { Fullname = String.Format("{0} {1} {2}", Lastname, this.Firstname, OtherName); }
        //}
    }

    public class CFIEmploymentDetailMetadata
    {
        public int EmploymentDetailId { get; set; }
        public Nullable<int> UserId { get; set; }
        public Nullable<int> SectorId { get; set; }
        public Nullable<bool> IsEmployerIPPIS { get; set; }
        [Required(ErrorMessage = "Employer name is required")]
        [StringLength(200, ErrorMessage = "EmployerName cannot exceed 200 characters.")]
        public string EmployerName { get; set; }

        [Required(ErrorMessage = "Employer location is required")]
        public Nullable<bool> IsNigerian { get; set; }
        [StringLength(20, ErrorMessage = "Building cannot exceed 20 characters.")]
        public string Building { get; set; }
        public string Street { get; set; }
        [StringLength(20, ErrorMessage = "City cannot exceed 20 characters.")]
        public string City { get; set; }
        public string LocalGovernmentCode { get; set; }

        [Required(ErrorMessage = "Nature of business is required")]
        public string NatureofBusiness { get; set; }
        public string StateCode { get; set; }
        [Required(ErrorMessage = "CountryCode  is required")]
        public string CountryCode { get; set; }
        public string ZIP { get; set; }
        public string POBox { get; set; }
        [Required(ErrorMessage = "Phone  field is required")]
        // [StringLength(15, ErrorMessage = "Phone 15 characters")]
        [MaxLength(15, ErrorMessage = "The field PhoneNo must be a numeric/numbers with a maxmium length of 15")]
        [MinLength(9, ErrorMessage = "The field PhoneNo must be a numeric/numbers with a minimum length of 9")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "PhoneNo must be numeric")]
        public string PhoneNo { get; set; }
        // [Required(ErrorMessage = "MobileNo  field is required")]
        //[StringLength(15, ErrorMessage = "MobileNo 15 characters")]
        // [MaxLength(15, ErrorMessage = "The field Mobile must be a numeric/numbers with a maxmium length of 15")]
        /// [MinLength(11, ErrorMessage = "The field Mobile must be a numeric/numbers with a minimum length of 11")]
        // [RegularExpression("^[0-9]*$", ErrorMessage = "MobileNo must be numeric")]
        public string MobileNo { get; set; }
        public string EmployeeId { get; set; }
        public Nullable<int> ServiceIdNo { get; set; }
        public string Designation { get; set; }
        [Required(ErrorMessage = "First appointment date in required")]
        [DataType(DataType.Date)]
        public DateTime DateOfFirstAppointment { get; set; }
        [Required(ErrorMessage = "Current employment date in required")]
        [DataType(DataType.Date)]
        public DateTime DateOfCurrentAppointment { get; set; }
        //public DateTime DateOfEmployment { get; set; }
        [Required(ErrorMessage = "Employer Name/Code required")]
        public string EmployerCode { get; set; }

    }
    [MetadataType(typeof(CFIEmploymentDetailMetadata))]
    public partial class CFIEmploymentDetail
    {

    }

    public class CFINextOfKinMetadata
    {
        public int NextOfKinId { get; set; }
        public Nullable<int> UserId { get; set; }
        [Required(ErrorMessage = "NOK Gender is required")]
        public Nullable<int> KinGenderId { get; set; }
        [Required(ErrorMessage = "NOK Title is required")]
        public Nullable<int> KinTitleId { get; set; }
        [Required(ErrorMessage = "NOK Surname is required")]
        public string Surname { get; set; }
        [Required(ErrorMessage = "NOK Firstname is required")]
        public string FirstName { get; set; }

        public string MiddleName { get; set; }
        [Required(ErrorMessage = "Relationship is required")]
        public Nullable<int> RelationshipId { get; set; }
        [Required(ErrorMessage = "Location is required")]
        public Nullable<bool> IsNigerian { get; set; }
        public string HouseNo { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public Nullable<int> LGAId { get; set; }
        public Nullable<int> StateId { get; set; }
        public Nullable<int> CountryId { get; set; }
        public string ZIP { get; set; }
        public string POBox { get; set; }
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        public string Email { get; set; }
        //[Required(ErrorMessage = "Phone  field is required")]
        //// [StringLength(15, ErrorMessage = "Phone 15 characters")]
        //[MaxLength(15, ErrorMessage = "The field PhoneNo must be a numeric/numbers with a maxmium length of 15")]
        //[MinLength(9, ErrorMessage = "The field PhoneNo must be a numeric/numbers with a minimum length of 9")]
        //[RegularExpression("^[0-9]*$", ErrorMessage = "PhoneNo must be numeric")]
        public string PhoneNo { get; set; }
        [Required(ErrorMessage = "MobileNo  field is required")]
        // [StringLength(15, ErrorMessage = "Phone 15 characters")]
        [MaxLength(15, ErrorMessage = "The field MobileNo must be a numeric/numbers with a maxmium length of 15")]
        [MinLength(9, ErrorMessage = "The field MobileNo must be a numeric/numbers with a minimum length of 9")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "MobileNo must be numeric")]
        public string MobileNo { get; set; }
        public bool Active { get; set; }
        public System.DateTime DatetimeCreated { get; set; }
        public System.DateTime DatetimeUpdated { get; set; }
        public string Createdby { get; set; }
        public string Modifiedby { get; set; }
        public string DataSrc { get; set; }
    }



    [MetadataType(typeof(CFINextOfKinMetadata))]
    public partial class CFINextOfKin
    {

    }
}