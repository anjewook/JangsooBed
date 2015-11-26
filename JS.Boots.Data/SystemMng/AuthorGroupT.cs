using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JS.Boots.Data.SystemMng
{
    public class AuthorGroupT : BaseModelT
    {
        /// <summary>
        /// 권한그룹코드
        /// </summary>
        public string AuthorGroupCode { get; set; }

        /// <summary>
        /// 권한그룹명
        /// </summary>
        public string AuthorGroupNm { get; set; }

        /// <summary>
        /// 사용여부
        /// </summary>
        public string UseAt { get; set; }

        /// <summary>
        /// KTC사용자설정여부
        /// </summary>
        public string KtcUserEstbsAt { get; set; }

        /// <summary>
        /// 권한그룹설명
        /// </summary>
        public string AuthorGroupDc { get; set; }

        /// <summary>
        /// 등록일시
        /// </summary>
        public DateTime RegistDt { get; set; }

        /// <summary>
        /// 등록자ID
        /// </summary>
        public string RegisterId { get; set; }

        /// <summary>
        /// 수정일시
        /// </summary>
        public DateTime UpdtDt { get; set; }

        /// <summary>
        /// 수정자ID
        /// </summary>
        public string UpdusrId { get; set; }

        /// <summary>
        /// Mode I:insert, U:update, D:delete
        /// </summary>
        public string Mode { get; set; }
    }
}
