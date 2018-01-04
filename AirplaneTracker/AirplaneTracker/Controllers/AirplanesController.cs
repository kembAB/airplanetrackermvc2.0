using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AirplaneTracker.Models;

namespace AirplaneTracker.Controllers
{
    public class AirplanesController : Controller
    {
        private mvcAssignmentEntities db = new mvcAssignmentEntities();

        public ActionResult Index()
        {
            var airplanes = db.Airplanes.Include(a => a.tblAirplaneType).Include(a => a.Airports).Include(a => a.tblpilots).Include(a => a.tblpilots1);
            return View(airplanes.ToList());
        }

        // GET: Airplanes
        public ActionResult AirportsAirplanes(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            List<Airplanes> airplanes = db.Airplanes.Where(exp => exp.currentAirport == id).ToList();
            if (airplanes == null)
            {
                return HttpNotFound();
            }
           
          
            return View(airplanes);
        }
        public ActionResult TransferAirplane(int? id)
        {
            
            ViewBag.currentAirport = new SelectList(db.Airplanes, "id", "currentAirport");
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Airplanes airplanes = db.Airplanes.Find(id);
            if (airplanes == null)
            {
                return HttpNotFound();
            }
            ViewBag.AirplaneType = new SelectList(db.tblAirplaneType, "id", "name", airplanes.AirplaneType);
            ViewBag.currentAirport = new SelectList(db.Airports, "id", "name", airplanes.currentAirport);
            ViewBag.currentpilot = new SelectList(db.tblpilots, "id", "name", airplanes.currentpilot);
            ViewBag.currentcopilot = new SelectList(db.tblpilots, "id", "name", airplanes.currentcopilot);
            return View(airplanes);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult TransferAirplane([Bind(Include = "id,name,AirplaneType,maxpass,size,currentAirport,currentpilot,currentcopilot")] Airplanes airplanes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(airplanes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AirplaneType = new SelectList(db.tblAirplaneType, "id", "name", airplanes.AirplaneType);
            ViewBag.currentAirport = new SelectList(db.Airports, "id", "name", airplanes.currentAirport);
            ViewBag.currentpilot = new SelectList(db.tblpilots, "id", "name", airplanes.currentpilot);
            ViewBag.currentcopilot = new SelectList(db.tblpilots, "id", "name", airplanes.currentcopilot);
            return View(airplanes);
        }



        // GET: Airplanes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Airplanes airplanes = db.Airplanes.Find(id);
            if (airplanes == null)
            {
                return HttpNotFound();
            }
            return View(airplanes);
        }

        // GET: Airplanes/Create
        public ActionResult Create()
        {
            ViewBag.AirplaneType = new SelectList(db.tblAirplaneType, "id", "name");
            ViewBag.currentAirport = new SelectList(db.Airports, "id", "name");
            ViewBag.currentpilot = new SelectList(db.tblpilots, "id", "name");
            ViewBag.currentcopilot = new SelectList(db.tblpilots, "id", "name");
            return View();
        }

        // POST: Airplanes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name,AirplaneType,maxpass,size,currentAirport,currentpilot,currentcopilot")] Airplanes airplanes)
        {
            if (ModelState.IsValid)
            {
                db.Airplanes.Add(airplanes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AirplaneType = new SelectList(db.tblAirplaneType, "id", "name", airplanes.AirplaneType);
            ViewBag.currentAirport = new SelectList(db.Airports, "id", "name", airplanes.currentAirport);
            ViewBag.currentpilot = new SelectList(db.tblpilots, "id", "name", airplanes.currentpilot);
            ViewBag.currentcopilot = new SelectList(db.tblpilots, "id", "name", airplanes.currentcopilot);
            return View(airplanes);
        }

        // GET: Airplanes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Airplanes airplanes = db.Airplanes.Find(id);
            if (airplanes == null)
            {
                return HttpNotFound();
            }
            ViewBag.AirplaneType = new SelectList(db.tblAirplaneType, "id", "name", airplanes.AirplaneType);
            ViewBag.currentAirport = new SelectList(db.Airports, "id", "name", airplanes.currentAirport);
            ViewBag.currentpilot = new SelectList(db.tblpilots, "id", "name", airplanes.currentpilot);
            ViewBag.currentcopilot = new SelectList(db.tblpilots, "id", "name", airplanes.currentcopilot);
            return View(airplanes);
        }

        // POST: Airplanes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name,AirplaneType,maxpass,size,currentAirport,currentpilot,currentcopilot")] Airplanes airplanes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(airplanes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AirplaneType = new SelectList(db.tblAirplaneType, "id", "name", airplanes.AirplaneType);
            ViewBag.currentAirport = new SelectList(db.Airports, "id", "name", airplanes.currentAirport);
            ViewBag.currentpilot = new SelectList(db.tblpilots, "id", "name", airplanes.currentpilot);
            ViewBag.currentcopilot = new SelectList(db.tblpilots, "id", "name", airplanes.currentcopilot);
            return View(airplanes);
        }

        // GET: Airplanes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Airplanes airplanes = db.Airplanes.Find(id);
            if (airplanes == null)
            {
                return HttpNotFound();
            }
            return View(airplanes);
        }

        // POST: Airplanes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Airplanes airplanes = db.Airplanes.Find(id);
            db.Airplanes.Remove(airplanes);
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
