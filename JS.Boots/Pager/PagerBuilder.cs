using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;

namespace JS.Boots.Pager
{
    public class PagerBuilder
    {
        private readonly RouteValueDictionary _routeValues = null;

        internal PagerBuilder() { }

        internal RouteValueDictionary GetCurrentRouteValues(ViewContext viewContext)
        {
            var routeValues = _routeValues ?? new RouteValueDictionary();
            var rq = viewContext.HttpContext.Request.QueryString;
            if (rq != null && rq.Count > 0)
            {
                var invalidParams = new[] { "x-requested-with", "xmlhttprequest", "page" };
                foreach (string key in rq.Keys)
                {
                    if (!string.IsNullOrEmpty(key) && Array.IndexOf(invalidParams, key.ToLower()) < 0)
                    {
                        routeValues[key] = rq[key];
                    }
                }
            }

            if (String.IsNullOrEmpty((string)routeValues["action"]))
            {
                routeValues["action"] = (string)viewContext.RouteData.Values["action"];
            }
            if (String.IsNullOrEmpty((string)routeValues["controller"]))
            {
                routeValues["controller"] = (string)viewContext.RouteData.Values["controller"];
            }

            return routeValues;
        }
    }
}
