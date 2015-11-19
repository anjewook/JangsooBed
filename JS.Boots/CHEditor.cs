using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JS.Boots
{
    public class CHEditor
    {
        public static string CHEditorImagePath
        {
            get
            {
                return System.Configuration.ConfigurationManager.AppSettings["CHEditorImagePath"];
            }
        }

        public static string CHEditorImageUrl
        {
            get
            {
                return System.Configuration.ConfigurationManager.AppSettings["CHEditorImageUrl"];
            }
        }

    }
}
