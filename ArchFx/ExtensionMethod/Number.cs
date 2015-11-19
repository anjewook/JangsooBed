using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchFx.ExtensionMethod
{
    public static class ExtensionNumber
    {
        public static string NullCheckFormat(this double? value, string format)
        {
            string result = "";

            if (value != null)
            {
                result = value.Value.ToString(format);
            }

            return result;
        }
    }
}
