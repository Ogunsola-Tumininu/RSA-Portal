using System;
using Recapture.DataAccess;
using PalRSA.Core.Models;
using System.IO;
using System.Linq;

namespace Recapture.Common
{
    public class RegisteredUser
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

        public RegisteredUser()
        {
            _countryDb = new CountryDb();
            _titleDb = new TitleDb();
            _maritialDb = new MaritialDb();
            _sexDb = new SexDb();
            _stateOfOriginDb = new StateOfOriginDb();
          //  _nationalityDb = new NationalityDb();
            _lgaDb = new LgaDb();
            _stateDb = new StateDb();
          //  _branchDb = new BranchDb();
            _agentDb = new AgentDb();
           // _employerDb = new EmployerDb();
            _cityDb = new CityDb();
            _stateOfPostingDb = new StateOfPostingDb();
           // _employerTypeDb = new EmployerTypeDb();
           // _employeeIndustryDb = new EmployeeIndustryDb();
            _employerStatusDb = new EmployerStatusDb();
            _relationshipDb = new RelationshipDb();
            //_pensionSchemeDb = new PensionSchemeDb();
            //_registrationDb = new RegistrationDb();
            //_employeeDetailDb = new EmployeeDetailDb();
            //_nextOfKinDb = new NextOfKinDb();
            _otherDb = new OtherDb();
            _imageAdministrationDb = new ImageAdministrationDb();
          //  _bioMetricDb = new BioMetricDb();

        }


