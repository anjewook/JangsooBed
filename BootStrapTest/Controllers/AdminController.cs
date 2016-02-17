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
using JS.Boots.BizDac.AdminMain;
using JS.Boots.Data.AdminMain;

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

        [BootstrapAuthorize("PARAM_CHECK", false)]
        [HttpGet]
        public ActionResult Main(ManagerSearchT searchT)
        {
            // 권한Model : AuthT
            ViewBag.AuthT = AuthT;

            // 관리자정보 가져오기
            /*
            ManagerT managerT = new ManagerBiz().SelectAtManager(searchT.ManagerSn);
            if (managerT == null){
                new Exception("관리자가 존재하지 않습니다.");
            }
            */
            

            ViewBag.SearchT = searchT;          // 관리자검색 정보
            CmmnCodeT rankT = new CmmnCodeT();
            rankT.cdIndex = "AD_RANK";

            IList<CmmnCodeT> rankCodeList = new CommonBiz().SelectOptCodeList(rankT);   // 직급정보
            ViewBag.rankCodeList = rankCodeList;
            //ViewBag.ManagerT    = managerT;     // 관리자정보

            CmmnCodeT postT = new CmmnCodeT();
            postT.cdIndex = "AD_POST";
            IList<CmmnCodeT> postCodeList = new CommonBiz().SelectOptCodeList(postT);   // 부서정보
            ViewBag.postCodeList = postCodeList;

            CmmnCodeT telT = new CmmnCodeT();
            telT.cdIndex = "BAS_0001";
            IList<CmmnCodeT> telCodeList = new CommonBiz().SelectOptCodeList(telT);   // 전화국번정보
            ViewBag.telCodeList = telCodeList;

            CmmnCodeT celT = new CmmnCodeT();
            celT.cdIndex = "BAS_0002";
            IList<CmmnCodeT> celCodeList = new CommonBiz().SelectOptCodeList(celT);   // 휴대폰국번정보
            ViewBag.celCodeList = celCodeList;

            CmmnCodeT mailT = new CmmnCodeT();
            mailT.cdIndex = "BAS_0003";
            mailT.cdorder = "CDORDER";
            IList<CmmnCodeT> mailCodeList = new CommonBiz().SelectOptCodeList(mailT);   // Email정보
            ViewBag.mailCodeList = mailCodeList;
            

            GridModelT<ManagerT> gridModel = new GridModelT<ManagerT>();
            gridModel.PageSize = searchT.PageSize;
            gridModel.page = searchT.page;

            gridModel.GridData = new ManagerBiz().SelectAtManagerList(searchT);
            gridModel.TotalCount = 0;

            if (gridModel.GridData.Count > 0)
            {
                gridModel.TotalCount = (int)gridModel.GridData[0].TotalCount;
            }

            return View(gridModel);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult ManagerRegist(string provider)
        {
            // 외부 로그인 공급자에 대한 리디렉션 요청
            //return new ChallengeResult(provider, Url.Action("ExternalLoginCallback", "Account", new { ReturnUrl = returnUrl }));
            return View(provider);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult ManagerEdit(ManagerT managerT)
        {
            // 외부 로그인 공급자에 대한 리디렉션 요청
            //return new ChallengeResult(provider, Url.Action("ExternalLoginCallback", "Account", new { ReturnUrl = returnUrl }));
            return View(managerT);
        }

        [BootstrapAuthorize("PARAM_CHECK", false)]
        [HttpPost]
        //public ActionResult ManagerRegistAction(EntrprsT entrprsT)
        public ActionResult ManagerRegistAction(ManagerT managerT)
        {
            string userId = managerT.ManagerID;
            string userSeCode = "AC007002";             // 기업사용자

            //수정자,수정자구분코드 설정
            managerT.RegisterId = userId;
            managerT.RegisterSeCode = userSeCode;
            managerT.UpdusrId = userId;
            managerT.UpdusrSeCode = userSeCode;
            managerT.ManagerCode = 1000;
            //managerT.MberAt = "Y";                    // 회원여부 설정

            bool isSuccess = false;
            string strMessage = "";

            try
            {
                new ManagerBiz().JoinManagerMember(managerT);

                //회원가입 이메일 발송
                //new EmailSendBiz().SendJoinMember(userId, userSeCode, managerT.EmailAdres);

                isSuccess = true;
            }
            catch (Exception ex)
            {
                strMessage = ex.Message;
            }
            return Json(new { Success = isSuccess, Message = strMessage }, JsonRequestBehavior.AllowGet);

        }

        public ActionResult ManagerIDChk(string ManagerID)
        {

            bool isSuccess = false;
            string strMessage = "";

            try
            {
                //new ManagerBiz().CheckManagerID(ManagerID);
                string existYn = new ManagerBiz().SelectManagerExistYn(ManagerID);
                if (existYn == "N")
                {
                    isSuccess = true;
                    strMessage = "사용가능한 아이디 입니다.";
                }
                else
                {
                    isSuccess = false;
                    strMessage = "이미 존재하는 아이디 입니다.";
                }
            }
            catch (Exception ex)
            {
                strMessage = ex.Message;
            }
            return Json(new { Success = isSuccess, Message = strMessage }, JsonRequestBehavior.AllowGet);
        }



        [BootstrapAuthorize("PARAM_CHECK", false)]
        [HttpGet]
        public ActionResult ManagerAuth(ManagerSearchT searchT)
        {
            // 권한Model : AuthT
            ViewBag.AuthT = AuthT;

            // 관리자정보 가져오기
            /*
            ManagerT managerT = new ManagerBiz().SelectAtManager(searchT.ManagerSn);
            if (managerT == null){
                new Exception("관리자가 존재하지 않습니다.");
            }
            */


            ViewBag.SearchT = searchT;          // 관리자검색 정보
            CmmnCodeT rankT = new CmmnCodeT();
            rankT.cdIndex = "AD_RANK";

            IList<CmmnCodeT> rankCodeList = new CommonBiz().SelectOptCodeList(rankT);   // 직급정보
            ViewBag.rankCodeList = rankCodeList;
            //ViewBag.ManagerT    = managerT;     // 관리자정보

            CmmnCodeT postT = new CmmnCodeT();
            postT.cdIndex = "AD_POST";
            IList<CmmnCodeT> postCodeList = new CommonBiz().SelectOptCodeList(postT);   // 부서정보
            ViewBag.postCodeList = postCodeList;

            CmmnCodeT telT = new CmmnCodeT();
            telT.cdIndex = "BAS_0001";
            IList<CmmnCodeT> telCodeList = new CommonBiz().SelectOptCodeList(telT);   // 전화국번정보
            ViewBag.telCodeList = telCodeList;

            CmmnCodeT celT = new CmmnCodeT();
            celT.cdIndex = "BAS_0002";
            IList<CmmnCodeT> celCodeList = new CommonBiz().SelectOptCodeList(celT);   // 휴대폰국번정보
            ViewBag.celCodeList = celCodeList;

            CmmnCodeT mailT = new CmmnCodeT();
            mailT.cdIndex = "BAS_0003";
            mailT.cdorder = "CDORDER";
            IList<CmmnCodeT> mailCodeList = new CommonBiz().SelectOptCodeList(mailT);   // Email정보
            ViewBag.mailCodeList = mailCodeList;


            GridModelT<ManagerT> gridModel = new GridModelT<ManagerT>();
            gridModel.PageSize = searchT.PageSize;
            gridModel.page = searchT.page;

            gridModel.GridData = new ManagerBiz().SelectAtManagerList(searchT);
            gridModel.TotalCount = 0;

            if (gridModel.GridData.Count > 0)
            {
                gridModel.TotalCount = (int)gridModel.GridData[0].TotalCount;
            }

            return View(gridModel);
        }


        [HttpPost]
        public ActionResult managerJsonData(string managerID)
        {
            string message = string.Format("Created user '{0}' in the system.", managerID);

            ManagerT managerT = new ManagerBiz().SelectAtManager(managerID);

            return Json(new { Message = message, managerT = managerT });
        }

        /*
        public JsonResult managerJsonData()
        {
            // Creat basic JSON object with data for chart
            var chartData = new[] {
                new {Name = "Ashton Cox", Position = "Junior Technical Author", Office = "London", Age = 33},
                new {Name = "Bradley Greer", Position = "Pre-Sales Support", Office = "Tokyo", Age = 27},
                new {Name = "Airi Satou", Position = "Integration Specialist", Office = "New York", Age = 43},
                new {Name = "Caesar Vance", Position = "Software Engineer", Office = "San Francisco", Age = 36},
            };

            // Return JSON object
            return Json(chartData, JsonRequestBehavior.AllowGet);
        }
         */

        [BootstrapAuthorize("PARAM_CHECK", false)]
        [HttpPost]
        public ActionResult ManagerEditAction(ManagerT managerT)
        {
            string userId = managerT.ManagerID;
            string userSeCode = "AC007002";             // 기업사용자

            //수정자,수정자구분코드 설정
            managerT.RegisterId = userId;
            managerT.RegisterSeCode = userSeCode;
            managerT.UpdusrId = userId;
            managerT.UpdusrSeCode = userSeCode;
            managerT.ManagerCode = 1000;
            //managerT.MberAt = "Y";                    // 회원여부 설정

            bool isSuccess = false;
            string strMessage = "";

            try
            {
                new ManagerBiz().UpdateMangerMember(managerT);

                //회원가입 이메일 발송
                //new EmailSendBiz().SendJoinMember(userId, userSeCode, managerT.EmailAdres);

                isSuccess = true;
            }
            catch (Exception ex)
            {
                strMessage = ex.Message;
            }
            return Json(new { Success = isSuccess, Message = strMessage }, JsonRequestBehavior.AllowGet);

        }
    }
}