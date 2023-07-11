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
    public class ĐVTController : Controller
    {
        private taphoa_finalEntities db = new taphoa_finalEntities();

        // GET: ĐVT
        public ActionResult Index()
        {
            return View(db.ĐVT.ToList());
        }

        // GET: ĐVT/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ĐVT đVT = db.ĐVT.Find(id);
            if (đVT == null)
            {
                return HttpNotFound();
            }
            return View(đVT);
        }

        // GET: ĐVT/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ĐVT/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Tên")] ĐVT đVT)
        {
            if (ModelState.IsValid)
            {
                db.ĐVT.Add(đVT);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(đVT);
        }

        // GET: ĐVT/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ĐVT đVT = db.ĐVT.Find(id);
            if (đVT == null)
            {
                return HttpNotFound();
            }
            return View(đVT);
        }

        // POST: ĐVT/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Tên")] ĐVT đVT)
        {
            if (ModelState.IsValid)
            {
                db.Entry(đVT).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(đVT);
        }

        // GET: ĐVT/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ĐVT đVT = db.ĐVT.Find(id);
            if (đVT == null)
            {
                return HttpNotFound();
            }
            return View(đVT);
        }

        // POST: ĐVT/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            ĐVT đVT = db.ĐVT.Find(id);
            db.ĐVT.Remove(đVT);
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
