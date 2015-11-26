using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JS.Boots.Data.UserMng
{
    public class UserMenuAuthSearchT : BaseModelT
    {
        public string UserId { get; set; }
        public string MenuCode { get; set; }
        public string UserSeCode { get; set; }
        public IList<string> AuthorGroupList { get; set; }
    }
}
