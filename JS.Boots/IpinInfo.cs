using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JS.Boots
{
    public class IpinInfo
    {
        public static string IpinSiteUrl
        {
            get
            {
                return System.Configuration.ConfigurationManager.AppSettings["IpinSiteUrl"];
            }
        }

        public static string IpinSiteCode
        {

            get
            {
                return System.Configuration.ConfigurationManager.AppSettings["IpinSiteCode"];
            }

        }

        public static string IpinSitePw
        {

            get
            {
                return System.Configuration.ConfigurationManager.AppSettings["IpinSitePw"];
            }

        }
    }
}
