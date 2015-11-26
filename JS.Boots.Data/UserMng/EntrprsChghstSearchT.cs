using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JS.Boots.Data.UserMng
{

   /// <summary>
    /// 기업변경이력 검색조건
   /// </summary>
    public class EntrprsChghstSearchT : BaseSearchT
    {

        /// <summary>  
        /// 기업일련번호
        /// </summary> 
        public long SearchEntrprsSn { get; set; }

        /// <summary>  
        /// 기업변경이력일련번호
        /// </summary> 
        public long SearchEntrprsChghstSn { get; set; }

        /// <summary>  
        /// 변경일자
        /// </summary> 
        public string SearchChangeDe { get; set; }

        /// <summary>  
        /// 변경내용
        /// </summary> 
        public string SearchChangeCn { get; set; }

        /// <summary>  
        /// 등록자구분코드
        /// </summary> 
        public string SearchRegisterSeCode { get; set; }

        /// <summary>  
        /// 등록자ID
        /// </summary> 
        public string SearchRegisterId { get; set; }

        /// <summary>  
        /// 등록일시
        /// </summary> 
        public DateTime SearchRegistDt { get; set; }

    } 
}
