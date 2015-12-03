using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using IBatisNet.Common;
using IBatisNet.DataMapper;

namespace JS.Boots.BizDac
{
    public class BaseDac
    {
        private ISqlMapper sqlMapper;
        private ISqlMapper sqlMapperSMS;

        public ISqlMapper Js_Instance
        {
            get
            {
                if (sqlMapper == null)
                {
                    sqlMapper = Mapper.Instance();
                    sqlMapper.DataSource.ConnectionString = JsDb.JS_Connection;
                }

                return sqlMapper;
            }
        }



        public void BeginTran()
        {
            Js_Instance.BeginTransaction();
        }


        public void Commit()
        {
            Js_Instance.CommitTransaction();
        }


        public void RollBack()
        {
            Js_Instance.RollBackTransaction();
        }
    }
}
