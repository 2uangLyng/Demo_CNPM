using Demo_CNPM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Demo_CNPM.Models;

namespace Demo_CNPM.App_Start
{
    public class AdminAuthorize:AuthorizeAttribute
    {
        public taphoa_final_demoEntities4 db = new taphoa_final_demoEntities4();

        public int idChucNang { get; set; }
        public override void OnAuthorization(AuthorizationContext filterContext)
        {


            Nhân_viên nvSession = (Nhân_viên)HttpContext.Current.Session["user"];
            if(nvSession != null) 
            {
                taphoa_final_demoEntities4 db = new taphoa_final_demoEntities4();

                var count = db.PhanQuyens.Count(m => m.IdNV == nvSession.ID & m.IdChucNang == idChucNang);


                if (count != 0)
                {
                    return;
                }
                else
                {
                    var returnUrl = filterContext.RequestContext.HttpContext.Request.RawUrl;
                    filterContext.Result = new RedirectToRouteResult(new
                        RouteValueDictionary(new
                        {
                            controller = "BaoLoi",
                            action = "KhongCoQuyen",
                            returnUrl = returnUrl.ToString()
                        }));
                }

                return;
            }
            else
            {
                filterContext.Result = new RedirectToRouteResult(new
                    RouteValueDictionary(new {
                        controller = "Hàng_Hoá",
                        action = "DangNhap"
                    }));
            }
        }
    }
}