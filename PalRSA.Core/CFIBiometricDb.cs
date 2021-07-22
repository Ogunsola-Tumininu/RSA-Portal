using PalRSA.Core.DataAccess;using PalRSA.Core.DataAccess;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;

namespace Recapture.DataAccess
{
    public class CFIBiometricDb
    {
        private readonly PALSiteDBEntities _biometricEntities = InternetConnection.CheckForInternetConnection();
        public List<CFIBiometric> GetCityList()
        {
            return _biometricEntities.CFIBiometrics.Where(m => m.Active).ToList();
        }

        public void AddCfiBiometric(CFIBiometric biometric)
        {
            try
            {
                _biometricEntities.CFIBiometrics.Add(biometric);
                _biometricEntities.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                var entityValidationErrors = ex.EntityValidationErrors.ToList();
                var errorMessage = new StringBuilder();
                var count = entityValidationErrors.Count;
                errorMessage.AppendFormat("Entity validation returned {0} errors:", count);
                for (var index = 0; index < count; index++)
                {
                    errorMessage.AppendLine();
                    errorMessage.AppendFormat("Error {0} of {1}:", index + 1, count);
                    var error = entityValidationErrors[index];
                    foreach (var validationError in error.ValidationErrors)
                    {
                        errorMessage.AppendLine();
                        errorMessage.AppendFormat("Error text: {0} Property name: {1}",
                            validationError.ErrorMessage, validationError.PropertyName);
                    }
                }

            }
            //catch (DbUpdateException ex)
            //{

            //    throw ex;
            //}

        }

        public CFIBiometric GetCfiBiometricDetail(int id)
        {
            return _biometricEntities.CFIBiometrics.Where(x => x.UserId == id).FirstOrDefault();
        } 
    }
}
