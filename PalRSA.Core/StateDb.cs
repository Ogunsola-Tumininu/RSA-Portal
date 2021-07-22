using System.Collections.Generic;
using System.Linq;
using PalRSA.Core.DataAccess;using PalRSA.Core.DataAccess;
using System.Data.Entity;
using System.Data.Entity.Migrations;

namespace Recapture.DataAccess
{
    public class StateDb
    {
        private readonly PALSiteDBEntities _biometricEntities = InternetConnection.CheckForInternetConnection();
        public List<State> GetStateList()
        {
            return _biometricEntities.States.Where(m => m.Active).OrderBy(x => x.Name).ToList();
        }

        public void AddState(State state)
        {
            _biometricEntities.States.Add(state);
            _biometricEntities.SaveChanges();
        }

        public void UpdateState(State state)
        {

            _biometricEntities.Set<State>().AddOrUpdate(state);
            _biometricEntities.SaveChanges();
            //_biometricEntities.Entry(state).State = EntityState.Modified;
            //_biometricEntities.SaveChanges(); 
        }

    }
}