        public RegistrationListViewModel FetchRegisteredUser(int id)
        {

            RegistrationListViewModel registrationListViewModel = new RegistrationListViewModel();

            if (id > 0)
            {

                registrationListViewModel.TitleList = _titleDb.GetTitleList();
                registrationListViewModel.MaritialStatusList = _maritialDb.GetMartialStatusList();
                registrationListViewModel.SexList = _sexDb.GetSexesList();
                registrationListViewModel.StateOfOriginsList = _stateOfOriginDb.GetStateOfOriginsList();
                registrationListViewModel.NationalitiesList = _nationalityDb.GetNationalitiesList();
                registrationListViewModel.LgasList = _lgaDb.GetLgaList();
                registrationListViewModel.StatesList = _stateDb.GetStateList();
                registrationListViewModel.BranchList = _branchDb.GetBranchesList();
                registrationListViewModel.AgentList = _agentDb.GetAgentList();
                registrationListViewModel.EmployerList = _employerDb.GetEmployerList();
                registrationListViewModel.CityList = _cityDb.GetCityList();
                registrationListViewModel.StateOfPostingsList = _stateOfPostingDb.GetStateOfPostingsList();
                registrationListViewModel.EmployerTypesList = _employerTypeDb.GetEmployerTypesList();
                registrationListViewModel.EmployerIndustriesList = _employeeIndustryDb.GetEmployerIndustriesList();
                registrationListViewModel.EmployeeStatusList = _employerStatusDb.GetEmployeeStatusList();
                registrationListViewModel.RelationshipList = _relationshipDb.GetRelationshipList();
                registrationListViewModel.CountryList = _countryDb.GetCountryList();
                registrationListViewModel.PensionSchemesList = _pensionSchemeDb.GetPensionSchemesList();



                var registerUser = _registrationDb.GetRegisteredUser(id);
                if (registerUser != null)
                {
                    registrationListViewModel.UserId = registerUser.UserId;
                    registrationListViewModel.TitleId = registerUser.TitleId;
                    registrationListViewModel.BVN = registerUser.BVN;
                    registrationListViewModel.NIN = registerUser.NIN;
                    registrationListViewModel.FirstName = registerUser.FirstName;
                    registrationListViewModel.LastName = registerUser.LastName;
                    registrationListViewModel.OtherName = registerUser.OtherName;
                    registrationListViewModel.MaritialStatusId = registerUser.MartialStatusId;
                    registrationListViewModel.DateOfBirth = registerUser.DateOfBirth;
                    registrationListViewModel.SexIdClient = registerUser.SexId;
                    registrationListViewModel.NationalityId = registerUser.NationalityId;
                    registrationListViewModel.ClientPersonalStateOfOriginId = registerUser.StateOfOriginId;
                    registrationListViewModel.LgaId = registerUser.LGAId;
                    registrationListViewModel.CorrespondenceAddress = registerUser.Address;
                    registrationListViewModel.ClientContactStateId = registerUser.StateId;
                    registrationListViewModel.City = registerUser.City;
                    registrationListViewModel.PermanentAddress = registerUser.PermanentAddress;
                    registrationListViewModel.PermanentCity = registerUser.PermanentCity;
                    registrationListViewModel.ClientContactPermanentStateId = registerUser.PermanentStateId;
                    registrationListViewModel.Email = registerUser.Email;
                    registrationListViewModel.HomePhone = registerUser.Phone;
                    registrationListViewModel.MobilePhone = registerUser.Mobile;
                    registrationListViewModel.BranchId = registerUser.BranchId;
                    registrationListViewModel.AgentId = registerUser.AgentId;
                    registrationListViewModel.FormReferenceNumber = registerUser.FormReferenceNo;
                }


                //_employeeDetailDb.AddEmploymentDetails(employmentDetail);
                var employmentDetail = _employeeDetailDb.GetEmploymentDetail(id);
                if (employmentDetail != null)
                {
                    registrationListViewModel.EmployeeDetailId = employmentDetail.EmployeeDetailId;
                    registrationListViewModel.EmployerId = employmentDetail.EmployerId;
                    registrationListViewModel.PenComEmployerName = employmentDetail.Pencom;
                    registrationListViewModel.EmploymentCityId = employmentDetail.CityId;
                    registrationListViewModel.EmployerTypeId = employmentDetail.EmployerTypeId;
                    registrationListViewModel.EmployerIndustryId = employmentDetail.EmployerIndustryId;
                    registrationListViewModel.Designation = employmentDetail.Designation;
                    registrationListViewModel.EmployeeContribution = employmentDetail.EmployeeContribution;
                    registrationListViewModel.EmployerContribution = employmentDetail.EmployerContribution;
                    registrationListViewModel.StateOfPostingId = employmentDetail.StateOfPostingId;
                    registrationListViewModel.EmployeeStatusId = employmentDetail.EmployeeStatusId;
                    registrationListViewModel.EmployeeId = employmentDetail.EmployeeId;
                    registrationListViewModel.DateEmployed = employmentDetail.DateEmployed;
                }
                //Employer Info
                var employerInfo = _employerDb.GetEmployerList().FirstOrDefault(m => m.EmployerId == registrationListViewModel.EmployerId);
                if (employerInfo != null)
                {
                    registrationListViewModel.EmployerCode = employerInfo.Code;
                    registrationListViewModel.EmployerName = employerInfo.Name;
                    registrationListViewModel.EmployerAddress = employerInfo.Address;
                    registrationListViewModel.EmployerStateId = employerInfo.StateId;
                }

                var nextOfKins = _nextOfKinDb.GetNextOfKinDetail(id);
                int firstkin = 0;
                if (nextOfKins != null)
                {
                    foreach (NextOfKin nextOfkin in nextOfKins)
                    {
                        if (firstkin == 0)
                        {
                            registrationListViewModel.NextOfKinId1 = nextOfkin.NextOfKinId;
                            registrationListViewModel.KinFirstName = nextOfkin.FirstName;
                            registrationListViewModel.KinSurname = nextOfkin.LastName;
                            registrationListViewModel.KinOtherName = nextOfkin.OtherNames;
                            registrationListViewModel.SexIdKin1 = nextOfkin.SexId;
                            registrationListViewModel.KinAddress = nextOfkin.Address;
                            registrationListViewModel.KinEmail = nextOfkin.Email;
                            registrationListViewModel.KinPhoneNo = nextOfkin.Phone;
                            registrationListViewModel.KinTitle1 = nextOfkin.TitleId;
                            registrationListViewModel.KinCity = nextOfkin.City;
                            registrationListViewModel.KinStateId1 = nextOfkin.StateId;
                            registrationListViewModel.KinCountryId = nextOfkin.CountryId;
                            registrationListViewModel.KinRelationshipId = nextOfkin.RelationshipId;
                            firstkin++;
                        }
                        else
                        {
                            registrationListViewModel.NextOfKinId2 = nextOfkin.NextOfKinId;
                            registrationListViewModel.KinFirstName1 = nextOfkin.FirstName;
                            registrationListViewModel.KinSurname1 = nextOfkin.LastName;
                            registrationListViewModel.KinOtherName1 = nextOfkin.OtherNames;
                            registrationListViewModel.SexIdKin2 = nextOfkin.SexId;
                            registrationListViewModel.KinAddress1 = nextOfkin.Address;
                            registrationListViewModel.KinEmail1 = nextOfkin.Email;
                            registrationListViewModel.KinPhoneNo1 = nextOfkin.Phone;
                            registrationListViewModel.KinTitle2 = nextOfkin.TitleId;
                            registrationListViewModel.KinCity1 = nextOfkin.City;
                            registrationListViewModel.KinStateId2 = nextOfkin.StateId;
                            registrationListViewModel.KinCountryId1 = nextOfkin.CountryId;
                            registrationListViewModel.KinRelationshipId1 = nextOfkin.RelationshipId;
                            firstkin = 0;
                        }

                    }
                }


                var other = _otherDb.GetOtherDetail(id);
                if (other != null)
                {
                    registrationListViewModel.OtherId = other.OtherId;
                    registrationListViewModel.PensionSchemeId = other.PensionSchemeId;
                    registrationListViewModel.SalaryScale = other.SalaryScale;
                    registrationListViewModel.Step = other.SalaryStep;
                    registrationListViewModel.GradeLevel = other.SalaryGradeLevel;
                    registrationListViewModel.TransportAllownce = other.AnnualTransport ?? 0;
                    registrationListViewModel.BasicAllownce = other.AnnualBasicSalary ?? 0;
                    registrationListViewModel.OtherAllownce = other.AnnualOtherAllowances ?? 0;
                    registrationListViewModel.HousingAllownce = other.AnnualRent ?? 0;
                }

                var imageAdministration = _imageAdministrationDb.GetImageAdministrationList().FirstOrDefault();

                var biometric = _bioMetricDb.GetBiometricDetail(id);
                if (biometric != null && imageAdministration != null)
                {
                    registrationListViewModel.BiometricId = biometric.BiometricId;
                    if (biometric.Passport.Trim() != string.Empty)
                    {
                        registrationListViewModel.PassportPhotograph = imageAdministration.PassportPhotograph + "\\" + biometric.Passport;
                        FileInfo objFileInfo = new FileInfo(registrationListViewModel.PassportPhotograph);
                        if (objFileInfo.Exists)
                        {
                            FileStream fs = new FileStream(registrationListViewModel.PassportPhotograph, FileMode.Open, FileAccess.Read);
                            BinaryReader br = new BinaryReader(fs);
                            Byte[] bytes = br.ReadBytes((Int32)fs.Length);
                            registrationListViewModel.PassportPhotograph = Convert.ToBase64String(bytes);
                        }
                        else
                        {
                            registrationListViewModel.PassportPhotograph = null;
                        }
                    }
                    if (biometric.Signature.Trim() != string.Empty)
                    {
                        registrationListViewModel.Signature = imageAdministration.Signature + "\\" + biometric.Signature;
                        FileInfo objFileInfo = new FileInfo(registrationListViewModel.Signature);
                        if (objFileInfo.Exists)
                        {
                            FileStream fs1 = new FileStream(registrationListViewModel.Signature, FileMode.Open, FileAccess.Read);
                            BinaryReader br1 = new BinaryReader(fs1);
                            Byte[] bytes1 = br1.ReadBytes((Int32)fs1.Length);
                            registrationListViewModel.Signature = Convert.ToBase64String(bytes1);
                        }
                        else
                        {
                            registrationListViewModel.Signature = null;
                        }
                    }
                    if (biometric.RightThumb.Trim() != string.Empty)
                    {
                        registrationListViewModel.rightThumb = imageAdministration.RightThumb + "\\" + biometric.RightThumb;
                        FileInfo objFileInfo = new FileInfo(registrationListViewModel.rightThumb);
                        if (objFileInfo.Exists)
                        {

                            FileStream fs2 = new FileStream(registrationListViewModel.rightThumb, FileMode.Open, FileAccess.Read);
                            BinaryReader br2 = new BinaryReader(fs2);
                            Byte[] bytes2 = br2.ReadBytes((Int32)fs2.Length);
                            registrationListViewModel.rightThumb = Convert.ToBase64String(bytes2);
                        }
                        else
                        {
                            registrationListViewModel.rightThumb = null;
                        }
                    }
                    if (biometric.RightIndex.Trim() != string.Empty)
                    {
                        registrationListViewModel.RightIndexFinger = imageAdministration.RightIndexFinger + "\\" + biometric.RightIndex;
                        FileInfo objFileInfo = new FileInfo(registrationListViewModel.RightIndexFinger);
                        if (objFileInfo.Exists)
                        {
                            FileStream fs3 = new FileStream(registrationListViewModel.RightIndexFinger, FileMode.Open, FileAccess.Read);
                            BinaryReader br3 = new BinaryReader(fs3);
                            Byte[] bytes3 = br3.ReadBytes((Int32)fs3.Length);
                            registrationListViewModel.RightIndexFinger = Convert.ToBase64String(bytes3);

                        }
                        else
                        {
                            registrationListViewModel.RightIndexFinger = null;
                        }
                    }
                    if (biometric.RightMiddle.Trim() != string.Empty)
                    {
                        registrationListViewModel.RightMiddleFinger = imageAdministration.RightMiddleFinger + "\\" + biometric.RightMiddle;
                        FileInfo objFileInfo = new FileInfo(registrationListViewModel.RightMiddleFinger);
                        if (objFileInfo.Exists)
                        {
                            FileStream fs4 = new FileStream(registrationListViewModel.RightMiddleFinger, FileMode.Open, FileAccess.Read);
                            BinaryReader br4 = new BinaryReader(fs4);
                            Byte[] bytes4 = br4.ReadBytes((Int32)fs4.Length);
                            registrationListViewModel.RightMiddleFinger = Convert.ToBase64String(bytes4);

                        }
                        else
                        {
                            registrationListViewModel.RightMiddleFinger = null;
                        }
                    }

                    if (biometric.RightRing.Trim() != string.Empty)
                    {
                        registrationListViewModel.RightRingFinger = imageAdministration.RightRingFinger + "\\" + biometric.RightRing;
                        FileInfo objFileInfo = new FileInfo(registrationListViewModel.RightRingFinger);
                        if (objFileInfo.Exists)
                        {
                            FileStream fs5 = new FileStream(registrationListViewModel.RightRingFinger, FileMode.Open, FileAccess.Read);
                            BinaryReader br5 = new BinaryReader(fs5);
                            Byte[] bytes5 = br5.ReadBytes((Int32)fs5.Length);
                            registrationListViewModel.RightRingFinger = Convert.ToBase64String(bytes5);

                        }
                        else
                        {
                            registrationListViewModel.RightRingFinger = null;
                        }
                    }
                    if (biometric.RightLittle.Trim() != string.Empty)
                    {
                        registrationListViewModel.RightPinkyFinger = imageAdministration.RightPinkyFinger + "\\" + biometric.RightLittle;
                        FileInfo objFileInfo = new FileInfo(registrationListViewModel.RightPinkyFinger);
                        if (objFileInfo.Exists)
                        {
                            FileStream fs6 = new FileStream(registrationListViewModel.RightPinkyFinger, FileMode.Open, FileAccess.Read);
                            BinaryReader br6 = new BinaryReader(fs6);
                            Byte[] bytes6 = br6.ReadBytes((Int32)fs6.Length);
                            registrationListViewModel.RightPinkyFinger = Convert.ToBase64String(bytes6);

                        }
                        else
                        {
                            registrationListViewModel.RightPinkyFinger = null;
                        }
                    }
                    if (biometric.LeftThumb.Trim() != string.Empty)
                    {
                        registrationListViewModel.LeftThumb = imageAdministration.LeftThumb + "\\" + biometric.LeftThumb;
                        FileInfo objFileInfo = new FileInfo(registrationListViewModel.LeftThumb);
                        if (objFileInfo.Exists)
                        {

                            FileStream fs7 = new FileStream(registrationListViewModel.LeftThumb, FileMode.Open, FileAccess.Read);
                            BinaryReader br7 = new BinaryReader(fs7);
                            Byte[] bytes7 = br7.ReadBytes((Int32)fs7.Length);
                            registrationListViewModel.LeftThumb = Convert.ToBase64String(bytes7);
                        }
                        else
                        {
                            registrationListViewModel.LeftThumb = null;
                        }

                    }
                    if (biometric.LeftIndex.Trim() != string.Empty)
                    {
                        registrationListViewModel.LeftIndexFinger = imageAdministration.LeftIndexFinger + "\\" + biometric.LeftIndex;
                        FileInfo objFileInfo = new FileInfo(registrationListViewModel.LeftIndexFinger);
                        if (objFileInfo.Exists)
                        {
                            FileStream fs8 = new FileStream(registrationListViewModel.LeftIndexFinger, FileMode.Open, FileAccess.Read);
                            BinaryReader br8 = new BinaryReader(fs8);
                            Byte[] bytes8 = br8.ReadBytes((Int32)fs8.Length);
                            registrationListViewModel.LeftIndexFinger = Convert.ToBase64String(bytes8);

                        }
                        else
                        {
                            registrationListViewModel.LeftIndexFinger = null;
                        }
                    }
                    if (biometric.LeftMiddle.Trim() != string.Empty)
                    {
                        registrationListViewModel.LeftMiddleFinger = imageAdministration.LeftMiddleFinger + "\\" + biometric.LeftMiddle;
                        FileInfo objFileInfo = new FileInfo(registrationListViewModel.LeftMiddleFinger);
                        if (objFileInfo.Exists)
                        {
                            FileStream fs9 = new FileStream(registrationListViewModel.LeftMiddleFinger, FileMode.Open, FileAccess.Read);
                            BinaryReader br9 = new BinaryReader(fs9);
                            Byte[] bytes9 = br9.ReadBytes((Int32)fs9.Length);
                            registrationListViewModel.LeftMiddleFinger = Convert.ToBase64String(bytes9);

                        }
                        else
                        {
                            registrationListViewModel.LeftMiddleFinger = null;
                        }
                    }
                    if (biometric.LeftRing.Trim() != string.Empty)
                    {
                        registrationListViewModel.LeftRingFinger = imageAdministration.LeftRingFinger + "\\" + biometric.LeftRing;
                        FileInfo objFileInfo = new FileInfo(registrationListViewModel.LeftRingFinger);
                        if (objFileInfo.Exists)
                        {

                            FileStream fs10 = new FileStream(registrationListViewModel.LeftRingFinger, FileMode.Open, FileAccess.Read);
                            BinaryReader br10 = new BinaryReader(fs10);
                            Byte[] bytes10 = br10.ReadBytes((Int32)fs10.Length);
                            registrationListViewModel.LeftRingFinger = Convert.ToBase64String(bytes10);
                        }
                        else
                        {
                            registrationListViewModel.LeftRingFinger = null;
                        }
                    }
                    if (biometric.LeftLittle.Trim() != string.Empty)
                    {
                        registrationListViewModel.LeftPinkyFinger = imageAdministration.LeftPinkyFinger + "\\" + biometric.LeftLittle;
                        FileInfo objFileInfo = new FileInfo(registrationListViewModel.LeftPinkyFinger);
                        if (objFileInfo.Exists)
                        {

                            FileStream fs11 = new FileStream(registrationListViewModel.LeftPinkyFinger, FileMode.Open, FileAccess.Read);
                            BinaryReader br11 = new BinaryReader(fs11);
                            Byte[] bytes11 = br11.ReadBytes((Int32)fs11.Length);
                            registrationListViewModel.LeftPinkyFinger = Convert.ToBase64String(bytes11);
                        }
                        else
                        {
                            registrationListViewModel.LeftPinkyFinger = null;
                        }
                    }
                }
            }

            return registrationListViewModel;

        }

