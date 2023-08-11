﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Demo_CNPM.Models;
using Demo_CNPM.App_Start;

namespace Demo_CNPM.Controllers
{
    public class Hóa_đơnController : Controller
    {
        private taphoa_final_demoEntities4 db = new taphoa_final_demoEntities4();

        // GET: Hóa_đơn
        [AdminAuthorize(idChucNang = 1)]
        public ActionResult Index()
        {
            var hóa_đơn = db.Hóa_đơn.Include(h => h.Nhân_viên);
            return View(hóa_đơn.ToList());
        }

        // GET: Hóa_đơn/Details/5
        [AdminAuthorize(idChucNang = 1)]
        public ActionResult Details(int? id)
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
            return RedirectToAction("Details", "Chi_tiết_hóa_đơn", new { id = id });
        }

        // GET: Hóa_đơn/Create
        [AdminAuthorize(idChucNang = 1)]
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
        [AdminAuthorize(idChucNang = 1)]
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
        [AdminAuthorize(idChucNang = 1)]
        public ActionResult Edit(int? id)
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
        [AdminAuthorize(idChucNang = 1)]
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
        [AdminAuthorize(idChucNang = 1)]
        public ActionResult Delete(int? id)
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
        [AdminAuthorize(idChucNang = 1)]
        public ActionResult DeleteConfirmed(int? id)
        {
            Hóa_đơn hóa_đơn = db.Hóa_đơn.Find(id);
            if (hóa_đơn == null)
            {
                return HttpNotFound();
            }
            // Lấy danh sách các bản ghi Chi_tiết_hóa_đơn có liên quan đến Hóa_đơn
            var chiTiets = db.Chi_tiết_hóa_đơn.Where(ct => ct.ID_HD == id).ToList();

            // Xóa các bản ghi Chi_tiết_hóa_đơn liên quan
            foreach (var chiTiet in chiTiets)
            {
                db.Chi_tiết_hóa_đơn.Remove(chiTiet);
            }
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
