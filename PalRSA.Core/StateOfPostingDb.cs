using PalRSA.Core.DataAccess;using PalRSA.Core.DataAccess;
using System.Collections.Generic;
using System.Linq;

namespace Recapture.DataAccess
{
    public class StateOfPostingDb
    {
        private readonly PALSiteDBEntities _biometricEntities = InternetConnection.CheckForInternetConnection();
        public List<StateOfPosting> GetStateOfPostingsList()
        {
            return _biometricEntities.StateOfPostings.Where(m => m.Active == true).OrderBy(x => x.Name).ToList();
        } 
    }
}
