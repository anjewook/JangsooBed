using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JS.Boots.Data.OptionWorkMng
{
    public class JobContactSearchT : BaseSearchT
    {
        /// <summary>  
        /// 업무연락일련번호
        /// </summary> 
        public int JobContactSn { get; set; }

        /// <summary>
        /// 검색 : 등록자명
        /// </summary>
        public string SearchRegistName { get; set; }

        /// <summary>
        /// 검색 : 제목명
        /// </summary>
        public string SearchSjNm { get; set; }
    }
}
