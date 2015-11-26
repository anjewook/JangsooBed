using JS.Boots.Data.SystemMng;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JS.Boots.Data.UserMng
{
    public class InsttUserPageT
    {
        public InsttUserSearchT SearchModel { get; set; }
        public GridModelT<InsttUserT> GridModel { get; set; }
        public InsttUserT InsttUserT { get; set; }
        public IList<CmmnCodeT> InsttUserSttusCodeList { get; set; }
        public IList<CmmnCodeT> TelnoList { get; set; }
        public IList<CmmnCodeT> MbtlnumList { get; set; }
        public IList<CmmnCodeT> EmailList { get; set; }
        public IList<CmmnCodeT> InsttSeCodeList { get; set; }
    }
}
