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
    public class Hóa_đơnController : Controller
    {
        private taphoa_finalEntities1 db = new taphoa_finalEntities1();

        // GET: Hóa_đơn
        public ActionResult Index()
        {
            var hóa_đơn = db.Hóa_đơn.Include(h => h.Nhân_viên);
            return View(hóa_đơn.ToList());
        }

        // GET: Hóa_đơn/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hóa_đơn hóa_đơn = db.Hóa_đơn.Find(id);
            if (hóa_đơn == null)
            {
                return HttpNotFound();
            }
            return View(hóa_đơn);
        }

        // GET: Hóa_đơn/Create
        public ActionResult Create()
        {
            ViewBag.ID_NV = new SelectList(db.Nhân_viên, "ID", "Tên");
            return View();
        }

        // POST: Hóa_đơn/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ID_NV,Ngày_bán,Tổng_SL,Tổng_tiền")] Hóa_đơn hóa_đơn)
        {
            if (ModelState.IsValid)
            {
                db.Hóa_đơn.Add(hóa_đơn);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_NV = new SelectList(db.Nhân_viên, "ID", "Tên", hóa_đơn.ID_NV);
            return View(hóa_đơn);
        }

        // GET: Hóa_đơn/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hóa_đơn hóa_đơn = db.Hóa_đơn.Find(id);
            if (hóa_đơn == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_NV = new SelectList(db.Nhân_viên, "ID", "Tên", hóa_đơn.ID_NV);
            return View(hóa_đơn);
        }

        // POST: Hóa_đơn/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ID_NV,Ngày_bán,Tổng_SL,Tổng_tiền")] Hóa_đơn hóa_đơn)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hóa_đơn).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_NV = new SelectList(db.Nhân_viên, "ID", "Tên", hóa_đơn.ID_NV);
            return View(hóa_đơn);
        }

        // GET: Hóa_đơn/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hóa_đơn hóa_đơn = db.Hóa_đơn.Find(id);
            if (hóa_đơn == null)
            {
                return HttpNotFound();
            }
            return View(hóa_đơn);
        }

        // POST: Hóa_đơn/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Hóa_đơn hóa_đơn = db.Hóa_đơn.Find(id);
            db.Hóa_đơn.Remove(hóa_đơn);
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
