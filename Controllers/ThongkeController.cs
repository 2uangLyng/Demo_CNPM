using Demo_CNPM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Demo_CNPM.Controllers
{
    public class ThongkeController : Controller
    {
        // GET: Thongke
        private taphoa_final_testEntities1 db = new taphoa_final_testEntities1();
        public ActionResult Index()
        {
            return View();
        }
    }
}