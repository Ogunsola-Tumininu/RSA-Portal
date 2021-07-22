using log4net;

namespace Recapture.Common
{
    public class AppLog
    {
        public static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

    }
}