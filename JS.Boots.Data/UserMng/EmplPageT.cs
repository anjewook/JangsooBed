using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JS.Boots.Data.UserMng
{
    public class EmplPageT
    {
        public EmplSearchT SearchModel { get; set; }
        public EmplT EmplT { get; set; }
        public GridModelT<EmplT> GridModel { get; set; }

    }
}
