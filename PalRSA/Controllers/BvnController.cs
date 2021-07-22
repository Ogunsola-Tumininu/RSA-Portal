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
    [Authorize(Roles ="Client,Customer,Clients,Customers")]
    public class BvnController : Controller
    {
        
        private PALSiteDBEntities _db = new PALSiteDBEntities();
        static string pin="";

        // GET: Bvn
        public async Task<ActionResult> MyBvn()
        {
            pin = User.Identity.Name;
            return View(await _db.BVNdatas.Where(d=>d.Pin==pin).Take(1).ToListAsync());
        }

        // GET: Bvn/Details/5
        public async Task<ActionResult> Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BVNdata bVNdata = await _db.BVNdatas.FindAsync(id);
            if (bVNdata == null)
            {
                return HttpNotFound();
            }
            return View(bVNdata);
        }

        // GET: Bvn/Create
        public ActionResult SubmitBvn()
        {
            string pin = User.Identity.Name;
           //  ViewBag.Pin = pin;
            var bvn = new BVNdata();
            // bvn.Employee = _db.Employees.Where(d => d.Pin == pin).FirstOrDefault();
            bvn.Pin = pin;
            return View(bvn);
        }

        // POST: Bvn/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> SubmitBvn([Bind(Include = "Id,Pin,Bvn,Nin,CreatedOn,Confimed")] BVNdata bVNdata)
        {
            if (ModelState.IsValid)
            {
                bVNdata.CreatedOn = DateTime.Now;
                bVNdata.DateUpdated = DateTime.Now;
                bVNdata.CreatedBy = User.Identity.Name;
                _db.BVNdatas.Add(bVNdata);
                await _db.SaveChangesAsync();
                return RedirectToAction("myBvn");
            }

            return View(bVNdata);
        }

        // GET: Bvn/Edit/5
        public async Task<ActionResult> EditBvn()
        {
            pin = User.Identity.Name;
            if (pin == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BVNdata bVNdata = await _db.BVNdatas.Where(d=>d.Pin==pin).FirstOrDefaultAsync();
            if (bVNdata == null)
            {
                return HttpNotFound();
            }
            return View(bVNdata);
        }

        // POST: Bvn/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken] // ,Confimed
        public async Task<ActionResult> EditBvn([Bind(Include = "Id,Pin,Bvn,Nin,CreatedOn")] BVNdata bVNdata)
        {
            if (ModelState.IsValid)
            {
                bVNdata.DateUpdated = DateTime.Now;
                bVNdata.ModifiedBy = User.Identity.Name;
                _db.Entry(bVNdata).State = EntityState.Modified;
                await _db.SaveChangesAsync();
                return RedirectToAction("MyBvn");
            }
            return View(bVNdata);
        }

        //// GET: Bvn/Delete/5
        //public async Task<ActionResult> Delete(long? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    BVNdata bVNdata = await _db.BVNdatas.FindAsync(id);
        //    if (bVNdata == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(bVNdata);
        //}

        //// POST: Bvn/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> DeleteConfirmed(long id)
        //{
        //    BVNdata bVNdata = await _db.BVNdatas.FindAsync(id);
        //    _db.BVNdatas.Remove(bVNdata);
        //    await _db.SaveChangesAsync();
        //    return RedirectToAction("MyBvn");
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
