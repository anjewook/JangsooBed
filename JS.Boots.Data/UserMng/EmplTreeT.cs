using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JS.Boots.Data.UserMng
{
    public class EmplTreeT
    {
        /// <summary>
        /// 구분(D:부서,E:사용자)
        /// </summary>
        public string Flag { get; set; }

        /// <summary>  
        /// ID
        /// </summary> 
        public string Id { get; set; }

        /// <summary>  
        /// PID
        /// </summary> 
        public string PId { get; set; }

        /// <summary>  
        /// 부서명 혹은 사용자이름
        /// </summary> 
        public string Name { get; set; }

        /// <summary>  
        /// 부서명 혹은 사용자이름 전체 경로
        /// </summary> 
        public string Path { get; set; }

        /// <summary>  
        /// 부서명 혹은 사용자코드
        /// </summary> 
        public string Code { get; set; }

        /// <summary>  
        /// 상위코드
        /// </summary> 
        public string UpperCode { get; set; }

        /// <summary>  
        /// 사용여부
        /// </summary> 
        public string UseAt { get; set; }
    }
}
