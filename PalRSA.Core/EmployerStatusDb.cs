using PalRSA.Core.DataAccess;using PalRSA.Core.DataAccess;
using System.Collections.Generic;
using System.Linq;

namespace Recapture.DataAccess
{
    public class EmployerStatusDb
    {
        private readonly PALSiteDBEntities _biometricEntities = InternetConnection.CheckForInternetConnection();
        public List<EmployeeStatu> GetEmployeeStatusList()
        {
            return _biometricEntities.EmployeeStatus.Where(m => m.Active == true).OrderBy(x => x.Name).ToList();
        } 
    }
}
