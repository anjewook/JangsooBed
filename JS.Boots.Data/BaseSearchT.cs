using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JS.Boots.Data
{
    /// <summary>
    /// 검색조건을 담고있는 T Class에서 항상상속받아야함.
    /// </summary>
    public class BaseSearchT : BasePaging
    {
        /// <summary>
        /// 검색조건구분
        /// ex) ID, 성명 ....
        /// </summary>
        public string SearchType { get; set; }

        /// <summary>
        /// 검색조건 질의 Text값
        /// </summary>
        public string SearchText { get; set; }

        /// <summary>
        /// 검색 기간 StartDate
        /// </summary>
        public string SearchStartDate { get; set; }

        /// <summary>
        /// 검색 기간 EndDate
        /// </summary>
        public string SearchEndDate { get; set; }


        #region Index Property
        public int StartIndex
        {
            get
            {
                return ((page.Value - 1) * PageSize) + 1;
            }
        }

        public int EndIndex
        {
            get
            {
                return StartIndex + PageSize - 1;
            }
        }
        #endregion
    }
}
