using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using JS.Boots.Data.SystemMng;

namespace JS.Boots.Data.Product
{
    public class ProductViewT
    {
        public ProductT ProductT { get; set; }

        /// <summary>
        /// 검정 이력정보
        /// </summary>
        public IList<ProductT> AthrzHistList;
    }
}
