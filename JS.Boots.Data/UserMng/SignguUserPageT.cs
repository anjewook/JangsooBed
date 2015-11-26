using JS.Boots.Data.SystemMng;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JS.Boots.Data.UserMng
{
    public class SignguUserPageT
    {
        public SignguUserSearchT SearchModel { get; set; }
        public GridModelT<SignguUserT> GridModel { get; set; }
        public SignguUserT SignguUserT { get; set; }
        public IList<CmmnCodeT> SignguUserSttusCodeList { get; set; }
        public IList<CmmnCodeT> TelnoList { get; set; }
        public IList<CmmnCodeT> MbtlnumList { get; set; }
        public IList<CmmnCodeT> EmailList { get; set; }
        public IList<CmmnCodeT> AtptSeCodeList { get; set; }
        public IList<CmmnCodeT> GuGunSeCodeList { get; set; }
        
    }
}
