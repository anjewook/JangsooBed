using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JS.Boots.Data
{
    public class BasePaging
    {
        public int CurrentPageIndex { get; set; }
        public int? page { get; set; }
        public int PageSize { get; set; }
        public int PageGroupSize { get; set; }
        public long TotalCount { get; set; }

        public BasePaging()
        {
            CurrentPageIndex = 1;
            page = 1;
            PageSize = 10;
            PageGroupSize = 10;
        }
    }
}
