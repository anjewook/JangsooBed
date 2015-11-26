using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JS.Boots.Data.SystemMng
{
    public class CmmnCodeT : BaseModelT
    {
        /// <summary>
        /// 기초코드
        /// </summary>
        public string BsisCode { get; set; }

        /// <summary>
        /// 기초코드명
        /// </summary>
        public string BsisCodeNm { get; set; }

        /// <summary>
        /// 상위기초코드
        /// </summary>
        public string UpperBsisCode { get; set; }

        /// <summary>
        /// 상위기초코드명
        /// </summary>
        public string UpperBsisCodeNm { get; set; }

        /// <summary>
        /// 사용여부
        /// </summary>
        public string UseAt { get; set; }

        /// <summary>
        /// 기초코드설명
        /// </summary>
        public string BsisCodeDc { get; set; }

        /// <summary>
        /// 상위코드1
        /// </summary>
        public string UpperCodeOne { get; set; }

        /// <summary>
        /// 상위코드1명
        /// </summary>
        public string UpperCodeOneNm { get; set; }

        /// <summary>
        /// 상위코드2
        /// </summary>
        public string UpperCodeTwo { get; set; }

        /// <summary>
        /// 상위코드2명
        /// </summary>
        public string UpperCodeTwoNm { get; set; }

        /// <summary>
        /// 상위코드3
        /// </summary>
        public string UpperCodeThree { get; set; }

        /// <summary>
        /// 상위코드3명
        /// </summary>
        public string UpperCodeThreeNm { get; set; }

        /// <summary>
        /// 추가정보1
        /// </summary>
        public string AditInfoOne { get; set; }

        /// <summary>
        /// 추가정보2
        /// </summary>
        public string AditInfoTwo { get; set; }

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
        /// tree에서 사용하는 id
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// tree에서 사용하는 pId
        /// </summary>
        public string Pid { get; set; }

        /// <summary>
        /// tree에서 사용하는 level
        /// </summary>
        public int Level { get; set; }

        /// <summary>
        /// Mode I:insert, U:update, D:delete
        /// </summary>
        public string Mode { get; set; }
    
    }
}
