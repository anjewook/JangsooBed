using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JS.Boots.Data.AdminMain
{
    public class ManagerSearchT : BaseSearchT
    {
        /// <summary>
        /// 페이지번호
        /// </summary>
        //public long Page { get; set; }

        /// <summary>
        /// 일련번호
        /// </summary>
        public long ManagerSn { get; set; }

        /// <summary>
        /// 아이디
        /// </summary>
        public string ManagerID { get; set; }

        /// <summary>
        /// 이름
        /// </summary>
        public string ManagerNM { get; set; }

        /// <summary>
        /// 휴대폰
        /// </summary>
        public string ManagerCelNum { get; set; }

        /// <summary>
        /// 정렬컬럼코드(01:등록일, 02:)
        /// </summary>
        public string OrderColumn { get; set; }

        /// <summary>
        /// 정렬형식(A:오름차순, D:내림차순)
        /// </summary>
        public string OrderType { get; set; }

        /// <summary>
        /// 메뉴코드
        /// </summary>
        public string menuCode { get; set; }


    }
}
