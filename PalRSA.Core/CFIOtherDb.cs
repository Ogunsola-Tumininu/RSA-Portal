using PalRSA.Core.DataAccess;using PalRSA.Core.DataAccess;

namespace Recapture.DataAccess
{
    public class CfiOtherDb
    {
        private readonly PALSiteDBEntities _biometricEntities = InternetConnection.CheckForInternetConnection();
        public void AddCfiOthers(CFIOther model)
        {
            _biometricEntities.CFIOthers.Add(model);
            _biometricEntities.SaveChanges();
        } 
    }
}
