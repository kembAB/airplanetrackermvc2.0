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
    
    public class AirportsController : Controller
    {
        private mvcAssignmentEntities db = new mvcAssignmentEntities();
      
        // GET: Airports
        public ActionResult Index()
        {
            List<Airports> Airportslist = db.Airports.ToList();
            // return View(db.Airports.ToList());
            return View(Airportslist);
        }
      
        // GET: Airports/Details/5
        public ActionResult Details(int? id)
        {
          
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Airports airports = db.Airports.Find(id);
            if (airports == null)
            {
                return HttpNotFound();
            }

            return View(airports);
            //return View(query);
        }

        // GET: Airports/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Airports/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name,city")] Airports airports)
        {
            if (ModelState.IsValid)
            {
                db.Airports.Add(airports);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(airports);
        }

        // GET: Airports/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Airports airports = db.Airports.Find(id);
            if (airports == null)
            {
                return HttpNotFound();
            }
            return View(airports);
        }

        // POST: Airports/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name,city")] Airports airports)
        {
            if (ModelState.IsValid)
            {
                db.Entry(airports).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(airports);
        }

        // GET: Airports/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Airports airports = db.Airports.Find(id);
            if (airports == null)
            {
                return HttpNotFound();
            }
            return View(airports);
        }

        // POST: Airports/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Airports airports = db.Airports.Find(id);
            db.Airports.Remove(airports);
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
