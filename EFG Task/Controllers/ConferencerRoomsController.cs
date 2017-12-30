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
    public class ConferencerRoomsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ConferencerRooms
        public ActionResult Index()
        {
            return View(db.ConferencerRooms.ToList());
        }

        // GET: ConferencerRooms/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ConferencerRoom conferencerRoom = db.ConferencerRooms.Find(id);
            if (conferencerRoom == null)
            {
                return HttpNotFound();
            }
            return View(conferencerRoom);
        }

        // GET: ConferencerRooms/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ConferencerRooms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "conferencerRoomID,roomNumber,timeSector")] ConferencerRoom conferencerRoom)
        {
            if (ModelState.IsValid)
            {
                db.ConferencerRooms.Add(conferencerRoom);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(conferencerRoom);
        }

        // GET: ConferencerRooms/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ConferencerRoom conferencerRoom = db.ConferencerRooms.Find(id);
            if (conferencerRoom == null)
            {
                return HttpNotFound();
            }
            return View(conferencerRoom);
        }

        // POST: ConferencerRooms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "conferencerRoomID,roomNumber,timeSector")] ConferencerRoom conferencerRoom)
        {
            if (ModelState.IsValid)
            {
                db.Entry(conferencerRoom).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(conferencerRoom);
        }

        // GET: ConferencerRooms/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ConferencerRoom conferencerRoom = db.ConferencerRooms.Find(id);
            if (conferencerRoom == null)
            {
                return HttpNotFound();
            }
            return View(conferencerRoom);
        }

        // POST: ConferencerRooms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ConferencerRoom conferencerRoom = db.ConferencerRooms.Find(id);
            db.ConferencerRooms.Remove(conferencerRoom);
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
