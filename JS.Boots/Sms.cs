using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JS.Boots
{
    public class Sms
    {
        public static string SmsConnection
        {
            get
            {
                return System.Configuration.ConfigurationManager.AppSettings["SMS_Connection"];
            }
        }


        public static string JSNumber
        {
            get
            {
                return "0260004030";
            }
        }
    }
}
