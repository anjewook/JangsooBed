using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JS.Boots.Data.SystemMng
{

    /// <summary>  
    /// 사용자접속이력
    /// </summary> 
    public class EmplyrConectHistT : BaseModelT
    {
        /// <summary>  
        /// 사용자접속이력일련번호
        /// </summary> 
        public long EmplyrConectHistSn { get; set; }

        /// <summary>  
        /// 사원코드
        /// </summary> 
        public string EmplCode { get; set; }

        /// <summary>  
        /// 사용자ID
        /// </summary> 
        public string UserId { get; set; }

        /// <summary>  
        /// 사용자명
        /// </summary> 
        public string UserNm { get; set; }

        /// <summary>  
        /// 사용자구분코드
        /// </summary> 
        public string UserSeCode { get; set; }

        /// <summary>  
        /// 사용자구분코드명
        /// </summary> 
        public string UserSeCodeNm { get; set; }

        /// <summary>  
        /// 소속명
        /// </summary> 
        public string PsitnNm { get; set; }

        /// <summary>  
        /// 메뉴코드
        /// </summary> 
        public string MenuCode { get; set; }

        /// <summary>  
        /// 메뉴명
        /// </summary> 
        public string MenuNm { get; set; }

        /// <summary>  
        /// 접속ip
        /// </summary> 
        public string ConectIp { get; set; }

        /// <summary>  
        /// 접속일시
        /// </summary> 
        public DateTime ConectDt { get; set; }

    }  
  
}
