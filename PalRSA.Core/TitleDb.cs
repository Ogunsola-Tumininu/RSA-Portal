using PalRSA.Core.DataAccess;
 
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Recapture.DataAccess
{
    public class TitleDb 
    {
        private readonly PALSiteDBEntities _biometricEntities = InternetConnection.CheckForInternetConnection();
        public List<Title> GetTitleList()
        {
            return _biometricEntities.Titles.Where(x => x.Active==true).OrderBy(x => x.Name).ToList();
        }

        public void AddTitle(Title title)
        {
            _biometricEntities.Titles.Add(title);
            _biometricEntities.SaveChanges();
        }

        public void UpdateTitle(Title title)
        {
            _biometricEntities.Entry(title).State = EntityState.Modified;
            _biometricEntities.SaveChanges();
        }

    }
}
