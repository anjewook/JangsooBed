using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JS.Boots
{
    public class JsDb
    {
        public static string JS_Connection
        {
            get
            {
                return System.Configuration.ConfigurationManager.AppSettings["JS_Connection"];
            }
        }
    }
}
