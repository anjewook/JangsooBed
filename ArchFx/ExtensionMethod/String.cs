using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchFx.ExtensionMethod
{
    public static class ExtensionString
    {
        public static string ArchSplit(this string value, char splitChar, int index)
        {
            string result = "";

            if (String.IsNullOrEmpty(value) == false)
            {
                if (value.Split(splitChar).Length - 1 >= index)
                {
                    result = value.Split(splitChar)[index];
                }
            }
            return result;
        }

        public static string ArchSubstring(this string value, int startIndex, int length)
        {
            string result = "";
            if (String.IsNullOrEmpty(value) == false)
            {
                if (value.Length >= (startIndex + length))
                {
                    result = value.Substring(startIndex, length);
                }
            }
            return result;
        }

        public static string EmptyCheckAddString(this string value, string frontString, string realString)
        {
            string result = "";

            if (String.IsNullOrEmpty(value) == false)
            {
                result = frontString + value + realString;
            }

            return result;
        }


        public static string EmptyCheckEnter(this string value)
        {
            string result = "";

            if (String.IsNullOrEmpty(value) == false)
            {
                result = value.Replace("\r\n", "<br />");
            }

            return result;
        }



        public static string EmptyPostNumber(this string value)
        {
            string result = "";

            if (String.IsNullOrEmpty(value) == false)
            {
                if (value.Length == 6)
                {
                    result = value.Substring(0, 3) + "-" + value.Substring(3, 3);
                }
            }

            return result;
        }


        public static string EmptyBizNumber(this string value)
        {
            string result = "";

            if (String.IsNullOrEmpty(value) == false)
            {
                if (value.Length == 10)
                {
                    result = value.Substring(0, 3) + "-" + value.Substring(3, 2) + "-" + value.Substring(5, 5);
                }
            }

            return result;
        }


        public static string NullCheckString(this string value)
        {
            string result = "";

            if (String.IsNullOrEmpty(value) == false)
            {
                result = value;
            }

            return result;
        }
    }
}
