using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using JS.Boots.Data.UserMng;

namespace JS.Boots.BizDac.UserMng
{
    public class EmplBiz : BaseBiz
    {
        /// <summary>
        /// 사원 목록 조회
        /// </summary>
        /// <param name="searchT"></param>
        /// <returns></returns>
        public IList<EmplT> SelectEmplList(EmplSearchT searchT)
        {
            return new EmplDac().SelectEmplList(searchT);
        }

        /// <summary>
        /// 사원TREE 조회
        /// </summary>
        /// <param name="searchT"></param>
        /// <returns></returns>
        public IList<EmplTreeT> SelectEmplTree()
        {
            return new EmplDac().SelectEmplTree();
        }

        /// <summary>
        /// 사원 상세 조회
        /// </summary>
        /// <param name="emplCode"></param>
        /// <returns></returns>
        public EmplT SelectEmpl(string emplCode)
        {
            return new EmplDac().SelectEmpl(emplCode);
        }

        /// <summary>
        /// 조직정보 연계실행
        /// </summary>
        public void OrganizationTrans()
        {
            new EmplDac().OrganizationTrans();
        }

    }
}
