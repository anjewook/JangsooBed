using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JS.Boots.Data.SystemMng
{
    public class AuthorGroupSearchT : BaseSearchT
    {
        /// <summary>
        /// 검색 사용여부
        /// </summary>
        public string SearchUseAt { get; set; }

        /// <summary>
        /// KTC담당자권한설정여부
        /// </summary>
        public string SearchKtcUserEstbsAt { get; set; }
    }
}
