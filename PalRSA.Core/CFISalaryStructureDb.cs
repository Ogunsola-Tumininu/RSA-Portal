using PalRSA.Core.DataAccess;using PalRSA.Core.DataAccess;

namespace Recapture.DataAccess
{
    public class CfiSalaryStructureDb
    {
        private readonly PALSiteDBEntities _biometricEntities = InternetConnection.CheckForInternetConnection();

        public int AddCfiSalaryStructures(CFISalaryStructure cfiSalaryStructure)
        {
            _biometricEntities.CFISalaryStructures.Add(cfiSalaryStructure);
            _biometricEntities.SaveChanges();
            int id = cfiSalaryStructure.SalaryId;
            return id; 
        }
    }
}
