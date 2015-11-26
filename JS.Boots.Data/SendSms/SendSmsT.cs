using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JS.Boots.Data.SendSms
{
    public class SendSmsT : BaseModelT
    {
        /// <summary>  
        /// 문자메세지이력일련번호
        /// </summary> 
        public int SmsHistSn { get; set; }

        /// <summary>  
        /// 문자메세지내용
        /// </summary> 
        public string SmsCn { get; set; }

        /// <summary>  
        /// 발송자번호(문자메세지 보낸사람 번호)
        /// </summary> 
        public string SenderNo { get; set; }

        /// <summary>  
        /// 수신자번호(문자메세지 받는사람 번호)
        /// </summary> 
        public string RcverNo { get; set; }

        /// <summary>  
        /// 등록일지
        /// </summary> 
        public DateTime RegistDt { get; set; }

        /// <summary>  
        /// 등록자ID
        /// </summary> 
        public string RegisterId { get; set; }  
    }
}
