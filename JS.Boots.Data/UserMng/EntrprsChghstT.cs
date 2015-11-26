using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JS.Boots.Data.UserMng
{

    /// <summary>
    /// 기업변경이력
    /// </summary>
    public class EntrprsChghstT : BaseModelT
    {
        /// <summary>  
        /// 기업일련번호
        /// </summary> 
        public long EntrprsSn { get; set; }

        /// <summary>  
        /// 기업변경이력일련번호
        /// </summary> 
        public long EntrprsChghstSn { get; set; }

        /// <summary>  
        /// 변경일자
        /// </summary> 
        public string ChangeDe { get; set; }

        /// <summary>  
        /// 변경내용
        /// </summary> 
        public string ChangeCn { get; set; }

        /// <summary>  
        /// 등록자구분코드
        /// </summary> 
        public string RegisterSeCode { get; set; }

        /// <summary>  
        /// 등록자ID
        /// </summary> 
        public string RegisterId { get; set; }

        /// <summary>  
        /// 등록일시
        /// </summary> 
        public DateTime RegistDt { get; set; }

        /// <summary>  
        /// 등록자명
        /// </summary> 
        public string RegisterNm { get; set; }
    }  
}
