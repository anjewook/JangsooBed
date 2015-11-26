using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JS.Boots.Data.SystemMng
{
    public class AuthorGroupEmplyrHistPageT
    {
        public AuthorGroupEmplyrHistSearchT SearchModel { get; set; }
        public GridModelT<AuthorGroupEmplyrHistT> GridModel { get; set; }
        public IList<CmmnCodeT> AuthorSttusCodeList { get; set; }
    }
}
