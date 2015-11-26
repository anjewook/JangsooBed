using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JS.Boots.Data.ZipCode
{
    public class RdnmadrT : BaseModelT
    {
        public RdnmadrT()
        {
            ZipCode = string.Empty;
            ZipSnCode = string.Empty;
            Sido = string.Empty;
            SidoEng = string.Empty;
            Sigungu = string.Empty;
            SigunguEng = string.Empty;
            Eupmyun = string.Empty;
            EupmyunEng = string.Empty;
            Li = string.Empty;
            RnCd = string.Empty;
            Rn = string.Empty;
            RnEng = string.Empty;
            UndgrndAt = string.Empty;
            BdnbrMnnm = 0;
            BdnbrSlno = 0;
            MuchDlvrOfficNm = string.Empty;
            DongCode = string.Empty;
            DongNm = string.Empty;
            LnmMnnm = 0;
            LnmSlno = 0;
            BuldNm = string.Empty;
            BuldManageNoCode = string.Empty;
        }

        /// <summary>  
        /// 우편번호코드
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
        /// 시도영문
        /// </summary> 
        public string SidoEng { get; set; }

        /// <summary>  
        /// 시군구
        /// </summary> 
        public string Sigungu { get; set; }

        /// <summary>  
        /// 시군구영문
        /// </summary> 
        public string SigunguEng { get; set; }

        /// <summary>  
        /// 읍면
        /// </summary> 
        public string Eupmyun { get; set; }

        /// <summary>  
        /// 읍면영문
        /// </summary> 
        public string EupmyunEng { get; set; }

        /// <summary>  
        /// 리
        /// </summary> 
        public string Li { get; set; }

        /// <summary>  
        /// 도로명코드
        /// </summary> 
        public string RnCd { get; set; }

        /// <summary>  
        /// 도로명
        /// </summary> 
        public string Rn { get; set; }

        /// <summary>  
        /// 도로명영문
        /// </summary> 
        public string RnEng { get; set; }

        /// <summary>  
        /// 지하여부
        /// </summary> 
        public string UndgrndAt { get; set; }

        /// <summary>  
        /// 건물번호본번
        /// </summary> 
        public int BdnbrMnnm { get; set; }

        /// <summary>  
        /// 건물번호부번
        /// </summary> 
        public int BdnbrSlno { get; set; }

        /// <summary>  
        /// 다량배달처명
        /// </summary> 
        public string MuchDlvrOfficNm { get; set; }

        /// <summary>  
        /// 법정동코드
        /// </summary> 
        public string DongCode { get; set; }

        /// <summary>  
        /// 법정동명
        /// </summary> 
        public string DongNm { get; set; }

        /// <summary>  
        /// 지번본번
        /// </summary> 
        public int LnmMnnm { get; set; }

        /// <summary>  
        /// 지번부번
        /// </summary> 
        public int LnmSlno { get; set; }

        /// <summary>  
        /// 건물명
        /// </summary> 
        public string BuldNm { get; set; }

        /// <summary>  
        /// 건물관리번호코드
        /// </summary> 
        public string BuldManageNoCode { get; set; }

        /// <summary>  
        /// 
        /// </summary> 
        public long RdnmadrSn { get; set; }

    }  
}
