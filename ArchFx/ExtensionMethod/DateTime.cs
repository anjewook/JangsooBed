using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchFx.ExtensionMethod
{
    public static class ExtensionDateTime
    {
        public static string ToDashDateString(this string dt)
        {
            return dt.Substring(0, 4) + "-" + dt.Substring(4, 2) + "-" + dt.Substring(6, 2);
        }


        public static string ToEmptyString(this DateTime dt, string format)
        {
            if (dt == DateTime.MinValue)
            {
                return "";
            }
            else
            {
                return dt.ToString(format);
            }
        }
    }
}
