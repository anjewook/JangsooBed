using JS.Boots.Data.Atchmnfl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JS.Boots.Data.SystemMng
{
    public class PopupPageT
    {
        public PopupSearchT SearchModel { get; set; }
        public GridModelT<PopupT> GridModel { get; set; }
        public PopupT PopupT { get; set; }
        public AtchmnflT AtchmnflT { get; set; }
    }
}
