using System;
using System.Web.Mvc;
using Recapture.DataAccess;
using System.IO;
using System.Linq;
using PalRSA.Core.DataAccess;
using PalRSA.Core.Models;
using Recapture.Common;
using PalRSA.Core;
using System.Web;
using System.Data.Entity;

namespace Recapture.Controllers
{
    // [CustomAuthorize(Roles = "Admin,Approver,Updater")]
   [Authorize()] // Roles ="Customer, Client"
    public class CfiController : Controller
    {

        private readonly CountryDb _countryDb;
        private readonly TitleDb _titleDb;
        private readonly SectorDb _sectorDb;
        private readonly MaritialDb _maritialDb;
        private readonly SexDb _sexDb;
        private readonly StateOfOriginDb _stateOfOriginDb;
      //  private readonly NationalityDb _nationalityDb;
        private readonly LgaDb _lgaDb;
        private readonly StateDb _stateDb;
       // private readonly BranchDb _branchDb;
        private readonly AgentDb _agentDb;
       // private readonly EmployerDb _employerDb;
        private readonly CityDb _cityDb;
        private readonly StateOfPostingDb _stateOfPostingDb;
      //  private readonly EmployerTypeDb _employerTypeDb;
      //  private readonly EmployeeIndustryDb _employeeIndustryDb;
        private readonly EmployerStatusDb _employerStatusDb;
        private readonly RelationshipDb _relationshipDb;
      //  private readonly PensionSchemeDb _pensionSchemeDb;
        private readonly CfiRegisterUserDb _cFIUpdateDb;
        private readonly CfiEmploymentDetailDb _cfiEmploymentDetailDb;
        private readonly CfiSalaryStructureDb _cfiSalaryStructureDb;
        private readonly CfiOtherDb _cfiOtherDb;
        private readonly CfiNextOfKinDb _cfiNextOfKinDb;
        private readonly OtherDb _otherDb;
        private readonly CFIBiometricDb _cfiBiometricDb;
        private readonly ImageAdministrationDb _imageAdministrationDb;
      //  private readonly BioMetricDb _bioMetricDb;
        private readonly PALSiteDBEntities _db;
        private PalManager _manager;
        //private static readonly ILog Log = MyLog.Log;

