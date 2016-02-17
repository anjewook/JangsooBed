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
        public ManagerT SelectAtManager(string ManagerID)
        {
            return Js_Instance.QueryForObject<ManagerT>("ManagerDac.SelectAtManager", ManagerID);
        }

        /// <summary> 
        /// 관리자 생성 
        /// </summary>  
        /// <param name="managerT">관리자 정보</param> 
        //public object InsertManager(ManagerT managerT)
        public void InsertManager(ManagerT managerT)
        {
            Js_Instance.Insert("ManagerDac.InsertManager", managerT);
        }

        /// <summary> 
        /// 관리자 수정 
        /// </summary>  
        /// <param name="managerT">관리자 정보</param>
        public void UpdateManager(ManagerT managerT)
        {
            Js_Instance.Update("ManagerDac.UpdateManager", managerT);
        }

        /// <summary> 
        /// 관리자 삭제 
        /// </summary>  
        /// <param name="managerT">관리자 정보</param> 
        public void DeleteManager(long ManagerSn)
        {
            Js_Instance.Delete("ManagerDac.DeleteManager", ManagerSn);
        }

        /// <summary>
        /// 관리자ID 존재여부 조회
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public string SelectManagerExistYn(string userId)
        {
            return Js_Instance.QueryForObject<string>("ManagerDac.SelectManagerExistYn", userId);
        }
    }
}
