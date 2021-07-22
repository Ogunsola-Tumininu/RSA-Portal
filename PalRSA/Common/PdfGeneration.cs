using PalRSA.Core;
using System;
using System.IO;
using System.Linq;
using System.Web;
using PalRSA.Core.DataAccess;

namespace Recapture.Common
{
    public class PdfGeneration
    {
        private readonly CountryDb _countryDb;
        private readonly TitleDb _titleDb;
        private readonly MaritialDb _maritialDb;
        private readonly SexDb _sexDb;
        private readonly StateOfOriginDb _stateOfOriginDb;
        private readonly NationalityDb _nationalityDb;
        private readonly LgaDb _lgaDb;
        private readonly StateDb _stateDb;
        private readonly BranchDb _branchDb;
        private readonly AgentDb _agentDb;
        private readonly EmployerDb _employerDb;
        private readonly CityDb _cityDb;
        private readonly StateOfPostingDb _stateOfPostingDb;
        private readonly EmployerTypeDb _employerTypeDb;
        private readonly EmployeeIndustryDb _employeeIndustryDb;
        private readonly EmployerStatusDb _employerStatusDb;
        private readonly RelationshipDb _relationshipDb;
        private readonly PensionSchemeDb _pensionSchemeDb;
        private readonly RegistrationDb _registrationDb;
        private readonly EmployeeDetailDb _employeeDetailDb;
        private readonly NextOfKinDb _nextOfKinDb;
        private readonly OtherDb _otherDb;
        private readonly ImageAdministrationDb _imageAdministrationDb;
        private readonly BioMetricDb _bioMetricDb;
        private readonly BiometricEntities _biometricEntities;
        private readonly RegisteredUser _registeredUser;
        public PdfGeneration()
        {
            _countryDb = new CountryDb();
            _titleDb = new TitleDb();
            _maritialDb = new MaritialDb();
            _sexDb = new SexDb();
            _stateOfOriginDb = new StateOfOriginDb();
            _nationalityDb = new NationalityDb();
            _lgaDb = new LgaDb();
            _stateDb = new StateDb();
            _branchDb = new BranchDb();
            _agentDb = new AgentDb();
            _employerDb = new EmployerDb();
            _cityDb = new CityDb();
            _stateOfPostingDb = new StateOfPostingDb();
            _employerTypeDb = new EmployerTypeDb();
            _employeeIndustryDb = new EmployeeIndustryDb();
            _employerStatusDb = new EmployerStatusDb();
            _relationshipDb = new RelationshipDb();
            _pensionSchemeDb = new PensionSchemeDb();
        }

