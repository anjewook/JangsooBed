using JS.Boots.Data.Atchmnfl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JS.Boots.Data.ContentsMng
{
    public class TchnlgyStdrT : BaseModelT
    {
        /// <summary>  
        /// 기술기준일련번호
        /// </summary> 
        public long TchnlgyStdrSn { get; set; }

        /// <summary>  
        /// 기술기준명
        /// </summary> 
        public string TchnlgyStdrNm { get; set; }

        /// <summary>
        /// 계량기구분코드
        /// </summary>
        public string MrnrSeCode { get; set; }

        /// <summary>
        /// 계량기구분코드명
        /// </summary>
        public string MrnrSeCodeNm { get; set; }

        /// <summary>  
        /// 고시번호명
        /// </summary> 
        public string NtfcNoNm { get; set; }

        /// <summary>  
        /// 고시일자
        /// </summary> 
        public string NtfcDe { get; set; }

        /// <summary>  
        /// 내용
        /// </summary> 
        public string Contents { get; set; }

        /// <summary>  
        /// 조회수
        /// </summary> 
        public long Rdcnt { get; set; }

        /// <summary>  
        /// 삭제여부 : Y/N
        /// </summary> 
        public string DeleteAt { get; set; }

        /// <summary>  
        /// 등록일시
        /// </summary> 
        public DateTime RegistDt { get; set; }

        /// <summary>  
        /// 등록자구분코드
        /// </summary> 
        public string RegisterSeCode { get; set; }  

        /// <summary>  
        /// 등록자ID
        /// </summary> 
        public string RegisterId { get; set; }

        /// <summary>  
        /// 수정일시
        /// </summary> 
        public DateTime UpdtDt { get; set; }

        /// <summary>  
        /// 수정자구분코드
        /// </summary> 
        public string UpdusrSeCode { get; set; }  

        /// <summary>  
        /// 수정자ID
        /// </summary> 
        public string UpdusrId { get; set; }

        /// <summary>
        /// 공통파일저장
        /// </summary>
        public AtchmnflArgsT atchmnflArgsT;

        /// <summary>
        /// 첨부파일 List
        /// </summary>
        public IList<TchnlgyStdrAtchmnflT> AtchmnflList { get; set; }


        /// <summary>
        /// 기술기준명 메인에서 사용
        ///  - 길이가 길면 문자열을 자른뒤 ... 을 붙여준다.
        /// </summary>
        public string TchnlgyStdrNmUseMain
        {
            get
            {
                if (!String.IsNullOrWhiteSpace(TchnlgyStdrNm))
                {
                    if (TchnlgyStdrNm.Length > 22)
                    {
                        return TchnlgyStdrNm.Substring(0, 22) + "...";
                    }
                    else
                    {
                        return TchnlgyStdrNm;
                    }
                }
                else
                {
                    return "";
                }
            }
        }


    }
}
