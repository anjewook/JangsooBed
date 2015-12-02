using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JS.Boots.BizDac
{
    public class TestBiz : BaseBiz
    {
        public string SelectTest()
        {
            return new TestDac().SelectTest();
        }

    }
}
