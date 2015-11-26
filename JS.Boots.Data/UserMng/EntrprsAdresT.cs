using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JS.Boots.Data.UserMng
{
    public class EntrprsAdresT : BaseModelT
    {
        /// <summary>  
        /// 기업주소일련번호
        /// </summary> 
        public long EntrprsAdresSn { get; set; }

        /// <summary>  
        /// 기업일련번호
        /// </summary> 
        public long EntrprsSn { get; set; }

        /// <summary>  
        /// 기업주소구분코드
        /// </summary> 
        public string EntrprsAdresSeCode { get; set; }

        /// <summary>  
        /// 기업주소구분코드명
        /// </summary> 
        public string EntrprsAdresSeCodeNm { get; set; }

        /// <summary>  
        /// 기업주소명
        /// </summary> 
        public string EntrprsAdresNm { get; set; }

        /// <summary>  
        /// 주소지전화번호
        /// </summary> 
        public string AdresTelno { get; set; }

        /// <summary>  
        /// 주소지팩스번호
        /// </summary> 
        public string AdresFxnum { get; set; }

        /// <summary>  
        /// 주소구분코드
        /// </summary> 
        public string AdresSeCode { get; set; }
        
        /// <summary>  
        /// 상세주소
        /// </summary> 
        public string DetailAdres { get; set; }

        /// <summary>  
        /// 기본주소
        /// </summary> 
        public string BassAdres { get; set; }

        /// <summary>  
        /// 우편번호
        /// </summary> 
        public string Zip { get; set; }

        /// <summary>
        /// 우편번호1
        /// </summary>
        public string Zip1 { get; set; }

        /// <summary>
        /// 우편번호2
        /// </summary>
        public string Zip2 { get; set; }

        /// <summary>
        /// 국내여부
        /// </summary>
        public string DmstcAt { get; set; }

    }
}