        public string GeneratePdf(RegistrationListViewModel inputModel)
        {
            try
            {
                inputModel.TitleList = _titleDb.GetTitleList();
                inputModel.MaritialStatusList = _maritialDb.GetMartialStatusList();
                inputModel.SexList = _sexDb.GetSexesList();
                inputModel.StateOfOriginsList = _stateOfOriginDb.GetStateOfOriginsList();
                inputModel.NationalitiesList = _nationalityDb.GetNationalitiesList();
                inputModel.LgasList = _lgaDb.GetLgaList();
                inputModel.StatesList = _stateDb.GetStateList();
                inputModel.BranchList = _branchDb.GetBranchesList();
                inputModel.AgentList = _agentDb.GetAgentList();
                inputModel.EmployerList = _employerDb.GetEmployerList();
                inputModel.CityList = _cityDb.GetCityList();
                inputModel.StateOfPostingsList = _stateOfPostingDb.GetStateOfPostingsList();
                inputModel.EmployerTypesList = _employerTypeDb.GetEmployerTypesList();
                inputModel.EmployerIndustriesList = _employeeIndustryDb.GetEmployerIndustriesList();
                inputModel.EmployeeStatusList = _employerStatusDb.GetEmployeeStatusList();
                inputModel.RelationshipList = _relationshipDb.GetRelationshipList();
                inputModel.CountryList = _countryDb.GetCountryList();
                inputModel.PensionSchemesList = _pensionSchemeDb.GetPensionSchemesList();

                string htmlContent = File.ReadAllText(HttpContext.Current.Server.MapPath("~/Views/RegistrationForm.html"));
                htmlContent = htmlContent.Replace("[BVN]", inputModel.BVN);
                htmlContent = htmlContent.Replace("[NIN]", inputModel.NIN);
                htmlContent = htmlContent.Replace("[Title]", inputModel.TitleList.FirstOrDefault(x => x.TitleId == inputModel.TitleId)?.Name);
                htmlContent = htmlContent.Replace("[Surname]", inputModel.LastName);
                htmlContent = htmlContent.Replace("[First Name]", inputModel.FirstName);
                htmlContent = htmlContent.Replace("[Other Name]", inputModel.OtherName);
                htmlContent = htmlContent.Replace("[Maritial Status]", inputModel.MaritialStatusList.FirstOrDefault(x => x.MartialStatusId == inputModel.MaritialStatusId)?.Name);
                htmlContent = htmlContent.Replace("[Date Of Birth]", inputModel.DateOfBirth);
                htmlContent = htmlContent.Replace("[Sex]", inputModel.SexList.FirstOrDefault(x => x.SexId == inputModel.SexIdClient)?.Name);
                htmlContent = htmlContent.Replace("[Nationality]", inputModel.NationalitiesList.FirstOrDefault(x => x.NationalityId == inputModel.NationalityId)?.Name);
                htmlContent = htmlContent.Replace("[State Of Origin]", inputModel.StatesList.FirstOrDefault(x => x.StateId == inputModel.ClientPersonalStateOfOriginId)?.Name);
                htmlContent = htmlContent.Replace("[LGA]", inputModel.LgasList.FirstOrDefault(x => x.LGAId == inputModel.LgaId)?.Name);
                htmlContent = htmlContent.Replace("[Correspondence Address]", inputModel.CorrespondenceAddress);
                htmlContent = htmlContent.Replace("[City]", inputModel.City);
                htmlContent = htmlContent.Replace("[State]", (inputModel.ClientContactStateId == null) ? "" : (inputModel.StatesList.FirstOrDefault(x => x.StateId == inputModel.ClientContactStateId)?.Name));
                htmlContent = htmlContent.Replace("[Permanent Address]", inputModel.PermanentAddress);
                htmlContent = htmlContent.Replace("[Permanent City]", inputModel.PermanentCity);
                htmlContent = htmlContent.Replace("[Permanent State]", inputModel.StatesList.FirstOrDefault(x => x.StateId == inputModel.ClientContactPermanentStateId)?.Name);
                htmlContent = htmlContent.Replace("[Mobile Phone]", inputModel.MobilePhone);
                htmlContent = htmlContent.Replace("[Home Phone]", inputModel.HomePhone);
                htmlContent = htmlContent.Replace("[E-Mail]", inputModel.Email);
                htmlContent = htmlContent.Replace("[Branch]", inputModel.BranchList.FirstOrDefault(x => x.BranchId == inputModel.BranchId)?.Name);
                htmlContent = htmlContent.Replace("[Form Reference Number]", inputModel.FormReferenceNumber);
                htmlContent = htmlContent.Replace("[Agent]", inputModel.AgentList.FirstOrDefault(x => x.AgentId == inputModel.AgentId)?.FirstName);
                htmlContent = htmlContent.Replace("[Select Employer]", inputModel.EmployerList.FirstOrDefault(x => x.EmployerId == inputModel.EmployerId)?.Name);
                htmlContent = htmlContent.Replace("[Employer Code]", inputModel.EmployerCode);
                htmlContent = htmlContent.Replace("[PENCOM(Employer Name)]", inputModel.PenComEmployerName);
                htmlContent = htmlContent.Replace("[Employer Name]", inputModel.EmployerName);
                htmlContent = htmlContent.Replace("[Employer Address]", inputModel.EmployerAddress);
                htmlContent = htmlContent.Replace("[Employer City]", inputModel.EmploymentCityId);
                htmlContent = htmlContent.Replace("[EmployerState]", (inputModel.EmployerStateId == null) ? "" : (inputModel.StatesList.FirstOrDefault(x => x.StateId == inputModel.EmployerStateId)?.Name));
                htmlContent = htmlContent.Replace("[State Of Posting]", inputModel.StateOfPostingsList.FirstOrDefault(x => x.StateOfPostingId == inputModel.StateOfPostingId)?.Name);
                htmlContent = htmlContent.Replace("[Designation]", inputModel.Designation);
                htmlContent = htmlContent.Replace("[Employer Type]", inputModel.EmployerTypesList.FirstOrDefault(x => x.EmployerTypeId == inputModel.EmployerTypeId)?.Name);
                htmlContent = htmlContent.Replace("[Employer Industry]", inputModel.EmployerIndustriesList.FirstOrDefault(x => x.EmployerIndustryId == inputModel.EmployerIndustryId)?.Name);
                htmlContent = htmlContent.Replace("[Employee Id]", inputModel.EmployeeId.ToString());
                htmlContent = htmlContent.Replace("[Employee Status]", inputModel.EmployeeStatusList.FirstOrDefault(x => x.EmployeeStatusId == inputModel.EmployeeStatusId)?.Name);
                htmlContent = htmlContent.Replace("[Date Employed]", inputModel.DateEmployed);
                htmlContent = htmlContent.Replace("[Employer Contribution]", inputModel.EmployerContribution);
                htmlContent = htmlContent.Replace("[Employee Contribution]", inputModel.EmployeeContribution);
                htmlContent = htmlContent.Replace("[Title]", (inputModel.KinTitle1 == null) ? "" : inputModel.TitleList.FirstOrDefault(x => x.TitleId == inputModel.KinTitle1)?.Name);
                htmlContent = htmlContent.Replace("[Surname]", inputModel.KinSurname);
                htmlContent = htmlContent.Replace("[First Name]", inputModel.KinFirstName);
                htmlContent = htmlContent.Replace("[Other Name]", inputModel.KinOtherName);
                htmlContent = htmlContent.Replace("[Correspondence Address]", inputModel.KinAddress);
                htmlContent = htmlContent.Replace("[City]", inputModel.KinCity);
                htmlContent = htmlContent.Replace("[KinStateId1]", inputModel.StatesList.FirstOrDefault(x => x.StateId == inputModel.KinStateId1)?.Name);
                htmlContent = htmlContent.Replace("[Country]", inputModel.CountryList.FirstOrDefault(x => x.CountryId == inputModel.KinCountryId)?.Name);
                htmlContent = htmlContent.Replace("[Relationship]", inputModel.RelationshipList.FirstOrDefault(x => x.RelationshipId == inputModel.KinRelationshipId)?.Name);
                htmlContent = htmlContent.Replace("[Sex]", inputModel.SexList.FirstOrDefault(x => x.SexId == inputModel.SexIdKin1)?.Name);
                htmlContent = htmlContent.Replace("[Phone]", inputModel.KinPhoneNo);
                htmlContent = htmlContent.Replace("[Email]", inputModel.KinEmail);
                htmlContent = htmlContent.Replace("[Title2]", (inputModel.KinTitle2 == null) ? "" : inputModel.TitleList.FirstOrDefault(x => x.TitleId == inputModel.KinTitle2)?.Name);
                htmlContent = htmlContent.Replace("[Surname2]", inputModel.KinSurname1);
                htmlContent = htmlContent.Replace("[First Name2]", inputModel.KinFirstName1);
                htmlContent = htmlContent.Replace("[Other Name2]", inputModel.KinOtherName1);
                htmlContent = htmlContent.Replace("[Correspondence Address2]", inputModel.KinAddress1);
                htmlContent = htmlContent.Replace("[City2]", inputModel.KinCity1);
                htmlContent = htmlContent.Replace("[KinStateId2]", (inputModel.KinStateId2 == null) ? "" : inputModel.StatesList.FirstOrDefault(x => x.StateId == inputModel.KinStateId2)?.Name);
                htmlContent = htmlContent.Replace("[Country2]", (inputModel.KinCountryId1 == null) ? "" : inputModel.CountryList.FirstOrDefault(x => x.CountryId == inputModel.KinCountryId1)?.Name);
                htmlContent = htmlContent.Replace("[Relationship2]", (inputModel.KinRelationshipId1 == null) ? "" : inputModel.RelationshipList.FirstOrDefault(x => x.RelationshipId == inputModel.KinRelationshipId1)?.Name);
                htmlContent = htmlContent.Replace("[Sex2]", (inputModel.SexIdKin2 == null) ? "" : inputModel.SexList.FirstOrDefault(x => x.SexId == inputModel.SexIdKin2)?.Name);
                htmlContent = htmlContent.Replace("[Phone2]", inputModel.KinPhoneNo1);
                htmlContent = htmlContent.Replace("[Email2]", inputModel.KinEmail1);
                htmlContent = htmlContent.Replace("[Pension Scheme]", inputModel.PensionSchemesList.FirstOrDefault(x => x.PensionSchemeId == inputModel.PensionSchemeId)?.Name);
                htmlContent = htmlContent.Replace("[Salary Scale]", inputModel.SalaryScale);
                htmlContent = htmlContent.Replace("[Step]", inputModel.Step);
                htmlContent = htmlContent.Replace("[Grade Level]", inputModel.GradeLevel);
                htmlContent = htmlContent.Replace("[Transport Allowance]", inputModel.TransportAllownce.ToString());
                htmlContent = htmlContent.Replace("[Basic Allowance]", inputModel.BasicAllownce.ToString());
                htmlContent = htmlContent.Replace("[Other Allownce]", inputModel.OtherAllownce.ToString());
                htmlContent = htmlContent.Replace("[Housing Allownce]", inputModel.HousingAllownce.ToString());
                htmlContent = htmlContent.Replace("[passport]", inputModel.PassportPhotograph);
                htmlContent = htmlContent.Replace("[signature]", inputModel.Signature);
                htmlContent = htmlContent.Replace("[rightThumb]", inputModel.rightThumb);
                htmlContent = htmlContent.Replace("[rightIndex]", inputModel.RightIndexFinger);
                htmlContent = htmlContent.Replace("[rightMiddle]", inputModel.RightMiddleFinger);
                htmlContent = htmlContent.Replace("[rightRing]", inputModel.RightRingFinger);
                htmlContent = htmlContent.Replace("[rightLittle]", inputModel.RightPinkyFinger);
                htmlContent = htmlContent.Replace("[leftThumb]", inputModel.LeftThumb);
                htmlContent = htmlContent.Replace("[leftIndex]", inputModel.LeftIndexFinger);
                htmlContent = htmlContent.Replace("[leftMiddle]", inputModel.LeftMiddleFinger);
                htmlContent = htmlContent.Replace("[leftRing]", inputModel.LeftRingFinger);
                htmlContent = htmlContent.Replace("[leftLittle]", inputModel.LeftPinkyFinger);
                string fileName = inputModel.UserId + ".pdf";
                string filePath = Path.Combine(HttpContext.Current.Server.MapPath("~/Content/RegisteredUser/"), fileName);


                PdfSharp.Pdf.PdfDocument pdf = TheArtOfDev.HtmlRenderer.PdfSharp.PdfGenerator.GeneratePdf(htmlContent, PdfSharp.PageSize.A4);
                pdf.Save(filePath);
                //PdfSharp.Pdf.PdfDocument pdf = TheArtOfDev.HtmlRenderer.PdfSharp.PdfGenerator.GeneratePdf(htmlContent, PdfSharp.PageSize.A4);
                //pdf.Save(filePath);
                return filePath;
            }
            catch (Exception exc)
            {
                BiometricLog.Log.Error(exc.Message);
                return exc.Message;
            }



            //return File(fileName, "application/pdf", filePath);
        }
    }
}