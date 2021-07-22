//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PalRSA.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class EMPLOYEE
    {
        public string REGISTRATION_CODE { get; set; }
        public string PIN { get; set; }
        public string TITLE { get; set; }
        public string SURNAME { get; set; }
        public string FIRSTNAME { get; set; }
        public string OTHERNAMES { get; set; }
        public string GENDER { get; set; }
        public string SSN { get; set; }
        public Nullable<System.DateTime> DATE_OF_BIRTH { get; set; }
        public string MARITAL_STATUS_CODE { get; set; }
        public string PERMANENT_ADDRESS { get; set; }
        public string NATIONALITY_CODE { get; set; }
        public string STATE_OF_ORIGIN { get; set; }
        public string LGA_CODE { get; set; }
        public string QUALIFICATION_CODE { get; set; }
        public string OCCUPATION_CODE { get; set; }
        public string INDUSTRY_CODE { get; set; }
        public string HOME_PHONE { get; set; }
        public string MOBILE_PHONE { get; set; }
        public string EMAIL { get; set; }
        public string NOK_NAME { get; set; }
        public string NOK_ADDRESS { get; set; }
        public string NOK_RELATIONSHIP { get; set; }
        public string NOK_OFFICE_PHONE { get; set; }
        public string NOK_MOBILE_PHONE { get; set; }
        public string NOK_HOME_PHONE { get; set; }
        public string EMPLOYEE_ID { get; set; }
        public string employer_name { get; set; }
        public string EMPLOYER_RCNO { get; set; }
        public string EMPLOYER_ADDRESS { get; set; }
        public string EMPLOYER_PHONE { get; set; }
        public string EMPLOYER_EMAIL { get; set; }
        public string EMPLOYER_WEBSITE { get; set; }
        public string EMPLOYER_CONTACT { get; set; }
        public string EMPLOYER_BANK { get; set; }
        public string EMPLOYER_INDUSTRY { get; set; }
        public string EMPLOYER_BUSINESS { get; set; }
        public Nullable<System.DateTime> DATE_EMPLOYED { get; set; }
        public Nullable<decimal> MONTHLY_SALARY { get; set; }
        public string PICTURE_URL { get; set; }
        public string SIGNATURE_URL { get; set; }
        public Nullable<decimal> SERIAL { get; set; }
        public Nullable<decimal> INVESTOR_ID { get; set; }
        public bool EXTRACTED { get; set; }
        public string PFA_CODE { get; set; }
        public string BRANCH_CODE { get; set; }
        public string NOTES { get; set; }
        public bool CHECKED_BY { get; set; }
        public Nullable<System.DateTime> CHECKED_DATE { get; set; }
        public Nullable<decimal> APPROVED_BY { get; set; }
        public Nullable<System.DateTime> APPROVED_DATE { get; set; }
        public Nullable<decimal> CHECKED { get; set; }
        public bool APPROVED { get; set; }
        public bool EXP_TO_PENCOM { get; set; }
        public bool EXP_TO_PRINT { get; set; }
        public bool PIN_NOTIFICATION { get; set; }
        public Nullable<bool> UPLOAD { get; set; }
        public string CORRESPONDENCE_ADDS { get; set; }
        public Nullable<decimal> EMPLOYEE_CONTRIBUTION { get; set; }
        public Nullable<decimal> EMPLOYER_CONTRIBUTION { get; set; }
        public Nullable<decimal> OTHER_CONTRIBUTION { get; set; }
        public string DEPARTMENT { get; set; }
        public string DESIGNATION { get; set; }
        public string PASSPORT { get; set; }
        public string SIGNATURE { get; set; }
        public string STATUS { get; set; }
        public Nullable<decimal> PRINTED_BY { get; set; }
        public Nullable<decimal> NO_OF_PRINTS { get; set; }
        public Nullable<System.DateTime> PRINT_DATE { get; set; }
        public bool PRINT_STATUS { get; set; }
        public string PICTURE_TYPE { get; set; }
        public string SIGNATURE_TYPE { get; set; }
        public bool COY_SELECT_OPTION { get; set; }
        public string AGENT_CODE { get; set; }
        public byte[] FINGER_PRINT { get; set; }
        public Nullable<System.DateTime> DATE_CONFIRMED { get; set; }
        public string SALARY_SCALE { get; set; }
        public Nullable<decimal> GRADE_LEVEL { get; set; }
        public Nullable<decimal> STEP { get; set; }
        public string POSTING_LOCATION { get; set; }
        public Nullable<decimal> BASIC_ALLOWANCE { get; set; }
        public Nullable<decimal> TRANSPORT_ALLOWANCE { get; set; }
        public Nullable<decimal> HOUSING_ALLOWANCE { get; set; }
        public Nullable<decimal> OTHER_ALLOWANCE { get; set; }
        public string EMPLOYEE_TYPE { get; set; }
        public string MAIDEN_NAME { get; set; }
        public Nullable<decimal> INVEST_PRODUCT1 { get; set; }
        public Nullable<decimal> INVEST_PRODUCT2 { get; set; }
        public Nullable<decimal> INVEST_PERCENTAGE2 { get; set; }
        public Nullable<decimal> INVEST_PRODUCT3 { get; set; }
        public Nullable<decimal> INVEST_PERCENTAGE3 { get; set; }
        public Nullable<decimal> INVEST_PRODUCT4 { get; set; }
        public Nullable<decimal> INVEST_PERCENTAGE4 { get; set; }
        public Nullable<decimal> INVEST_PRODUCT5 { get; set; }
        public Nullable<decimal> INVEST_PERCENTAGE5 { get; set; }
        public Nullable<decimal> SCHEME_ID { get; set; }
        public Nullable<decimal> INVEST_PERCENTAGE1 { get; set; }
        public string EMPLOYER_ADDRESS1 { get; set; }
        public string EMPLOYER_CITY { get; set; }
        public string EMPLOYER_STATECODE { get; set; }
        public string CORRESPONDENCE_ADDS1 { get; set; }
        public string NOK_SURNAME { get; set; }
        public string NOK_OTHERNAME { get; set; }
        public string NOK_GENDER { get; set; }
        public string NOK_STATECODE { get; set; }
        public string NOK_CORRADDRESS1 { get; set; }
        public string NOK_CORRADDRESS2 { get; set; }
        public string NOK_CITY { get; set; }
        public string NOK_EMAILADDRESS { get; set; }
        public string CITY { get; set; }
        public string STATE_OF_POSTING { get; set; }
        public string STATE { get; set; }
        public string PFA_TRANS_IN { get; set; }
        public string ACCT_TYPE { get; set; }
        public string RSA_NUMBER { get; set; }
        public string CLIENT_STATUS { get; set; }
        public string FORM_IMAGE { get; set; }
        public string BIOMETRICS { get; set; }
        public Nullable<System.DateTime> DATE_CREATED { get; set; }
        public Nullable<decimal> USERID { get; set; }
        public string PIN_BATCH { get; set; }
        public Nullable<decimal> ER_NO_OF_PRINTS { get; set; }
        public bool ER_PRINT_STATUS { get; set; }
        public Nullable<decimal> ER_PRINTED_BY { get; set; }
        public Nullable<System.DateTime> ER_PRINT_DATE { get; set; }
        public string BIOMETRICS1 { get; set; }
        public string BATCH_ID { get; set; }
        public string FORM_REFNO { get; set; }
        public bool GENDER1 { get; set; }
        public bool MARITAL_STATUS1 { get; set; }
        public Nullable<bool> NOK_GENDER1 { get; set; }
        public string NOK_TITLE { get; set; }
        public string NOK_COUNTRY { get; set; }
        public bool PIN_INVALID { get; set; }
        public Nullable<decimal> EE_NO_OF_PRINTS { get; set; }
        public Nullable<decimal> EE_PRINTED_BY { get; set; }
        public Nullable<System.DateTime> EE_PRINT_DATE { get; set; }
        public bool EE_PRINT_STATUS { get; set; }
        public bool EE_PFC_CHECK { get; set; }
        public bool ER_PFC_CHECK { get; set; }
        public string EE_PFC_BATCH { get; set; }
        public string ER_PFC_BATCH { get; set; }
        public string OLD_EMPLOYEEID { get; set; }
        public string EMPLOYEE_GROUP { get; set; }
        public string LOCATION_CODE { get; set; }
        public string SAP_NO { get; set; }
        public Nullable<decimal> MEAL_SUBSIDY { get; set; }
        public Nullable<decimal> LEAVE_ALLOWANCE { get; set; }
        public string STAFF_GRADE { get; set; }
        public Nullable<System.DateTime> DATE_JOINED_FUND { get; set; }
        public Nullable<System.DateTime> LAST_PROMO_DATE { get; set; }
        public Nullable<System.DateTime> DATE_SENT { get; set; }
        public string REQ_BY_PENCOM { get; set; }
        public string UPLOAD_PIN { get; set; }
        public byte[] PICTURE_IMAGE { get; set; }
        public byte[] SIGNATURE_IMAGE { get; set; }
        public byte[] THUMBPRINT { get; set; }
        public byte[] THUMBPRINT1 { get; set; }
        public Nullable<decimal> GRATUITY_RATE { get; set; }
        public Nullable<System.DateTime> EXIT_DATE { get; set; }
        public string EMPLOYEE_CATEGORY { get; set; }
        public bool STMT_OPTION { get; set; }
        public string PIN_INVALID1 { get; set; }
        public string PIN_NOTIFY { get; set; }
        public string APPROVED1 { get; set; }
        public Nullable<System.DateTime> UPLOAD_DATE { get; set; }
        public Nullable<System.DateTime> LAST_CONTRIBUTION_DATE { get; set; }
        public string FLAGNARRATION { get; set; }
        public string FLAGDESCRIPTION { get; set; }
        public string TEAM { get; set; }
        public string COMMENT { get; set; }
        public string PERM_STATE { get; set; }
        public string PERM_CITY { get; set; }
        public bool SAP { get; set; }
        public Nullable<int> CODE { get; set; }
        public string OLDVALUE { get; set; }
        public string NEWVALUE { get; set; }
        public string COLUMN_NAME { get; set; }
        public string ATTRIBUTE { get; set; }
        public Nullable<System.DateTime> UPLOAD_DATE1 { get; set; }
        public string EMPLOYER_NAME_PAL { get; set; }
        public string NOK2_TITLE { get; set; }
        public string NOK2_SURNAME { get; set; }
        public string NOK2_FIRSTNAME { get; set; }
        public string NOK2_OTHERNAME { get; set; }
        public string NOK2_GENDER { get; set; }
        public Nullable<System.DateTime> NOK2_DATE_OF_BIRTH { get; set; }
        public string NOK2_RELATIONSHIP { get; set; }
        public string NOK2_MAIDENNAME { get; set; }
        public string NOK2_ADDRESS { get; set; }
        public string NOK2_CITY { get; set; }
        public string NOK2_STATECODE { get; set; }
        public string NOK2_COUNTRYCODE { get; set; }
        public string NOK2_MOBILEPHONE { get; set; }
        public string NOK2_EMAILADDRESS { get; set; }
        public bool SEND_SMS { get; set; }
        public string RESEND_PIN { get; set; }
        public string SMS_STATUS { get; set; }
        public string FILE_NUM { get; set; }
        public string ACCOUNT_OFFICERS { get; set; }
        public string ER_ADDR { get; set; }
        public string ACCT_FLAG { get; set; }
        public Nullable<System.DateTime> NOK_DOB { get; set; }
        public Nullable<System.DateTime> NOK_DOB2 { get; set; }
        public string EMAIL_ONLY { get; set; }
        public int ID { get; set; }
        public string BRANCHADDRESS_NAME { get; set; }
        public string ADDRESS_CODE { get; set; }
        public string SECTOR { get; set; }
        public string ACCOUNT_OFFICER_PHONE { get; set; }
        public string ACCOUNT_OFFICER_EMAIL { get; set; }
        public string BVN { get; set; }
        public Nullable<decimal> FUND_ID { get; set; }
        public string NIN { get; set; }
    }
}