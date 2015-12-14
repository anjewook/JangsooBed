using BootStrapTest.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using JS.Boots.BizDac.Common;
using JS.Boots.BizDac.UserMng;
using JS.Boots.Data;
using JS.Boots.Data.Member;
using JS.Boots.Data.SystemMng;
using JS.Boots.Data.UserMng;
//using JS.Boots.Common;

namespace BootStrapTest.Controllers
{
    public class AdminController : BaseAdminController
    {
        #region 로그인/로그아웃

        /// <summary>
        /// 로그인 화면
        /// </summary>
        /// <param name="returnUrl"></param>
        /// <returns></returns>
        //[BootstrapAuthorize("00168", false)]
        [HttpGet]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        /// <summary>
        /// 로그인
        /// </summary>
        /// <param name="profileT"></param>
        /// <returns></returns>
        //[BootstrapAuthorize("00168", false)]
        [HttpPost]
        public ActionResult Login(ProfileT profileT)
        {
            profileT.UserHostAddress = Request.UserHostAddress;						//사용자 IP

            MessageT messageT = BootstrapCertification.SignOn(profileT);

            string passChangeElapseAt = "N";													//비밀번호변경 시간경과 여부

            if (BootstrapCertification.User.PassChangeElapseAt != null)
            {
                passChangeElapseAt = BootstrapCertification.User.PassChangeElapseAt;
            }

            return Json(new { Success = messageT.IsSuccess, Message = messageT.Message, PassChangeElapseAt = passChangeElapseAt });

        }

        /// <summary>
        /// 로그아웃
        /// </summary>
        /// <returns></returns>
        //[BootstrapAuthorize("00168", true)]
        [HttpGet]
        public ActionResult LogOut()
        {
            BootstrapCertification.SignOut();
            return Redirect("/");
        }

        #endregion

        public ActionResult TestBoot()
        {
            return View();
        }

        public ActionResult Main()
        {
            return View();
        }
	}
}