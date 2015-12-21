using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using JS.Boots.BizDac.SystemMng;
using JS.Boots.Data.SystemMng;
using BootStrapTest.Common;
using JS.Boots.Security;

namespace BootStrapTest.Controllers
{
    public class MenuController : BaseAdminController
    {
        /// <summary>
        /// 메뉴관리
        /// </summary>
        /// <returns></returns>
        [BootstrapAuthorize("00004", true, Authorize.Read)]
        public ActionResult MenuMng()
        {
            // 권한Model : AuthT
            ViewBag.AuthT = base.AuthT;

            return View();
        }


        /// <summary>
        /// 메뉴 Tree 목록 조회
        /// </summary>
        /// <param name="searchT"></param>
        /// <returns></returns>
        [HttpGet]
        [BootstrapAuthorize("00004", true, Authorize.Read)]
        public JsonResult MenuTreeList(MenuSearchT searchT)
        {
            if (searchT.SearchUpperMenuCode == null)
            {
                //default 설정 : 관리자 메뉴[00001]
                searchT.SearchUpperMenuCode = "00001";
            }

            IList<MenuT> menuTreeList = new MenuBiz().SelectMenuTree(searchT);

            var lists = from n in menuTreeList
                        select new { id = n.Id, pId = n.Pid, name = n.MenuNm, open = false, isParent = (n.MenuTyCode == "AC009001" ? true : false), menuCode = n.MenuCode, menuTycode = n.MenuTyCode, icon = (n.UseAt == "Y") ? "" : "/Content/ztree/css/zTreeStyle/img/diy/10.png" };
            return Json(lists, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 메뉴상세 조회
        /// </summary>
        /// <param name="searchMenuCode"></param>
        /// <returns></returns>
        [HttpGet]
        [BootstrapAuthorize("00004", true, Authorize.Read)]
        public ActionResult MenuView(string searchMenuCode)
        {
            MenuT menuT = new MenuBiz().SelectMenu(searchMenuCode);
            return Json(menuT, JsonRequestBehavior.AllowGet);
        }

        public ActionResult LowerMenuList()
        {
            return View();
        }

        /// <summary>
        /// 메뉴 영속성 관리
        /// </summary>
        /// <param name="menuT"></param>
        /// <returns></returns>
        [HttpPost]
        [BootstrapAuthorize("00004", true, Authorize.Admin)]
        public ActionResult MenuProcess(MenuT menuT)
        {
            //권한체크시 parameter로 menuCode를 체크하기 때문에 ParamMenuCode로 치환하여 넘김.
            menuT.MenuCode = menuT.ParamMenuCode;

            bool success = true;
            string message = "";

            try
            {
                //메뉴 정보 영속성 관리 호출
                new MenuBiz().ProcessMenu(menuT);
            }
            catch (Exception ex)
            {
                success = false;
                message = ex.Message;
            }
            return Json(new { Success = success, Message = message });
        }
    }
}
