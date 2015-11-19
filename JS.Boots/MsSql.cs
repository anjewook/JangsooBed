using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JS.Boots
{
    public class MsSql
    {
        public static string Conn
        {
            get
            {
                return System.Configuration.ConfigurationManager.ConnectionStrings["DuzonConn"].ConnectionString;
            }
        }
    }
}
