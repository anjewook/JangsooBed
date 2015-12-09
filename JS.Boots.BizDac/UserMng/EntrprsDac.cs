using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using JS.Boots.Data.UserMng;

namespace JS.Boots.BizDac.UserMng
{
    public class EntrprsDac : BaseDac
    {
        /// <summary> 
        /// 기업관리 목록
        /// </summary>  
        /// <remarks>  
        ///  자세한 설명  
        /// </remarks> 
        /// <param name="EntrprsSearchT"></param> 
        /// <returns></returns> 
        public IList<EntrprsT> SelectEntrprsList(EntrprsSearchT entrprsSearchT)
        {
            return Js_Instance.QueryForList<EntrprsT>("EntrprsDac.SelectEntrprsList", entrprsSearchT);
        }

        /// <summary>
        /// 기업관리 상세
        /// </summary>
        /// <param name="entrprsT"></param>
        /// <returns></returns>
        public EntrprsT SelectEntrprs(EntrprsT entrprsT)
        {
            return (EntrprsT)Js_Instance.QueryForObject("EntrprsDac.SelectEntrprs", entrprsT);
        }

        /// <summary>
        /// 사업자번호의 기업상세 조회
        /// </summary>
        /// <param name="bizrno"></param>
        /// <returns></returns>
        public EntrprsT SelectEntrprsOfBizrno(string bizrno)
        {
            return (EntrprsT)Js_Instance.QueryForObject("EntrprsDac.SelectEntrprsOfBizrno", bizrno);
        }

        /// <summary> 
        /// 기업관리 생성 
        /// </summary>  
        /// <remarks>  
        ///  자세한 설명  
        /// </remarks> 
        /// <param name="EntrprsT"></param> 
        /// <returns></returns> 
        public long InsertEntrprs(EntrprsT entrprsT)
        {
            return (long)Js_Instance.Insert("EntrprsDac.InsertEntrprs", entrprsT);
        }

        /// <summary> 
        /// 기업관리 수정 
        /// </summary>  
        /// <remarks>  
        ///  자세한 설명  
        /// </remarks> 
        /// <param name="EntrprsT"></param> 
        /// <returns></returns> 
        public long UpdateEntrprs(EntrprsT entrprsT)
        {
            return Js_Instance.Update("EntrprsDac.UpdateEntrprs", entrprsT);
        }

        /// <summary> 
        /// 기업관리 삭제 
        /// </summary>  
        /// <remarks>  
        ///  자세한 설명  
        /// </remarks> 
        /// <param name="EntrprsT"></param> 
        /// <returns></returns> 
        public long DeleteEntrprs(EntrprsT entrprsT)
        {
            return Js_Instance.Delete("EntrprsDac.DeleteEntrprs", entrprsT);
        }



        /// <summary> 
        /// 기업관리 주소 생성 
        /// </summary>  
        /// <remarks>  
        ///  자세한 설명  
        /// </remarks> 
        /// <param name="EntrprsAdresT"></param> 
        /// <returns></returns> 
        public void InsertEntrprsAdres(EntrprsAdresT entrprsAdresT)
        {
            Js_Instance.Insert("EntrprsDac.InsertEntrprsAdres", entrprsAdresT);
        }

        /// <summary> 
        /// 기업관리 주소 수정 
        /// </summary>  
        /// <remarks>  
        ///  자세한 설명  
        /// </remarks> 
        /// <param name="EntrprsAdresT"></param> 
        /// <returns></returns> 
        public void UpdateEntrprsAdres(EntrprsAdresT entrprsAdresT)
        {
            Js_Instance.Update("EntrprsDac.UpdateEntrprsAdres", entrprsAdresT);
        }

        /// <summary> 
        /// 기업관리 주소 삭제 
        /// </summary>  
        /// <remarks>  
        ///  자세한 설명  
        /// </remarks> 
        /// <param name="EntrprsAdresT"></param> 
        /// <returns></returns> 
        public void DeleteEntrprsAdres(long EntrprsSn)
        {
            Js_Instance.Delete("EntrprsDac.DeleteEntrprsAdres", EntrprsSn);
        }

        /// <summary>
        /// 기업 일련번호로 다수의 기업주소 목록 가져오기
        /// </summary>
        /// <param name="EntrprsSn"></param>
        /// <returns></returns>
        public IList<EntrprsAdresT> SelectEntrprsAdresList(EntrprsAdresT entrprsAdresT)
        {
            return Js_Instance.QueryForList<EntrprsAdresT>("EntrprsDac.SelectEntrprsAdresList", entrprsAdresT);
        }

        /// <summary>
        /// 기업주소구분코드별 기업주소 상세 조회(최초등록된 단건조회용)
        /// </summary>
        /// <param name="entrprsAdresT"></param>
        /// <returns></returns>
        public EntrprsAdresT SelectEntrprsAdresByEntrPrsAdresSeCode(EntrprsAdresT entrprsAdresT)
        {
            return Js_Instance.QueryForObject<EntrprsAdresT>("EntrprsDac.SelectEntrprsAdresByEntrPrsAdresSeCode", entrprsAdresT);
        }

        /// <summary>
        /// 기업 사업자등록번호 존재여부 조회
        /// </summary>
        /// <param name="bizrno"></param>
        /// <returns></returns>
        public string SelectEntrprsBizrnoExistYn(string bizrno)
        {
            return Js_Instance.QueryForObject<string>("EntrprsDac.SelectEntrprsBizrnoExistYn", bizrno);
        }

        /// <summary> 
        /// 기업변경이력 목록 
        /// </summary>  
        /// <param name="searchT">기업변경이력 검색조건</param> 
        /// <returns>기업변경이력 목록</returns> 
        public IList<EntrprsChghstT> SelectEntrprsChghstList(long entrprsSn)
        {
            return Js_Instance.QueryForList<EntrprsChghstT>("EntrprsDac.SelectEntrprsChghstList", entrprsSn);
        }

        /// <summary> 
        /// 기업변경이력 생성 
        /// </summary>  
        /// <param name="entrprsChghstT">기업변경이력 정보</param> 
        /// <returns>생성된 Row의 Key값</returns> 
        public object InsertEntrprsChghst(EntrprsChghstT entrprsChghstT)
        {
            return Js_Instance.Insert("EntrprsDac.InsertEntrprsChghst", entrprsChghstT);
        }

    }
}
