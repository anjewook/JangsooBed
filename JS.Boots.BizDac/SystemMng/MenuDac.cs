using JS.Boots.Data.SystemMng;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JS.Boots.BizDac.SystemMng
{
    public class MenuDac : BaseDac
    {

        /// <summary> 
        /// 메뉴Tree 조회 
        /// </summary>  
        /// <remarks>  
        ///  메뉴리스트를 Tree형태로 조회한다.
        /// </remarks> 
        /// <param name="MenuSearchT"></param> 
        /// <returns></returns> 
        public IList<MenuT> SelectMenuTree(MenuSearchT searchT)
        {
            return Js_Instance.QueryForList<MenuT>("MenuDac.SelectMenuTree", searchT);
        }

        /// <summary>
        /// 메뉴 상세 조회
        /// </summary>
        /// <remarks>  
        ///  메뉴의 상세정보를 조회한다.
        /// </remarks> 
        /// <param name="menuCode"></param>
        /// <returns></returns>
        public MenuT SelectMenu(string menuCode)
        {
            return Js_Instance.QueryForObject<MenuT>("MenuDac.SelectMenu", menuCode);
        }

        /// <summary>
        /// 하위 메뉴 목록 조회
        /// </summary>
        /// <remarks>  
        /// 하위 메뉴 목록을 조회한다.
        /// </remarks> 
        /// <param name="upperMenuCode"></param>
        /// <returns></returns>
        public IList<MenuT> SelectLowerMenuList(string upperMenuCode)
        {
            return Js_Instance.QueryForList<MenuT>("MenuDac.SelectLowerMenuList", upperMenuCode);
        }

        /// <summary> 
        /// 메뉴 등록
        /// </summary>  
        /// <remarks>  
        ///  메뉴정보를 INSERT 한다.
        /// </remarks> 
        /// <param name="MenuT"></param> 
        /// <returns></returns> 
        public string InsertMenu(MenuT menuT)
        {
            return (string)Js_Instance.Insert("MenuDac.InsertMenu", menuT);
        }

        /// <summary> 
        /// 메뉴 수정 
        /// </summary>  
        /// <remarks>  
        ///  메뉴정보를 UPDATE 한다.
        /// </remarks> 
        /// <param name="MenuT"></param> 
        /// <returns></returns> 
        public void UpdateMenu(MenuT menuT)
        {
            Js_Instance.Update("MenuDac.UpdateMenu", menuT);
        }

        /// <summary> 
        /// 메뉴 삭제 
        /// </summary>  
        /// <remarks>  
        ///  메뉴정보를 DELETE 한다.
        /// </remarks> 
        /// <param name="MenuT"></param> 
        /// <returns></returns> 
        public void DeleteMenu(string menuCode)
        {
            Js_Instance.Delete("MenuDac.DeleteMenu", menuCode);
        }

        /// <summary>
        /// 1단메뉴정보 조회
        /// </summary>
        /// <param name="menuCode"></param>
        /// <returns></returns>
        public MenuT SelectOneUpperMenu(string menuCode)
        {
            return Js_Instance.QueryForObject<MenuT>("MenuDac.SelectOneUpperMenu", menuCode);
        }

    }
}
