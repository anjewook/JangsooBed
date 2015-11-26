using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JS.Boots.Data.SystemMng
{
    public class AuthorGroupMenuT : BaseModelT
    {
        /// <summary>
        /// 권한그룹코드
        /// </summary>
        public string AuthorGroupCode { get; set; }

        /// <summary>
        /// 메뉴코드
        /// </summary>
        public string MenuCode { get; set; }

        /// <summary>
        /// 부여권한코드
        /// </summary>
        public string AlwncAuthorCode { get; set; }

        /// <summary>
        /// 부여권한코드 배열
        /// </summary>
        public string[] ArrAlwncAuthorCode { get; set; }

        /// <summary>
        /// 읽기권한여부
        /// </summary>
        public string ReadAuthYn { get; set; }

        /// <summary>
        /// 등록권한여부
        /// </summary>
        public string CreateAuthYn { get; set; }

        /// <summary>
        /// 수정권한여부
        /// </summary>
        public string UpdateAuthYn { get; set; }

        /// <summary>
        /// 삭제권한여부
        /// </summary>
        public string DeleteAuthYn { get; set; }

        /// <summary>
        /// 출력권한여부
        /// </summary>
        public string PrintAuthYn { get; set; }

        /// <summary>
        /// 관리권한여부
        /// </summary>
        public string ManageAuthYn { get; set; }

        /// <summary>  
        /// 메뉴명
        /// </summary> 
        public string MenuNm { get; set; }

        /// <summary>  
        /// 메뉴유형코드
        /// </summary> 
        public string MenuTyCode { get; set; }

        /// <summary>  
        /// 사용여부
        /// </summary> 
        public string UseAt { get; set; }

        /// <summary>
        /// tree table에서 사용하는 id
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// tree table에서 사용하는 pId
        /// </summary>
        public string Pid { get; set; }


    }
}
