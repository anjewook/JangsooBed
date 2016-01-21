using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BootStrapTest.Controllers
{
    public class DeliveryController : Controller
    {
        //
        // GET: /Delivery/
        public ActionResult DeliveryManage()
        {
            return View();
        }
        public ActionResult DeliveryFee()
        {
            return View();
        }
	}
}