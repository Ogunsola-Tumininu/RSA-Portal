using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PalRSA.Core.DataAccess;
using EntityState = System.Data.Entity.EntityState;

namespace PalRSA.Controllers
{
    [Authorize(Roles ="Customer,Client")]
    public class EmailNoficationsController : Controller
    {
        private PALSiteDBEntities _db = new PALSiteDBEntities();
        static string pin = "";

        // GET: EmailNofications
        public async Task<ActionResult> Index()
        {
            pin = User.Identity.Name;
            // return View(await _db.DigitalSubscriptions.Where(d => d.Pin == pin).Take(1).ToListAsync());
            return View(await _db.DigitalSubscriptions.FirstOrDefaultAsync(d => d.Pin == pin)); //.Take(1).ToListAsync());
            // return View(await _db.EmailNofications.ToListAsync());
        }

        // GET: EmailNofications/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DigitalSubscription emailNofication = await _db.DigitalSubscriptions.FindAsync(id);
            if (emailNofication == null)
            {
                return HttpNotFound();
            }
            return View(emailNofication);
        }

        // GET: EmailNofications/Create
        public ActionResult Create()
        {
            DigitalSubscription not = new DigitalSubscription();
            not.Pin = User.Identity.Name;
            return View(not);
        }

        // POST: EmailNofications/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
      //  [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,Pin,DigitalStatement,HardCopyStatement,NoStatementNoAlert,TransactionSMS,EventNofication,NewsLetters,DateCreated,DateUpdated")] DigitalSubscription emailNofication)
        {
            if (ModelState.IsValid)
            {
                emailNofication.DateCreated = DateTime.Now;
                emailNofication.DateUpdated = DateTime.Now;
                emailNofication.Pin = User.Identity.Name;
                _db.DigitalSubscriptions.Add(emailNofication);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(emailNofication);
        }

        // GET: EmailNofications/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DigitalSubscription emailNofication = await _db.DigitalSubscriptions.FindAsync(id);
            if (emailNofication == null)
            {
                return HttpNotFound();
            }
            return View(emailNofication);
        }

        // POST: EmailNofications/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
       // [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,Pin,DigitalStatement,HardCopyStatement,NoStatementNoAlert,TransactionSMS,EventNofication,NewsLetters,,DateCreated,DateUpdated")] DigitalSubscription emailNofication)
        {
            if (ModelState.IsValid)
            {
                emailNofication.DateUpdated = DateTime.Now;
                _db.Entry(emailNofication).State = EntityState.Modified;
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(emailNofication);
        }

        // GET: EmailNofications/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DigitalSubscription emailNofication = await _db.DigitalSubscriptions.FindAsync(id);
            if (emailNofication == null)
            {
                return HttpNotFound();
            }
            return View(emailNofication);
        }

        // POST: EmailNofications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            DigitalSubscription emailNofication = await _db.DigitalSubscriptions.FindAsync(id);
            _db.DigitalSubscriptions.Remove(emailNofication);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

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
