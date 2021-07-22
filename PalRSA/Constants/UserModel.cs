using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PalRSA.Constants
{
    public class UserModel
    {
        public string Pin { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string OtherNames { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public Nullable<System.DateTime> DateOfBirth { get; set; }
        public string MobileNumber { get; set; }
        public string Email { get; set; }
        public string Employer_Recno { get; set; }

        public string AccountOfficer { get; set; }

        public string ClientStatus { get; set; }

        public decimal RSABalance { get; set; }
        public decimal AVC { get; set; }
        public decimal TotalBalance { get; set; }
        public int TotalCountributionCount { get; set; }
        public string ResponseMessage { get; set; }
        public string ResponseCode { get; set; }
        public string EmployerName { get; set; }
        public decimal TotalUnit { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalGrowth { get; set; }
        public decimal TotalRSA { get; set; }
        public decimal TotalVC { get; set; }
        public DateTime ValueDate { get; set; }
    }
}