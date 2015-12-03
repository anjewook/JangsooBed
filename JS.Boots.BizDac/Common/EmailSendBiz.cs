using JS.Boots.BizDac.UserMng;
using JS.Boots.Data.UserMng;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace JS.Boots.BizDac.Common
{
    public class EmailSendBiz : BaseBiz
    {

        /// <summary>
        /// 회원가입 이메일 발송
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="userSeCode"></param>
        /// <param name="userEmailAdres"></param>
        public void SendJoinMember(string userId, string userSeCode, string userEmailAdres)
        {
            try
            {
                string content = new CommonBiz().ReadEmailTemplete(EmailInfo.EmailTempletePath + "/joinMember.html");

                if (!String.IsNullOrEmpty(content))
                {
                    string userSeCodeNm = "";
                    if (userSeCode == "AC007001")
                    {
                        userSeCodeNm = "개인사용자";
                    }
                    else if (userSeCode == "AC007002")
                    {
                        userSeCodeNm = "기업사용자";
                    }
                    else if (userSeCode == "AC007003")
                    {
                        userSeCodeNm = "기관사용자";
                    }
                    content = content.Replace("$$HOST_URL$$", EmailInfo.EmailSiteUrl);
                    content = content.Replace("$$IMG_PATH$$", Images.PortalImagesPath);
                    content = content.Replace("$$USER_SE_CODE$$", userSeCodeNm);
                    content = content.Replace("$$USER_ID$$", userId);
                    content = content.Replace("$$EMAIL_ADRES$$", userEmailAdres);
                    content = content.Replace("$$JOIN_DATE$$", DateTime.Now.ToString("yyyy") + "년 " + DateTime.Now.ToString("MM") + "월" + DateTime.Now.ToString("dd") + "일");

                    string[] arrToMailAddress = new string[] { userEmailAdres };

                    //이메일 발송
                    new CommonBiz().SendMail(EmailInfo.SenderEmailAddress, arrToMailAddress, "계량종합관리시스템 회원가입 안내", content, true);
                }

            }
            catch (Exception ex)
            {
                //메일보내기 실패
            }
        }

        /// <summary>
        /// 임시비밀번호 발급 이메일 전송
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="userSeCode"></param>
        /// <param name="userEmailAdres"></param>
        /// <param name="password"></param>
        public void SendTempPassword(string userId)
        {
            try
            {
                //사용자 정보 조회
                ProfileT profileT = new ProfileT();
                profileT.UserId = userId;
                /*
                profileT = new ProfileDac().SelectUser(profileT);


                if (profileT != null && profileT.Email.Length > 0)
                {
                    string content = new CommonBiz().ReadEmailTemplete(EmailInfo.EmailTempletePath + "/InitPassword.html");

                    if (!String.IsNullOrEmpty(content))
                    {
                        content = content.Replace("$$HOST_URL$$", EmailInfo.EmailSiteUrl);
                        content = content.Replace("$$IMG_PATH$$", Images.PortalImagesPath);
                        content = content.Replace("$$USER_SE_CODE$$", profileT.UserSeName);
                        content = content.Replace("$$USER_ID$$", userId);
                        content = content.Replace("$$PASSWORD$$", Security.Security.Decrypt(profileT.Password));

                        string[] arrToMailAddress = new string[] { profileT.Email };

                        //이메일 발송
                        new CommonBiz().SendMail(EmailInfo.SenderEmailAddress, arrToMailAddress, "계량종합관리시스템 임시 비밀번호 발송 안내", content, true);
                    }
                }
                 */
            }
            catch (Exception ex)
            {
                //메일보내기 실패
            }
        }
    }
}
