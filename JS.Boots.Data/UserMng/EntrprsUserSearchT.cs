using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JS.Boots.Data.UserMng
{
    public class EntrprsUserSearchT : BaseSearchT
    {
        /// <summary>  
        /// 검색 기업명
        /// </summary> 
        public string SearchEntrprsNm { get; set; }

        /// <summary>  
        /// 검색 기업사용자상태코드
        /// </summary> 
        public string SearchEntrprsUserSttusCode { get; set; }

        /// <summary>
        /// 검색 기업일련번호
        /// </summary>
        public long SearchEntrprsSn { get; set; }

    }
}
