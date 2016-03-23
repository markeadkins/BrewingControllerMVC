using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.IO;
using BrewingControllerMVC.Models;

namespace BrewingControllerMVC.Controllers
{
    public class TempProbeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        
        // GET: /TempProbe/
        public ActionResult Index()
        {
            return View(db.TempProbes.ToList());
        }

        // GET: /TempProbe/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TempProbe tempprobe = db.TempProbes.Find(id);
            if (tempprobe == null)
            {
                return HttpNotFound();
            }
            return View(tempprobe);
        }

        // GET: /TempProbe/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /TempProbe/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ID,Name,AssignedPID,CurrentTemp")] TempProbe tempprobe)
        {
            if (ModelState.IsValid)
            {
                db.TempProbes.Add(tempprobe);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tempprobe);
        }

        // GET: /TempProbe/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TempProbe tempprobe = db.TempProbes.Find(id);
            if (tempprobe == null)
            {
                return HttpNotFound();
            }
            return View(tempprobe);
        }

        // POST: /TempProbe/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ID,Name,AssignedPID,CurrentTemp")] TempProbe tempprobe)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tempprobe).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tempprobe);
        }

        // GET: /TempProbe/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TempProbe tempprobe = db.TempProbes.Find(id);
            if (tempprobe == null)
            {
                return HttpNotFound();
            }
            return View(tempprobe);
        }

        // POST: /TempProbe/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TempProbe tempprobe = db.TempProbes.Find(id);
            db.TempProbes.Remove(tempprobe);
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
