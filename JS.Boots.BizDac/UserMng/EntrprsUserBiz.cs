using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using JS.Boots.Data.UserMng;

namespace JS.Boots.BizDac.UserMng
{
    public class EntrprsUserBiz : BaseBiz
    {

        /// 기업사용자 목록 
        /// </summary>  
        /// <param name="searchT">기업사용자 검색조건</param> 
        /// <returns>기업사용자 목록</returns> 
        public IList<EntrprsUserT> SelectEntrprsUserList(EntrprsUserSearchT searchT)
        {
            return new EntrprsUserDac().SelectEntrprsUserList(searchT);
        }

        /// <summary>
        /// 기업사용자 상세
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public EntrprsUserT SelectEntrprsUser(string userId)
        {
            return new EntrprsUserDac().SelectEntrprsUser(userId);
        }

        /// <summary> 
        /// 기업사용자 생성 
        /// </summary>  
        /// <param name="entrprsUserT">기업사용자 정보</param> 
        /// <returns>생성된 Row의 Key값</returns> 
        public void InsertEntrprsUser(EntrprsUserT entrprsUserT)
        {
            BeginTran();
            try
            {
                string existYn = new UserDac().SelectUserExistYn(entrprsUserT.UserId);
                if (existYn == "Y")
                {
                    // 사용자 ID 중복체크
                    throw new Exception("해당 사용자ID 는 이미 사용중입니다.");
                }

                // 사용자 생성 
                UserT userT = new UserT();
                userT.UserId = entrprsUserT.UserId;
                userT.UserSeCode = "AC007002"; //사용자구분코드( 기업사용자: AC007002)

                new UserBiz().InsertUser(userT, "Y");

                // 기업사용자 INSERT
                new EntrprsUserDac().InsertEntrprsUser(entrprsUserT);

                Commit();
            }
            catch (Exception ex)
            {
                RollBack();
                throw (ex);
            }
        }

        /// <summary> 
        /// 기업사용자 수정 
        /// </summary>  
        /// <param name="entrprsUserT">기업사용자 정보</param> 
        /// <returns>수정된 Row 수</returns> 
        public int UpdateEntrprsUser(EntrprsUserT entrprsUserT)
        {
            return new EntrprsUserDac().UpdateEntrprsUser(entrprsUserT);
        }

        /// <summary> 
        /// 기업사용자 상태변경 
        /// </summary>  
        /// <param name="entrprsUserT">기업사용자 정보</param> 
        /// <returns>삭제된 Row 수</returns> 
        public int UpdateEntrprsUserSttusCode(EntrprsUserT entrprsUserT)
        {
            return new EntrprsUserDac().UpdateEntrprsUserSttusCode(entrprsUserT);
        }
    }
}
