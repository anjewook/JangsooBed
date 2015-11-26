using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JS.Boots.Data.UserMng
{
    public class InsttUserSearchT : BaseSearchT
    {
        /// <summary>  
        /// 사용자ID
        /// </summary> 
        public string SearchUserId { get; set; }

        /// <summary>
        /// 기관일련번호
        /// </summary>
        public long SearchInsttSn { get; set; }

        /// <summary>  
        /// 기관명
        /// </summary> 
        public string SearchInsttNm { get; set; }

        /// <summary>  
        /// 기관사용자상태코드
        /// </summary> 
        public string SearchInsttUserSttusCode { get; set; }

        /// <summary>  
        /// 기관구분코드
        /// </summary> 
        public string SearchInsttSeCode { get; set; }

        /// <summary>  
        /// 메뉴코드
        /// </summary> 
        public string MenuCode { get; set; }
    }
}
