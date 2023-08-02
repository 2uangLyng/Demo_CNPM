using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Demo_CNPM.Models;

namespace Demo_CNPM.Controllers
{
    public class LoạiController : Controller
    {
        private taphoa_finalEntities4 db = new taphoa_finalEntities4();

        // GET: Loại
        public ActionResult Index()
        {
            return View(db.Loại.ToList());
        }

        // GET: Loại/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Loại loại = db.Loại.Find(id);
            if (loại == null)
            {
                return HttpNotFound();
            }
            return View(loại);
        }

        // GET: Loại/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Loại/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Tên")] Loại loại)
        {
            if (ModelState.IsValid)
            {
                db.Loại.Add(loại);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(loại);
        }

        // GET: Loại/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Loại loại = db.Loại.Find(id);
            if (loại == null)
            {
                return HttpNotFound();
            }
            return View(loại);
        }

        // POST: Loại/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Tên")] Loại loại)
        {
            if (ModelState.IsValid)
            {
                db.Entry(loại).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(loại);
        }

        // GET: Loại/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Loại loại = db.Loại.Find(id);
            if (loại == null)
            {
                return HttpNotFound();
            }
            return View(loại);
        }

        // POST: Loại/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Loại loại = db.Loại.Find(id);
            db.Loại.Remove(loại);
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
