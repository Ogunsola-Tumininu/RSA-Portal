
using PalRSA.Core.DataAccess;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Recapture.DataAccess
{
    public class CountryDb 
    {
        //private readonly PALSiteDBEntities _biometricEntities = InternetConnection.CheckForInternetConnection();
        private readonly PALSiteDBEntities _biometricEntities = InternetConnection.CheckForInternetConnection();
        public List<Country> GetCountryList()
        {
            return _biometricEntities.Countries.Where(x => x.Active).OrderBy(x => x.Name).ToList();
        }

        public void AddCountry(Country conuntry)
        {
            _biometricEntities.Countries.Add(conuntry);
            _biometricEntities.SaveChanges();
        }

        public void UpdateCountry(Country country)
        {
            _biometricEntities.Entry(country).State = EntityState.Modified;
            _biometricEntities.SaveChanges();
        }
    }
}
