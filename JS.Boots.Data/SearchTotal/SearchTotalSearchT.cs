using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JS.Boots.Data.SearchTotal
{
    public class SearchTotalSearchT : BaseSearchT
    {
        public IList<string> SearchKeywordCompleteList { get; set; }

        /// <summary>
        /// 검색어
        /// </summary>
        public string SearchKeyword { get; set; }

        /// <summary>
        /// 숨김검색어
        /// </summary>
        public string HiddenSearchKeyword { get; set; }

        /// <summary>
        /// 검색타입
        ///  TOTAL          : 통합검색
        ///  FOMCONFM       : 형식승인정보
        ///  ATHRZ          : 검정정보
        ///  FDRMPRSECMANAG : 정기검사정보
        ///  MESURPROOF     : 계량증명업체
        ///  MNFCTUR        : 제작/수리/수입업체
        ///  TCHNLGYSTDR    : 기술기준
        ///  RLQYINDICT     : 실량상품
        ///  BBSCTT         : 기술동향
        /// </summary>
        public string SearchType { get; set; }

        /// <summary>
        /// 정렬키
        ///  - A 이면 정확도순
        ///  - B 이면 가나다 순서
        ///  - C 이면 하파타 순서
        ///  - D 이면 최신 순서
        /// </summary>
        public string SortKey { get; set; }

        /// <summary>
        /// 결과내재검색여부(Y/N)
        /// </summary>
        public string ResearchYn { get; set; }

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
        /// 검색시작일
        /// </summary>
        public string SearchStartDate { get; set; }

        /// <summary>
        /// 검색종료일
        /// </summary>
        public string SearchEndDate { get; set; }

        /// <summary>
        /// 목록개수
        /// </summary>
        public string ListNum { get; set; }

    }
}
