using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using JS.Boots.Data.UserMng;

namespace JS.Boots.BizDac.UserMng
{
    public class EmplDac : BaseDac
    {
        /// <summary> 
        /// 사원 목록 조회 
        /// </summary>  
        /// <remarks>  
        ///  자세한 설명  
        /// </remarks> 
        /// <param name="EmplSearchT"></param> 
        /// <returns></returns> 
        public IList<EmplT> SelectEmplList(EmplSearchT searchT)
        {
            return Js_Instance.QueryForList<EmplT>("EmplDac.SelectEmplList", searchT);
        }

        /// <summary> 
        /// 사원 TREE 조회
        /// </summary>  
        /// <remarks>  
        ///  자세한 설명  
        /// </remarks> 
        /// <param name="DeptSearchT"></param> 
        /// <returns></returns> 
        public IList<EmplTreeT> SelectEmplTree()
        {
            return Js_Instance.QueryForList<EmplTreeT>("EmplDac.SelectEmplTree", null);
        }

        /// <summary>
        /// 사원 상세 조회
        /// </summary>
        /// <param name="emplCode"></param>
        /// <returns></returns>
        public EmplT SelectEmpl(string emplCode)
        {
            return Js_Instance.QueryForObject<EmplT>("EmplDac.SelectEmpl", emplCode);
        }

        /// <summary>
        /// 조직정보 연계실행
        /// </summary>
        public void OrganizationTrans()
        {
            Js_Instance.QueryForObject("EmplDac.OrganizationTrans", null);
        }

    }
}
