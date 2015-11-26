using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JS.Boots.Data.UserMng
{
    public class InsttSearchT : BaseSearchT
    {
        /// <summary>  
        /// 기관일련번호
        /// </summary> 
        public int SearchInsttSn { get; set; }

        /// <summary>  
        /// 기관명
        /// </summary> 
        public string SearchInsttNm { get; set; }

        /// <summary>  
        /// 사업자등록번호
        /// </summary> 
        public string SearchBizrno { get; set; }

        /// <summary>  
        /// 대표자명
        /// </summary> 
        public string SearchRprsntvNm { get; set; }

        /// <summary>  
        /// 대표전화번호
        /// </summary> 
        public string SearchReprsntTelno { get; set; }

        /// <summary>  
        /// 주소구분코드
        /// </summary> 
        public string SearchAdresSeCode { get; set; }

        /// <summary>  
        /// 우편번호
        /// </summary> 
        public string SearchZip { get; set; }

        /// <summary>  
        /// 기본주소
        /// </summary> 
        public string SearchBassAdres { get; set; }

        /// <summary>  
        /// 상세주소
        /// </summary> 
        public string SearchDetailAdres { get; set; }

        /// <summary>  
        /// 기관구분코드
        /// </summary> 
        public string SearchInsttSeCode { get; set; }

        /// <summary>  
        /// 형식승인기관여부
        /// </summary> 
        public string SearchFomConfmInsttAt { get; set; }

        /// <summary>  
        /// 검정기관여부
        /// </summary> 
        public string SearchAthrzInsttAt { get; set; }

        /// <summary>  
        /// 기관상태코드
        /// </summary> 
        public string SearchInsttSttusCode { get; set; }

        /// <summary>  
        /// 계량기구분코드
        /// </summary> 
        public string SearchMrnrSeCode { get; set; }

        /// <summary>  
        /// 시도구분코드
        /// </summary> 
        public string SearchAtptSeCode { get; set; }

        /// <summary>  
        /// 구군구분코드
        /// </summary> 
        public string SearchGuGunSeCode { get; set; }

        /// <summary>  
        /// 지정번호
        /// </summary> 
        public string SearchAppnNoNm { get; set; }

        /// <summary>  
        /// 메뉴코드
        /// </summary> 
        public string MenuCode { get; set; }

        /// <summary>
        /// 검색 형식승인, 검정
        /// </summary>
        public string SearchFomConAthrz { get; set; }
    }
}
