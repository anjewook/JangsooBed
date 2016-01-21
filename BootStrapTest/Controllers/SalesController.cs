using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BootStrapTest.Controllers
{
    public class SalesController : Controller
    {
        //
        // GET: /Sales/
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult SalesState()
        {
            return View();
        }
        public ActionResult CalcState()
        {
            return View();
        }
	}
}