using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JS.Boots.Data.Stats
{
    public class StatsMenuT : BaseModelT
    {
        /// <summary>  
        /// 통계일련번호
        /// </summary> 
        public long StatsSn { get; set; }

        /// <summary>  
        /// 접속일자
        /// </summary> 
        public string ConectDe { get; set; }

        /// <summary>  
        /// 접속시
        /// </summary> 
        public string ConectHour { get; set; }

        /// <summary>  
        /// 메뉴코드
        /// </summary> 
        public string MenuCode { get; set; }

        /// <summary>  
        /// 접속수
        /// </summary> 
        public long ConectCo { get; set; }  
    }
}
