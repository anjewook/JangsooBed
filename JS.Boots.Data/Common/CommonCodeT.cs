using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JS.Boots.Data.Common
{
    // 공통코드 관련 (Table : base_codeT )
    public class CommonCodeT : BaseModelT
    {
        /// <summary>
        /// 구분코드
        /// </summary>
        public string catCode { get; set; }

        /// <summary>
        /// 코드 Index
        /// </summary>
        public string idxCode { get; set; }

        /// <summary>
        /// 코드명
        /// </summary>
        public string codeName { get; set; }
    }
}
