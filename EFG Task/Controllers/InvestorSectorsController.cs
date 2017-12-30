using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EFG_Task.Models;

namespace EFG_Task.Controllers
{
    public class InvestorSectorsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: InvestorSectors
        public ActionResult Index()
        {
            return View(db.InvestorSectors.ToList());
        }

        // GET: InvestorSectors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InvestorSector investorSector = db.InvestorSectors.Find(id);
            if (investorSector == null)
            {
                return HttpNotFound();
            }
            return View(investorSector);
        }

        // GET: InvestorSectors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: InvestorSectors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "investorSectorID,interestedSector,timeSector")] InvestorSector investorSector)
        {
            if (ModelState.IsValid)
            {
                db.InvestorSectors.Add(investorSector);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(investorSector);
        }

        // GET: InvestorSectors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InvestorSector investorSector = db.InvestorSectors.Find(id);
            if (investorSector == null)
            {
                return HttpNotFound();
            }
            return View(investorSector);
        }

        // POST: InvestorSectors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "investorSectorID,interestedSector,timeSector")] InvestorSector investorSector)
        {
            if (ModelState.IsValid)
            {
                db.Entry(investorSector).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(investorSector);
        }

        // GET: InvestorSectors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InvestorSector investorSector = db.InvestorSectors.Find(id);
            if (investorSector == null)
            {
                return HttpNotFound();
            }
            return View(investorSector);
        }

        // POST: InvestorSectors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            InvestorSector investorSector = db.InvestorSectors.Find(id);
            db.InvestorSectors.Remove(investorSector);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
