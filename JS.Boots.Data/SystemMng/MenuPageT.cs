using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JS.Boots.Data.SystemMng
{
    public class MenuPageT 
    {
        public MenuT MenuT { get; set; }
        public MenuSearchT MenuSearchT { get; set; }
        public IList<MenuT> MenuTreeList { get; set; }
        public IList<MenuT> LowerMenuList { get; set; }
    }
}
