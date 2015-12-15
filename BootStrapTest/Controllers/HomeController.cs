using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using JS.Boots.Data.UserMng;
using BootStrapTest.Common;
using JS.Boots.Data;
using JS.Boots.Data.SystemMng;
using JS.Boots.BizDac.Common;
//using JS.Boots.BizDac.SystemMng;
using Neoplus.Cryptor;

namespace BootStrapTest.Controllers
{
	public class HomeController : BaseController
	{
		public ActionResult Index()
		{
			return View();
		}
		public ActionResult Test1()
		{
			return View();
		}

		public ActionResult About()
		{
			ViewBag.Message = "Your application description page.";

			return View();
		}

		public ActionResult Contact()
		{
			ViewBag.Message = "Your contact page.";

			return View();
		}

        public ActionResult bootstrap_mvc()
        {
            ViewBag.Message = "Boot Strap Start.";

            return View();
        }

        public ActionResult _AdminTopMenu()
        {
            // 로그인 사용자정보
            ViewBag.User = BootstrapCertification.User;

            /*
            MenuBiz menuBiz = new MenuBiz();

            // 형식승인관리 하위메뉴
            IList<MenuT> menuList01 = menuBiz.SelectLowerMenuList("00051");

            // 검정관리
            IList<MenuT> menuList02 = menuBiz.SelectLowerMenuList("00052");

            // 사후관리정보
            IList<MenuT> menuList03 = menuBiz.SelectLowerMenuList("00053");

            // 실량표시상품관리
            IList<MenuT> menuList04 = menuBiz.SelectLowerMenuList("00054");

            // 부가업무관리
            IList<MenuT> menuList05 = menuBiz.SelectLowerMenuList("00055");

            // 콘텐츠관리
            IList<MenuT> menuList06 = menuBiz.SelectLowerMenuList("00056");

            // 통계관리
            IList<MenuT> menuList07 = menuBiz.SelectLowerMenuList("00057");

            // 사용자관리
            IList<MenuT> menuList08 = menuBiz.SelectLowerMenuList("00058");

            // 시스템관리
            IList<MenuT> menuList09 = menuBiz.SelectLowerMenuList("00003");

            ViewBag.menuList01 = menuList01;
            ViewBag.menuList02 = menuList02;
            ViewBag.menuList03 = menuList03;
            ViewBag.menuList04 = menuList04;
            ViewBag.menuList05 = menuList05;
            ViewBag.menuList06 = menuList06;
            ViewBag.menuList07 = menuList07;
            ViewBag.menuList08 = menuList08;
            ViewBag.menuList09 = menuList09;
            */

            return View((object)MenuCode);
        }

	}
}