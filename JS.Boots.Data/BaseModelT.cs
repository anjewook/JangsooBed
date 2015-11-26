using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JS.Boots.Data
{
    /// <summary>
    /// 모든 일반 T Class에서 항상상속받아야함.
    /// </summary>
    public class BaseModelT
    {
        public long RowNumber { get; set; }
        public long TotalCount { get; set; }

        public string ListNo
        {
            get
            {
                long listNo = TotalCount - (RowNumber - 1);
                //return listNo.ToString("N0");
                return listNo.ToString();
            }
        }
    }
}
