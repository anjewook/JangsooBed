using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using JS.Boots.Data.AdminMain;

namespace JS.Boots.BizDac.AdminMain
{
    public class ManagerDac : BaseDac
    {
        /// <summary> 
        /// 관리자 목록 조회 
        /// </summary>
        /// <param name="ManagerSearchT"></param> 
        /// <returns></returns> 
        public IList<ManagerT> SelectAtManagerList(ManagerSearchT searchT)
        {
            return Js_Instance.QueryForList<ManagerT>("ManagerDac.SelectAtManagerList", searchT);
        }

        /// <summary>
        /// 관리자 상세 조회
        /// </summary>
        /// <param name="emplCode"></param>
        /// <returns></returns>
        public ManagerT SelectAtManager(long ManagerSn)
        {
            return Js_Instance.QueryForObject<ManagerT>("ManagerDac.SelectAtManager", ManagerSn);
        }
    }
}
