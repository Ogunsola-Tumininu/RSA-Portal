using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using PalRSA.Core.DataAccess;using PalRSA.Core.DataAccess;

namespace Recapture.DataAccess
{
    public class AgentDb
    {
        private readonly PALSiteDBEntities _biometricEntities = InternetConnection.CheckForInternetConnection();
        public List<Agent> GetAgentList()
        {
            return _biometricEntities.Agents.Where(x => x.Active).OrderBy(x => x.FirstName).ToList();
        }

        

        public void AddAgent(Agent agent)
        {
            _biometricEntities.Agents.Add(agent);
            _biometricEntities.SaveChanges();
        }

        public void UpdateAgent(Agent agent) 
        {
            _biometricEntities.Entry(agent).State = EntityState.Modified;
            _biometricEntities.SaveChanges();
        } 
    }
}