        public CfiController()
        {
            _countryDb = new CountryDb();
            _titleDb = new TitleDb();
            _sectorDb = new SectorDb();
            _maritialDb = new MaritialDb();
            _sexDb = new SexDb();
            _stateOfOriginDb = new StateOfOriginDb();
            //  _nationalityDb = new NationalityDb();
            _lgaDb = new LgaDb();
            _stateDb = new StateDb();
            //  _branchDb = new BranchDb();
            _agentDb = new AgentDb();
            //  _employerDb = new EmployerDb();
            _cityDb = new CityDb();
            _stateOfPostingDb = new StateOfPostingDb();
            //  _employerTypeDb = new EmployerTypeDb();
            //  _employeeIndustryDb = new EmployeeIndustryDb();
            _employerStatusDb = new EmployerStatusDb();
            _relationshipDb = new RelationshipDb();
            // _pensionSchemeDb = new PensionSchemeDb();    
            _cFIUpdateDb = new CfiRegisterUserDb();
            _cfiEmploymentDetailDb = new CfiEmploymentDetailDb();
            _cfiSalaryStructureDb = new CfiSalaryStructureDb();
            _cfiOtherDb = new CfiOtherDb();
            _cfiBiometricDb = new CFIBiometricDb();
            _cfiNextOfKinDb = new CfiNextOfKinDb();
            _otherDb = new OtherDb();
            _imageAdministrationDb = new ImageAdministrationDb();
            //  _bioMetricDb = new BioMetricDb();
            _db = InternetConnection.CheckForInternetConnection();
            //_db = new BiometricEntities();
            _manager = new PalManager();
        }
        // GET: Registration
        public ActionResult index()
        {
            return RedirectToAction("edit", "Recapture");

            string pin = User.Identity.Name;

            var cfiData = _db.CFIRegisterUsers.FirstOrDefault(d => d.Pin == pin);
            if (cfiData != null)
            {
                return RedirectToAction("edit");
            }

            var emp = _manager.GetEmployee(pin);
                        
            try
            {
                var cfiUpdateViewModel = new CFIUpdateViewModel
                {
                    //TitleList = _titleDb.GetTitleList(),
                    //SectorList = _sectorDb.GetSectorList(),
                    //MaritialStatusList = _maritialDb.GetMartialStatusList(),
                    //SexList = _sexDb.GetSexesList(),

                    //EmployeeStatusList = _employerStatusDb.GetEmployeeStatusList(),
                    //RelationshipList = _relationshipDb.GetRelationshipList(),

                    Surname = emp.Surname,
                    FirstName = emp.FirstName,
                    Pin = emp.Pin
                };
                var countries = _db.Countries.ToList();
                var states = _db.States.OrderBy(x=>x.Name).ToList();

                ViewBag.TitleId = new SelectList(_db.Titles.Where(d=>d.Active==true), "TitleId", "Name");
                ViewBag.KinTitleId = new SelectList(_db.Titles.Where(d=>d.Active==true), "TitleId", "Name");
                ViewBag.SectorId = new SelectList(_db.Sectors, "SectorId", "Name");
                ViewBag.GenderId = new SelectList(_db.Sexes, "SexId", "Name");
                ViewBag.KinGenderId = new SelectList(_db.Sexes, "SexId", "Name");
                ViewBag.MaritalStatusId = new SelectList(_db.MartialStatus.Where(d=>d.Active==true), "MartialStatusId", "Name");
                ViewBag.EmployeeStatusId = new SelectList(_db.EmployeeStatus.Where(d=>d.Active==true), "EmployeeStatusId", "Name");
                ViewBag.KinRelationshipId = new SelectList(_db.Relationships.Where(d=>d.Active==true), "RelationshipId", "Name");

                ViewBag.NationalityId = new SelectList(countries, "CountryId", "Name",160);
                ViewBag.PersonalStateOfOriginId =  new SelectList(states, "StateId", "Name");
                ViewBag.LGAId = new SelectList(_db.LGAreas.Take(10).ToList(), "LGAId", "Name");

                ViewBag.CountryOfResidanceId = new SelectList(countries, "CountryId", "Name", 160);
                ViewBag.StateCode = new SelectList(states, "StateCode", "Name");
                ViewBag.LGACode = new SelectList(_db.LGAreas.Take(10).ToList(), "LGACode", "Name");
                // Employment Record
                ViewBag.EmployerCountryCode = new SelectList(countries, "NumCode", "Name", 566);
                ViewBag.EmployerStateCode = new SelectList(states, "StateCode", "Name");
                ViewBag.LocalGovernmentCode = new SelectList(_db.LGAreas, "LGACode", "Name");
                //  Salary Structure
                ViewBag.HarmonisedSalary = new SelectList(_db.SalaryStructures, "SalaryStructureId", "Name");
                ViewBag.GL2004 = new SelectList(_db.GradeLevels, "GradeLevelId", "Name");
                ViewBag.Step2004 = new SelectList(_db.Steps, "StepId", "Name");

                ViewBag.ConsolidatedSalary2007 = new SelectList(_db.SalaryStructures, "SalaryStructureId", "Name");
                ViewBag.GL2007 = new SelectList(_db.GradeLevels, "GradeLevelId", "Name");
                ViewBag.Step2007 = new SelectList(_db.Steps, "StepId", "Name");

                ViewBag.ConsolidatedSalary2010 = new SelectList(_db.SalaryStructures, "SalaryStructureId", "Name");
                ViewBag.GL2010 = new SelectList(_db.GradeLevels, "GradeLevelId", "Name");
                ViewBag.Step2010 = new SelectList(_db.Steps, "StepId", "Name");
                //
                ViewBag.CurrentSalary = new SelectList(_db.SalaryStructures, "SalaryStructureId", "Name");
                ViewBag.CurrentGL = new SelectList(_db.GradeLevels, "GradeLevelId", "Name");
                ViewBag.CurrentStep = new SelectList(_db.Steps, "StepId", "Name");
                //
                ViewBag.KinCountryId = new SelectList(countries, "CountryId", "Name", 160);
                ViewBag.KinStateId = new SelectList(states, "StateId", "Name");
                ViewBag.KinLGAId1 = new SelectList(_db.LGAreas.Take(10), "LGAId", "Name");


                return View(cfiUpdateViewModel);
            }
            catch (Exception ex)
            {
                AppLog.Log.Error(ex.Message);
                TempData["Error"] = "User Register failed";
                return View();
               // return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public ActionResult Index(CFIUpdateViewModel inputModel)
        {
            CFIUpdateViewModel cfiUpdateViewModel = new CFIUpdateViewModel();
            try
            {
                cfiUpdateViewModel = new CFIUpdateViewModel
                {
                    //  TitleList = _titleDb.GetTitleList(),
                    //  SectorList = _sectorDb.GetSectorList(),
                    //  MaritialStatusList = _maritialDb.GetMartialStatusList(),
                    //  SexList = _sexDb.GetSexesList(),
                    // StateOfOriginsList = _stateOfOriginDb.GetStateOfOriginsList(),
                    // NationalitiesList = _countryDb.GetCountryList(), //  _nationalityDb.GetNationalitiesList(),
                    // LgasList = _lgaDb.GetLgaList(),
                    // StatesList = _stateDb.GetStateList(),
                    //BranchList = _branchDb.GetBranchesList(),
                    //AgentList = _agentDb.GetAgentList(),
                    //EmployerList = _employerDb.GetEmployerList(),
                    // CityList = _cityDb.GetCityList(),
                    // StateOfPostingsList = _stateOfPostingDb.GetStateOfPostingsList(),
                    //EmployerTypesList = _employerTypeDb.GetEmployerTypesList(),
                    //EmployerIndustriesList = _employeeIndustryDb.GetEmployerIndustriesList(),
                    //EmployeeStatusList = _employerStatusDb.GetEmployeeStatusList(),
                    //RelationshipList = _relationshipDb.GetRelationshipList(),
                    // CountryList = _countryDb.GetCountryList(),
                    //PensionSchemesList = _pensionSchemeDb.GetPensionSchemesList()
                };

                var countries = _db.Countries.ToList();
                var states = _db.States.OrderBy(x => x.Name).ToList();

                ViewBag.TitleId = new SelectList(_db.Titles.Where(d => d.Active == true), "TitleId", "Name", inputModel.TitleId);
                ViewBag.KinTitleId = new SelectList(_db.Titles.Where(d => d.Active == true), "TitleId", "Name", inputModel.KinTitleId);
                ViewBag.SectorId = new SelectList(_db.Sectors, "SectorId", "Name", inputModel.SectorId);
                ViewBag.GenderId = new SelectList(_db.Sexes, "SexId", "Name", inputModel.GenderId);
                ViewBag.KinGenderId = new SelectList(_db.Sexes, "SexId", "Name", inputModel.KinGenderId);
                ViewBag.MaritalStatusId = new SelectList(_db.MartialStatus.Where(d => d.Active == true), "MartialStatusId", "Name", inputModel.MaritalStatusId);
                ViewBag.EmployeeStatusId = new SelectList(_db.EmployeeStatus.Where(d => d.Active == true), "EmployeeStatusId", "Name", inputModel.EmployeeStatusId);
                ViewBag.KinRelationshipId = new SelectList(_db.Relationships.Where(d => d.Active == true), "RelationshipId", "Name", inputModel.KinRelationshipId);

                ViewBag.NationalityId = new SelectList(countries, "CountryId", "Name", inputModel.NationalityId);
                ViewBag.PersonalStateOfOriginId = new SelectList(states, "StateId", "Name", inputModel.PersonalStateOfOriginId);
                ViewBag.LGAId = new SelectList(_db.LGAreas.Take(20).ToList(), "LGAId", "Name", inputModel.LGAId);
                ViewBag.CountryOfResidanceId = new SelectList(countries, "CountryId", "Name", inputModel.CountryOfResidanceId);
                ViewBag.StateCode = new SelectList(states, "StateCode", "Name", inputModel.StateCode);
                ViewBag.LGACode = new SelectList(_db.LGAreas.Take(20).ToList(), "LGACode", "Name", inputModel.LGACode);
                // Employment Record
                ViewBag.EmployerCountryCode = new SelectList(countries, "NumCode", "Name", inputModel.EmployerCountryCode);
                ViewBag.EmployerStateCode = new SelectList(_db.States, "StateCode", "Name", inputModel.EmployerStateCode);
                ViewBag.LocalGovernmentCode = new SelectList(_db.LGAreas.Take(20), "LGACode", "Name", inputModel.LocalGovernmentCode);
                //  Salary Structure
                ViewBag.HarmonisedSalary = new SelectList(_db.SalaryStructures, "SalaryStructureId", "Name", inputModel.HarmonisedSalary);
                ViewBag.GL2004 = new SelectList(_db.GradeLevels, "GradeLevelId", "Name", inputModel.GL2004);
                ViewBag.Step2004 = new SelectList(_db.Steps, "StepId", "Name", inputModel.Step2004);

                ViewBag.ConsolidatedSalary2007 = new SelectList(_db.SalaryStructures, "SalaryStructureId", "Name", inputModel.ConsolidatedSalary2007);
                ViewBag.GL2007 = new SelectList(_db.GradeLevels, "GradeLevelId", "Name", inputModel.GL2007);
                ViewBag.Step2007 = new SelectList(_db.Steps, "StepId", "Name", inputModel.Step2007);

                ViewBag.ConsolidatedSalary2010 = new SelectList(_db.SalaryStructures, "SalaryStructureId", "Name", inputModel.ConsolidatedSalary2010);
                ViewBag.GL2010 = new SelectList(_db.GradeLevels, "GradeLevelId", "Name", inputModel.GL2010);
                ViewBag.Step2010 = new SelectList(_db.Steps, "StepId", "Name", inputModel.Step2010);
                //
                ViewBag.CurrentSalary = new SelectList(_db.SalaryStructures, "SalaryStructureId", "Name", inputModel.CurrentSalary);
                ViewBag.CurrentGL = new SelectList(_db.GradeLevels, "GradeLevelId", "Name", inputModel.CurrentGL);
                ViewBag.CurrentStep = new SelectList(_db.Steps, "StepId", "Name", inputModel.CurrentStep);
                //
                ViewBag.KinCountryId = new SelectList(countries, "CountryId", "Name", inputModel.KinCountryId);
                ViewBag.KinStateId = new SelectList(states, "StateId", "Name", inputModel.KinStateId);
                ViewBag.KinLGAId1 = new SelectList(_db.LGAreas.Take(20), "LGAId", "Name", inputModel.KinLGAId1);
            }
            catch (Exception ex)
            {
                AppLog.Log.Error(ex.Message, ex.InnerException);
                TempData["Error"] = "User Register failed";
                // return RedirectToAction("Index");
            }
           //  ViewBag.NationalityId = new SelectList(_db.Countries, "CountryId", "Name", 160); 

            if (ModelState.IsValid)
            {

                using (var dbContextTransaction = _db.Database.BeginTransaction())
                {
                    
                    try
                    {
                        var registerUser = new CFIRegisterUser
                        {
                            Pin = inputModel.Pin,
                            BVN = inputModel.BVN,
                            NIN = inputModel.NIN,
                            IPN = inputModel.IPN,
                            PFAName =inputModel.PFAName,
                            EmployeeStatusId = inputModel.EmployeeStatusId,
                            TitleId = inputModel.TitleId,
                            Surname = inputModel.Surname,
                            FirstName = inputModel.FirstName,
                            MiddleName = inputModel.MiddleName,
                            MaritalStatusId = inputModel.MaritalStatusId,
                            DateOfBirth = inputModel.DateOfBirth,
                            GenderId = inputModel.GenderId,
                            NationalityId = inputModel.NationalityId,
                            PersonalStateOfOriginId = inputModel.PersonalStateOfOriginId,
                            LGAId = inputModel.LGAId,
                            City = inputModel.City,
                            Mobile = inputModel.MobilePhone,
                            Phone = inputModel.HomePhone,
                            Email = inputModel.Email,
                            MotherMaidenName = inputModel.MotherName,
                            PlaceOfBirth = inputModel.PlaceOfBirth,
                            IsNigerian = inputModel.IsNigerian,
                            HouseNo = inputModel.HouseNo,
                            StreetName = inputModel.StreetName,
                            LGACode = inputModel.LGACode,
                            StateCode = inputModel.StateCode,
                            CountryCode = inputModel.CountryCode,
                            CountryOfResidanceId = inputModel.CountryOfResidanceId,
                            ZIP = inputModel.ZIP,
                            POBox = inputModel.POBox,
                            Active = true,
                            DatetimeUpdated = DateTime.Now,
                            DatetimeCreated = DateTime.Now

                        };

                        var userId = _cFIUpdateDb.AddCfiRegisterUsers(registerUser);

                        var cfiEmploymentDetail = new CFIEmploymentDetail
                        {
                            UserId = userId,
                            SectorId = inputModel.SectorId,
                            IsEmployerIPPIS = inputModel.IsEmployerIPPIS,
                            EmployerName = inputModel.EmployerName,
                            IsNigerian = inputModel.IsNigerianEmployer,
                            Building = inputModel.Building,
                            Street = inputModel.EmployerStreetName,
                            City = inputModel.EmployerCity,
                            LocalGovernmentCode = inputModel.LocalGovernmentCode,
                            StateCode = inputModel.EmployerStateCode,
                            CountryCode = inputModel.EmployerCountryCode,
                            ZIP = inputModel.EmployerZIP,
                            POBox = inputModel.EmployerPOBox,
                            PhoneNo = inputModel.EmployerPhoneNo,
                            MobileNo = inputModel.EmployerMobileNo,
                            EmployeeId = inputModel.EmployeeId,
                            ServiceIdNo = inputModel.ServiceIdNo,
                            Designation = inputModel.Designation,
                            DateOfFirstAppointment = inputModel.DateOfFirstAppointment,
                            DateOfCurrentAppointment = inputModel.DateOfCurrentAppointment,
                            DateOfEmployment = inputModel.DateOfEmployment,
                            Active = true,
                            DatetimeUpdated = DateTime.Now,
                            DatetimeCreated = DateTime.Now
                        };
                        _cfiEmploymentDetailDb.AddCfiEmploymentDetails(cfiEmploymentDetail);


                        var cfiSalaryStructure = new CFISalaryStructure
                        {
                            UserId = userId,
                            HarmonisedSalary = inputModel.HarmonisedSalary,
                            ConsolidatedSalary2007 = inputModel.ConsolidatedSalary2007,
                            ConsolidatedSalary2010 = inputModel.ConsolidatedSalary2010,
                            GL2004 = inputModel.GL2004,
                            Step2004 = inputModel.Step2004,
                            GL2007 = inputModel.GL2007,
                            Step2007 = inputModel.Step2007,
                            GL2010 = inputModel.GL2010,
                            Step2010 = inputModel.Step2010,
                            CurrentSalary = inputModel.CurrentSalary,
                            CurrentGL = inputModel.CurrentGL,
                            CurrentStep = inputModel.CurrentStep,
                            Active = true,
                            DatetimeUpdated = DateTime.Now,
                            DatetimeCreated = DateTime.Now
                        };
                        _cfiSalaryStructureDb.AddCfiSalaryStructures(cfiSalaryStructure);


                        var cfiNextOfKin = new CFINextOfKin
                        {
                            UserId = userId,
                            Surname = inputModel.KinSurname,
                            KinGenderId = inputModel.KinGenderId,
                            KinTitleId = inputModel.KinTitleId,
                            FirstName = inputModel.KinFirstName,
                            MiddleName = inputModel.KinMiddleName,
                            RelationshipId = inputModel.KinRelationshipId,
                            IsNigerian = inputModel.IsNigerianKin,
                            HouseNo = inputModel.KinHouseNo,
                            Street = inputModel.KinStreetName,
                            City = inputModel.KinCity,
                            LGAId = inputModel.KinLGAId1,
                            StateId = inputModel.KinStateId,
                            CountryId = inputModel.KinCountryId,
                            ZIP = inputModel.KinZip,
                            POBox = inputModel.KinPOBox,
                            Email = inputModel.KinEmail,
                            PhoneNo = inputModel.KinPhoneNo,
                            MobileNo = inputModel.KinMobile,
                            Active = true,
                            DatetimeUpdated = DateTime.Now,
                            DatetimeCreated = DateTime.Now
                        };
                        _cfiNextOfKinDb.AddCfiNextOfKins(cfiNextOfKin);

                        var other = new CFIOther
                        {
                            UserId = userId,
                            ContributorDate = inputModel.ContributorDate,
                            IsFingerprintChallenge = inputModel.IsFingerprintChallenge,
                            ChallengeType = inputModel.ChallengeType,
                            Designation = inputModel.DesignationPFA,
                            DatetimeUpdated = DateTime.Now,
                            Active = true,
                            DatetimeCreated = DateTime.Now
                        };
                        _cfiOtherDb.AddCfiOthers(other);

                        var passportFile = Request.Files["passport"];
                        var signatureFile = Request.Files["signature"];
                        var pfaSignatureFile = Request.Files["pfaSignature"];

                        var passportFileName = string.Empty;
                        var signatureFileName = string.Empty;
                        var pfaSignatureFileName = string.Empty;

                        if (passportFile != null || signatureFile != null || pfaSignatureFile != null)
                        {
                            if (passportFile != null)
                            {
                                var storePath = _imageAdministrationDb.GetImageAdministrationPassportStorePath();
                                if (!Directory.Exists(storePath))
                                {
                                    Directory.CreateDirectory(storePath);
                                }
                                if (passportFile.FileName.Trim() != string.Empty)
                                {
                                    passportFileName = userId + "_CFIPassport" + Path.GetExtension(passportFile.FileName);
                                    var serverSavePath = Path.Combine(storePath, passportFileName);
                                    passportFile.SaveAs(serverSavePath);
                                }


                            }
                            if (signatureFile != null)
                            {
                                var storePath = _imageAdministrationDb.GetImageAdministrationSignaturePath();
                                if (!Directory.Exists(storePath))
                                {
                                    Directory.CreateDirectory(storePath);
                                }
                                if (signatureFile.FileName.Trim() != string.Empty)
                                {
                                    signatureFileName = userId + "_CFIContributor_Signature" + Path.GetExtension(signatureFile.FileName);

                                    var serverSavePath = Path.Combine(storePath, signatureFileName);
                                    signatureFile.SaveAs(serverSavePath);
                                }
                            }
                            if (pfaSignatureFile != null)
                            {
                                var storePath = _imageAdministrationDb.GetImageAdministrationSignaturePath();
                                if (!Directory.Exists(storePath))
                                {
                                    Directory.CreateDirectory(storePath);
                                }
                                if (pfaSignatureFile.FileName.Trim() != string.Empty)
                                {
                                    pfaSignatureFileName = userId + "_CFIPFA_Signature" + Path.GetExtension(pfaSignatureFile.FileName);

                                    var serverSavePath = Path.Combine(storePath, pfaSignatureFileName);
                                    pfaSignatureFile.SaveAs(serverSavePath);
                                }
                            }

                            var biometric = new CFIBiometric
                            {
                                UserId = userId,
                                Passport = passportFileName,
                                ContributorSignature = signatureFileName,
                                PFASignature = pfaSignatureFileName,
                                DatetimeUpdated = DateTime.Now,
                                Active = true,
                                DatetimeCreated = DateTime.Now
                            };
                            _cfiBiometricDb.AddCfiBiometric(biometric);
                        }
                        
                        // _db.SaveChanges();
                        dbContextTransaction.Commit();
                        TempData["Success"] = "User Register successfully";

                        return RedirectToAction("SupportDoc","cfi");
                    }
                    catch (Exception ex)
                    {
                        AppLog.Log.Error(ex.Message, ex.InnerException);
                        dbContextTransaction.Rollback();
                        TempData["Error"] = "User Register failed";
                        return View(cfiUpdateViewModel);
                    }
                }
            }

            ModelState.AddModelError("Error", "Data Validation Failed! Please check your entry");
            return View(cfiUpdateViewModel);
        }

        [HttpGet]
        public ActionResult Edit()
        {
            CFIUpdateViewModel inputModel= new CFIUpdateViewModel();
            CFIUpdateViewModel cfiUpdateViewModel;
           //  _db.Database.Log = Console.Write;

            var data = _db.CFIRegisterUsers.Include("CFIBiometrics") // .Include("CFISupportDocuments")
                .Include("CFIEmploymentDetails").Include("CFINextOfKins")
                .Include("CFISalaryStructures").Where(d => d.Pin == User.Identity.Name).FirstOrDefault();

            var er = data.CFIEmploymentDetails.FirstOrDefault();
            var sal = data.CFISalaryStructures.FirstOrDefault();
            var kin = data.CFINextOfKins.FirstOrDefault();

           // var docs = _db.CFISupportDocuments.FirstOrDefault(d => d.Pin == data.Pin);
            // CFIBiometric,CFISupportDocument,CFIEmploymentDetail,CFINextOfKin,CFISalaryStructure
            try
            {
                cfiUpdateViewModel = new CFIUpdateViewModel  // 
                {
                    UserId=data.UserId,EmploymentDetailId=er.EmploymentDetailId, NextOfKinId=kin.NextOfKinId,SalaryId=sal.SalaryId,
                    BVN = data.BVN, Pin= data.Pin, PFAName=data.PFAName, EmployeeStatusId=Convert.ToInt32( data.EmployeeStatusId),
                    TitleId = data.TitleId, Surname=data.Surname, FirstName=data.FirstName, MiddleName=data.MiddleName,MotherName=data.MotherMaidenName,
                    GenderId=data.GenderId,MaritalStatusId = data.MaritalStatusId, NIN=data.NIN,IPN=data.IPN, DateOfBirth=data.DateOfBirth,
                    NationalityId =data.NationalityId,PlaceOfBirth=data.PlaceOfBirth,PersonalStateOfOriginId=data.PersonalStateOfOriginId,
                    LGAId = data.LGAId, // Address
                    IsNigerian=data.IsNigerian,HouseNo=data.HouseNo,StreetName=data.StreetName, City=data.City,CountryOfResidanceId=data.CountryOfResidanceId,
                    StateCode=data.StateCode,LGACode=data.LGACode,ZIP=data.ZIP,POBox=data.POBox,Email=data.Email,MobilePhone=data.Mobile,
                    HomePhone=data.Phone,

                    SectorId=er.SectorId, IsEmployerIPPIS= er.IsEmployerIPPIS, EmployerName=er.EmployerName, IsNigerianEmployer=er.IsNigerian,
                    Building=er.Building,EmployerStreetName=er.Street,EmployerCity=er.City,EmployerCountryCode=er.CountryCode, 
                    EmployerStateCode=er.StateCode, LocalGovernmentCode = er.LocalGovernmentCode, EmployerZIP=er.ZIP,EmployerPOBox=er.POBox,
                    EmployerPhoneNo=er.PhoneNo, EmployerMobileNo=er.MobileNo, EmployeeId=er.EmployeeId,ServiceIdNo=er.ServiceIdNo,
                    Designation=er.Designation,DateOfFirstAppointment=er.DateOfFirstAppointment,DateOfCurrentAppointment=er.DateOfCurrentAppointment,
                    DateOfEmployment=er.DateOfEmployment, // Salary Structure
                    HarmonisedSalary =sal.HarmonisedSalary, GL2004=sal.GL2004,Step2004=sal.Step2004,GL2007=sal.GL2007,Step2007=sal.Step2007,
                    ConsolidatedSalary2007=sal.ConsolidatedSalary2007, ConsolidatedSalary2010=sal.ConsolidatedSalary2010, GL2010=sal.GL2010,
                    Step2010=sal.Step2010, CurrentSalary=sal.CurrentSalary,CurrentGL=sal.CurrentGL,CurrentStep=sal.CurrentStep,
                    // NOK
                    KinSurname=kin.Surname, KinFirstName=kin.FirstName, KinMiddleName=kin.MiddleName,KinGenderId=kin.KinGenderId,
                    KinTitleId=kin.KinTitleId, KinRelationshipId=kin.RelationshipId, IsNigerianKin=kin.IsNigerian,KinHouseNo=kin.HouseNo,
                    KinStreetName=kin.Street, KinCity=kin.City,KinCountryId=kin.CountryId, KinStateId=kin.StateId,KinLGAId1=kin.LGAId,
                    KinZip=kin.ZIP,KinPOBox=kin.POBox,KinEmail=kin.Email,KinMobile=kin.MobileNo, KinPhoneNo=kin.PhoneNo, 
                    //
                     


                };

                inputModel = cfiUpdateViewModel;

                var countries = _db.Countries.ToList();
                var states = _db.States.OrderBy(x => x.Name).ToList();

                ViewBag.TitleId = new SelectList(_db.Titles.Where(d => d.Active == true), "TitleId", "Name", inputModel.TitleId);
                ViewBag.KinTitleId = new SelectList(_db.Titles.Where(d => d.Active == true), "TitleId", "Name", inputModel.KinTitleId);
                ViewBag.SectorId = new SelectList(_db.Sectors, "SectorId", "Name", inputModel.SectorId);
                ViewBag.GenderId = new SelectList(_db.Sexes, "SexId", "Name", inputModel.GenderId);
                ViewBag.KinGenderId = new SelectList(_db.Sexes, "SexId", "Name", inputModel.KinGenderId);
                ViewBag.MaritalStatusId = new SelectList(_db.MartialStatus.Where(d => d.Active == true), "MartialStatusId", "Name", inputModel.MaritalStatusId);
                ViewBag.EmployeeStatusId = new SelectList(_db.EmployeeStatus.Where(d => d.Active == true), "EmployeeStatusId", "Name", inputModel.EmployeeStatusId);
                ViewBag.KinRelationshipId = new SelectList(_db.Relationships.Where(d => d.Active == true), "RelationshipId", "Name", inputModel.KinRelationshipId);

                ViewBag.NationalityId = new SelectList(countries, "CountryId", "Name", inputModel.NationalityId);
                ViewBag.PersonalStateOfOriginId = new SelectList(states, "StateId", "Name", inputModel.PersonalStateOfOriginId);
                ViewBag.LGAId = new SelectList(_db.LGAreas.ToList(), "LGAId", "Name", inputModel.LGAId);
                ViewBag.CountryOfResidanceId = new SelectList(countries, "CountryId", "Name", inputModel.CountryOfResidanceId);
                ViewBag.StateCode = new SelectList(states, "StateCode", "Name", inputModel.StateCode);
                ViewBag.LGACode = new SelectList(_db.LGAreas.ToList(), "LGACode", "Name", inputModel.LGACode);
                // Employment Record
                ViewBag.EmployerCountryCode = new SelectList(countries, "NumCode", "Name", inputModel.EmployerCountryCode);
                ViewBag.EmployerStateCode = new SelectList(_db.States, "StateCode", "Name", inputModel.EmployerStateCode);
                ViewBag.LocalGovernmentCode = new SelectList(_db.LGAreas, "LGACode", "Name", inputModel.LocalGovernmentCode);
                //  Salary Structure
                ViewBag.HarmonisedSalary = new SelectList(_db.SalaryStructures, "SalaryStructureId", "Name", inputModel.HarmonisedSalary);
                ViewBag.GL2004 = new SelectList(_db.GradeLevels, "GradeLevelId", "Name", inputModel.GL2004);
                ViewBag.Step2004 = new SelectList(_db.Steps, "StepId", "Name", inputModel.Step2004);

                ViewBag.ConsolidatedSalary2007 = new SelectList(_db.SalaryStructures, "SalaryStructureId", "Name", inputModel.ConsolidatedSalary2007);
                ViewBag.GL2007 = new SelectList(_db.GradeLevels, "GradeLevelId", "Name", inputModel.GL2007);
                ViewBag.Step2007 = new SelectList(_db.Steps, "StepId", "Name", inputModel.Step2007);

                ViewBag.ConsolidatedSalary2010 = new SelectList(_db.SalaryStructures, "SalaryStructureId", "Name", inputModel.ConsolidatedSalary2010);
                ViewBag.GL2010 = new SelectList(_db.GradeLevels, "GradeLevelId", "Name", inputModel.GL2010);
                ViewBag.Step2010 = new SelectList(_db.Steps, "StepId", "Name", inputModel.Step2010);
                //
                ViewBag.CurrentSalary = new SelectList(_db.SalaryStructures, "SalaryStructureId", "Name", inputModel.CurrentSalary);
                ViewBag.CurrentGL = new SelectList(_db.GradeLevels, "GradeLevelId", "Name", inputModel.CurrentGL);
                ViewBag.CurrentStep = new SelectList(_db.Steps, "StepId", "Name", inputModel.CurrentStep);
                //
                ViewBag.KinCountryId = new SelectList(countries, "CountryId", "Name", inputModel.KinCountryId);
                ViewBag.KinStateId = new SelectList(states, "StateId", "Name", inputModel.KinStateId);
                ViewBag.KinLGAId1 = new SelectList(_db.LGAreas, "LGAId", "Name", inputModel.KinLGAId1);
            }
            catch (Exception ex)
            {
                AppLog.Log.Error(ex.Message, ex.InnerException);
                TempData["Error"] = "User Register failed";
                // return RedirectToAction("Index");
            }
            return View(inputModel);
        }

        [HttpPost]
        public ActionResult Edit(CFIUpdateViewModel inputModel)
        {
            
            CFIUpdateViewModel cfiUpdateViewModel;
            //  _db.Database.Log = Console.Write;

            var data = _db.CFIRegisterUsers.Include("CFIBiometrics") // .Include("CFISupportDocuments")
                .Include("CFIEmploymentDetails").Include("CFINextOfKins")
                .Include("CFISalaryStructures").Where(d => d.Pin == User.Identity.Name).FirstOrDefault();

            var er = data.CFIEmploymentDetails.FirstOrDefault();
            var sal = data.CFISalaryStructures.FirstOrDefault();
            var kin = data.CFINextOfKins.FirstOrDefault();

            // var docs = _db.CFISupportDocuments.FirstOrDefault(d => d.Pin == data.Pin);
            // CFIBiometric,CFISupportDocument,CFIEmploymentDetail,CFINextOfKin,CFISalaryStructure

            if (ModelState.IsValid)
            {
                var cfiReg = _db.CFIRegisterUsers.FirstOrDefault(d => d.UserId == data.UserId);
                if (cfiReg != null)
                {


                    cfiReg.DatetimeUpdated = DateTime.Now;
                    cfiReg.ModifiedBy = User.Identity.Name;
                    cfiReg.Pin = inputModel.Pin;
                    cfiReg.BVN = inputModel.BVN;
                    cfiReg.NIN = inputModel.NIN;
                    cfiReg.IPN = inputModel.IPN;
                    cfiReg.PFAName = inputModel.PFAName;
                    cfiReg.EmployeeStatusId = inputModel.EmployeeStatusId;
                    cfiReg.TitleId = inputModel.TitleId;
                    cfiReg.Surname = inputModel.Surname;
                    cfiReg.FirstName = inputModel.FirstName;
                    cfiReg.MiddleName = inputModel.MiddleName;
                    cfiReg.MaritalStatusId = inputModel.MaritalStatusId;
                    cfiReg.DateOfBirth = inputModel.DateOfBirth;
                    cfiReg.GenderId = inputModel.GenderId;
                    cfiReg.NationalityId = inputModel.NationalityId;
                    cfiReg.PersonalStateOfOriginId = inputModel.PersonalStateOfOriginId;
                    cfiReg.LGAId = inputModel.LGAId;
                    cfiReg.City = inputModel.City;
                    cfiReg.Mobile = inputModel.MobilePhone;
                    cfiReg.Phone = inputModel.HomePhone;
                    cfiReg.Email = inputModel.Email;
                    cfiReg.MotherMaidenName = inputModel.MotherName;
                    cfiReg.PlaceOfBirth = inputModel.PlaceOfBirth;
                    cfiReg.IsNigerian = inputModel.IsNigerian;
                    cfiReg.HouseNo = inputModel.HouseNo;
                    cfiReg.StreetName = inputModel.StreetName;
                    cfiReg.LGACode = inputModel.LGACode;
                    cfiReg.StateCode = inputModel.StateCode;
                    cfiReg.CountryCode = inputModel.CountryCode;
                    cfiReg.CountryOfResidanceId = inputModel.CountryOfResidanceId;
                    cfiReg.ZIP = inputModel.ZIP;
                    cfiReg.POBox = inputModel.POBox;
                    cfiReg.Active = true;
                    cfiReg.DatetimeUpdated = DateTime.Now;
                    cfiReg.DatetimeCreated = DateTime.Now;

                    _db.Entry(cfiReg).State = EntityState.Modified;
                    _db.SaveChanges();

                }
            }

            try
            {
                cfiUpdateViewModel = new CFIUpdateViewModel
                {
                    BVN = data.BVN,
                    Pin = data.Pin,
                    PFAName = data.PFAName,
                    EmployeeStatusId = Convert.ToInt32(data.EmployeeStatusId),
                    TitleId = data.TitleId,
                    Surname = data.Surname,
                    FirstName = data.FirstName,
                    MiddleName = data.MiddleName,
                    MotherName = data.MotherMaidenName,
                    GenderId = data.GenderId,
                    MaritalStatusId = data.MaritalStatusId,
                    NIN = data.NIN,
                    IPN = data.IPN,
                    DateOfBirth = data.DateOfBirth,
                    NationalityId = data.NationalityId,
                    PlaceOfBirth = data.PlaceOfBirth,
                    PersonalStateOfOriginId = data.PersonalStateOfOriginId,
                    LGAId = data.LGAId, // Address
                    IsNigerian = data.IsNigerian,
                    HouseNo = data.HouseNo,
                    StreetName = data.StreetName,
                    City = data.City,
                    CountryOfResidanceId = data.CountryOfResidanceId,
                    StateCode = data.StateCode,
                    LGACode = data.LGACode,
                    ZIP = data.ZIP,
                    POBox = data.POBox,
                    Email = data.Email,
                    MobilePhone = data.Mobile,
                    HomePhone = data.Phone,

                    SectorId = er.SectorId,
                    IsEmployerIPPIS = er.IsEmployerIPPIS,
                    EmployerName = er.EmployerName,
                    IsNigerianEmployer = er.IsNigerian,
                    Building = er.Building,
                    EmployerStreetName = er.Street,
                    EmployerCity = er.City,
                    EmployerCountryCode = er.CountryCode,
                    EmployerStateCode = er.StateCode,
                    LocalGovernmentCode = er.LocalGovernmentCode,
                    EmployerZIP = er.ZIP,
                    EmployerPOBox = er.POBox,
                    EmployerPhoneNo = er.PhoneNo,
                    EmployerMobileNo = er.MobileNo,
                    EmployeeId = er.EmployeeId,
                    ServiceIdNo = er.ServiceIdNo,
                    Designation = er.Designation,
                    DateOfFirstAppointment = er.DateOfFirstAppointment,
                    DateOfCurrentAppointment = er.DateOfCurrentAppointment,
                    DateOfEmployment = er.DateOfEmployment, // Salary Structure
                    HarmonisedSalary = sal.HarmonisedSalary,
                    GL2004 = sal.GL2004,
                    Step2004 = sal.Step2004,
                    GL2007 = sal.GL2007,
                    Step2007 = sal.Step2007,
                    ConsolidatedSalary2007 = sal.ConsolidatedSalary2007,
                    ConsolidatedSalary2010 = sal.ConsolidatedSalary2010,
                    GL2010 = sal.GL2010,
                    Step2010 = sal.Step2010,
                    CurrentSalary = sal.CurrentSalary,
                    CurrentGL = sal.CurrentGL,
                    CurrentStep = sal.CurrentStep,
                    // NOK
                    KinSurname = kin.Surname,
                    KinFirstName = kin.FirstName,
                    KinMiddleName = kin.MiddleName,
                    KinGenderId = kin.KinGenderId,
                    KinTitleId = kin.KinTitleId,
                    KinRelationshipId = kin.RelationshipId,
                    IsNigerianKin = kin.IsNigerian,
                    KinHouseNo = kin.HouseNo,
                    KinStreetName = kin.Street,
                    KinCity = kin.City,
                    KinCountryId = kin.CountryId,
                    KinStateId = kin.StateId,
                    KinLGAId1 = kin.LGAId,
                    KinZip = kin.ZIP,
                    KinPOBox = kin.POBox,
                    KinEmail = kin.Email,
                    KinMobile = kin.MobileNo,
                    KinPhoneNo = kin.PhoneNo,
                    //



                };

               // inputModel = cfiUpdateViewModel;

               
            }
            catch (Exception ex)
            {
                AppLog.Log.Error(ex.Message, ex.InnerException);
                TempData["Error"] = "User Register failed";
                // return RedirectToAction("Index");
            }
            var countries = _db.Countries.ToList();
            var states = _db.States.OrderBy(x => x.Name).ToList();

            ViewBag.TitleId = new SelectList(_db.Titles.Where(d => d.Active == true), "TitleId", "Name", inputModel.TitleId);
            ViewBag.KinTitleId = new SelectList(_db.Titles.Where(d => d.Active == true), "TitleId", "Name", inputModel.KinTitleId);
            ViewBag.SectorId = new SelectList(_db.Sectors, "SectorId", "Name", inputModel.SectorId);
            ViewBag.GenderId = new SelectList(_db.Sexes, "SexId", "Name", inputModel.GenderId);
            ViewBag.KinGenderId = new SelectList(_db.Sexes, "SexId", "Name", inputModel.KinGenderId);
            ViewBag.MaritalStatusId = new SelectList(_db.MartialStatus.Where(d => d.Active == true), "MartialStatusId", "Name", inputModel.MaritalStatusId);
            ViewBag.EmployeeStatusId = new SelectList(_db.EmployeeStatus.Where(d => d.Active == true), "EmployeeStatusId", "Name", inputModel.EmployeeStatusId);
            ViewBag.KinRelationshipId = new SelectList(_db.Relationships.Where(d => d.Active == true), "RelationshipId", "Name", inputModel.KinRelationshipId);

            ViewBag.NationalityId = new SelectList(countries, "CountryId", "Name", inputModel.NationalityId);
            ViewBag.PersonalStateOfOriginId = new SelectList(states, "StateId", "Name", inputModel.PersonalStateOfOriginId);
            ViewBag.LGAId = new SelectList(_db.LGAreas.Take(10).ToList(), "LGAId", "Name", inputModel.LGAId);
            ViewBag.CountryOfResidanceId = new SelectList(countries, "CountryId", "Name", inputModel.CountryOfResidanceId);
            ViewBag.StateCode = new SelectList(states, "StateCode", "Name", inputModel.StateCode);
            ViewBag.LGACode = new SelectList(_db.LGAreas.ToList(), "LGACode", "Name", inputModel.LGACode);
            // Employment Record
            ViewBag.EmployerCountryCode = new SelectList(countries, "NumCode", "Name", inputModel.EmployerCountryCode);
            ViewBag.EmployerStateCode = new SelectList(_db.States, "StateCode", "Name", inputModel.EmployerStateCode);
            ViewBag.LocalGovernmentCode = new SelectList(_db.LGAreas, "LGACode", "Name", inputModel.LocalGovernmentCode);
            //  Salary Structure
            ViewBag.HarmonisedSalary = new SelectList(_db.SalaryStructures, "SalaryStructureId", "Name", inputModel.HarmonisedSalary);
            ViewBag.GL2004 = new SelectList(_db.GradeLevels, "GradeLevelId", "Name", inputModel.GL2004);
            ViewBag.Step2004 = new SelectList(_db.Steps, "StepId", "Name", inputModel.Step2004);

            ViewBag.ConsolidatedSalary2007 = new SelectList(_db.SalaryStructures, "SalaryStructureId", "Name", inputModel.ConsolidatedSalary2007);
            ViewBag.GL2007 = new SelectList(_db.GradeLevels, "GradeLevelId", "Name", inputModel.GL2007);
            ViewBag.Step2007 = new SelectList(_db.Steps, "StepId", "Name", inputModel.Step2007);

            ViewBag.ConsolidatedSalary2010 = new SelectList(_db.SalaryStructures, "SalaryStructureId", "Name", inputModel.ConsolidatedSalary2010);
            ViewBag.GL2010 = new SelectList(_db.GradeLevels, "GradeLevelId", "Name", inputModel.GL2010);
            ViewBag.Step2010 = new SelectList(_db.Steps, "StepId", "Name", inputModel.Step2010);
            //
            ViewBag.CurrentSalary = new SelectList(_db.SalaryStructures, "SalaryStructureId", "Name", inputModel.CurrentSalary);
            ViewBag.CurrentGL = new SelectList(_db.GradeLevels, "GradeLevelId", "Name", inputModel.CurrentGL);
            ViewBag.CurrentStep = new SelectList(_db.Steps, "StepId", "Name", inputModel.CurrentStep);
            //
            ViewBag.KinCountryId = new SelectList(countries, "CountryId", "Name", inputModel.KinCountryId);
            ViewBag.KinStateId = new SelectList(states, "StateId", "Name", inputModel.KinStateId);
            ViewBag.KinLGAId1 = new SelectList(_db.LGAreas, "LGAId", "Name", inputModel.KinLGAId1);
            return View(inputModel);
        }

        [HttpGet]
        public ActionResult SupportDoc()
        {
            ViewBag.DocumentId = new SelectList(_db.CFIDocuments.Where(d => d.Active == true), "DocumentId", "Name");
            ViewBag.Pin = User.Identity.Name;
            return View();
        }
        [HttpPost]
        public ActionResult SupportDoc(CFISupportDocument doc, string submit)
        {
            ViewBag.Pin = User.Identity.Name;
            ViewBag.DocumentId = new SelectList(_db.CFIDocuments.Where(d => d.Active == true), "DocumentId", "Name", doc.DocumentId);
            doc.CFIDocument = _db.CFIDocuments.Find(doc.DocumentId);
            //
          //  var documentName = Request.Form["BenefitDocument"];
            switch (submit)
            {
                case "Upload":
                    {
                        //
                        String[] allowedExtensions = { ".gif", ".png", ".jpeg", ".jpg", ".pdf" };

                        bool fileOK = false;
                        string fileName = "";
                        try
                        {//

                            foreach (string file in Request.Files)
                            {
                                //
                                //create object that provide access to uploaded files

                                HttpPostedFileBase hpf = Request.Files[file] as HttpPostedFileBase;
                                if (hpf.ContentLength == 0)
                                {
                                    continue;
                                }

                                //Test file extension
                                fileOK = allowedExtensions.Contains(Path.GetExtension(hpf.FileName.ToLower()));

                                string path = AppDomain.CurrentDomain.BaseDirectory + "uploads\\CFIDocuments";


                                //Create Directory if not exist
                                if (!Directory.Exists(path))
                                {
                                    Directory.CreateDirectory(path);
                                }

                                if (fileOK)
                                {
                                    try
                                    {
                                        fileName = Path.GetFileName(doc.Pin + "_" + doc.CFIDocument.Name
                                                                        + "_" + DateTime.Now.Date.ToString("yyyyMMdd")) + Path.GetExtension(hpf.FileName);

                                        string fullFileName = Path.Combine(path, fileName); //
                                                                                            
                                        hpf.SaveAs(fullFileName);

                                        doc.DocumentName = fileName;

                                        doc.DatetimeCreated = DateTime.Now;
                                        doc.DatetimeUpdated = DateTime.Now;

                                        //if (ModelState.IsValid) //&& fileOK
                                        // {
                                        _db.CFISupportDocuments.Add(doc);
                                        _db.SaveChanges();
                                        //GetLists();

                                        TempData["success"] = "Upload successful. You can upload more document";

                                    }
                                    catch (Exception ex)
                                    {
                                        TempData["error"] = "Upload error: " + ex.Message;
                                    }
                                    //return RedirectToAction("upload");
                                }
                                else
                                {
                                    fileOK = false;
                                    TempData["error"] = "Oops!!! Invalid file found";
                                }

                            }
                        }
                        catch (Exception ex)
                        {
                            TempData["error"] = "Upload failed: " + ex.Message;
                        }


                        return View(doc);
                    }
                case "Complete":
                    {
                        return RedirectToAction("Home", "Customer");
                    }
                 

                default:
                    {

                        return View(doc);
                    }
            }
            //
            return View(doc);
        }

        [HttpGet]
        [AllowAnonymous]
        public string GetLGA()
        {
            int stateid = Convert.ToInt32(Request.Params["StateId"]);
            var selectedState = _db.States.FirstOrDefault(d => d.StateId == stateid);
            string l = "<option value=\"\"> </option>";
            var lgas = _db.LGAreas.Where(x => x.StateCode == selectedState.StateCode).OrderBy(d => d.Name).ToList();


            foreach (var item in lgas)
            {
                l += "<option value='" + item.LGAId + "'>" + item.Name + "</option>";
            }
          //  System.Threading.Thread.Sleep(200);
            return l;
        }

        [HttpGet]
        [AllowAnonymous]
        public string GetLGACode()
        {
            string stateid = Convert.ToString(Request.Params["StateCode"]);
           // var selectedState = _db.States.FirstOrDefault(d => d.StateCode == stateid);
            string l = "<option value=\"\"> </option>";
            var lgas = _db.LGAreas.Where(x => x.StateCode == stateid).OrderBy(d => d.Name).ToList();


            foreach (var item in lgas)
            {
                l += "<option value='" + item.LGACode + "'>" + item.Name + "</option>";
            }
           //  System.Threading.Thread.Sleep(200);
            return l;
        }
    }
}