using JS.Boots.BizDac.Common;
using JS.Boots.Data.UserMng;

using System;
using System.Collections.Generic;

namespace JS.Boots.BizDac.UserMng
{
    public class UserBiz : BaseBiz
    {
        /// <summary>
        /// 사용자ID 존재여부 판별
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public string SelectUserExistYn(string userId)
        {
            return new UserDac().SelectUserExistYn(userId);
        }

        /// <summary>
        /// 사용자 등록
        /// </summary>
        /// <param name="userT"></param>
        public void InsertUser(UserT userT, string createPwYn)
        {
            if (createPwYn == "Y")
            {
                //임시 비밀번호 생성
                string password = Security.Security.GetTempPassword();
                userT.Password = Security.Security.Encrypt(password); //비밀번호 암호화
                //TODO 비밀번호 이메일 전송
                new EmailSendBiz().SendTempPassword(userT.UserId);
            }
            userT.PasswordInitlAt = createPwYn;

            new UserDac().InsertUser(userT);
        }

        /// <summary>
        /// 사용자 비밀번호 수정
        /// </summary>
        /// <param name="userT"></param>
        public void UpdateUserPassword(UserT userT)
        {
            //사용자정보 조회
            ProfileT profileT = new ProfileT();
            profileT.UserId = userT.UserId;
            profileT.UserSeCode = userT.UserSeCode;
            //profileT = new ProfileDac().SelectUser(profileT);

            if (profileT != null)
            {
                //기존비밀번호 일치여부 판별
                if (profileT.Password == Security.Security.Encrypt(userT.OldPassword))
                {
                    userT.PasswordInitlAt = "N"; //비밀번호 초기화 여부
                    userT.Password = Security.Security.Encrypt(userT.Password); //비밀번호 암호화
                    new UserDac().UpdateUserPassword(userT);
                }
                else
                {
                    throw new Exception("기존비밀번호가 일치하지 않습니다.");
                }
            }
            else
            {
                throw new Exception("존재하지 않는 사용자 입니다.");
            }
        }

        /// <summary>
        /// 사용자 비밀번호 초기화
        /// </summary>
        /// <param name="userId"></param>
        public UserT InitUserPassword(string userId)
        {
            string initPassword = Security.Security.GetTempPassword();
            UserT userT = new UserT();
            userT.UserId = userId;
            userT.PasswordInitlAt = "Y";
            userT.Password = Security.Security.Encrypt(initPassword);

            //비밀번호 수정
            new UserDac().UpdateUserPassword(userT);

            //비밀번호 이메일 전송
            ArchFx.EventLog.WindowEventLog.WriteLog("Ktc : SendTempPassword", "SendTempPassword", System.Diagnostics.EventLogEntryType.Information);
            new EmailSendBiz().SendTempPassword(userId);

            return userT;
        }

        /// <summary>
        /// 사용자 삭제(물리삭제)
        /// </summary>
        /// <param name="userId"></param>
        public void DeleteUser(string userId)
        {
            new UserBiz().DeleteUser(userId);
        }

        /// <summary>
        /// ID,PW 찾기
        /// </summary>
        /// <param name="userT"></param>
        /// <returns></returns>
        public UserT FindIdPw(UserT userT)
        {
            string userId = new UserDac().SelectUserId(userT);
            if (userId != null && userId.Length > 0)
            {
                if (userT.FindSeCode == "PW")
                {
                    //비밀번호 초기화
                    InitUserPassword(userT.UserId);
                }
                userT.UserId = userId;
                userT.IsSuccess = true;
            }
            else
            {
                userT.IsSuccess = false;
            }
            return userT;
        }

        /// <summary>
        /// 회원탈퇴(개인회원)
        /// </summary>
        /// <param name="userT"></param>
        /// <returns></returns>
        public bool MberSecsn(UserT userT)
        {
            bool isSuceess = true;

            //사용자(개인사용자) 존재여부 판별
            ProfileT profileT = new ProfileT();
            profileT.UserId = userT.UserId;
            profileT.UserSeCode = "AC007001";

            //profileT = new ProfileDac().SelectUser(profileT);

            if (profileT != null)
            {
                //비밀번호 비교
                if (profileT.Password == Security.Security.Encrypt(userT.Password))
                {
                    //회원삭제
                    BeginTran();
                    try
                    {
                        //개인회원정보 삭제
                        //new IndvdlUserDac().DeleteIndvdlUser(userT.UserId);

                        //사용자정보 삭제 [김동훈 주석처리(2013-05-16) : 동일ID의 다른 유저의 가입을 막기위해 삭제하지 않는다.]
                        //new UserDac().DeleteUser(userT.UserId);

                        Commit();
                    }
                    catch (Exception ex)
                    {
                        RollBack();
                        throw ex;
                    }
                }
                else
                {
                    throw new Exception("비밀번호가 맞지 않습니다.");
                }
            }
            else
            {
                throw new Exception("존재하지 않는 사용자 이거나 개인사용자가 아닙니다.");
            }

            return isSuceess;
        }
            
    }
}
