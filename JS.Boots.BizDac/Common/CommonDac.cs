using JS.Boots.Data.SystemMng;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JS.Boots.BizDac.Common
{
    public class CommonDac : BaseDac
    {
        /// <summary>
        /// 공통코드 목록 조회
        /// </summary>
        /// <remark>
        /// 상위기초코드에 해당하는 하위 공통코드 리스트를 가져온다.
        /// </remark>
        /// <param name="upperBsisCode"></param>
        /// <returns></returns>
        public IList<CmmnCodeT> SelectCmmnCodeList(String upperBsisCode)
        {
            return Js_Instance.QueryForList<CmmnCodeT>("CommonDac.SelectCmmnCodeList", upperBsisCode);
        }

        /// <summary>
        /// base_codeT 테이블의 분류에 따른 코드를 List Up
        /// </summary>
        /// <param name="upperBsisCode"></param>
        /// <returns></returns>
        public IList<CmmnCodeT> SelectOptCodeList(CmmnCodeT cmdT)
        {
            return Js_Instance.QueryForList<CmmnCodeT>("CommonDac.SelectOptCodeList", cmdT);
        }

        /// <summary>
        /// 상위코드1(UPPER_CODE_ONE) 을 상위코드로 하는 하위 공통코드 목록 조회
        /// </summary>
        /// <param name="upperCodeOne"></param>
        /// <returns></returns>
        public IList<CmmnCodeT> SelectCmmnCodeListByUpperCodeOne(String upperCodeOne)
        {
            return Js_Instance.QueryForList<CmmnCodeT>("CommonDac.SelectCmmnCodeListByUpperCodeOne", upperCodeOne);
        }

        public IList<CmmnCodeT> SelectCmmnCodeListByUpperCodeTwo(String upperCodeTwo)
        {
            return Js_Instance.QueryForList<CmmnCodeT>("CommonDac.SelectCmmnCodeListByUpperCodeTwo", upperCodeTwo);
        }

        public IList<CmmnCodeT> SelectCmmnCodeListByUpperCodeThree(String upperCodeThree)
        {
            return Js_Instance.QueryForList<CmmnCodeT>("CommonDac.SelectCmmnCodeListByUpperCodeThree", upperCodeThree);
        }

        /// <summary>
        /// 공통코드명 매핑 공통코드 조회
        /// </summary>
        /// <param name="bsisCodeNm"></param>
        /// <returns></returns>
        public string SelectCmmnCodeByCmmnCodeNm(CmmnCodeT cmmnCodeT)
        {
            return Js_Instance.QueryForObject<string>("CommonDac.SelectCmmnCodeByCmmnCodeNm", cmmnCodeT);
        }

    }
}
