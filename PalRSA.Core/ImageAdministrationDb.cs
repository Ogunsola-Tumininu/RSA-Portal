using PalRSA.Core.DataAccess;using PalRSA.Core.DataAccess;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Recapture.DataAccess
{
    public class ImageAdministrationDb
    {
        private readonly PALSiteDBEntities _biometricEntities = InternetConnection.CheckForInternetConnection();
        public List<ImageAdministration> GetImageAdministrationList()
        {
            return _biometricEntities.ImageAdministrations.Where(m => m.Active == true).ToList();
        }

        public void AddImageAdministration(ImageAdministration model)
        {
            _biometricEntities.ImageAdministrations.Add(model);
            _biometricEntities.SaveChanges();
        }

        public void UpdateImageAdministration(ImageAdministration model)
        {
            _biometricEntities.Entry(model).State = EntityState.Modified;
            _biometricEntities.SaveChanges();
        }

        public string GetImageAdministrationPassportStorePath()
        {
            
            return _biometricEntities.ImageAdministrations.Where(m => m.Active == true).Select(m=>m.PassportPhotograph).FirstOrDefault();
         
        }

        public string GetImageAdministrationSignaturePath()
        {
            return _biometricEntities.ImageAdministrations.Where(m => m.Active == true).Select(m => m.Signature).FirstOrDefault();
            
        }

        public string GetImageAdministrationRighThumbPath()
        {
            return _biometricEntities.ImageAdministrations.Where(m => m.Active == true).Select(m => m.RightThumb).FirstOrDefault();
        }

        public string GetImageAdministrationRighIndexPath()
        {
            return _biometricEntities.ImageAdministrations.Where(m => m.Active == true).Select(m => m.RightIndexFinger).FirstOrDefault();
        }

        public string GetImageAdministrationRighMiddlePath()
        {
            return _biometricEntities.ImageAdministrations.Where(m => m.Active == true).Select(m => m.RightMiddleFinger).FirstOrDefault();
        }

        public string GetImageAdministrationRighRingPath()
        {
            return _biometricEntities.ImageAdministrations.Where(m => m.Active == true).Select(m => m.RightRingFinger).FirstOrDefault();
        }

        public string GetImageAdministrationRighLittlePath()
        {
            return _biometricEntities.ImageAdministrations.Where(m => m.Active == true).Select(m => m.RightPinkyFinger).FirstOrDefault();
        }

        public string GetImageAdministrationLeftThumbPath()
        {
            return _biometricEntities.ImageAdministrations.Where(m => m.Active == true).Select(m => m.LeftThumb).FirstOrDefault();
        }

        public string GetImageAdministrationLeftIndexPath()
        {
            return _biometricEntities.ImageAdministrations.Where(m => m.Active == true).Select(m => m.LeftIndexFinger).FirstOrDefault();
        }

        public string GetImageAdministrationLeftMiddlePath()
        {
            return _biometricEntities.ImageAdministrations.Where(m => m.Active == true).Select(m => m.LeftMiddleFinger).FirstOrDefault();
        }

        public string GetImageAdministrationLeftRingPath()
        {
            return _biometricEntities.ImageAdministrations.Where(m => m.Active == true).Select(m => m.LeftRingFinger).FirstOrDefault();
        }

        public string GetImageAdministrationLeftLittlePath()
        {
            return _biometricEntities.ImageAdministrations.Where(m => m.Active == true).Select(m => m.LeftPinkyFinger).FirstOrDefault();
        }
    }
}
