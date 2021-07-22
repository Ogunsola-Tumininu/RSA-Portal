using PalRSA.Core.DataAccess;using PalRSA.Core.DataAccess;
using System.Collections.Generic;
using System.Linq;

namespace Recapture.DataAccess
{
    public class CfiNextOfKinDb
    {
        private readonly PALSiteDBEntities _biometricEntities = InternetConnection.CheckForInternetConnection();
        public List<CFINextOfKin> GetCfiNextOfKinsList()
        {
            return _biometricEntities.CFINextOfKins.Where(m => m.Active).ToList();
        }

        public void AddCfiNextOfKins(CFINextOfKin nextOfKin)
        {
            _biometricEntities.CFINextOfKins.Add(nextOfKin);
            _biometricEntities.SaveChanges();
        } 
    }
}
