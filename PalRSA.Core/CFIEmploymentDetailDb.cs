using System.Collections.Generic;
using System.Linq;
using PalRSA.Core.DataAccess;using PalRSA.Core.DataAccess;

namespace Recapture.DataAccess
{
    public class CfiEmploymentDetailDb
    {
        private readonly PALSiteDBEntities _biometricEntities = InternetConnection.CheckForInternetConnection();
        public void AddCfiEmploymentDetails(CFIEmploymentDetail model)
        {
            _biometricEntities.CFIEmploymentDetails.Add(model);
            _biometricEntities.SaveChanges();
        }

        public List<CFIEmploymentDetail> GetCFIEmploymentDetail()
        {
            return _biometricEntities.CFIEmploymentDetails.ToList(); 
        }
    }
}
