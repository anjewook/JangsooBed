using JS.Boots.Data.Atchmnfl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JS.Boots.Data.SystemMng
{
    public class BannerPageT
    {
        public BannerSearchT SearchModel { get; set; }
        public GridModelT<BannerT> GridModel { get; set; }
        public IList<CmmnCodeT> LinkTyCodeList { get; set; }
        public AtchmnflT AtchmnflT { get; set; }
    }
}
