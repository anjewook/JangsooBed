using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using JS.Boots.Security;
using JS.Boots.Data;

namespace BootStrapTest.Common
{
    public class BaseController : Controller
    {
        //
        // GET: /Base/
        public ActionResult Index()
        {
            return View();
        }

        protected string MenuCode = "";
        protected AuthT AuthT = new AuthT();

        /// <summary>
        /// OnActionExecuting
        /// </summary>
        /// <param name="filterContext">filterContext</param>
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            //if (!filterContext.IsChildAction)
            //{
                MenuCode = (string)filterContext.HttpContext.Items["MenuCode"];
                AuthT = (AuthT)filterContext.HttpContext.Items["AuthT"];
            //}

            HttpRequestBase req = filterContext.HttpContext.Request;
            HttpResponseBase res = filterContext.HttpContext.Response;
            string url = req.Url.ToString().ToLower();

#if DEBUG
#else
            //if (url.IndexOf("http://metrology.kr") != -1)
            //{
            //   url = url.Replace("http://metrology.kr", "http://www.metrology.kr");
            //    res.Redirect(url);
            //}
#endif
        }

    }
}