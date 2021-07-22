using PalRSA.Core.DataAccess;using PalRSA.Core.DataAccess;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Recapture.DataAccess
{
    public class LgaDb
    {
        private readonly PALSiteDBEntities _biometricEntities = InternetConnection.CheckForInternetConnection();
        public List<LGArea> GetLgaList()
        {
            return _biometricEntities.LGAreas.Where(m => m.Active == true).OrderBy(x => x.Name).ToList();
        }

        public void AddLga(LGArea model)
        {
            _biometricEntities.LGAreas.Add(model);
            _biometricEntities.SaveChanges();
        }

        public void UpdateLga(LGArea model)
        { 
            _biometricEntities.Entry(model).State = EntityState.Modified;
            _biometricEntities.SaveChanges();
        }

    }
}
