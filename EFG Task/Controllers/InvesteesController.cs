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
    public class InvesteesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Investees
        public ActionResult Index()
        {
            return View(db.Investees.ToList());
        }

        // GET: Investees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Investee investee = db.Investees.Find(id);
            if (investee == null)
            {
                return HttpNotFound();
            }
            return View(investee);
        }

        // GET: Investees/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Investees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idInvestee,name,mobile,investorSecteeID")] Investee investee)
        {
            if (ModelState.IsValid)
            {
                db.Investees.Add(investee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(investee);
        }

        // GET: Investees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Investee investee = db.Investees.Find(id);
            if (investee == null)
            {
                return HttpNotFound();
            }
            return View(investee);
        }

        // POST: Investees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idInvestee,name,mobile,investorSecteeID")] Investee investee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(investee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(investee);
        }

        // GET: Investees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Investee investee = db.Investees.Find(id);
            if (investee == null)
            {
                return HttpNotFound();
            }
            return View(investee);
        }

        // POST: Investees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Investee investee = db.Investees.Find(id);
            db.Investees.Remove(investee);
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
