using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Demo_CNPM.App_Start;
using Demo_CNPM.Models;

namespace Demo_CNPM.Controllers
{
    public class Chi_tiết_hóa_đơnController : Controller
    {
        private taphoa_finalEntities4 db = new taphoa_finalEntities4();

        // GET: Chi_tiết_hóa_đơn
        [AdminAuthorize(idChucNang = 1)]
        public ActionResult Index()
        {
            var chi_tiết_hóa_đơn = db.Chi_tiết_hóa_đơn.Include(c => c.Hóa_đơn).Include(c => c.Hàng_Hóa);
            return View(chi_tiết_hóa_đơn.ToList());
        }

        // GET: Chi_tiết_hóa_đơn/Details/5
        [AdminAuthorize(idChucNang = 1)]
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chi_tiết_hóa_đơn chi_tiết_hóa_đơn = db.Chi_tiết_hóa_đơn.Find(id);
            if (chi_tiết_hóa_đơn == null)
            {
                return HttpNotFound();
            }
            return View(chi_tiết_hóa_đơn);
        }

        // GET: Chi_tiết_hóa_đơn/Create
        [AdminAuthorize(idChucNang = 1)]
        public ActionResult Create()
        {
            ViewBag.ID_HD = new SelectList(db.Hóa_đơn, "ID", "ID_NV");
            ViewBag.ID_HH = new SelectList(db.Hàng_Hóa, "ID", "Tên");
            return View();
        }

        // POST: Chi_tiết_hóa_đơn/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AdminAuthorize(idChucNang = 1)]
        public ActionResult Create([Bind(Include = "ID_HH,ID_HD,SL,Đơn_giá,Thành_tiền")] Chi_tiết_hóa_đơn chi_tiết_hóa_đơn)
        {
            if (ModelState.IsValid)
            {
                db.Chi_tiết_hóa_đơn.Add(chi_tiết_hóa_đơn);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_HD = new SelectList(db.Hóa_đơn, "ID", "ID_NV", chi_tiết_hóa_đơn.ID_HD);
            ViewBag.ID_HH = new SelectList(db.Hàng_Hóa, "ID", "Tên", chi_tiết_hóa_đơn.ID_HH);
            return View(chi_tiết_hóa_đơn);
        }

        // GET: Chi_tiết_hóa_đơn/Edit/5
        [AdminAuthorize(idChucNang = 1)]
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chi_tiết_hóa_đơn chi_tiết_hóa_đơn = db.Chi_tiết_hóa_đơn.Find(id);
            if (chi_tiết_hóa_đơn == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_HD = new SelectList(db.Hóa_đơn, "ID", "ID_NV", chi_tiết_hóa_đơn.ID_HD);
            ViewBag.ID_HH = new SelectList(db.Hàng_Hóa, "ID", "Tên", chi_tiết_hóa_đơn.ID_HH);
            return View(chi_tiết_hóa_đơn);
        }

        // POST: Chi_tiết_hóa_đơn/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AdminAuthorize(idChucNang = 1)]
        public ActionResult Edit([Bind(Include = "ID_HH,ID_HD,SL,Đơn_giá,Thành_tiền")] Chi_tiết_hóa_đơn chi_tiết_hóa_đơn)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chi_tiết_hóa_đơn).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_HD = new SelectList(db.Hóa_đơn, "ID", "ID_NV", chi_tiết_hóa_đơn.ID_HD);
            ViewBag.ID_HH = new SelectList(db.Hàng_Hóa, "ID", "Tên", chi_tiết_hóa_đơn.ID_HH);
            return View(chi_tiết_hóa_đơn);
        }

        // GET: Chi_tiết_hóa_đơn/Delete/5
        [AdminAuthorize(idChucNang = 1)]
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chi_tiết_hóa_đơn chi_tiết_hóa_đơn = db.Chi_tiết_hóa_đơn.Find(id);
            if (chi_tiết_hóa_đơn == null)
            {
                return HttpNotFound();
            }
            return View(chi_tiết_hóa_đơn);
        }

        // POST: Chi_tiết_hóa_đơn/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [AdminAuthorize(idChucNang = 1)]
        public ActionResult DeleteConfirmed(string id)
        {
            Chi_tiết_hóa_đơn chi_tiết_hóa_đơn = db.Chi_tiết_hóa_đơn.Find(id);
            db.Chi_tiết_hóa_đơn.Remove(chi_tiết_hóa_đơn);
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