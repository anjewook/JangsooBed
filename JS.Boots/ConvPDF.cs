using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JS.Boots
{
    public class ConvPDF
    {
        public static string Conn
        {
            get
            {
                return System.Configuration.ConfigurationManager.ConnectionStrings["ConvPDFConn"].ConnectionString;
            }
        }
    }
}
