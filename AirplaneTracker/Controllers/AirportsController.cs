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
        // to avoid duplicate keys json result, as it is client side
        //[HttpPost]
        //public JsonResult IsIdAvailable(int id)
        //{
        

        
        //   return Json(!db.Airports.Any(User => User.id == id), JsonRequestBehavior.AllowGet);
        //}   
        

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
        [HttpGet]
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


                if (db.Airports.Any(i => i.id == airports.id))
                {

                    return RedirectToAction("Index");
                }

                else
                {
                    db.Airports.Add(airports);
                    db.SaveChanges();
                }


                return RedirectToAction("Index");

            
               
            }
            //else
            //{
            //    return RedirectToAction("Index");
            //}

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
            //using (var context = new DataContext())
            //{
            //    Person person = context.Persons.Find(id);

            //    foreach (var child in person.Children.ToList())
            //    {
            //        person.Children.Remove(child);
            //    }

            //    foreach (var parent in person.Parents.ToList())
            //    {
            //        person.Parents.Remove(parent);
            //    }

            //    context.Persons.Remove(patient);

            //    context.SaveChanges();
            //}
            using (var db = new mvcAssignmentEntities())
            {
                Airports airports = db.Airports.Find(id);
                //db.Airports.Remove(airports);
                foreach (var child in airports.Airplanes.ToList())
                {
                       {
                       
                        airports.Airplanes.Remove(child);
                       }
                    //Airplanes airplanes = db.Airplanes.Find(id);
                   // db.Airplanes.Remove(airplanes);
                    db.Airports.Remove(airports);
                   
                }

                db.Airports.Remove(airports);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
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
