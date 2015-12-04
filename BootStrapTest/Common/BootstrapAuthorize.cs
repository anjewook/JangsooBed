using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web.Mvc;

using JS.Boots.Security;
using JS.Boots.Data.UserMng;
using JS.Boots.BizDac.UserMng;
//using JS.Boots.BizDac.Stats;
using JS.Boots.Data;
using JS.Boots.Data.SystemMng;
//using JS.Boots.BizDac.SystemMng;


namespace BootStrapTest.Common
{
    public class BootstrapAuthorize : AuthorizeAttribute
    {
        private bool IsLoginNeed = false;
        private bool IsLogin = false;
        private string MenuCode = "";
        private Authorize[] CheckAuth = null;

        public BootstrapAuthorize(string menuCode,bool isLoginNeed, params Authorize[] checkAuth/*, UserType[] possibleTypeList*/)
        {
            MenuCode = menuCode;
            CheckAuth = checkAuth;

            IsLoginNeed = isLoginNeed;
        }


        /*
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            IsLogin = base.AuthorizeCore(httpContext);

            //파라미터로 넘기는 menuCode를 받는다.[하나의 URL로 여러개의 메뉴를 다루는 곳에서 권한인증을 위해 설정]
            if (MenuCode == "PARAM_CHECK" || !String.IsNullOrEmpty(httpContext.Request["menuCode"]))
            {
                string checkMenuCode = httpContext.Request["menuCode"];//httpContext.Request.Params.Get("menuCode");
                if (checkMenuCode != null)
                {
                    MenuCode = checkMenuCode;
                }
            }

            httpContext.Items["MenuCode"] = MenuCode;

            // 메뉴코드 통계INSERT
            new StatsBiz().ProcessStatsMenuCount(MenuCode);

            if (IsLogin == true)
            {
                bool bIsAuth = true;

                try
                {
                    if (BootsrapCertification.User == null || BootsrapCertification.User.UserId == null)
                    {
                        BootsrapCertification.SignOut();
                        IsLogin = false;
                        bIsAuth = false;
                    }
                    else
                    {
                        // MenuCode 에 해당하는 사용자의 권한목록을 DB에서 조회
                        UserMenuAuthSearchT userMenuAuthSearchT = new UserMenuAuthSearchT();
                        userMenuAuthSearchT.MenuCode = MenuCode; //메뉴ID
                        userMenuAuthSearchT.UserId = BootsrapCertification.User.UserId; //사용자ID
                        userMenuAuthSearchT.UserSeCode = BootsrapCertification.User.UserSeCode; //사용자구분코드
                        userMenuAuthSearchT.AuthorGroupList = BootsrapCertification.User.AuthorGroupList; //권한그룹목록

                        IList<string> authList = new ProfileBiz().SelectUserMenuAuthList(userMenuAuthSearchT);

                        // 해당 메뉴의 사용권한을 저장
                        AuthT authT = new AuthT();
                        if (authList != null && authList.Count > 0) 
                        {
                            authT.IsRead = authList.Contains("AC006001");
                            authT.IsCreate = authList.Contains("AC006002");
                            authT.IsUpdate = authList.Contains("AC006003");
                            authT.IsDelete = authList.Contains("AC006004");
                            authT.IsPrint = authList.Contains("AC006005");
                            authT.IsAdmin = authList.Contains("AC006006");
                        }


                        httpContext.Items["AuthT"] = authT;


                        // 체크할 기능권한이 있으면
                        List<Authorize> authotizeList = Security.Security.AuthorizeTypeChange(authList.ToList());
                        if (CheckAuth != null)
                        {
                            // 권한이 존재하는지 체크
                            bool isAllHave = true;

                            foreach (Authorize checkauthotize in CheckAuth)
                            {
                                bool isHave = false;

                                foreach (Authorize userAuthotize in authotizeList)
                                {
                                    if (checkauthotize == userAuthotize)
                                    {
                                        isHave = true;
                                    }
                                }

                                if (isHave == false)
                                {
                                    isAllHave = false;
                                }
                            }

                            if (isAllHave == false)
                            {
                                bIsAuth = false;
                            }
                        }

                        if (bIsAuth)
                        {
                            //사용자접속통계 INSERT 
                            if (BootsrapCertification.User.UserSeCode == "AC007003" || BootsrapCertification.User.UserSeCode == "AC007004" || BootsrapCertification.User.UserSeCode == "AC007005")
                            {
                                //new EmplyrConectHistBiz().InsertEmplyrConectHist(MenuCode, BootsrapCertification.User);
                            }
                        } 
                    }

                }
                catch (Exception ex)
                {
                    throw ex;
                }

#if DEBUG
                if (BootsrapCertification.User.UserId == "system" || BootsrapCertification.User.UserId == "entr01")
                {
                    bIsAuth = true;
                }
#endif
                return bIsAuth;
            }
            else
            {
                if (IsLoginNeed == true)
                {
                    return IsLogin;
                }
                else
                {
                    return true;
                }
            }
        }
        */

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            UrlHelper urlHelper = new UrlHelper(filterContext.RequestContext);
            if (filterContext.HttpContext.Request.IsAjaxRequest())
            {
                //return Json 
                JsonResult result = new JsonResult();
                result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
                filterContext.Result = result;
            }
            else
            {
                if (filterContext.HttpContext.User.Identity.IsAuthenticated && IsLogin == true)
                    filterContext.Result = new RedirectResult("/Home/NoAuth");
                else
                    base.HandleUnauthorizedRequest(filterContext);
            }
        }
    }
}