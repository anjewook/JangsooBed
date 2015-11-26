using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JS.Boots.Data.ZipCode
{
    public class LnmAdresT : BaseModelT
    {
        public LnmAdresT()
        {
            ZipCode = string.Empty;
            ZipSnCode = string.Empty;
            Sido = string.Empty;
            Sigungu = string.Empty;
            Eupmyundong = string.Empty;
            Li = string.Empty;
            Islnds = string.Empty;
            MtlnbrNm = string.Empty;
            BeginLnbrMnnm = 0;
            BeginLnbrSlno = 0;
            EndLnbrMnnm = 0;
            EndLnbrSlno = 0;
            BuldNm = string.Empty;
            DongScopeBegin = string.Empty;
            DongScopeEnd = string.Empty;
            Adres = string.Empty;
        }

        /// <summary>  
        /// 우편번호
        /// </summary> 
        public string ZipCode { get; set; }

        /// <summary>  
        /// 우편일련번호코드
        /// </summary> 
        public string ZipSnCode { get; set; }

        /// <summary>  
        /// 시도
        /// </summary> 
        public string Sido { get; set; }

        /// <summary>  
        /// 시군구
        /// </summary> 
        public string Sigungu { get; set; }

        /// <summary>  
        /// 읍면동
        /// </summary> 
        public string Eupmyundong { get; set; }

        /// <summary>  
        /// 리
        /// </summary> 
        public string Li { get; set; }

        /// <summary>  
        /// 도서
        /// </summary> 
        public string Islnds { get; set; }

        /// <summary>  
        /// 산번지
        /// </summary> 
        public string MtlnbrNm { get; set; }

        /// <summary>  
        /// 시작번지본번
        /// </summary> 
        public int BeginLnbrMnnm { get; set; }

        /// <summary>  
        /// 시작번지부번
        /// </summary> 
        public int BeginLnbrSlno { get; set; }

        /// <summary>  
        /// 끝번지본번
        /// </summary> 
        public int EndLnbrMnnm { get; set; }

        /// <summary>  
        /// 끝번지부번
        /// </summary> 
        public int EndLnbrSlno { get; set; }

        /// <summary>  
        /// 건물명
        /// </summary> 
        public string BuldNm { get; set; }

        /// <summary>  
        /// 동범위시작
        /// </summary> 
        public string DongScopeBegin { get; set; }

        /// <summary>  
        /// 동범위끝
        /// </summary> 
        public string DongScopeEnd { get; set; }

        /// <summary>  
        /// 주소
        /// </summary> 
        public string Adres { get; set; }

    }  

}
