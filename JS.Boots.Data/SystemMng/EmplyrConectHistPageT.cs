using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JS.Boots.Data.SystemMng
{
    public class EmplyrConectHistPageT
    {
        public EmplyrConectHistSearchT SearchModel { get; set; }
        public GridModelT<EmplyrConectHistT> GridModel { get; set; }
        public IList<CmmnCodeT> UserSeCodeList { get; set; }
    }
}
