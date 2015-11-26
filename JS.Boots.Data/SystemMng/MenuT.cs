using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JS.Boots.Data.SystemMng
{
    public class MenuT : BaseModelT
    {
        /// <summary>  
        /// 메뉴코드
        /// </summary> 
        public string MenuCode { get; set; }

        /// <summary>
        /// 상위메뉴코드
        /// </summary> 
        public string UpperMenuCode { get; set; }

        /// <summary>  
        /// 상위메뉴명
        /// </summary> 
        public string UpperMenuNm { get; set; }

        /// <summary>  
        /// 메뉴명
        /// </summary> 
        public string MenuNm { get; set; }

        /// <summary>  
        /// 메뉴유형코드
        /// </summary> 
        public string MenuTyCode { get; set; }

        /// <summary>  
        /// 컨텐츠유형코드
        /// </summary> 
        public string CntntsTyCode { get; set; }

        /// <summary>
        /// 링크유형코드
        /// </summary>
        public string LinkTyCode { get; set; }

        /// <summary>  
        /// 메뉴URL
        /// </summary> 
        public string MenuUrl { get; set; }

        /// <summary>  
        /// 정렬순서
        /// </summary> 
        public int SortOrdr { get; set; }

        /// <summary>  
        /// 사용여부
        /// </summary> 
        public string UseAt { get; set; }

        /// <summary>  
        /// 메뉴설명
        /// </summary> 
        public string MenuDc { get; set; }

        /// <summary>  
        /// 삭제여부
        /// </summary> 
        public string DeleteAt { get; set; }

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
        /// Mode I:insert, U:update, D:delete
        /// </summary>
        public string Mode { get; set; }

        /// <summary>
        /// 메뉴코드
        /// </summary>
        public string ParamMenuCode { get; set; }

    }
}
