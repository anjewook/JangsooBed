using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JS.Boots.Data.SystemMng
{
    public class BannerT : BaseModelT
    {   
        /// <summary>
        /// 배너일련번호
        /// </summary>
        public long BannerSn { get; set; }

        /// <summary>
        /// 제목명
        /// </summary>
        public string SjNm { get; set; }

        /// <summary>
        /// 링크유형코드
        /// </summary>
        public string LinkTyCode { get; set; }

        /// <summary>
        /// 배너URL
        /// </summary>
        public string BannerUrl { get; set; }

        /// <summary>
        /// 사용여부
        /// </summary>
        public string UseAt { get; set; }

        /// <summary>
        /// 첨부파일일련번호
        /// </summary>
        public long AtchmnflSn { get; set; }

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

        /// <summary>
        /// 성공여부
        /// </summary>
        public bool IsSuccess { get; set; }

        /// <summary>
        /// 메세지
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 파일 삭제 여부
        /// </summary>
        public string FileDeleteYn { get; set; }

        /// <summary>
        /// 첨부파일구분
        /// </summary>
        public string AtchmnflClCode { get; set; }

        /// <summary>
        /// 첨부파일경로
        /// </summary>
        public string AtchmnflCours { get; set; }

        /// <summary>
        /// 첨부파일명
        /// </summary>
        public string AtchmnflNm { get; set; }
    }
}
