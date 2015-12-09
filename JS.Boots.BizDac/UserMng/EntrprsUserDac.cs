using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using JS.Boots.Data.UserMng;

namespace JS.Boots.BizDac.UserMng
{
    public class EntrprsUserDac : BaseDac
    {
        /// <summary> 
        /// 기업사용자 목록 
        /// </summary>  
        /// <param name="searchT">기업사용자 검색조건</param> 
        /// <returns>기업사용자 목록</returns> 
        public IList<EntrprsUserT> SelectEntrprsUserList(EntrprsUserSearchT searchT)
        {
            return Js_Instance.QueryForList<EntrprsUserT>("EntrprsUserDac.SelectEntrprsUserList", searchT);
        }

        /// <summary>
        /// 기업사용자 상세 조회
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public EntrprsUserT SelectEntrprsUser(string userId)
        {
            return Js_Instance.QueryForObject<EntrprsUserT>("EntrprsUserDac.SelectEntrprsUser", userId);
        }

        /// <summary> 
        /// 기업사용자 생성 
        /// </summary>  
        /// <param name="entrprsUserT">기업사용자 정보</param> 
        /// <returns>생성된 Row의 Key값</returns> 
        public object InsertEntrprsUser(EntrprsUserT entrprsUserT)
        {
            return Js_Instance.Insert("EntrprsUserDac.InsertEntrprsUser", entrprsUserT);
        }

        /// <summary> 
        /// 기업사용자 수정 
        /// </summary>  
        /// <param name="entrprsUserT">기업사용자 정보</param> 
        /// <returns>수정된 Row 수</returns> 
        public int UpdateEntrprsUser(EntrprsUserT entrprsUserT)
        {
            return Js_Instance.Update("EntrprsUserDac.UpdateEntrprsUser", entrprsUserT);
        }

        /// <summary> 
        /// 기업사용자 상태변경 
        /// </summary>  
        /// <param name="entrprsUserT">기업사용자 정보</param> 
        /// <returns>삭제된 Row 수</returns> 
        public int UpdateEntrprsUserSttusCode(EntrprsUserT entrprsUserT)
        {
            return Js_Instance.Delete("EntrprsUserDac.UpdateEntrprsUserSttusCode", entrprsUserT);
        }

    }
}
