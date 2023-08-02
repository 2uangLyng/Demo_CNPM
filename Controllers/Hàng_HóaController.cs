using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.IO;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Demo_CNPM.Models;
using System.Web.Security;
using Demo_CNPM.App_Start;

namespace Demo_CNPM.Controllers
{
    public class Hàng_HóaController : Controller
    {
        private taphoa_finalEntities4 db = new taphoa_finalEntities4();



        public ActionResult DangNhap()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DangNhap(string user, string password)
        {
            //check DB
            var nhanVien = db.Nhân_viên.SingleOrDefault(m => m.ID == user && m.Password == password);

            if (nhanVien != null)
            {
                Session["user"] = nhanVien;
                ViewBag.user = nhanVien;
                TempData["error"] = new Nhân_viên();

                return RedirectToAction("Proview");
            }

            else
            {
                TempData["error"] = "Tài khoản đăng nhập không đúng";
                return View();
            }

        }
        //public ActionResult DangXuat()
        //{
        //    Session.Remove("user");
        //    FormsAuthentication.SignOut();
        //    return RedirectToAction("DangNhap");
        //}



        // GET: Hàng_Hóa
        [AdminAuthorize(idChucNang = 2)]
        public ActionResult Index()
        {
            var hàng_Hóa = db.Hàng_Hóa.Include(h => h.ĐVT).Include(h => h.Loại);
            return View(hàng_Hóa.ToList());
        }

        // GET: Hàng_Hóa/Details/5
        [AdminAuthorize(idChucNang = 2)]
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hàng_Hóa hàng_Hóa = db.Hàng_Hóa.Find(id);
            if (hàng_Hóa == null)
            {
                return HttpNotFound();
            }
            return View(hàng_Hóa);
        }

        // GET: Hàng_Hóa/Create
        [AdminAuthorize(idChucNang = 2)]
        public ActionResult Create()
        {
            ViewBag.ID_DVT = new SelectList(db.ĐVT, "ID", "Tên");
            ViewBag.ID_loại = new SelectList(db.Loại, "ID", "Tên");
            return View();
        }

        // POST: Hàng_Hóa/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AdminAuthorize(idChucNang = 2)]
        public ActionResult Create([Bind(Include = "ID,Tên,Số_Lượng,Giá_mua,Giá_bán,ID_loại,ID_DVT,SL_ton,Hinh_anh")] Hàng_Hóa hàng_Hóa, HttpPostedFileBase Hinh_anh)
        {
            if (ModelState.IsValid)
            {
                if (Hinh_anh != null)
                {
                    //Lấy tên file của hình được up lên
                    var fileName = Path.GetFileName(Hinh_anh.FileName);
                    //Tạo đường dẫn tới file
                    var path = Path.Combine(Server.MapPath("~/Images"), fileName);
                    //Lưu tên
                    hàng_Hóa.Hinh_anh = fileName;
                    //Save vào Images Folder
                    Hinh_anh.SaveAs(path);
                }
                db.Hàng_Hóa.Add(hàng_Hóa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_DVT = new SelectList(db.ĐVT, "ID", "Tên", hàng_Hóa.ID_DVT);
            ViewBag.ID_loại = new SelectList(db.Loại, "ID", "Tên", hàng_Hóa.ID_loại);
            return View(hàng_Hóa);
        }

        // GET: Hàng_Hóa/Edit/5
        [AdminAuthorize(idChucNang = 2)]
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hàng_Hóa hàng_Hóa = db.Hàng_Hóa.Find(id);
            if (hàng_Hóa == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_DVT = new SelectList(db.ĐVT, "ID", "Tên", hàng_Hóa.ID_DVT);
            ViewBag.ID_loại = new SelectList(db.Loại, "ID", "Tên", hàng_Hóa.ID_loại);
            return View(hàng_Hóa);
        }

        // POST: Hàng_Hóa/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AdminAuthorize(idChucNang = 2)]
        public ActionResult Edit([Bind(Include = "ID,Tên,Số_Lượng,Giá_mua,Giá_bán,ID_loại,ID_DVT,SL_ton,Hinh_anh")] Hàng_Hóa hàng_Hóa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hàng_Hóa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_DVT = new SelectList(db.ĐVT, "ID", "Tên", hàng_Hóa.ID_DVT);
            ViewBag.ID_loại = new SelectList(db.Loại, "ID", "Tên", hàng_Hóa.ID_loại);
            return View(hàng_Hóa);
        }

        // GET: Hàng_Hóa/Delete/5
        [AdminAuthorize(idChucNang = 2)]
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hàng_Hóa hàng_Hóa = db.Hàng_Hóa.Find(id);
            if (hàng_Hóa == null)
            {
                return HttpNotFound();
            }
            return View(hàng_Hóa);
        }

        // POST: Hàng_Hóa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Hàng_Hóa hàng_Hóa = db.Hàng_Hóa.Find(id);
            db.Hàng_Hóa.Remove(hàng_Hóa);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Quanlyban(string SearchString)
        {
            var Hàng_Hóa = db.Hàng_Hóa.Include(p => p.Loại);
            if (!String.IsNullOrEmpty(SearchString))
            {
                Hàng_Hóa = Hàng_Hóa.Where(s => s.Tên.Contains(SearchString));
            }
            return View(Hàng_Hóa.ToList());
        }
        public ActionResult Proview(string SearchString)
        {
                var Hàng_Hóa = db.Hàng_Hóa.Include(p => p.Loại);
                if (!String.IsNullOrEmpty(SearchString))
                {
                    Hàng_Hóa = Hàng_Hóa.Where(s => s.Tên.Contains(SearchString));
                }
                return View(Hàng_Hóa.ToList());
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
