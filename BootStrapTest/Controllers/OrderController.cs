using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BootStrapTest.Controllers
{
    public class OrderController : Controller
    {
        //
        // GET: /Order/
        public ActionResult OrderManage()
        {
            return View();
        }
        public ActionResult CancelManage()
        {
            return View();
        }
        public ActionResult ReturnManage()
        {
            return View();
        }
        public ActionResult StatementManage()
        {
            return View();
        }
	}
}