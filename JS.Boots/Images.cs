using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Web;

namespace JS.Boots
{
    public class Images
    {
        public static string ImagesPath
        {
            get
            {
                return System.Configuration.ConfigurationManager.AppSettings["ImagesPath"];
            }
        }


        public static string AdminImagesPath
        {
            get
            {
                return System.Configuration.ConfigurationManager.AppSettings["AdminImagesPath"];
            }
        }

        public static string PortalImagesPath
        {
            get
            {
                return System.Configuration.ConfigurationManager.AppSettings["PortalImagesPath"];
            }
        }

    }
}
