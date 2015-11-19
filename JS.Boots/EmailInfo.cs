using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JS.Boots
{
    public class EmailInfo
    {
        public static string EmailSiteUrl
        {
            get
            {
                return System.Configuration.ConfigurationManager.AppSettings["EmailSiteUrl"];
            }
        }

        public static string EmailServerHost
        {
            get
            {
                return System.Configuration.ConfigurationManager.AppSettings["EmailServerHost"];
            }
        }

        public static string EmailTempletePath
        {
            get
            {
                return System.Configuration.ConfigurationManager.AppSettings["EmailTempletePath"];
            }
        }

        public static string EmailImagePath
        {
            get
            {
                return System.Configuration.ConfigurationManager.AppSettings["EmailImagePath"];
            }
        }

        public static string SenderEmailAddress
        {
            get
            {
                return System.Configuration.ConfigurationManager.AppSettings["SenderEmailAddress"];
            }
        }
    }
}
