using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JS.Boots.Data.Stats
{
    public class EntrprsStatsT : BaseModelT
    {
        /// <summary>
        /// 코드
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 명칭
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 제작업 수
        /// </summary>
        public int MfcrtrCnt { get; set; }

        /// <summary>
        /// 수리업 수
        /// </summary>
        public int RepairIndutyCnt { get; set; }

        /// <summary>
        /// 수입업 수
        /// </summary>
        public int IrtbCnt { get; set; }

        /// <summary>
        /// 계량증명업 수
        /// </summary>
        public int MesurProofIndutyCnt { get; set; }

        /// <summary>
        /// 합계
        /// </summary>
        public int Total { get; set; }

    }
}
