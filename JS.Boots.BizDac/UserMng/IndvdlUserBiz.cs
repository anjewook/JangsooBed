using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using JS.Boots.Data.UserMng;

namespace JS.Boots.BizDac.UserMng
{
    public class IndvdlUserBiz : BaseBiz
    {
        /// <summary> 
        /// 개인사용자 목록 
        /// </summary>  
        /// <param name="searchT">개인사용자 검색조건</param> 
        /// <returns>개인사용자 목록</returns> 
        public IList<IndvdlUserT> SelectIndvdlUserList(IndvdlUserSearchT searchT)
        {
            return new IndvdlUserDac().SelectIndvdlUserList(searchT);
        }

        /// <summary>
        /// 개인사용자 상세
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public IndvdlUserT SelectIndvdlUser(string userId)
        {
            return new IndvdlUserDac().SelectIndvdlUser(userId);
        }

        /// <summary> 
        /// 개인사용자 생성 
        /// </summary>  
        /// <param name="indvdlUserT">개인사용자 정보</param> 
        /// <returns>생성된 Row의 Key값</returns> 
        public void InsertIndvdlUser(IndvdlUserT indvdlUserT)
        {

            BeginTran();
            try
            {
                //회원가입을 통해 개인사용자를 생성하는 경우 아이핀 고유번호 중복체크
                if (!String.IsNullOrEmpty(indvdlUserT.IpinInnb))
                {
                    string ipinExistYn = new IndvdlUserDac().SelectIpinExistYn(indvdlUserT.IpinInnb);
                    if (ipinExistYn == "Y")
                    {
                        //아이핀 고유번호 중복체크
                        throw new Exception("해당 사용자는 이미 회원가입된 사용자입니다.");
                    }
                }

                string existYn = new UserDac().SelectUserExistYn(indvdlUserT.UserId);
                if (existYn == "Y")
                {
                    // 사용자 ID 중복체크
                    throw new Exception("해당 사용자ID 는 이미 사용중입니다.");
                }

                // 사용자 생성 
                UserT userT = new UserT();
                userT.UserId = indvdlUserT.UserId;
                userT.Password = Security.Security.Encrypt(indvdlUserT.Password); //TODO 암호화
                //userT.Password = indvdlUserT.Password;
                userT.UserSeCode = "AC007001"; //사용자구분코드( 개인사용자: AC007001)

                new UserBiz().InsertUser(userT, "N");

                // 개인사용자 INSERT
                new IndvdlUserDac().InsertIndvdlUser(indvdlUserT);

                Commit();
            }
            catch (Exception ex)
            {
                RollBack();
                throw (ex);
            }
        }

        /// <summary> 
        /// 개인사용자 수정 
        /// </summary>  
        /// <param name="indvdlUserT">개인사용자 정보</param> 
        /// <returns>수정된 Row 수</returns> 
        public int UpdateIndvdlUser(IndvdlUserT indvdlUserT)
        {
            return new IndvdlUserDac().UpdateIndvdlUser(indvdlUserT);
        }

        /// <summary> 
        /// 개인사용자 삭제 (물리삭제)
        /// </summary>  
        /// <param name="indvdlUserT">개인사용자 정보</param> 
        public void DeleteIndvdlUser(string userId)
        {
            BeginTran();
            try
            {
                //개인사용자 삭제
                new IndvdlUserDac().DeleteIndvdlUser(userId);

                //사용자 삭제
                new UserDac().DeleteUser(userId);

                Commit();
            }
            catch (Exception ex)
            {
                RollBack();
                throw ex;
            }
        }

    }
}
