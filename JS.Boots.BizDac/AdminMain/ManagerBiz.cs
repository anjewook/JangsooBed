using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using JS.Boots.Data;
using JS.Boots.Data.AdminMain;

namespace JS.Boots.BizDac.AdminMain
{
    public class ManagerBiz : BaseBiz
    {

        /// <summary>
        /// 관리자 정보 리스트
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        public IList<ManagerT> SelectAtManagerList(ManagerSearchT searchT)
        {
            return new ManagerDac().SelectAtManagerList(searchT);
        }

        /// <summary>
        /// 관리자 정보 가져오기
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        public ManagerT SelectAtManager(long ManagerSn)
        {
            return new ManagerDac().SelectAtManager(ManagerSn);
        }
    }
}
