using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JS.Boots.Data.Atchmnfl
{
    public class AtchmnflT : BaseModelT
    {
        /// <summary>  
        /// 첨부파일일련번호
        /// </summary> 
        public long AtchmnflSn { get; set; }

        /// <summary>  
        /// 첨부파일분류코드
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

        /// <summary>  
        /// 확장자명
        /// </summary> 
        public string Eventn { get; set; }

        /// <summary>  
        /// 첨부파일사이즈
        /// </summary> 
        public long AtchmnflSize { get; set; }

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
        /// 컴포넌트명
        /// </summary> 
        public string ComponentName { get; set; }

        /// <summary>  
        /// 컴포넌트명
        /// </summary> 
        public string InnorixSavepath { get; set; }

        /// <summary>
        /// 파일이 저장된 전체경로
        /// </summary>
        public string FileAllPath { get; set; }
            
    }
}
