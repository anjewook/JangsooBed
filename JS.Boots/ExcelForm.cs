using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JS.Boots
{
    public class ExcelForm
    {
        public static string ExcelFormFilePath
        {
            get
            {
                return System.Configuration.ConfigurationManager.AppSettings["ExcelFormFilePath"];
            }
        }

        public static string ExcelFormDownLoadFilePath
        {
            get
            {
                string filePath = ExcelFormFilePath + "\\UserDownLoad\\";
                if (System.IO.Directory.Exists(filePath) == false)
                {
                    System.IO.Directory.CreateDirectory(filePath);
                }

                return filePath;
            }
        }
    }
}
