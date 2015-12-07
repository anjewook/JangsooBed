using BootStrapTest.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BootStrapTest.Controllers
{
    public class AdminController : BaseAdminController
    {
        //
        // GET: /Admin/
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult TestBoot()
        {
            return View();
        }
	}
}