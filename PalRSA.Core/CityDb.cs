using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using PalRSA.Core.DataAccess; 
namespace Recapture.DataAccess
{
    public class CityDb
    {
        private readonly PALSiteDBEntities _biometricEntities = InternetConnection.CheckForInternetConnection();
        //public List<City> GetCityList()
        //{
        //    return _biometricEntities.Cities.Where(m => m.Active==true).OrderBy(x => x.Name).ToList();
        //}

        //public void AddCity(City city)
        //{
        //    _biometricEntities.Cities.Add(city);
        //    _biometricEntities.SaveChanges();
        //}

        //public void UpdateCity(City city)
        //{
        //    _biometricEntities.Entry(city).State = EntityState.Modified;
        //    _biometricEntities.SaveChanges();
        //}



    }
}