        public RegistrationListViewModel GetRegistrationListViewModel()
        {
            var registrationListViewModel = new RegistrationListViewModel
            {
                TitleList = _titleDb.GetTitleList(),
                MaritialStatusList = _maritialDb.GetMartialStatusList(),
                SexList = _sexDb.GetSexesList(),
                StateOfOriginsList = _stateOfOriginDb.GetStateOfOriginsList(),
                NationalitiesList = _nationalityDb.GetNationalitiesList(),
                LgasList = _lgaDb.GetLgaList(),
                StatesList = _stateDb.GetStateList(),
                BranchList = _branchDb.GetBranchesList(),
                AgentList = _agentDb.GetAgentList(),
                EmployerList = _employerDb.GetEmployerList(),
                CityList = _cityDb.GetCityList(),
                StateOfPostingsList = _stateOfPostingDb.GetStateOfPostingsList(),
                EmployerTypesList = _employerTypeDb.GetEmployerTypesList(),
                EmployerIndustriesList = _employeeIndustryDb.GetEmployerIndustriesList(),
                EmployeeStatusList = _employerStatusDb.GetEmployeeStatusList(),
                RelationshipList = _relationshipDb.GetRelationshipList(),
                CountryList = _countryDb.GetCountryList(),
                PensionSchemesList = _pensionSchemeDb.GetPensionSchemesList()
            };
            

            return registrationListViewModel;
        }

    }
}