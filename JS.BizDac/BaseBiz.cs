using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JS.Boots.BizDac
{
    public class BaseBiz
    {
        //
        private BaseDac baseDac;

        public BaseBiz()
        {
            baseDac = new BaseDac();
        }



        public void BeginTran()
        {
            baseDac.BeginTran();
        }


        public void Commit()
        {
            baseDac.Commit();
        }


        public void RollBack()
        {
            baseDac.RollBack();
        }
    }
}
