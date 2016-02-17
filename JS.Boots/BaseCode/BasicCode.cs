using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Web;

using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;

namespace JS.Boots.BaseCode
{
    public static class BasicCode
    {

        // IHtmlString >> 인코딩된 문자열 반환
        public static IHtmlString DropDownListFor(this HtmlHelper htmlHelper, string cdindex, string selectName, string selectID, Dictionary<string, IEnumerable<SelectListItem>> selectList)
        {
            /*
             * <select name="tmodel">
             *   <optgroup title="Items">
             *   <option value="item">Item</option>
             * </select>
             */

            var select = new TagBuilder("select");

            select.Attributes.Add("name", selectName);
            select.Attributes.Add("id", selectID);

            var optgroups = new StringBuilder();
            
            foreach (var kvp in selectList)
            {
                var optgroup = new TagBuilder("optgroup");
                optgroup.Attributes.Add("label", kvp.Key);

                var options = new StringBuilder();

                foreach (var item in kvp.Value)
                {
                    var option = new TagBuilder("option");

                    option.Attributes.Add("value", item.Value);
                    option.SetInnerText(item.Text);

                    if (item.Selected)
                    {
                        option.Attributes.Add("selected", "selected");
                    }

                    options.Append(option.ToString(TagRenderMode.Normal));
                }

                optgroup.InnerHtml = options.ToString();

                optgroups.Append(optgroup.ToString(TagRenderMode.Normal));
            }

            select.InnerHtml = optgroups.ToString();

            return MvcHtmlString.Create(select.ToString(TagRenderMode.Normal));
        }
    }
}
