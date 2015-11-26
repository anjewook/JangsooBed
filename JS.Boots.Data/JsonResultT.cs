using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JS.Boots.Data
{
    public class JsonResultT<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; }

        public List<T> resultData;
    }
}
