using JS.Boots.Data.Bbs;
using JS.Boots.Data.ContentsMng;
using JS.Boots.Data.SystemMng;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JS.Boots.Data.PortalMain
{
    /// <summary>
    /// 포털 메인 Page모델
    /// </summary>
    public class PortalMainPageT : BaseModelT
    {
        /// <summary>
        /// 공지사항 목록
        /// </summary>
        public IList<BbscttT> NoticeList { get; set; }

        /// <summary>
        /// 뉴스 목록
        /// </summary>
        public IList<BbscttT> NewsList { get; set; }

        /// <summary>
        /// 자료실 목록
        /// </summary>
        public IList<BbscttT> DataList { get; set; }

        /// <summary>
        /// 팝업 목록
        /// </summary>
        public IList<PopupT> PopupList { get; set; }

        /// <summary>
        /// 배너 목록
        /// </summary>
        public IList<BannerT> BannerList { get; set; }
    }
}
