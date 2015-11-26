using JS.Boots.Data.SystemMng;
using JS.Boots.Data.UserMng;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JS.Boots.Data.Member
{
    public class JoinMembPageT
    {
        public IndvdlUserT IndvdlUserT { get; set; }
        public InsttT InsttT { get; set; }
        public InsttUserT InsttUserT { get; set; }
        public EntrprsT EntrprsT { get; set; }
        public EntrprsUserT EntrprsUserT { get; set; }
        public SignguUserT SignguUserT { get; set; }
        public IList<CmmnCodeT> EntrprsAdresSeCodeList { get; set; }
        public IList<CmmnCodeT> TelnoList { get; set; }
        public IList<CmmnCodeT> MbtlnumList { get; set; }
        public IList<CmmnCodeT> EmailList { get; set; }
        public IList<CmmnCodeT> PasswordHintSeCodeList { get; set; }
        public IList<CmmnCodeT> InsttSeCodeList { get; set; }
    }
}
