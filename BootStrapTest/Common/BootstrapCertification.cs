using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.Web.Security;

using JS.Boots.Data.UserMng;
using JS.Boots.BizDac.UserMng;
using JS.Boots.Data;

namespace BootStrapTest.Common
{
    public class BootstrapCertification
    {
        public static MessageT SignOn(ProfileT profileT)
        {
            MessageT messageT = new MessageT();

            messageT.IsSuccess = false;
            messageT.Message = "";
            try
            {
                // DB 에서 사용자 인증 확인
                //profileT = new ProfileBiz().LoginCheck(profileT);

                if (profileT != null)
                {
                    messageT.IsSuccess = true;

                    // 확인된 사용자 인증 처리
                    System.Web.Security.FormsAuthentication.SetAuthCookie(profileT.UserSeCode + "_" + profileT.UserId, false);

                    // 세션에는 사용자 기본정보만 저장
                    User = profileT;
                }

            }
            catch (Exception ex)
            {
                messageT.IsSuccess = false;
                messageT.Message = ex.Message;
            }
            return messageT;
        }

        public static void SignOut()
        {
            System.Web.Security.FormsAuthentication.SignOut();

            User = null;
        }

        public static ProfileT User
        {
            get
            {
                if (HttpContext.Current.Session["ProfileT"] == null)
                {
                    return new ProfileT();
                }
                else
                {
                    return (ProfileT)HttpContext.Current.Session["ProfileT"];
                }
            }
            set
            {
                HttpContext.Current.Session["ProfileT"] = value;
            }
        }
	}
}