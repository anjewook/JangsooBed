using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JS.Boots.Data
{
    public class AuthT
    {
        public AuthT()
        {
            IsRead = false;
            IsCreate = false;
            IsUpdate = false;
            IsDelete = false;
            IsPrint = false;
            IsAdmin = false;
        }

        /// <summary>
        /// 등록권한 여부
        /// </summary>
        public bool IsCreate { get; set; }

        /// <summary>
        /// 읽기권한 여부
        /// </summary>
        public bool IsRead { get; set; }

        /// <summary>
        /// 수정권한 여부
        /// </summary>
        public bool IsUpdate { get; set; }

        /// <summary>
        /// 삭제권한 여부
        /// </summary>
        public bool IsDelete { get; set; }

        /// <summary>
        /// 출력 및 다운로드 권한 여부
        /// </summary>
        public bool IsPrint { get; set; }

        /// <summary>
        /// 관리자 권한 여부
        /// </summary>
        public bool IsAdmin { get; set; }

        //권한그룹별 권한 여부
    }
}
