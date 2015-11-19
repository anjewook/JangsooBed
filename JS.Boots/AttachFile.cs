using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JS.Boots
{
    public class AttachFile
    {
        public static string AttachFilePath
        {
            get
            {
                return System.Configuration.ConfigurationManager.AppSettings["AttachFilePath"];
            }
        }
    }
}
