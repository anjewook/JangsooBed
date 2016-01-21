using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Web;

using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;

namespace JS.Boots.Pager
{
    /// <summary>
    /// static : 영역이 제한된 전역
    /// static 선언시 해당변수(or 함수)는 전역변수(함수)로서의 성격을 갖지만 일반전역변수와는 달리 선언된영역(scope)에서만 사용가능
    /// </summary>
    public static class MvcHtmlHelpers
    {
        public static MvcHtmlString Pager(this HtmlHelper helper, int currentPage, int pageSize, long totalItemCount, int cGroupSize, string divCss = "pagination", string ulCss = "pagination")
        {
            var builder = new PagerBuilder();

            //!DIV 0
            if (totalItemCount == 0)
                totalItemCount = 1;

            //!DIV 0
            if (pageSize == 0)
                pageSize = 1;

            var routeValues = builder.GetCurrentRouteValues(helper.ViewContext);
            var pageCount = (int)Math.Ceiling(totalItemCount / (double)pageSize);

            // 올바르지 않은 페이지를 걸러냄
            currentPage = Math.Max(currentPage, 1);
            currentPage = Math.Min(currentPage, pageCount);

            var urlHelper   = new UrlHelper(helper.ViewContext.RequestContext, helper.RouteCollection);
            var container   = new TagBuilder("ul");
            var container2  = new TagBuilder("li");

            container.AddCssClass(divCss);
            //container2.AddCssClass(ulCss);

            var actionName = helper.ViewContext.RouteData.GetRequiredString("Action");

            // 그룹사이즈에 따른 마지막 그룹 계산
            var lastGroupNumber = currentPage;

            while ((lastGroupNumber % cGroupSize != 0)) lastGroupNumber++;

            // 페이지의 사이즈를 넘지 못하도록 함
            var groupEnd = Math.Min(lastGroupNumber, pageCount);
            var groupStart = lastGroupNumber - (cGroupSize - 1);

            /*
            // 이전 페이지로 돌아가기 버튼 생성	
            if (currentPage > 1)
            {
                var previous = new TagBuilder("a");
                //previous.InnerHtml = "<img src='" + Images.ImagesPath + "/Admin/btn/btn_prev.gif' alt='이전 리스트' />";
                previous.AddCssClass("pre");
                var routingValues = new RouteValueDictionary(routeValues);
                routingValues.Add("page", currentPage - 1);
                previous.MergeAttribute("href", urlHelper.Action(actionName, routingValues));
                container.InnerHtml += previous.ToString() + " ";
            }
            */

            // 그룹사이즈 크기를 넘어서 페이지이동을 하면 좌측에 이전 생성
            if (currentPage > cGroupSize)
            {
                /*
                var pageFirst = new TagBuilder("a");                            // 첫페이지로
                var routingValues2 = new RouteValueDictionary(routeValues);     // 
                // Images.PortalImagesPath >> /Content/Portal/img
                pageFirst.InnerHtml = "<img src='" + Images.PortalImagesPath + "/common/bl_prev.gif' alt='맨앞' />";
                pageFirst.AddCssClass("pre_end");
                routingValues2.Add("page", 1);
                pageFirst.MergeAttribute("href", urlHelper.Action(actionName, routingValues2));
                container.InnerHtml += pageFirst.ToString() + " ";
                 */
                
                var previous = new TagBuilder("a");                             // 이전페이지
                var routingValues = new RouteValueDictionary(routeValues);      //

                // previous.InnerHtml = "<img src='" + Images.PortalImagesPath + "/common/bl_prev2.gif' alt='이전' />";
                // previous.AddCssClass("pre");
                previous.InnerHtml = "<<<<";

                routingValues.Add("page", groupStart - cGroupSize);
                previous.MergeAttribute("href", urlHelper.Action(actionName, routingValues));
                container2.InnerHtml += previous.ToString();
                container.InnerHtml += container2.ToString();

            }
            else
            {
                var previous = new TagBuilder("a");                      // 이전페이지
                var routingValues = new RouteValueDictionary(routeValues);    //

                previous.InnerHtml = "&laquo;";
                //previous.AddCssClass("disabled");

                //routingValues.Add("page", groupStart - cGroupSize);
                previous.MergeAttribute("href", "#");

                container2.InnerHtml += previous.ToString();
                container2.AddCssClass("disabled");
                container.InnerHtml += container2.ToString();

            }


            //페이지 버튼 생성
            for (var i = groupStart; i <= groupEnd; i++)
            {
                TagBuilder pageNumber = new TagBuilder("a");
                TagBuilder liTag = new TagBuilder("li");

                if (i == currentPage)
                {
                    var routingValues = new RouteValueDictionary(routeValues);

                    routingValues.Remove("page");
                    routingValues.Add("page", i);

                    pageNumber.MergeAttribute("href", urlHelper.Action(actionName, routingValues));

                    liTag.AddCssClass("active");
                    pageNumber.SetInnerText((i).ToString());

                    liTag.InnerHtml += pageNumber.ToString();
                    container.InnerHtml += liTag.ToString();
                }
                else
                {
                    var routingValues = new RouteValueDictionary(routeValues);

                    pageNumber = new TagBuilder("a");
                    pageNumber.SetInnerText((i).ToString());

                    routingValues.Remove("page");
                    routingValues.Add("page", i);
                    pageNumber.MergeAttribute("href", urlHelper.Action(actionName, routingValues));
                    container.InnerHtml += pageNumber.ToString() + " ";
                }
            }

            // 그룹사이즈에 따른 ... 처리및 마지막 페이지 버튼 생성
            if (pageCount > groupEnd)
            {

                var next            = new TagBuilder("a");
                var routingValues   = new RouteValueDictionary(routeValues);
                var pageEnd         = new TagBuilder("a");
                var routingValues2  = new RouteValueDictionary(routeValues);

                next.InnerHtml = "<img src=\"" + Images.PortalImagesPath + "/common/bl_next2.gif\" alt=\"다음\" />";
                next.AddCssClass("next");

                routingValues.Add("page", groupEnd + 1);
                next.MergeAttribute("href", urlHelper.Action(actionName, routingValues));
                container.InnerHtml += next.ToString() + " ";

                pageEnd.InnerHtml = "<img src=\"" + Images.PortalImagesPath + "/common/bl_next.gif\" alt=\"맨뒤\" />";
                pageEnd.AddCssClass("next_end");

                routingValues2.Add("page", pageCount);
                pageEnd.MergeAttribute("href", urlHelper.Action(actionName, routingValues2));
                container.InnerHtml += pageEnd.ToString() + " ";
            }
            else
            {
                var next = new TagBuilder("a");                      // 이전페이지
                var nextLi = new TagBuilder("li");
                var routingValues = new RouteValueDictionary(routeValues);    //

                next.InnerHtml = "&raquo;";
                //previous.AddCssClass("disabled");

                //routingValues.Add("page", groupStart - cGroupSize);
                next.MergeAttribute("href", "#");

                nextLi.InnerHtml += next.ToString();
                nextLi.AddCssClass("disabled");
                container.InnerHtml += nextLi.ToString();

            }

            /*
        // 다음페이지 출력 버튼 생성
        if (currentPage < pageCount)
        {
            var next = new TagBuilder("a");
            //next.InnerHtml = "<img src='" + Images.ImagesPath + "/Admin/btn/btn_next.gif' alt='다음 리스트' />";
            next.AddCssClass("next");
            var routingValues = new RouteValueDictionary(routeValues);
            routingValues.Add("page", currentPage + 1);
            next.MergeAttribute("href", urlHelper.Action(actionName, routingValues));
            container.InnerHtml += next.ToString() + " ";
        }
             * /

        //string onChangeScript = "window.l-ocation.href=this.options[this.selectedIndex].value";

        // 바로이동
        //var pageMoveDiv = new TagBuilder("div");
        //pageMoveDiv.AddCssClass("normal_page_move");

        //TagBuilder tag = new TagBuilder("em");
        //tag.SetInnerText("페이지 바로이동  ");
        //pageMoveDiv.InnerHtml += tag.ToString();

        //TagBuilder input = new TagBuilder("input");
        ////select.AddCssClass("selectType01");
        //input.MergeAttribute("type", "text");
        //input.MergeAttribute("style", "width:50px");
        //input.MergeAttribute("id", "page");
        //input.MergeAttribute("value", currentPage.ToString());
        // 바로이동

        /*
        for (int i = 1; i <= pageCount; i++)
        {
            var routingValues3 = new RouteValueDictionary(routeValues);
            routingValues3.Add("page", i);

            select.InnerHtml += string.Format("<option text=\"{0}\" value=\"{1}\"", i, urlHelper.Action(actionName, routingValues3));
            if (i == currentPage)
                select.InnerHtml += string.Format(" selected=\"selected\"");
            select.InnerHtml += string.Format("><strong>{0}</strong><strong> / {1}</strong></option>", i, pageCount);
        }
        //*/

            //pageMoveDiv.InnerHtml += input.ToString();


            //var routingValues3 = new RouteValueDictionary(routeValues);
            //routingValues3.Remove("page");
            //string onClickScript = urlHelper.Action(actionName, routingValues3);
            //if (onClickScript.IndexOf("?") < 0)
            //{
            //    onClickScript = String.Format("window.l-ocation.href='{0}?page=' + $('#page').val();", onClickScript);
            //}
            //else
            //{
            //    onClickScript = String.Format("window.l-ocation.href='{0}&page=' + $('#page').val();", onClickScript);
            //}

            //TagBuilder button = new TagBuilder("input");
            //button.MergeAttribute("type", "button");
            //button.MergeAttribute("style", "width:50px");
            //button.MergeAttribute("value", "Go");
            //button.MergeAttribute("onclick", onClickScript);

            //pageMoveDiv.InnerHtml += button.ToString();

            //container.InnerHtml += pageMoveDiv.ToString();

            return MvcHtmlString.Create(container.ToString());
        }
    }
}
