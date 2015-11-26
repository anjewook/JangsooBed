using JS.Boots.Data.Bbs;
using JS.Boots.Data.OptionWorkMng;
using JS.Boots.Data.UserMng;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JS.Boots.Data.AdminMain
{
    public class AdminMainPageT : BaseModelT
    {
        /// <summary>
        /// 사용자권한
        /// </summary>
        public ProfileT User;

        /// <summary>
        /// 공지사항 목록
        /// </summary>
        public IList<BbscttT> NoticeList { get; set; }

        /// <summary>
        /// 자료실 목록
        /// </summary>
        public IList<BbscttT> DataList { get; set; }


        /// <summary>
        /// 형식승인/검정 건수
        /// </summary>
        public AdminMainCountT AdminMainCountT;

        /// <summary>
        /// 메인보기 전체권한
        /// </summary>
        public bool IsMainAll { get; set; }

        /// <summary>
        /// 메인보기 형식승인권한
        /// </summary>
        public bool IsMainFormConfm { get; set; }

        /// <summary>
        /// 메인보기 검정권한
        /// </summary>
        public bool IsMainAthrz { get; set; }

    }
}
