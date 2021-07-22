using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PalRSA.Core.DataAccess;
using PalRSA.Core.Models;
using Recapture.Common;
using PalRSA.Core;
using System.Threading.Tasks;
using PalRSA.Helpers;
using System.IO;
using EntityState = System.Data.Entity.EntityState;

namespace PalRSA.Controllers
{
    [Authorize(Roles = "Customer,Client")] // 
    public class RecaptureController : Controller
    {
        private PALSiteDBEntities _db = new PALSiteDBEntities();

        // GET: Recapture
        public async Task<ActionResult> Home(string searchString)
        {
            // var cfiUsers = new CFIRegisterUser();
            ////if (!String.IsNullOrEmpty(searchString))
            ////{
            ////    var cfiUser = _db.CFIRegisterUsers.Where(d => d.Pin.Contains(searchString) || d.Email.Contains(searchString) || searchString.Contains(d.Mobile))
            ////           .Include(c => c.Country).Include(c => c.MartialStatu).Include(c => c.Country1).Include(c => c.Sex)
            ////           .Include(c => c.StateOfOrigin).Include(c => c.Title).ToList();

            //    return View(cfiUser.Take(100).OrderByDescending(d => d.DatetimeUpdated).ToList());

            //}

            var cfi = await _db.CFIRegisterUsers.FirstOrDefaultAsync(d => d.Pin == SessionHelper.UserName);//.Include(c => c.Country).Include(c => c.MartialStatu).Include(c => c.Country1).Include(c => c.Sex).Include(c => c.StateOfOrigin).Include(c => c.Title);
            if (cfi != null)
            {
                return RedirectToAction("edit");
            }
            return View(cfi);
        }

        // GET: Recapture/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CFIRegisterUser cFIRegisterUser = await _db.CFIRegisterUsers.FindAsync(id);
            if (cFIRegisterUser == null)
            {
                return HttpNotFound();
            }
            return View(cFIRegisterUser);
        }

        // GET: Recapture/Create
        public async Task<ActionResult> Create()
        {
            ViewBag.userReg = _db.Registrations.Where(d => d.Pin == User.Identity.Name).FirstOrDefault();
            GetList();
            return View();
        }

