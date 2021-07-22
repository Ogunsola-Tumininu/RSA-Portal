using PalRSA.Core.DataAccess;using PalRSA.Core.DataAccess;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Recapture.DataAccess
{
    public class OtherDb
    {

        private readonly PALSiteDBEntities _biometricEntities = InternetConnection.CheckForInternetConnection();
        public List<Other> GetOtherList()
        {
            return _biometricEntities.Other.Where(m => m.Active == true).ToList();
        }

        public void AddOther(Other other)
        {
            _biometricEntities.Other.Add(other);
            _biometricEntities.SaveChanges();
        }

        public void UpdateOther(Other other)
        {
            _biometricEntities.Entry(other).State = EntityState.Modified;
            _biometricEntities.SaveChanges();
        }

        public Other GetOtherDetail(int id)
        {
            return _biometricEntities.Other.Where(x => x.UserId == id).FirstOrDefault();
        }
         

    }
}
