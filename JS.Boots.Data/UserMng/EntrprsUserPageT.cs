using JS.Boots.Data.SystemMng;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JS.Boots.Data.UserMng
{
    /// <summary>
    /// abc
    /// </summary>
    public class EntrprsUserPageT
    {
        /// <summary>
        /// aa
        /// </summary>
        public EntrprsUserSearchT SearchModel { get; set; }

        /// <summary>
        /// bb
        /// </summary>
        public GridModelT<EntrprsUserT> GridModel { get; set; }

        public EntrprsUserT EntrprsUserT { get; set; }

        public EntrprsT EntrprsT { get; set; }

        //public MyPageFrmIptCountT MyPageFrmIptCountT { get; set; }

        public IList<CmmnCodeT> EntrprsUserSttusCodeList { get; set; }

        public IList<CmmnCodeT> TelnoList { get; set; }

        public IList<CmmnCodeT> MbtlnumList { get; set; }

        public IList<CmmnCodeT> EmailList { get; set; }
        
    }
}
