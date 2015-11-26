using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JS.Boots.Data.UserMng
{
    public class EntrprsSearchT : BaseSearchT
    {
        /// <summary>  
        /// 기업명
        /// </summary> 
        public string SearchEntrprsNm { get; set; }

        /// <summary>  
        /// 사업자등록번호
        /// </summary> 
        public string SearchBizrNO { get; set; }

        /// <summary>  
        /// 대표자명
        /// </summary> 
        public string SearchRprsntvNm { get; set; }

        /// <summary>  
        /// 담당자명
        /// </summary> 
        public string SearchChargerNm { get; set; }

        /// <summary>
        /// 기업 일련번호
        /// </summary>
        public long EntrprsSn { get; set; }

        /// <summary>
        /// 함수 형식(기업검색 목록팝업시 사용)
        /// </summary>
        public string FunctionType { get; set; }

        /// <summary>
        /// 제조/수리/수입업 여부
        /// </summary>
        public string SearchMnfcturAt { get; set; }

        /// <summary>
        /// 계량증명업 여부
        /// </summary>
        public string SearchMesurProofIndutyAt { get; set; }

        /// <summary>
        /// 구분 [제조, 수리, 수입]
        /// </summary>
        public string SearchEntrprsSeCode { get; set; }

        /// <summary>
        /// 계량기종류코드
        /// </summary>
        public string SearchMrnrKndCode { get; set; }

        /// <summary>  
        /// 시도구분코드
        /// </summary> 
        public string SearchAtptSeCode { get; set; }

        /// <summary>  
        /// 구군구분코드
        /// </summary> 
        public string SearchGuGunSeCode { get; set; }

        /// <summary>
        /// 인정번호
        /// </summary>
        public string SearchRcognNoNm { get; set; }

        /// <summary>
        /// 회원여부
        /// </summary>
        public string SearchMberAt { get; set; }

    }
}
