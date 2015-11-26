using JS.Boots.Data.SystemMng;
using JS.Boots.Data.UserMng;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JS.Boots.Data.UserMng
{
    public class IndvdlUserPageT
    {
        public IndvdlUserSearchT SearchModel { get; set; }
        public GridModelT<IndvdlUserT> GridModel { get; set; }
        public IndvdlUserT IndvdlUserT { get; set; }
        public IList<CmmnCodeT> IndvdlUserSttusCodeList { get; set; }
        public IList<CmmnCodeT> TelnoList { get; set; }
        public IList<CmmnCodeT> MbtlnumList { get; set; }
        public IList<CmmnCodeT> EmailList { get; set; }
        public IList<CmmnCodeT> PasswordHintSeCodeList { get; set; }
    }
}
