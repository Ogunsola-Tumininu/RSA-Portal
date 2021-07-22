using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using PalRSA.Core.DataAccess;using PalRSA.Core.DataAccess;

namespace Recapture.DataAccess
{
    public class SectorDb 
    {
        private readonly PALSiteDBEntities _biometricEntities = InternetConnection.CheckForInternetConnection();
        public List<Sector> GetSectorList()
        {
            return _biometricEntities.Sectors.Where(x => x.Active == true).ToList();
        }

        public void AddSector(Sector sector)
        {
            _biometricEntities.Sectors.Add(sector);
            _biometricEntities.SaveChanges();
        }

        public void UpdateSector(Sector sector)
        {
            _biometricEntities.Entry(sector).State = EntityState.Modified;
            _biometricEntities.SaveChanges();
        }
    }
}
