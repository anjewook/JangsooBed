using JS.Boots.Data.Bbs;
using JS.Boots.Data.ContentsMng;
using JS.Boots.Data.UserMng;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JS.Boots.Data.SearchTotal
{
    public class SearchTotalT : BaseSearchT
    {

        public string[] SearchAutoCompleteKeyword { get; set; }


        /// <summary>
        /// 인기검색어 목록
        /// </summary>
        public IList<string> PopularSearchWordList { get; set; }




        //----------------------------------------------------------------------------
        // 기술기준(TCHNLGYSTDR)
        //----------------------------------------------------------------------------

        /// <summary>
        /// 기술기준 검색 총건수(totcnt)
        /// </summary>
        public long tchnlgyStdrTotCnt { get; set; }

        /// <summary>
        /// 기술기준 현재페이지 숫자
        /// </summary>
        public long tchnlgyStdrPageNum { get; set; }

        /// <summary>
        /// 기술기준 목록
        /// </summary>
        public IList<TchnlgyStdrT> tchnlgyStdrList { get; set; }



        //----------------------------------------------------------------------------
        // 기술동향(BBSCTT)
        //----------------------------------------------------------------------------

        /// <summary>
        /// 기술동향 검색 총건수(totcnt)
        /// </summary>
        public long bbscttTotCnt { get; set; }

        /// <summary>
        /// 기술동향 현재페이지 숫자
        /// </summary>
        public long bbscttPageNum { get; set; }

        /// <summary>
        /// 기술동향 목록
        /// </summary>
        public IList<BbscttT> bbscttList { get; set; }


        //----------------------------------------------------------------------------
        // 제작/수리/수입 업체(MNFCTUR)
        //----------------------------------------------------------------------------

        /// <summary>
        /// 제작/수리/수입 업체 검색 총건수(totcnt)
        /// </summary>
        public long mnfcturMrnrTotCnt { get; set; }

        /// <summary>
        /// 제작/수리/수입 업체 현재페이지 숫자
        /// </summary>
        public long mnfcturMrnrPageNum { get; set; }

        /// <summary>
        /// 제작/수리/수입 업체 목록
        /// </summary>
        //public IList<MnfcturMrnrInfoSearchTotalT> mnfcturMrnrList { get; set; }




        //----------------------------------------------------------------------------
        // 계량증명 업체(MESURPROOF)
        //----------------------------------------------------------------------------

        /// <summary>
        /// 계량증명 업체 검색 총건수(totcnt)
        /// </summary>
        public long mesurProofTotCnt { get; set; }

        /// <summary>
        ///계량증명 업체 현재페이지 숫자
        /// </summary>
        public long mesurProofPageNum { get; set; }

        /// <summary>
        /// 계량증명 목록
        /// </summary>
        //public IList<MesurProofInfoSearchTotalT> mesurProofList { get; set; }




        //----------------------------------------------------------------------------
        // 정기검사정보(MESURPROOF)
        //----------------------------------------------------------------------------

        /// <summary>
        /// 정기검사정보 검색 총건수(totcnt)
        /// </summary>
        public long fdrmPrsecManageTotCnt { get; set; }

        /// <summary>
        /// 정기검사정보 현재페이지 숫자
        /// </summary>
        public long fdrmPrsecManagePageNum { get; set; }




        //----------------------------------------------------------------------------
        // 형식승인(FOMCONFM)
        //----------------------------------------------------------------------------

        /// <summary>
        /// 형식승인 검색 총건수(totcnt)
        /// </summary>
        public long formConsentTotCnt { get; set; }

        /// <summary>
        /// 형식승인 현재페이지 숫자
        /// </summary>
        public long formConsentPageNum { get; set; }

        /// <summary>
        /// 형식승인 목록
        /// </summary>
        //public IList<FormConsentSearchTotalT> formConsentList { get; set; }




        //----------------------------------------------------------------------------
        // 검정(ATHRZ)
        //----------------------------------------------------------------------------

        /// <summary>
        /// 검정 검색 총건수(totcnt)
        /// </summary>
        public long athrzTotCnt { get; set; }

        /// <summary>
        /// 검정 현재페이지 숫자
        /// </summary>
        public long athrzPageNum { get; set; }

        /// <summary>
        /// 검정 목록
        /// </summary>
        //public IList<InspectionT> athrzList { get; set; }

        

    }
}
