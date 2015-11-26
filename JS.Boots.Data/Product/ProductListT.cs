using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JS.Boots.Data.SystemMng;

namespace JS.Boots.Data.Product
{
    public class ProductListT
    {
        /// <summary>
        /// 검색용T
        /// </summary>
        public ProductSearchT SearchModel { get; set; }

        /// <summary>
        /// 그리드
        /// </summary>
        public GridModelT<ProductT> GridModel { get; set; }

        /// <summary>
        /// 계량기 종류[AB001000] 공통코드 목록
        /// </summary>
        public IList<CmmnCodeT> MrnrSeCodeList;
    }
}
