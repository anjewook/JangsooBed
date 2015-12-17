using JS.Boots.Data.SystemMng;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JS.Boots.BizDac.SystemMng
{
    public class MenuBiz : BaseBiz
    {
        /// <summary>
        /// 메뉴TREE 목록 조회
        /// </summary>
        /// <param name="searchT"></param>
        /// <returns></returns>
        public IList<MenuT> SelectMenuTree(MenuSearchT searchT)
        {
            return new MenuDac().SelectMenuTree(searchT);
        }

        /// <summary>
        /// 메뉴 상세 조회
        /// </summary>
        /// <param name="menuCode"></param>
        /// <returns></returns>
        public MenuT SelectMenu(string menuCode)
        {
            return new MenuDac().SelectMenu(menuCode);
        }

        /// <summary>
        /// 하위 메뉴 목록 조회
        /// </summary>
        /// <param name="upperMenuCode"></param>
        /// <returns></returns>
        public IList<MenuT> SelectLowerMenuList(string upperMenuCode)
        {
            return new MenuDac().SelectLowerMenuList(upperMenuCode);
        }

        /// <summary>
        /// 메뉴정보 영속성 관리
        /// </summary>
        /// <param name="menuT"></param>
        /// <returns></returns>
        public string ProcessMenu(MenuT menuT)
        {
            string mode = menuT.Mode;
            string menuCode = "";

            if (mode != null)
            {
                if (mode != "I" && mode != "U" && mode != "D")
                {
                    throw new Exception("Mode 는 I,U,D 중 하나 이어야 합니다.");
                }

                if (mode != "I")
                {
                    menuCode = menuT.MenuCode;
                }

                if (mode == "I")
                {
                    menuCode = new MenuDac().InsertMenu(menuT);
                }
                else if (mode == "U")
                {
                    new MenuDac().UpdateMenu(menuT);
                }
                else if (mode == "D")
                {
                    //논리삭제
                    new MenuDac().DeleteMenu(menuCode);
                }
            }
            else
            {
                throw new Exception("Mode 값이 NULL 입니다.");
            }
            return menuCode;
        }


        /// <summary>
        /// 1단 메뉴 조회
        /// </summary>
        /// <param name="menuCode"></param>
        /// <returns></returns>
        public MenuT SelectOneUpperMenu(string menuCode)
        {
            return new MenuDac().SelectOneUpperMenu(menuCode);
        }

    }

}
