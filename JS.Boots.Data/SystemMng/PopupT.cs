using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JS.Boots.Data.SystemMng
{
    public class PopupT : BaseModelT
    {
        /// <summary>
        /// 팝업일련번호
        /// </summary>
        public long PopupSn { get; set; }

        /// <summary>
        /// 제목명
        /// </summary>
        public string SjNm { get; set; }

        /// <summary>
        /// 내용
        /// </summary>
        public string Contents { get; set; }

        /// <summary>
        /// 게시시작일
        /// </summary>
        public string NtceBgnDe { get; set; }

        /// <summary>
        /// 게시종료일
        /// </summary>
        public string NtceEndDe { get; set; }

        /// <summary>
        /// 팝업가로크기
        /// </summary>
        public int PopupWidthMg { get; set; }

        /// <summary>
        /// 팝업세로크기
        /// </summary>
        public int PopupVrticlMg { get; set; }

        /// <summary>
        /// 팝업엑스좌표
        /// </summary>
        public int PopupXcnts { get; set; }

        /// <summary>
        /// 팝업와이좌표
        /// </summary>
        public int PopupYdnts { get; set; }

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
