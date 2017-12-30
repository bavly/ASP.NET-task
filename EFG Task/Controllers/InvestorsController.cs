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
    public class InvestorsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Investors
        public ActionResult Index()
        {
            var investors = db.Investors.Include(i => i.InvestorSector);
            return View(investors.ToList());
        }

        // GET: Investors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Investor investor = db.Investors.Find(id);
            if (investor == null)
            {
                return HttpNotFound();
            }
            return View(investor);
        }

        // GET: Investors/Create
        public ActionResult Create()
        {
            ViewBag.investorSectorID = new SelectList(db.InvestorSectors, "investorSectorID", "interestedSector");
            return View();
        }

        // POST: Investors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idInvestor,name,mobile,investorSectorID")] Investor investor)
        {
            if (ModelState.IsValid)
            {
                db.Investors.Add(investor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.investorSectorID = new SelectList(db.InvestorSectors, "investorSectorID", "interestedSector", investor.investorSectorID);
            return View(investor);
        }

        // GET: Investors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Investor investor = db.Investors.Find(id);
            if (investor == null)
            {
                return HttpNotFound();
            }
            ViewBag.investorSectorID = new SelectList(db.InvestorSectors, "investorSectorID", "interestedSector", investor.investorSectorID);
            return View(investor);
        }

        // POST: Investors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idInvestor,name,mobile,investorSectorID")] Investor investor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(investor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.investorSectorID = new SelectList(db.InvestorSectors, "investorSectorID", "interestedSector", investor.investorSectorID);
            return View(investor);
        }

        // GET: Investors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Investor investor = db.Investors.Find(id);
            if (investor == null)
            {
                return HttpNotFound();
            }
            return View(investor);
        }

        // POST: Investors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Investor investor = db.Investors.Find(id);
            db.Investors.Remove(investor);
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
