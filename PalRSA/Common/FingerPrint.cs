using System;
using System.Linq;
using Biometric.Common;
using Biometric.DataAccess;
using Biometric.Entity;
using Recapture.Models;

namespace Recapture.Common
{
    public class FingerPrint
    {
        private readonly RegistrationDb _registrationDb;
        private readonly BiometricEntities _biometricEntities;
        private readonly BioMetricDb _bioMetricDb;

        public FingerPrint()
        {
            _registrationDb = new RegistrationDb();
            _biometricEntities = InternetConnection.CheckForInternetConnection();
            _bioMetricDb = new BioMetricDb();
        }
        public FingerPrintViewModel GetFingerPrintViewModel(int? id, Biometric.Entity.Biometric userBiometric)
        {
            FingerPrintViewModel objFingerPrintViewModel = new FingerPrintViewModel();
            var user = _registrationDb.GetRegistrationDetails().FirstOrDefault(x => x.UserId == id);
            if (user != null)
            {
                objFingerPrintViewModel.FirstName = user.FirstName;
                objFingerPrintViewModel.LastName = user.LastName;
                if (userBiometric != null)
                {
                    objFingerPrintViewModel.LeftIndex = userBiometric.LeftIndex;
                    objFingerPrintViewModel.LeftLittle = userBiometric.LeftLittle;
                    objFingerPrintViewModel.LeftMiddle = userBiometric.LeftMiddle;
                    objFingerPrintViewModel.LeftRing = userBiometric.LeftRing;
                    objFingerPrintViewModel.LeftThumb = userBiometric.LeftThumb;
                    objFingerPrintViewModel.RightIndex = userBiometric.RightIndex;
                    objFingerPrintViewModel.RightLittle = userBiometric.RightLittle;
                    objFingerPrintViewModel.RightMiddle = userBiometric.RightMiddle;
                    objFingerPrintViewModel.RightRing = userBiometric.RightRing;
                    objFingerPrintViewModel.RightThumb = userBiometric.RightThumb;
                    objFingerPrintViewModel.Signature = userBiometric.Signature;
                    objFingerPrintViewModel.Passport = userBiometric.Passport;
                }
                return objFingerPrintViewModel;
            }
            return null;

        }

        public void AddUpdateBiometric(int id, FingerPrintViewModel fingerPrintImageViewModel, Constant.BiometricDevice device)
        {
            //FOR fingerPrintViewModel END


            //2)FOR fingerPrintImageViewModel START
            var biometric = new Biometric.Entity.Biometric
            {
                UserId = id,
                DeviceId = (device == Constant.BiometricDevice.USB) ? 1 : 2,
                Passport = fingerPrintImageViewModel.Passport ?? string.Empty,
                Signature = fingerPrintImageViewModel.Signature ?? string.Empty,
                RightThumb = fingerPrintImageViewModel.RightThumb ?? string.Empty,
                RightIndex = fingerPrintImageViewModel.RightIndex ?? string.Empty,
                RightMiddle = fingerPrintImageViewModel.RightMiddle ?? string.Empty,
                RightRing = fingerPrintImageViewModel.RightRing ?? string.Empty,
                RightLittle = fingerPrintImageViewModel.RightLittle ?? string.Empty,
                LeftThumb = fingerPrintImageViewModel.LeftThumb ?? string.Empty,
                LeftIndex = fingerPrintImageViewModel.LeftIndex ?? string.Empty,
                LeftMiddle = fingerPrintImageViewModel.LeftMiddle ?? string.Empty,
                LeftRing = fingerPrintImageViewModel.LeftRing ?? string.Empty,
                LeftLittle = fingerPrintImageViewModel.LeftLittle ?? string.Empty,
                DatetimeUpdated = DateTime.Now,
                Active = true,
                DatetimeCreated = DateTime.Now
            };

            if (_biometricEntities.Biometrics.Any(m => m.UserId == id))
            {
                var userBiometric = _biometricEntities.Biometrics.SingleOrDefault(x => x.UserId == id);
                biometric.BiometricId = userBiometric.BiometricId;
                if (_biometricEntities.Biometrics.Any(m => m.UserId == id && (m.DeviceId == 1 || m.DeviceId == 2)))
                {
                    biometric.RightThumb = (biometric.RightThumb == string.Empty) ? (userBiometric.RightThumb ?? string.Empty) : biometric.RightThumb;
                    biometric.RightIndex = (biometric.RightIndex == string.Empty) ? (userBiometric.RightIndex ?? string.Empty) : biometric.RightIndex;
                    biometric.RightMiddle = (biometric.RightMiddle == string.Empty) ? (userBiometric.RightMiddle ?? string.Empty) : biometric.RightMiddle;
                    biometric.RightRing = (biometric.RightRing == string.Empty) ? (userBiometric.RightRing ?? string.Empty) : biometric.RightRing;
                    biometric.RightLittle = (biometric.RightLittle == string.Empty) ? (userBiometric.RightLittle ?? string.Empty) : biometric.RightLittle;
                    biometric.LeftThumb = (biometric.LeftThumb == string.Empty) ? (userBiometric.LeftThumb ?? string.Empty) : biometric.LeftThumb;
                    biometric.LeftIndex = (biometric.LeftIndex == string.Empty) ? (userBiometric.LeftIndex ?? string.Empty) : biometric.LeftIndex;
                    biometric.LeftMiddle = (biometric.LeftMiddle == string.Empty) ? (userBiometric.LeftMiddle ?? string.Empty) : biometric.LeftMiddle;
                    biometric.LeftRing = (biometric.LeftRing == string.Empty) ? (userBiometric.LeftRing ?? string.Empty) : biometric.LeftRing;
                    biometric.LeftLittle = (biometric.LeftLittle == string.Empty) ? (userBiometric.LeftLittle ?? string.Empty) : biometric.LeftLittle;
                    biometric.Signature = (biometric.Signature == string.Empty) ? (userBiometric.Signature ?? string.Empty) : biometric.Signature;
                    biometric.Passport = (biometric.Passport == string.Empty) ? (userBiometric.Passport ?? string.Empty) : biometric.Passport;
                }
                _bioMetricDb.UpdateBiometric(biometric);
            }
            else
            {
                _bioMetricDb.AddBiometric(biometric);
            }
        }
    }
}