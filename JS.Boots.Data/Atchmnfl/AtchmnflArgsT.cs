using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JS.Boots.Data.Atchmnfl
{
    public class AtchmnflArgsT : BaseModelT
    {
        /// <summary>
        /// innorix 원본파일명
        /// </summary>
        public string[] _innorix_origfilename { get; set; }

        /// <summary>
        /// innorix 저장파일명
        /// </summary>
        public string[] _innorix_savefilename { get; set; }

        /// <summary>
        /// innorix 파일저장경로
        /// </summary>
        public string[] _innorix_savepath { get; set; }     

        /// <summary>
        /// innorix 파일사이즈
        /// </summary>
        public string[] _innorix_filesize { get; set; }

        /// <summary>
        /// innorix 개발자 정의값
        /// </summary>
        public string[] _innorix_customvalue { get; set; }

        /// <summary>
        /// innorix 컴포넌트 이름
        /// </summary>
        public string[] _innorix_componentname { get; set; }

        /// <summary>
        /// innorix 삭제 파일ID
        /// </summary>
        public string[] _innorix_deleted_id { get; set; }

        /// <summary>
        /// innorix 삭제 파일이름
        /// </summary>
        public string[] _innorix_deleted_name { get; set; }

        /// <summary>
        /// innorix 삭제 파일용량
        /// </summary>
        public string[] _innorix_deleted_size { get; set; }

        /// <summary>  
        /// 첨부파일분류코드
        /// </summary> 
        public string AtchmnflClCode { get; set; }

        /// <summary>  
        /// 등록자ID
        /// </summary> 
        public string RegisterId { get; set; }

        /// <summary>  
        /// 등록자구분코드
        /// </summary> 
        public string RegisterSeCode { get; set; }

    }
}
