using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using JS.Boots.Data.UserMng;

namespace JS.Boots.BizDac.UserMng
{
    public class IndvdlUserDac : BaseDac
    {
        /// <summary> 
        /// 개인사용자 목록 
        /// </summary>  
        /// <param name="searchT">개인사용자 검색조건</param> 
        /// <returns>개인사용자 목록</returns> 
        public IList<IndvdlUserT> SelectIndvdlUserList(IndvdlUserSearchT searchT)
        {
            return Js_Instance.QueryForList<IndvdlUserT>("IndvdlUserDac.SelectIndvdlUserList", searchT);
        }

        /// <summary>
        /// 개인사용자 상세
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public IndvdlUserT SelectIndvdlUser(string userId)
        {
            return Js_Instance.QueryForObject<IndvdlUserT>("IndvdlUserDac.SelectIndvdlUser", userId);
        }

        /// <summary> 
        /// 개인사용자 생성 
        /// </summary>  
        /// <param name="indvdlUserT">개인사용자 정보</param> 
        /// <returns>생성된 Row의 Key값</returns> 
        public object InsertIndvdlUser(IndvdlUserT indvdlUserT)
        {
            return Js_Instance.Insert("IndvdlUserDac.InsertIndvdlUser", indvdlUserT);
        }

        /// <summary> 
        /// 개인사용자 수정 
        /// </summary>  
        /// <param name="indvdlUserT">개인사용자 정보</param> 
        /// <returns>수정된 Row 수</returns> 
        public int UpdateIndvdlUser(IndvdlUserT indvdlUserT)
        {
            return Js_Instance.Update("IndvdlUserDac.UpdateIndvdlUser", indvdlUserT);
        }

        /// <summary>
        /// 개인사용자 삭제 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public int DeleteIndvdlUser(string userId)
        {
            return Js_Instance.Delete("IndvdlUserDac.DeleteIndvdlUser", userId);
        }

        /// <summary>
        /// 아이핀 고유번호 존재여부 조회
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public string SelectIpinExistYn(string ipinInnb)
        {
            return Js_Instance.QueryForObject<string>("IndvdlUserDac.SelectIpinExistYn", ipinInnb);
        }

    }
}
