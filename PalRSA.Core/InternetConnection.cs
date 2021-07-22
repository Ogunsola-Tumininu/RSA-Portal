using PalRSA.Core.DataAccess;
using System.Net;

namespace Recapture.DataAccess
{
    public class InternetConnection
    {
        public static PALSiteDBEntities CheckForInternetConnection()
        {
            try

            {
                using (var client = new WebClient())
                using (client.OpenRead("http://clients3.google.com/generate_204"))
                {
                    //return true;
                    return new PALSiteDBEntities();
                }
            }
            catch
            {
                return new PALSiteDBEntities();
                // return new PALSiteDBEntities("PALSiteDBEntitiesLocal");
            }
        }
    }
}