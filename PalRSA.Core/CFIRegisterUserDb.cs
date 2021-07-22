using System.Linq;
using PalRSA.Core.DataAccess;using PalRSA.Core.DataAccess;
using System.Collections.Generic;

namespace Recapture.DataAccess
{
    public class CfiRegisterUserDb
    {
        private readonly PALSiteDBEntities _biometricEntities = InternetConnection.CheckForInternetConnection();

        public int AddCfiRegisterUsers(CFIRegisterUser cfiRegisterUser)
        {
            _biometricEntities.CFIRegisterUsers.Add(cfiRegisterUser);
            _biometricEntities.SaveChanges();
            int id = cfiRegisterUser.UserId;
            return id;
        }

        public List<CFIRegisterUser> GetCFIRegisterUserList()
        {
            return _biometricEntities.CFIRegisterUsers.ToList();
        } 
    }
}
