using JS.Boots.Data.Atchmnfl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JS.Boots.Data.Bbs
{
    public class BbscttAtchmnflT : AtchmnflT
    {
        /// <summary>
        /// 게시판 일련번호
        /// </summary>
        public long BbscttSn { get; set; }

        /// <summary>
        /// 파일 일련번호
        /// </summary>
        public long AtchmnflSn { get; set; }

    }
}
