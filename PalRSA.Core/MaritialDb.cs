using PalRSA.Core.DataAccess;using PalRSA.Core.DataAccess;
using System.Collections.Generic;
using System.Linq;

namespace Recapture.DataAccess
{
 
    public class MaritialDb 
    {
        private readonly PALSiteDBEntities _biometricEntities = InternetConnection.CheckForInternetConnection();
        public List<MartialStatu> GetMartialStatusList()
        {
            return _biometricEntities.MartialStatus.Where(m => m.Active == true).OrderBy(x => x.Name).ToList();
        }
    }
}
