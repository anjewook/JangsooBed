using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JS.Boots.BizDac
{
    public class TestDac : BaseDac
    {

        public string SelectTest()
        {
            return Js_Instance.QueryForObject<string>("TestDac.SelectTest", null);
        }
    }
}
