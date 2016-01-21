using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BootStrapTest.Controllers
{
    public class BoardController : Controller
    {
        //
        // GET: /Board/
        public ActionResult Notice()
        {
            return View();
        }
        public ActionResult Product()
        {
            return View();
        }

        public ActionResult Individual()
        {
            return View();
        }

        public ActionResult GoodsReply()
        {
            return View();
        }

        public ActionResult Faq()
        {
            return View();
        }
	}
}