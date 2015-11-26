using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JS.Boots.Data.UserMng
{
    public class UserT : BaseModelT
    {
        /// <summary>  
        /// 사용자ID
        /// </summary> 
        public string UserId { get; set; }

        /// <summary>  
        /// 사용자구분코드
        /// </summary> 
        public string UserSeCode { get; set; }

        /// <summary>  
        /// 비밀번호
        /// </summary> 
        public string Password { get; set; }

        /// <summary>  
        /// 기존 비밀번호
        /// </summary> 
        public string OldPassword { get; set; }

        /// <summary>  
        /// 비밀번호초기화여부
        /// </summary> 
        public string PasswordInitlAt { get; set; }

        /// <summary>  
        /// 비밀번호변경일시
        /// </summary> 
        public DateTime PasswordChangeDt { get; set; }

        /// <summary>  
        /// 찾기구분코드(ID: 사용자ID , PW: 비밀번호)
        /// </summary> 
        public string FindSeCode { get; set; }

        /// <summary>  
        /// 사용자명
        /// </summary> 
        public string UserNm { get; set; }

        /// <summary>  
        /// 이메일주소
        /// </summary> 
        public string EmailAdres { get; set; }

        /// <summary>  
        /// 비밀번호힌트구분코드
        /// </summary> 
        public string PasswordHintSeCode { get; set; }

        /// <summary>  
        /// 비밀번호힌트정답
        /// </summary> 
        public string PasswordHintCnsr { get; set; }

        /// <summary>
        /// 성공여부
        /// </summary>
        public bool IsSuccess { get; set; }


    }
}
