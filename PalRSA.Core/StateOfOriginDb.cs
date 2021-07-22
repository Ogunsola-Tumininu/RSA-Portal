using PalRSA.Core.DataAccess;using PalRSA.Core.DataAccess;
using System.Collections.Generic;
using System.Linq;

namespace Recapture.DataAccess
{
   public class StateOfOriginDb
    {
        private readonly PALSiteDBEntities _biometricEntities = InternetConnection.CheckForInternetConnection();
        public List<StateOfOrigin> GetStateOfOriginsList()
        {
            return _biometricEntities.StateOfOrigins.Where(m => m.Active == true).OrderBy(x => x.Name).ToList();
        }  
    }
}