        // POST: Recapture/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "UserId,Pin,PFAName,BVN,NIN,IPN,TitleId,Surname,FirstName,MiddleName,EmployeeStatusId,MaidenName,MaritalStatusId,DateOfBirth,GenderId,NationalityId,PersonalStateOfOriginId,LGAId,City,Mobile,Phone,Email,MotherMaidenName,PlaceOfBirth,IsNigerian,HouseNo,StreetName,LGACode,StateCode,CountryCode,CountryOfResidanceId,ZIP,POBox")] CFIRegisterUser cFIRegisterUser)
        {
            if (ModelState.IsValid)
            {
                _db.CFIRegisterUsers.Add(cFIRegisterUser);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            GetList(cFIRegisterUser);

            return View(cFIRegisterUser);
        }


        // GET: Recapture/Edit/5
        public async Task<ActionResult> Edit()
        {
            var user = _db.CFIRegisterUsers.FirstOrDefault(d => d.Pin == User.Identity.Name);
            if (user == null)
            {
                return RedirectToAction("Create");
            }
            CFIRegisterUser cfi = _db.CFIRegisterUsers.FirstOrDefault(c => c.UserId == user.UserId);
            if (cfi == null)
            {
                return RedirectToAction("Create");
            }
            TempData["id"] = user.UserId;

            GetList(cfi);

            return View(cfi);

        }
        //
        // POST: Recapture/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = @"UserId,Email2,Pin,PFAName,BVN,NIN,IPN,TitleId,Surname,FirstName,MiddleName,EmployeeStatusId,
    MaritalStatusId,DateOfBirth,GenderId,NationalityId,PersonalStateOfOriginId,LGAId,City,Mobile,Phone,Email,MotherMaidenName,
PlaceOfBirth,IsNigerian,HouseNo,StreetName,LGACode,StateCode,CountryCode,CountryOfResidanceId,ZIP,POBox,CreatedBy,ModifiedBy,DatetimeUpdated,DatetimeCreated")] CFIRegisterUser cfi)
        {

            GetList(cfi);
            if (ModelState.IsValid)
            {
                if (cfi.DatetimeCreated == null)
                {
                    cfi.DatetimeCreated = DateTime.Now;
                }
                if (cfi.CreatedBy == null)
                {
                    cfi.CreatedBy = SessionHelper.UserName;
                }
                cfi.Channel = "Portal";
                cfi.DateUpdateChannel = DateTime.Now;
                cfi.DatetimeUpdated = DateTime.Now;
                cfi.ModifiedBy = SessionHelper.UserName;
                cfi.SentToPencom = false;
                try
                {
                    _db.Entry(cfi).State = EntityState.Modified;
                    await _db.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    TempData["error"] = ex.Message;
                    return View(cfi);
                }

                return RedirectToAction("AddEmployment", new { id = cfi.UserId });
            }

            return View(cfi);
        }

        #region Image/Biometrics Upload

        // GET: CFIBiometric/Create
        public ActionResult AddImages(int id)
        {
            var isOando = false;
            var cfi = _db.CFIRegisterUsers.FirstOrDefault(d => d.UserId == id);
            var employer = _db.CFIEmploymentDetails.FirstOrDefault(d => d.UserId == id);
            var image = _db.CFIBiometrics.Where(d => d.UserId == id).FirstOrDefault();
            if (image != null)
            {
                return RedirectToAction("EditImages", new { id = id });
            }
            //check whether the employee is Oando Staff
            if (employer != null)
            {
                if (employer.EmployerCode == "PR0000006474" || employer.EmployerCode == "PR0000614694")
                {
                    isOando = true;
                    var returnUrl = "https://pallite.palpensions.com/Recapture/AddImages/" + id.ToString();
                    var status = PalLibrary.Messaging.SendEmail("olusegun.obende@palpensions.com", "info@palpensions.com", "Oando Staff Initiated Recapture", $@"
                    <p>Dear Olusegun Obende</p>,<br/>

                    <p>Please be informed that a staff of {employer.EmployerName} with the following details has started recapture process</p> 

                    <span> Firstname : <b>{ cfi.FirstName }</b></span> <br/>
                    <span> Surname : <b>{ cfi.Surname }</b></span> <br/>
                    <span> PIN : <b> { cfi.Pin }</b></span> <br/>
                    <span> Email : <b> { cfi.Email }</b></span> <br/>
                    <span> Mobile : <b> { cfi.Mobile }</b></span> <br/>

                    <p>Kindly click the link below for review and authorization</p>
                    <p>{returnUrl}<p/>

                    <p>  Best Regards,</p>");
                }
            }
            ViewBag.IsOando = isOando;
            ViewBag.UserId = id;
            return View();
            // return RedirectToAction("SupportDoc", new { id = id });
        }


        // POST: CFIBiometric/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddImages([Bind(Include = "CFIBiometricId,UserId,Passport,ContributorSignature,CongentForm,Active")] CFIBiometric cFIBiometric)
        {
            var currentuser = User.Identity.Name;
            if (ModelState.IsValid)
            {
                int userId = cFIBiometric.UserId;
                var passportFile = Request.Files["passport"];
                var signatureFile = Request.Files["signature"];
                var congentFile = Request.Files["consent"];

                var passportFileName = string.Empty;
                var signatureFileName = string.Empty;
                var pfaSignatureFileName = string.Empty;
                var congentFileName = string.Empty;

                if (passportFile != null || signatureFile != null || congentFile != null)
                {
                    if (passportFile != null)
                    {
                        var storePath = GetImageAdministrationPassportStorePath();
                        if (!Directory.Exists(storePath))
                        {
                            Directory.CreateDirectory(storePath);
                        }
                        if (passportFile.FileName.Trim() != string.Empty)
                        {
                            passportFileName = cFIBiometric.UserId + "_CFIPassport" + Path.GetExtension(passportFile.FileName);
                            var serverSavePath = Path.Combine(storePath, passportFileName);
                            // Check file size
                            if (passportFile.ContentLength > 195500)    //97500(112KB)       65000                      75kb
                            {
                                TempData["error"] = "The passport size is too large. Allowed size is 112kb (2x2 Inches)";
                                return View(cFIBiometric);
                            }
                            passportFile.SaveAs(serverSavePath);
                        }
                    }
                    if (signatureFile != null)
                    {
                        var storePath = GetImageAdministrationSignaturePath();
                        if (!Directory.Exists(storePath))
                        {
                            Directory.CreateDirectory(storePath);
                        }
                        if (signatureFile.FileName.Trim() != string.Empty)
                        {
                            signatureFileName = userId + "_CFIContributor_Signature" + Path.GetExtension(signatureFile.FileName);

                            var serverSavePath = Path.Combine(storePath, signatureFileName);
                            // Check file size
                            if (signatureFile.ContentLength > 195500)   // 97500(112KB)      65000
                            {
                                TempData["error"] = "The signature size is too large. Allowed size is 112kb (2x2 Inches)";
                                return View(cFIBiometric);
                            }
                            signatureFile.SaveAs(serverSavePath);
                        }
                    }
                    if (congentFile != null)
                    {
                        var storePath = GetImageAdministrationCongentFormPath();
                        if (!Directory.Exists(storePath))
                        {
                            Directory.CreateDirectory(storePath);
                        }
                        if (congentFile.FileName.Trim() != string.Empty)
                        {
                            congentFileName = userId + "_CFIConsentForm" + Path.GetExtension(congentFile.FileName);

                            if (congentFile.ContentLength > 752880)   // 376440(300KB)       250960
                            {
                                TempData["error"] = "The ConsentForm size is too large. Allowed size is 300kb (7x10 Inches)";
                                return View(cFIBiometric);
                            }
                            var serverSavePath = Path.Combine(storePath, congentFileName);
                            congentFile.SaveAs(serverSavePath);
                        }
                    }
                    var biometric = new CFIBiometric
                    {
                        UserId = userId,
                        Passport = passportFileName,
                        ContributorSignature = signatureFileName,
                        CongentForm = congentFileName,
                        PFASignature = pfaSignatureFileName,
                        DatetimeUpdated = DateTime.Now,

                        Active = true,

                        DatetimeCreated = DateTime.Now
                    };
                    // cFIBiometric = biometric;
                }
                if (String.IsNullOrEmpty(passportFileName) || String.IsNullOrEmpty(signatureFileName) || string.IsNullOrEmpty(congentFileName))
                {
                    ModelState.AddModelError(String.Empty, "Please select images to upload");
                    ViewBag.UserId = cFIBiometric.UserId;//  new SelectList(_db.CFIRegisterUsers, "UserId", "Pin", cFIBiometric.UserId);
                    return View(cFIBiometric);
                }
                cFIBiometric.Passport = passportFileName;
                cFIBiometric.ContributorSignature = signatureFileName;
                cFIBiometric.CongentForm = congentFileName;
                cFIBiometric.CreatedBy = currentuser;
                cFIBiometric.DatetimeCreated = DateTime.Now;
                cFIBiometric.DatetimeUpdated = DateTime.Now;
                cFIBiometric.Active = true;
                _db.CFIBiometrics.Add(cFIBiometric);
                await _db.SaveChangesAsync();
                return RedirectToAction("SupportDoc", new { id = userId });
            }
            ViewBag.UserId = cFIBiometric.UserId;//  new SelectList(_db.CFIRegisterUsers, "UserId", "Pin", cFIBiometric.UserId);
            return View(cFIBiometric);
        }

        // GET: CFIBiometric/Edit/5
        public async Task<ActionResult> GetEmployeeImages(int? id) // id=> UserId
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeBiometric cFIBiometric = await _db.EmployeeBiometrics.FirstOrDefaultAsync(d => d.UserId == id);
            if (cFIBiometric == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = id;
            return View(cFIBiometric);
        }

        public async Task<ActionResult> EditImages(int? id) // id=> UserId
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CFIBiometric cFIBiometric = await _db.CFIBiometrics.FirstOrDefaultAsync(d => d.UserId == id);
            if (cFIBiometric == null)
            {
                return HttpNotFound();
            }

            // stop Oando staff from recapture
            var isOando = false;
            var cfi = _db.CFIRegisterUsers.FirstOrDefault(d => d.UserId == id);
            var employer = _db.CFIEmploymentDetails.FirstOrDefault(d => d.UserId == id);
            if (employer != null)
            {
                if (employer.EmployerCode == "PR0000006474" || employer.EmployerCode == "PR0000614694")
                {
                    isOando = true;
                    var returnUrl = "https://pallite.palpensions.com/Recapture/EditImages/" + id.ToString();
                    var status = PalLibrary.Messaging.SendEmail("olusegun.obende@palpensions.com", "info@palpensions.com", "Oando Staff Initiated Recapture", $@"
                    <p>Dear Olusegun Obende</p>,<br/>

                    <p>Please be informed that a staff of {employer.EmployerName} with the following details has started recapture process</p> 

                    <span> Firstname : <b>{ cfi.FirstName }</b></span> <br/>
                    <span> Surname : <b>{ cfi.Surname }</b></span> <br/>
                    <span> PIN : <b> { cfi.Pin }</b></span> <br/>
                    <span> Email : <b> { cfi.Email }</b></span> <br/>
                    <span> Mobile : <b> { cfi.Mobile }</b></span> <br/>

                    <p>Kindly click the link below for review and authorization</p>
                    <p>{returnUrl}<p/>

                    <p>  Best Regards,</p>");
                }
            }
            ViewBag.IsOando = isOando;
            ViewBag.UserId = id;
            return View(cFIBiometric);
        }
        // POST: CFIBiometric/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditImages([Bind(Include = "CFIBiometricId,UserId,Passport,ContributorSignature,CongentForm,Active,DatetimeCreated")] CFIBiometric cFIBiometric)
        {

            var empBio = _db.EmployeeBiometrics.Where(c => c.UserId == cFIBiometric.UserId).FirstOrDefault();
            if (empBio == null)
            {

            }
            else
            {
                _db.EmployeeBiometrics.Remove(empBio);
                _db.SaveChanges();

            }

            ViewBag.UserId = cFIBiometric.UserId;
            var currentuser = User.Identity.Name;
            if (ModelState.IsValid)
            {
                int userId = cFIBiometric.UserId;
                var passportFile = Request.Files["passport"];
                var signatureFile = Request.Files["signature"];
                var congentFile = Request.Files["consent"];
                // var pfaSignatureFile = Request.Files["pfaSignature"];

                var passportFileName = string.Empty;
                var signatureFileName = string.Empty;
                var pfaSignatureFileName = string.Empty;
                var congentFileName = string.Empty;
                if (passportFile != null || signatureFile != null || congentFile != null)
                {
                    if (passportFile != null)
                    {
                        var storePath = GetImageAdministrationPassportStorePath();
                        if (!Directory.Exists(storePath))
                        {
                            Directory.CreateDirectory(storePath);
                        }
                        if (passportFile.FileName.Trim() != string.Empty)
                        {
                            passportFileName = cFIBiometric.UserId + "_CFIPassport" + Path.GetExtension(passportFile.FileName);
                            var serverSavePath = Path.Combine(storePath, passportFileName);
                            // Check file size
                            if (passportFile.ContentLength > 195500)  //97500 (112KB)    65000
                            {
                                TempData["error"] = "The passport size is too large. Allowed size is 112kb (2x2 Inches)";
                                return View(cFIBiometric);
                            }


                            passportFile.SaveAs(serverSavePath);
                        }
                    }
                    if (signatureFile != null)
                    {
                        var storePath = GetImageAdministrationSignaturePath();
                        if (!Directory.Exists(storePath))
                        {
                            Directory.CreateDirectory(storePath);
                        }
                        if (signatureFile.FileName.Trim() != string.Empty)
                        {
                            signatureFileName = userId + "_CFIContributor_Signature" + Path.GetExtension(signatureFile.FileName);

                            var serverSavePath = Path.Combine(storePath, signatureFileName);

                            // Check file size // Check file size
                            if (signatureFile.ContentLength > 195500)  // 97500 (112KB)      65000
                            {
                                TempData["error"] = "The signature size is too large. Allowed size is 112kb (2x2 Inches)";
                                return View(cFIBiometric);
                            }

                            signatureFile.SaveAs(serverSavePath);
                        }
                    }
                    if (congentFile != null)
                    {
                        var storePath = GetImageAdministrationCongentFormPath();
                        if (!Directory.Exists(storePath))
                        {
                            Directory.CreateDirectory(storePath);
                        }
                        if (congentFile.FileName.Trim() != string.Empty)
                        {
                            congentFileName = userId + "_CFIConsentForm" + Path.GetExtension(congentFile.FileName);

                            // Check file size // Check file size
                            if (congentFile.ContentLength > 752880)  // 376440(300KB)    250960
                            {
                                TempData["error"] = "The Consent Form size is too large. Allowed size is 300kb (7x10 Inches)";
                                return View(cFIBiometric);
                            }
                            var serverSavePath = Path.Combine(storePath, congentFileName);
                            congentFile.SaveAs(serverSavePath);
                        }
                    }

                }
                var biometric = _db.CFIBiometrics.FirstOrDefault(d => d.UserId == cFIBiometric.UserId);
                if (String.IsNullOrEmpty(passportFileName))
                {
                    passportFileName = biometric.Passport;
                }
                if (String.IsNullOrEmpty(signatureFileName))
                {
                    signatureFileName = biometric.ContributorSignature;
                }
                if (String.IsNullOrEmpty(congentFileName))
                {
                    congentFileName = biometric.CongentForm;
                }

                biometric.Passport = passportFileName;
                biometric.ContributorSignature = signatureFileName;
                biometric.CongentForm = congentFileName;
                biometric.ModifiedBy = currentuser;
                biometric.SentToPencom = null;
                biometric.DatetimeUpdated = DateTime.Now;
                _db.Entry(biometric).State = EntityState.Modified;
                await _db.SaveChangesAsync();
                return RedirectToAction("SupportDoc", new { id = userId });
            }

            return View();
        }



        public ActionResult ShowPassport(int id)
        {
            var image = _db.CFIBiometrics.FirstOrDefault(d => d.UserId == id);

            var file = GetImageAdministrationPassportStorePath() + "\\" + image.Passport;
            var ext = file.Split('.').Last();
            return File(file, "image/" + ext, Path.GetFileName(file));
        }

        public ActionResult ShowSignature(int id)
        {
            var image = _db.CFIBiometrics.FirstOrDefault(d => d.UserId == id);
            var file = GetImageAdministrationSignaturePath() + "\\" + image.ContributorSignature;
            var ext = file.Split('.').Last();
            return File(file, "image/" + ext, Path.GetFileName(file));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">Support document id</param>
        /// <returns></returns>
        public ActionResult ShowSupportFile(int id)
        {
            var image = _db.CFISupportDocuments.FirstOrDefault(d => d.SupportDocId == id);
            var file = GetImageSupportDocPath() + "\\" + image.DocumentName;
            var ext = file.Split('.').Last();

            String[] imageExtensions = { "gif", "png", "jpeg", "jpg" };

            if (ext.ToLower() == "pdf")
            {
                return File(file, "application/" + ext, Path.GetFileName(file));
            }
            else if (imageExtensions.Contains(ext.ToLower()))
            {
                return File(file, "image/" + ext, Path.GetFileName(file));
            }
            else
            {
                return File(file, "application/" + ext, Path.GetFileName(file));
            }
        }
        public ActionResult ShowCongentForm(int id)
        {
            var image = _db.CFIBiometrics.FirstOrDefault(d => d.UserId == id);
            var file = GetImageAdministrationCongentFormPath() + "\\" + image.CongentForm;
            var ext = file.Split('.').Last();
            return File(file, "image/" + ext, Path.GetFileName(file));
        }
        private string GetImageAdministrationSignaturePath()
        {
            return _db.ImageAdministrations.Select(d => d.Signature).First();
        }
        private string GetImageAdministrationCongentFormPath()
        {
            return _db.ImageAdministrations.Select(d => d.CongentForm).First();
        }
        private string GetImageAdministrationPassportStorePath()
        {
            return _db.ImageAdministrations.Select(d => d.PassportPhotograph).First();
        }
        private string GetImageSupportDocPath()
        {
            return _db.ImageAdministrations.Select(d => d.SupportDocument).First();
        }
        #endregion
        [HttpGet]
        public ActionResult SupportDoc(int? id) // id= UserId
        {
            var cfi = _db.CFIRegisterUsers.FirstOrDefault(d => d.UserId == id);
            ViewBag.UserId = id;
            ViewBag.CFIPublicPrivateID = new SelectList(_db.CFIPublicPrivateSectors.Where(d => d.Active == true), "CFIPublicPrivateID", "Name");
            ViewBag.DocumentId = new SelectList(_db.CFIDocuments.Where(d => d.Active == true), "DocumentId", "Name");
            ViewBag.Pin = cfi.Pin;
            return View();

        }

        [HttpPost]
        public ActionResult SupportDoc(CFISupportDocument doc, int id, string submit)
        {
            ViewBag.Pin = User.Identity.Name;
            ViewBag.UserId = doc.UserId;
            ViewBag.CFIPublicPrivateID = new SelectList(_db.CFIPublicPrivateSectors.Where(d => d.Active == true), "CFIPublicPrivateID", "Name");

            ViewBag.DocumentId = new SelectList(_db.CFIDocuments.Where(d => d.Active == true), "DocumentId", "Name", doc.DocumentId);
            doc.CFIDocument = _db.CFIDocuments.Find(doc.DocumentId);

            //  var documentName = Request.Form["BenefitDocument"];
            switch (submit)
            {
                case "Upload":
                    {
                        String[] allowedExtensions = { ".gif", ".png", ".jpeg", ".jpg", ".pdf" };
                        bool fileOK = false;
                        string fileName = "";
                        try
                        {
                            foreach (string file in Request.Files)
                            {

                                // create object that provide access to uploaded files

                                HttpPostedFileBase hpf = Request.Files[file] as HttpPostedFileBase;
                                if (hpf.ContentLength == 0)
                                {
                                    continue;
                                }

                                //Test file extension
                                fileOK = allowedExtensions.Contains(Path.GetExtension(hpf.FileName.ToLower()));

                                // string path = AppDomain.CurrentDomain.BaseDirectory + "uploads\\CFIDocuments";
                                string path = GetImageSupportDocPath();

                                //Create Directory if not exist
                                if (!Directory.Exists(path))
                                {
                                    Directory.CreateDirectory(path);
                                }

                                if (fileOK)
                                {
                                    try
                                    {
                                        fileName = Path.GetFileName(doc.Pin + "_" + doc.CFIDocument.Name
                                                                        + "_" + DateTime.Now.Date.ToString("yyyyMMdd")) + Path.GetExtension(hpf.FileName);

                                        string fullFileName = Path.Combine(path, fileName); //

                                        hpf.SaveAs(fullFileName);

                                        doc.DocumentName = fileName;
                                        doc.UserId = id;
                                        doc.DatetimeCreated = DateTime.Now;
                                        doc.DatetimeUpdated = DateTime.Now;

                                        //if (ModelState.IsValid) //&& fileOK
                                        // {
                                        _db.CFISupportDocuments.Add(doc);
                                        _db.SaveChanges();
                                        //GetLists();

                                        TempData["success"] = "Upload successful. You can upload more document";

                                    }
                                    catch (Exception ex)
                                    {
                                        TempData["error"] = "Upload error: " + ex.Message;
                                    }
                                    //return RedirectToAction("upload");
                                }
                                else
                                {
                                    fileOK = false;
                                    TempData["error"] = "Oops!!! Invalid file found";
                                }

                            }
                        }
                        catch (Exception ex)
                        {
                            TempData["error"] = "Upload failed: " + ex.Message;
                        }
                        return View(doc);
                    }
                case "Submit":    //Complete
                    {
                        // TempData["success"] = "Data recapture submitted successfully";
                        // return RedirectToAction("index");
                        try
                        {

                            var emailConfirm = _db.CFIRegisterUsers.FirstOrDefault(d => d.Pin == doc.Pin);

                            //encrypt Pin here
                            byte[] b = System.Text.ASCIIEncoding.ASCII.GetBytes(emailConfirm.Pin);
                            string encrypted = Convert.ToBase64String(b);

                            var checkemailRepository = _db.EmailRepositories.Where(d => d.Pin == doc.Pin).FirstOrDefault();
                            if (checkemailRepository == null)
                            {
                                EmailRepository emailrepo = new EmailRepository();

                                emailrepo.Id = emailConfirm.UserId;
                                emailrepo.Pin = emailConfirm.Pin;
                                emailrepo.email = emailConfirm.Email;
                                emailrepo.IsSent = true;
                                emailrepo.DateCreated = DateTime.Now;

                                //byte[] b = System.Text.ASCIIEncoding.ASCII.GetBytes(emailConfirm.Pin);
                                //string encrypted = Convert.ToBase64String(b);
                                emailrepo.Token = encrypted;

                                _db.EmailRepositories.Add(emailrepo);
                                _db.SaveChanges();
                            }
                            else
                            {

                            }

                            //var emailUrl = "https://palllite.palpensions.com/Home/welcome?token=";    //  https://localhost:44301/Home/welcome?token=UEFMMDAx
                            var emailUrl = "https://palrsa.palpensions.com/account/welcome?token=";
                            var tokens = encrypted;
                            var returnURL = emailUrl + encrypted;


                            try
                            {
                                var clintemail = _db.CFIRegisterUsers.FirstOrDefault(d => d.Pin == doc.Pin);

                                var status = PalLibrary.Messaging.SendEmail(clintemail.Email, "info@palpensions.com", "Please Verify Your Email", $@"
                        <p>Dear {clintemail.Surname} {clintemail.FirstName},<br/>

                    <p>Thank you for choosing PAL PENSIONS.   <br />
                    In order to complete your recapture, kindly click the link below to verify your email address  <br/>

                    <p> {returnURL} </p>

                    </p>
                    
                     <p> If you encounter any problems with clicking the link, simply copy and paste it in your browser.  <br/>

                        Best Regards,
                        </p>");
                            }

                            catch (Exception ex)
                            {
                            }


                            //Send email to client and ECRS team on submission
                            //Check for client's detail
                            var clientDeatil = _db.CFIRegisterUsers.FirstOrDefault(d => d.Pin == doc.Pin);

                            try
                            {
                                //send mail to client
                                var msg = PalLibrary.Messaging.SendEmail(clientDeatil.Email, "info@palpensions.com", $"RSA Portal - DATA RECAPTURE SUBMISSION {clientDeatil.Pin}", $@"
                              
                                <p>Dear {clientDeatil.Surname} {clientDeatil.FirstName}: <br />
                     
                                <p>
                                     We have received your data recapture submission. <br/>
                                     Please note you will receive a confirmation notification via SMS once your recapture has been validated by the National Pension Commission.

                                </p>                   
                            <hr />    
   
                        <p>         Your PAL For Life. </p>");

                            }
                            catch (Exception)
                            {

                            }

                            finally
                            {
                                var urlEcrs = "https://pallite.palpensions.com/Recapture/Edit/";
                                var returnedUrl = urlEcrs + clientDeatil.UserId;

                                //Send mail to ECRS team      
                                var status1 = PalLibrary.Messaging.SendEmail("ecrs@palpensions.com", "info@palpensions.com", "RSA Portal - DATA RECAPTURE SUBMISSION", $@"
                        <p>Dear Recapture team<br/>

                          <p>Please be informed that a new data recapture has been submitted. <br />
                            <p> The detail of the client is as follows:   <br/>

                        Surname: <strong>{clientDeatil.Surname}</strong> <br />
                        First Name: <strong> {clientDeatil.FirstName} </strong> <br/>
                        NIN: <strong> {clientDeatil.NIN} </strong> <br/>
                        Email: <strong> {clientDeatil.Email} </strong> <br/>   
                        Mobile: <strong> {clientDeatil.Mobile} </strong> <br/> 

                        Kindly click the link below for review and authorization
                        <p>  {returnedUrl}  </p>
                           

                            </p>
                       <strong> <hr/> </strong>

                        <p> Regards<br/>

                        PAL Pensions</p>");
                            }


                        }
                        catch (Exception)
                        {

                        }




                        TempData["success"] = "Data recapture submitted successfully";
                        //return RedirectToAction("index"); 
                        return RedirectToAction("summary", new { id = id });

                    }
                default:
                    {
                        return View(doc);
                    }
            }

            return View(doc);
        }



        [HttpPost]
        public ActionResult SupportDoc_Old(CFISupportDocument doc, int id, string submit)
        {
            ViewBag.Pin = User.Identity.Name;
            ViewBag.UserId = doc.UserId;
            ViewBag.CFIPublicPrivateID = new SelectList(_db.CFIPublicPrivateSectors.Where(d => d.Active == true), "CFIPublicPrivateID", "Name");

            ViewBag.DocumentId = new SelectList(_db.CFIDocuments.Where(d => d.Active == true), "DocumentId", "Name", doc.DocumentId);
            doc.CFIDocument = _db.CFIDocuments.Find(doc.DocumentId);

            //
            //  var documentName = Request.Form["BenefitDocument"];
            switch (submit)
            {
                case "Upload":
                    {
                        //
                        String[] allowedExtensions = { ".gif", ".png", ".jpeg", ".jpg", ".pdf" };

                        bool fileOK = false;
                        string fileName = "";
                        try
                        {//

                            foreach (string file in Request.Files)
                            {
                                //
                                //create object that provide access to uploaded files

                                HttpPostedFileBase hpf = Request.Files[file] as HttpPostedFileBase;
                                if (hpf.ContentLength == 0)
                                {
                                    continue;
                                }

                                //Test file extension
                                fileOK = allowedExtensions.Contains(Path.GetExtension(hpf.FileName.ToLower()));

                                // string path = AppDomain.CurrentDomain.BaseDirectory + "uploads\\CFIDocuments";
                                string path = GetImageSupportDocPath();

                                //Create Directory if not exist
                                if (!Directory.Exists(path))
                                {
                                    Directory.CreateDirectory(path);
                                }

                                if (fileOK)
                                {
                                    try
                                    {
                                        //fileName = Path.GetFileName(doc.Pin + "_" + doc.CFIDocument.Name
                                        //                                + "_" + DateTime.Now.Date.ToString("yyyyMMdd")) + Path.GetExtension(hpf.FileName);
                                        fileName = Path.GetFileName(doc.Pin + "_" + doc.ECRSPrivatePublicSector.Name
                                                                        + "_" + DateTime.Now.Date.ToString("yyyyMMdd")) + Path.GetExtension(hpf.FileName);

                                        string fullFileName = Path.Combine(path, fileName); //

                                        hpf.SaveAs(fullFileName);

                                        doc.DocumentName = fileName;
                                        doc.UserId = id;
                                        doc.DatetimeCreated = DateTime.Now;
                                        doc.DatetimeUpdated = DateTime.Now;

                                        //if (ModelState.IsValid) //&& fileOK
                                        // {
                                        _db.CFISupportDocuments.Add(doc);
                                        _db.SaveChanges();
                                        //GetLists();

                                        TempData["success"] = "Upload successful. You can upload more document";

                                    }
                                    catch (Exception ex)
                                    {
                                        TempData["error"] = "Upload error: " + ex.Message;
                                    }
                                    //return RedirectToAction("upload");
                                }
                                else
                                {
                                    fileOK = false;
                                    TempData["error"] = "Oops!!! Invalid file found";
                                }

                            }
                        }
                        catch (Exception ex)
                        {
                            TempData["error"] = "Upload failed: " + ex.Message;
                        }


                        return View(doc);
                    }
                case "Complete":
                    {
                        TempData["success"] = "Data recapture submitted successfully";
                        return RedirectToAction("summary", new { id = id });
                    }


                default:
                    {

                        return View(doc);
                    }
            }
            //
            return View(doc);
        }


        public ActionResult DeleteSupportDoc(int id)
        {
            string path = GetImageSupportDocPath();
            var doc = _db.CFISupportDocuments.FirstOrDefault(d => d.SupportDocId == id);
            var fileName = path + "\\" + doc.DocumentName;
            if (System.IO.File.Exists(fileName))
            {
                System.IO.File.Delete(fileName);
            }
            var deleteddoc = _db.CFISupportDocuments.Where(o => o.SupportDocId == id).FirstOrDefault();
            _db.CFISupportDocuments.Remove(deleteddoc);
            _db.SaveChanges();
            //return Json("Succeful", JsonRequestBehavior.AllowGet);
            return RedirectToAction("SupportDoc", "Recapture", new { id = deleteddoc.UserId });
        }

        //public ActionResult summary(int id)
        //{
        //    var cfi = _db.CFIRegisterUsers.FirstOrDefault(d => d.UserId == id);
        //    return View(cfi);
        //}

        public async Task<ActionResult> Summary(int id)
        {
            var cFIRegisterUsers = _db.CFIRegisterUsers.Where(c => c.UserId == id).Include(c => c.Country).Include(c => c.MartialStatu).Include(c => c.Country1).Include(c => c.Sex)
                .Include(c => c.StateOfOrigin).Include(c => c.Title).Include(c => c.CFIEmploymentDetail).FirstOrDefault();
            return View(cFIRegisterUsers);
        }

        #region Salary Structure
        // GET: CFISalary/Create
        public ActionResult AddSalary(int id)
        {
            var salary = _db.CFISalaryStructures.Where(d => d.UserId == id).FirstOrDefault();
            if (salary != null)
            {
                return RedirectToAction("EditSalary", new { id = id });
            }

            ViewBag.UserId = id;
            GetSalaryList();
            return View();
        }

        // POST: CFISalary/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddSalary([Bind(Include = "SalaryId,UserId,HarmonisedSalary,ConsolidatedSalary2007,ConsolidatedSalary2010,GL2004,Step2004,GL2007,Step2007,GL2010,Step2010,CurrentSalary,CurrentGL,CurrentStep")]
        CFISalaryStructure salary, string submit)
        {
            if (submit.ToLower() == "skip")
            {
                return RedirectToAction("AddImages", new { id = salary.UserId });
            }
            if (ModelState.IsValid)
            {
                salary.DatetimeCreated = DateTime.Now;
                salary.DatetimeUpdated = DateTime.Now;
                _db.CFISalaryStructures.Add(salary);
                await _db.SaveChangesAsync();
                return RedirectToAction("AddImages", new { id = salary.UserId });
            }

            ViewBag.UserId = salary.UserId;
            GetSalaryList(salary);
            return View(salary);
        }

        // GET: CFISalary/Edit/5
        public async Task<ActionResult> EditSalary(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CFISalaryStructure salary = await _db.CFISalaryStructures.FirstOrDefaultAsync(d => d.UserId == id);
            if (salary == null)
            {
                return HttpNotFound();
            }

            GetSalaryList(salary);
            return View(salary);
        }

        // POST: CFISalary/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditSalary([Bind(Include = "SalaryId,UserId,HarmonisedSalary,ConsolidatedSalary2007,ConsolidatedSalary2010,GL2004,Step2004,GL2007,Step2007,GL2010,Step2010,CurrentSalary,CurrentGL,CurrentStep,DatetimeCreated")]
        CFISalaryStructure salary, string submit)
        {
            if (submit.ToLower() == "skip")
            {
                return RedirectToAction("AddImages", new { id = salary.UserId });
            }
            if (ModelState.IsValid)
            {
                salary.DatetimeUpdated = DateTime.Now;

                _db.Entry(salary).State = EntityState.Modified;
                await _db.SaveChangesAsync();
                return RedirectToAction("AddImages", new { id = salary.UserId });
            }
            GetSalaryList(salary);
            return View(salary);
        }

        #endregion

        #region NOK
        // GET: CFINextOfKin/Create
        public ActionResult AddNok(int id)
        {
            //var cfi = _db.CFIRegisterUsers.FirstOrDefault(d => d.UserId == id);
            //if (cfi != null)
            //{
            var kin = _db.CFINextOfKins.Where(d => d.UserId == id).FirstOrDefault();
            if (kin != null)
            {
                return RedirectToAction("EditNok", new { id = id });
            }
            //  }

            ViewBag.UserId = id;
            GetNOKList();

            return View();
        }

        // POST: CFINextOfKin/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddNok([Bind(Include = "NextOfKinId,UserId,KinGenderId,KinTitleId,Surname,FirstName,MiddleName,RelationshipId,IsNigerian,HouseNo,Street,City,LGAId,StateId,CountryId,ZIP,POBox,Email,PhoneNo,MobileNo")] CFINextOfKin kin)
        {
            var currentuser = User.Identity.Name;
            // if (ModelState.IsValid)
            {
                try
                {
                    kin.DatetimeCreated = DateTime.Now;
                    kin.DatetimeUpdated = DateTime.Now;
                    kin.Createdby = currentuser;

                    _db.CFINextOfKins.Add(kin);
                    await _db.SaveChangesAsync();
                    return RedirectToAction("addSalary", new { id = kin.UserId });
                }
                catch (Exception ex)
                {
                    TempData["error"] = "Error:  " + ex.Message;

                }


            }
            //else
            //{
            //    ModelState.AddModelError(ModelState.)
            //}
            ViewBag.UserId = kin.UserId;
            GetNOKList(kin);

            return View(kin);

        }

        // GET: CFINextOfKin/Edit/5
        public async Task<ActionResult> EditNok(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CFINextOfKin kin = await _db.CFINextOfKins.FirstAsync(d => d.UserId == id);
            if (kin == null)
            {
                return HttpNotFound();
            }

            ViewBag.UserId = kin.UserId;
            GetNOKList(kin);

            return View(kin);
        }

        // POST: CFINextOfKin/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditNok([Bind(Include = "NextOfKinId,UserId,KinGenderId,KinTitleId,Surname,FirstName,MiddleName,RelationshipId,IsNigerian,HouseNo,Street,City,LGAId,StateId,CountryId,ZIP,POBox,Email,PhoneNo,MobileNo")] CFINextOfKin kin)
        {
            var currentuser = User.Identity.Name;
            if (ModelState.IsValid)
            {
                try
                {
                    kin.DatetimeCreated = DateTime.Now;
                    kin.DatetimeUpdated = DateTime.Now;
                    kin.Modifiedby = currentuser;
                    _db.Entry(kin).State = EntityState.Modified;
                    await _db.SaveChangesAsync();
                    return RedirectToAction("addSalary", new { id = kin.UserId });
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(String.Empty, ex.Message);
                    ViewBag.UserId = kin.UserId;
                    GetNOKList(kin);

                    return View(kin);

                }

            }
            ViewBag.UserId = kin.UserId;
            GetNOKList(kin);

            return View(kin);
        }

        private void GetNOKList(CFINextOfKin kin)
        {
            var countries = _db.Countries.ToList();
            var states = _db.States.OrderBy(x => x.Name).ToList();

            ViewBag.KinGenderId = new SelectList(_db.Sexes, "SexId", "Name", kin.KinGenderId);
            if (kin.CountryId == null)
            {
                ViewBag.CountryId = new SelectList(_db.Countries, "CountryId", "Name", 160);
            }
            else
            {
                ViewBag.CountryId = new SelectList(_db.Countries, "CountryId", "Name", kin.CountryId);
            }

            var stateCode = _db.States.FirstOrDefault(d => d.StateId == kin.StateId);

            ViewBag.StateId = new SelectList(states, "StateId", "Name", kin.StateId);
            if (kin.StateId == null)
            {
                ViewBag.LGAId = new SelectList(_db.LGAreas.ToList(), "LGAId", "Name", kin.LGAId);
            }
            else
            {
                ViewBag.LGAId = new SelectList(_db.LGAreas.Where(d => d.StateCode == stateCode.StateCode).ToList(), "LGAId", "Name", kin.LGAId);
            }

            ViewBag.RelationshipId = new SelectList(_db.Relationships, "RelationshipId", "Name", kin.RelationshipId);
            ViewBag.KinTitleId = new SelectList(_db.Titles.Where(d => d.Active == true), "TitleId", "Name", kin.KinTitleId);
        }
        private void GetNOKList()
        {
            var countries = _db.Countries.ToList();
            var states = _db.States.OrderBy(x => x.Name).ToList();
            //
            ViewBag.CountryId = new SelectList(countries, "CountryId", "Name", 160);
            ViewBag.StateId = new SelectList(states, "StateId", "Name");
            ViewBag.LGAId = new SelectList(_db.LGAreas.Take(10), "LGAId", "Name");
            ViewBag.RelationshipId = new SelectList(_db.Relationships.Where(d => d.Active == true), "RelationshipId", "Name");
            ViewBag.KinTitleId = new SelectList(_db.Titles.Where(d => d.Active == true), "TitleId", "Name");
            ViewBag.KinGenderId = new SelectList(_db.Sexes, "SexId", "Name");
            //  
        }



        #endregion

        // GET: CFIEmployment/Create
        public ActionResult AddEmployment(int id) // id=UserId
        {
            var cfi = _db.CFIRegisterUsers.FirstOrDefault(d => d.UserId == id);
            if (cfi != null)
            {
                var cfiEr = _db.CFIEmploymentDetails.Where(d => d.UserId == cfi.UserId).FirstOrDefault();
                if (cfiEr != null)
                {
                    return RedirectToAction("EditEmployment", new { id = cfiEr.UserId });
                }
            }

            GetEmployementLists();
            ViewBag.UserId = id;
            return View();
        }

        // POST: CFIEmployment/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> AddEmployment([Bind(Include = "EmploymentDetailId,UserId,SectorId,IsEmployerIPPIS,NatureofBusiness,EmployerName,EmployerCode,OfficeName,OfficeStreetName,OfficeStateCode,OfficeLGACode,IsNigerian,Building,Street,City,LocalGovernmentCode,StateCode,CountryCode,ZIP,POBox,PhoneNo,MobileNo,EmployeeId,ServiceIdNo,Designation,DateOfFirstAppointment,DateOfCurrentAppointment")] CFIEmploymentDetail cfiEr)
        //{
        //    if (ModelState.IsValid)
        //        try
        //        {
        //            cfiEr.DatetimeUpdated = DateTime.Now;
        //            cfiEr.DatetimeUpdated = DateTime.Now;
        //            cfiEr.ModifiedBy = SessionHelper.UserName;
        //            _db.CFIEmploymentDetails.Add(cfiEr);
        //            await _db.SaveChangesAsync();
        //            return RedirectToAction("addNok", new { id = cfiEr.UserId });
        //        }
        //        catch (Exception ex)
        //        {
        //            ModelState.AddModelError("", ex.Message);
        //        }
        //    GetEmployementLists(cfiEr);
        //    return View(cfiEr);
        //}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddEmployment([Bind(Include = "EmploymentDetailId,UserId,SectorId,IsEmployerIPPIS,EmployerCode,EmployerName,IsNigerian,Building,NatureofBusiness,Street,City,LocalGovernmentCode,StateCode,CountryCode,OfficeName,OfficeStreetName,OfficeStateCode,OfficeLGACode,ZIP,POBox,PhoneNo,MobileNo,EmployeeId,ServiceIdNo,Designation,DateOfFirstAppointment,DateOfCurrentAppointment")] CFIEmploymentDetail cfiEr)
        {
            GetEmployementLists(cfiEr);
            // if (ModelState.IsValid)
            if (cfiEr.SectorId == 3 && !cfiEr.EmployerCode.StartsWith("MP"))
            {
                TempData["error"] = $"The employer code selected is not for Micro Pension ";
                return View(cfiEr);
            }
            {

                cfiEr.DatetimeCreated = DateTime.Now;
                cfiEr.CreatedBy = SessionHelper.UserName;
                try
                {
                    _db.CFIEmploymentDetails.Add(cfiEr);
                    await _db.SaveChangesAsync();
                    return RedirectToAction("addNok", new { id = cfiEr.UserId });
                }
                catch (Exception ex)
                {

                    ModelState.AddModelError("", ex.Message);
                }
            }
            // GetEmployementLists(cfiEr);
            return View(cfiEr);
        }


        // GET: CFIEmployment/Edit/5
        public async Task<ActionResult> EditEmployment(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CFIEmploymentDetail cFIEmploymentDetail = await _db.CFIEmploymentDetails.FirstOrDefaultAsync(d => d.UserId == id);

            if (cFIEmploymentDetail == null)
            {
                return HttpNotFound();
            }

            GetEmployementLists(cFIEmploymentDetail);
            return View(cFIEmploymentDetail);
        }

        //// POST: CFIEmployment/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> EditEmployment(CFIEmploymentDetail cfiEr)
        //{
        //    try
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            cfiEr.DatetimeUpdated = DateTime.Now;
        //            cfiEr.ModifiedBy = SessionHelper.UserName;
        //            _db.Entry(cfiEr).State = EntityState.Modified;
        //            await _db.SaveChangesAsync();
        //            return RedirectToAction("addNok", new { id = cfiEr.UserId });
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        ModelState.AddModelError("", ex.Message);
        //    }
        //    GetEmployementLists(cfiEr);

        //    return View(cfiEr);
        //}


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditEmployment(CFIEmploymentDetail cfiEr)
        {
            GetEmployementLists(cfiEr);
            if (cfiEr.SectorId == 3 && !cfiEr.EmployerCode.StartsWith("MP"))
            {
                TempData["error"] = $"The employer code selected is not for Micro Pension ";
                return View(cfiEr);
            }

            if (ModelState.IsValid)
            {
                try
                {
                    cfiEr.DatetimeUpdated = DateTime.Now;
                    cfiEr.ModifiedBy = SessionHelper.UserName;
                    _db.Entry(cfiEr).State = EntityState.Modified;
                    await _db.SaveChangesAsync();
                    return RedirectToAction("addNok", new { id = cfiEr.UserId });
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                }
            }
            // GetEmployementLists(cfiEr);
            return View(cfiEr);
        }



        private void GetEmployementLists()
        {
            var countries = _db.Countries.ToList();
            var states = _db.States.OrderBy(x => x.Name).ToList();
            ViewBag.CountryCode = new SelectList(countries, "NumCode", "Name", 566);
            ViewBag.StateCode = new SelectList(states, "StateCode", "Name");
            ViewBag.LocalGovernmentCode = new SelectList(_db.LGAreas.OrderBy(d => d.Name), "LGACode", "Name");
            ViewBag.SectorId = new SelectList(_db.Sectors, "SectorId", "Name");
            ViewBag.OfficeStateCode = new SelectList(states, "StateCode", "Name");
            ViewBag.OfficeLGACode = new SelectList(_db.LGAreas.OrderBy(d => d.Name), "LGACode", "Name");
        }
        private void GetEmployementLists(CFIEmploymentDetail cfiEr)
        {
            var countries = _db.Countries.ToList();
            var states = _db.States.OrderBy(x => x.Name).ToList();
            ViewBag.CountryCode = new SelectList(countries, "NumCode", "Name", cfiEr.CountryCode);
            ViewBag.StateCode = new SelectList(states, "StateCode", "Name", cfiEr.StateCode);
            var stateCode = _db.States.FirstOrDefault(d => d.StateCode == cfiEr.StateCode);
            ViewBag.LocalGovernmentCode = new SelectList(_db.LGAreas.Where(d => d.StateCode == stateCode.StateCode).OrderBy(d => d.Name).ToList(), "LGACode", "Name", cfiEr.LocalGovernmentCode);
            ViewBag.SectorId = new SelectList(_db.Sectors, "SectorId", "Name", cfiEr.SectorId);
            ViewBag.OfficeStateCode = new SelectList(states, "StateCode", "Name", cfiEr.OfficeStateCode);
            var stateCode2 = _db.States.FirstOrDefault(d => d.StateCode == cfiEr.OfficeStateCode);
            // ViewBag.OfficeLGACode = new SelectList(_db.LGAreas.Where(d => d.StateCode == stateCode2.StateCode).OrderBy(d=>d.Name).ToList(), "LGACode", "Name", cfiEr.OfficeLGACode);
            ViewBag.OfficeLGACode = new SelectList(_db.LGAreas.Where(d => d.StateCode == stateCode.StateCode).OrderBy(d => d.Name).ToList(), "LGACode", "Name", cfiEr.OfficeLGACode);
        }


        // GET: Recapture/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CFIRegisterUser cFIRegisterUser = await _db.CFIRegisterUsers.FindAsync(id);
            if (cFIRegisterUser == null)
            {
                return HttpNotFound();
            }
            return View(cFIRegisterUser);
        }

        // POST: Recapture/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            CFIRegisterUser cFIRegisterUser = _db.CFIRegisterUsers.Find(id);
            _db.CFIRegisterUsers.Remove(cFIRegisterUser);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private void GetSalaryList()
        {
            //  Salary Structure
            ViewBag.HarmonisedSalary = new SelectList(_db.SalaryStructures, "SalaryStructureId", "Name");
            ViewBag.GL2004 = new SelectList(_db.GradeLevels, "GradeLevelId", "Name");
            ViewBag.Step2004 = new SelectList(_db.Steps, "StepId", "Name");

            ViewBag.ConsolidatedSalary2007 = new SelectList(_db.SalaryStructures, "SalaryStructureId", "Name");
            ViewBag.GL2007 = new SelectList(_db.GradeLevels, "GradeLevelId", "Name");
            ViewBag.Step2007 = new SelectList(_db.Steps, "StepId", "Name");

            ViewBag.ConsolidatedSalary2010 = new SelectList(_db.SalaryStructures, "SalaryStructureId", "Name");
            ViewBag.GL2010 = new SelectList(_db.GradeLevels, "GradeLevelId", "Name");
            ViewBag.Step2010 = new SelectList(_db.Steps, "StepId", "Name");
            //
            ViewBag.CurrentSalary = new SelectList(_db.SalaryStructures, "SalaryStructureId", "Name");
            ViewBag.CurrentGL = new SelectList(_db.GradeLevels, "GradeLevelId", "Name");
            ViewBag.CurrentStep = new SelectList(_db.Steps, "StepId", "Name");
        }

        private void GetSalaryList(CFISalaryStructure salary)
        {
            //  Salary Structure
            ViewBag.HarmonisedSalary = new SelectList(_db.SalaryStructures, "SalaryStructureId", "Name", salary.HarmonisedSalary);
            ViewBag.GL2004 = new SelectList(_db.GradeLevels, "GradeLevelId", "Name", salary.GL2004);
            ViewBag.Step2004 = new SelectList(_db.Steps, "StepId", "Name", salary.Step2004);

            ViewBag.ConsolidatedSalary2007 = new SelectList(_db.SalaryStructures, "SalaryStructureId", "Name", salary.ConsolidatedSalary2007);
            ViewBag.GL2007 = new SelectList(_db.GradeLevels, "GradeLevelId", "Name", salary.GL2007);
            ViewBag.Step2007 = new SelectList(_db.Steps, "StepId", "Name", salary.Step2007);

            ViewBag.ConsolidatedSalary2010 = new SelectList(_db.SalaryStructures, "SalaryStructureId", "Name", salary.ConsolidatedSalary2010);
            ViewBag.GL2010 = new SelectList(_db.GradeLevels, "GradeLevelId", "Name", salary.GL2010);
            ViewBag.Step2010 = new SelectList(_db.Steps, "StepId", "Name", salary.Step2010);
            //
            ViewBag.CurrentSalary = new SelectList(_db.SalaryStructures, "SalaryStructureId", "Name", salary.CurrentSalary);
            ViewBag.CurrentGL = new SelectList(_db.GradeLevels, "GradeLevelId", "Name", salary.CurrentGL);
            ViewBag.CurrentStep = new SelectList(_db.Steps, "StepId", "Name", salary.CurrentStep);
        }
        private void GetList()
        {
            //List<string> bloodGroup = new List<string> { "A", "B", "AB", "O" };
            //ViewBag.BloodGroup = new SelectList(bloodGroup); // new LGA().

            var countries = _db.Countries.ToList();
            var states = _db.States.OrderBy(x => x.Name).ToList();

            ViewBag.TitleId = new SelectList(_db.Titles.Where(d => d.Active == true), "TitleId", "Name");
            ViewBag.GenderId = new SelectList(_db.Sexes, "SexId", "Name");
            ViewBag.MaritalStatusId = new SelectList(_db.MartialStatus.Where(d => d.Active == true), "MartialStatusId", "Name");
            ViewBag.EmployeeStatusId = new SelectList(_db.EmployeeStatus.Where(d => d.Active == true), "EmployeeStatusId", "Name");

            ViewBag.NationalityId = new SelectList(countries, "CountryId", "Name", 160);
            ViewBag.PersonalStateOfOriginId = new SelectList(states, "StateId", "Name");
            ViewBag.LGAId = new SelectList(_db.LGAreas.Take(10).ToList(), "LGAId", "Name");

            ViewBag.CountryOfResidanceId = new SelectList(countries, "CountryId", "Name", 160);
            ViewBag.StateCode = new SelectList(states, "StateCode", "Name");
            ViewBag.LGACode = new SelectList(_db.LGAreas.Take(10).ToList(), "LGACode", "Name");
            // Employment Record


            //


        }

        public ActionResult Autocomplete(string term)
        {
            string names = term;
            var items = _db.EmployerDetails.Where(
             (item => item.EmployerName.ToUpper().Contains(term.ToUpper()) && item.Active == true
               ||
                (item.Recno.ToUpper().Contains(term.ToUpper()) && item.Active == true)
            )
            ).
            Select(e => new { e.Recno, e.EmployerName, e.MobilePhone })
            .Distinct().Take(25).ToList();
            return Json(items, JsonRequestBehavior.AllowGet);
        }
        private void GetList(CFIRegisterUser cfi /*, CFINextOfKin kin, CFIEmploymentDetail emp, CFISalaryStructure salary*/)
        {

            var countries = _db.Countries.ToList();
            var states = _db.States.OrderBy(x => x.Name).ToList();

            ViewBag.TitleId = new SelectList(_db.Titles.Where(d => d.Active == true), "TitleId", "Name", cfi.TitleId);
            ViewBag.GenderId = new SelectList(_db.Sexes, "SexId", "Name", cfi.GenderId);
            ViewBag.MaritalStatusId = new SelectList(_db.MartialStatus.Where(d => d.Active == true), "MartialStatusId", "Name", cfi.MaritalStatusId);
            ViewBag.EmployeeStatusId = new SelectList(_db.EmployeeStatus.Where(d => d.Active == true), "EmployeeStatusId", "Name", cfi.EmployeeStatusId);

            var state = _db.States.FirstOrDefault(d => d.StateId == cfi.PersonalStateOfOriginId);



            if (cfi.NationalityId == null)
            {
                ViewBag.NationalityId = new SelectList(_db.Countries, "CountryId", "Name", 160);
            }
            else
            {
                ViewBag.NationalityId = new SelectList(_db.Countries, "CountryId", "Name", cfi.NationalityId);
            }
            ViewBag.PersonalStateOfOriginId = new SelectList(states, "StateId", "Name", cfi.PersonalStateOfOriginId);

            if (cfi.PersonalStateOfOriginId != null)
            {
                ViewBag.LGAId = new SelectList(_db.LGAreas.Where(d => d.StateCode == state.StateCode).ToList(), "LGAId", "Name", cfi.LGAId);
            }
            else
            {
                ViewBag.LGAId = new SelectList(_db.LGAreas.Take(20), "LGAId", "Name");
            }
            ViewBag.CountryOfResidanceId = new SelectList(countries, "CountryId", "Name", cfi.CountryOfResidanceId);
            ViewBag.StateCode = new SelectList(states, "StateCode", "Name", cfi.StateCode);
            // var stateCode = _db.States.FirstOrDefault(d => d.StateCode == cfi.StateCode);
            if (!String.IsNullOrEmpty(cfi.StateCode))
            {
                // var stateCode = _db.States.FirstOrDefault(d => d.StateCode == cfi.StateCode).StateCode;
                ViewBag.LGACode = new SelectList(_db.LGAreas.Where(d => d.StateCode == cfi.StateCode && d.Active == true).ToList(), "LGACode", "Name", cfi.LGACode);
            }
            else
            {
                ViewBag.LGACode = new SelectList(_db.LGAreas.Take(0), "LGACode", "Name", cfi.LGACode);
            }
        }


        [HttpGet]
        [AllowAnonymous]
        public string GetLGA()
        {
            int stateid = Convert.ToInt32(Request.Params["StateId"]);
            var selectedState = _db.States.FirstOrDefault(d => d.StateId == stateid && d.Active == true);
            string l = "<option value=\"\"> </option>";
            var lgas = _db.LGAreas.Where(x => x.StateCode == selectedState.StateCode && x.Active == true).OrderBy(d => d.Name).ToList();


            foreach (var item in lgas)
            {
                l += "<option value='" + item.LGAId + "'>" + item.Name + "</option>";
            }
            //  System.Threading.Thread.Sleep(200);
            return l;
        }

        [HttpGet]
        [AllowAnonymous]
        public string GetLGACode()
        {
            string stateid = Convert.ToString(Request.Params["StateCode"]);
            // var selectedState = _db.States.FirstOrDefault(d => d.StateCode == stateid);
            string l = "<option value=\"\"> </option>";
            var lgas = _db.LGAreas.Where(x => x.StateCode == stateid && x.Active == true).OrderBy(d => d.Name).ToList();


            foreach (var item in lgas)
            {
                l += "<option value='" + item.LGACode + "'>" + item.Name + "</option>";
            }
            //  System.Threading.Thread.Sleep(200);
            return l;
        }


        [HttpGet]
        [AllowAnonymous]
        public string GetECRSDocument()
        {
            int docId = Convert.ToInt32(Request.Params["CFIPublicPrivateID"]);
            var selectedSector = _db.CFIPublicPrivateSectors.FirstOrDefault(d => d.CFIPublicPrivateID == docId && d.Active == true).SectorCode;
            string l = "<option value=\"\"> </option>";
            // var ecrsDocs = _db.CFIDocuments.Where(x => x.SectorCode == selectedState.SectorCode && x.Active == true).OrderBy(d => d.Name).ToList();
            var ecrsDocs = _db.CFIDocuments.Where(x => x.Active == true); //.OrderBy(d => d.Name); //.ToList();
                                                                          // var ecrsDocs = _db.CFIDocuments.Where(x => x.SectorCode == selectedSector.SectorCode && x.Active == true).OrderBy(d => d.Name).ToList();
            ecrsDocs = ecrsDocs.Where(d => d.SectorCode == selectedSector || d.SectorCode == "Common").OrderBy(d => d.Name);


            foreach (var item in ecrsDocs)
            {
                l += "<option value='" + item.DocumentId + "'>" + item.Name + "</option>";
            }
            //  System.Threading.Thread.Sleep(200);
            return l;
        }



        //public static string getClientRecapSMS(string surname)
        //{
        //    return "Dear Client, We acknowledge the submission of your data recapture. You will receive further updates. Thank you.";
        //}



        //[HttpGet]
        //[AllowAnonymous]
        //public string GetECRSDocument()
        //{
        //    int docId = Convert.ToInt32(Request.Params["CFIPublicPrivateID"]);
        //    var selectedState = _db.CFIPublicPrivateSectors.FirstOrDefault(d => d.CFIPublicPrivateID == docId && d.Active == true);
        //    string l = "<option value=\"\"> </option>";
        //    //var ecrsDocs = _db.ECRSPrivatePublicSectors.Where(x => x.SectorCode == selectedState.SectorCode && x.Active == true).OrderBy(d => d.Name).ToList();
        //    var ecrsDocs = _db.CFIDocuments.Where(x => x.SectorCode == selectedState.SectorCode && x.Active == true).OrderBy(d => d.Name).ToList();

        //    foreach (var item in ecrsDocs)
        //    {
        //        l += "<option value='" + item.DocumentId + "'>" + item.Name + "</option>";
        //    }
        //    //  System.Threading.Thread.Sleep(200);
        //    return l;
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
