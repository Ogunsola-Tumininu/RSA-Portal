using PalRSA.Core.DataAccess;using PalRSA.Core.DataAccess;
using System.Collections.Generic;
using System.Linq;

namespace Recapture.DataAccess
{
    public class SexDb 
    {
        private readonly PALSiteDBEntities _biometricEntities = InternetConnection.CheckForInternetConnection();
        public List<Sex> GetSexesList()
        {
            return _biometricEntities.Sexes.Where(m => m.Active == true).OrderBy(x => x.Name).ToList();
        }
    }
}
