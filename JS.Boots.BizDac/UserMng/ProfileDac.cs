using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using IBatisNet.Common;
using IBatisNet.DataMapper;

using JS.Boots.Data;
using JS.Boots.Data.UserMng;

namespace JS.Boots.BizDac.UserMng
{
    public class ProfileDac : BaseDac
    {
        /// <summary>
        /// 사용자 상세 조회
        /// </summary>
        /// <param name="profileT"></param>
        /// <returns></returns>
        public ProfileT SelectUser(ProfileT profileT)
        {
            return Js_Instance.QueryForObject<ProfileT>("ProfileDac.SelectUser", profileT);
        }

        /// <summary>
        /// Js사용자 상세 조회
        /// </summary>
        /// <param name="profileT"></param>
        /// <returns></returns>
        public ProfileT SelectJsUser(ProfileT profileT)
        {
            return Js_Instance.QueryForObject<ProfileT>("ProfileDac.SelectJsUser", profileT);
        }

        /// <summary>
        /// Js사용자 메뉴별 권한 목록 조회
        /// </summary>
        /// <param name="userMenuAuthSearchT"></param>
        /// <returns></returns>
        public IList<string> SelectJsUserMenuAuthList(UserMenuAuthSearchT userMenuAuthSearchT)
        {
            return Js_Instance.QueryForList<string>("ProfileDac.SelectJsUserMenuAuthList", userMenuAuthSearchT);
        }

        /// <summary>
        /// Js사용자 권한그룹 목록 조회
        /// </summary>
        /// <param name="emplCode"></param>
        /// <returns></returns>
        public IList<string> SelectJsUserAuthGroupList(string emplCode)
        {
            return Js_Instance.QueryForList<string>("ProfileDac.SelectJsUserAuthGroupList", emplCode);
        }

        /// <summary>
        /// 사용자 메뉴별 권한 목록 조회
        /// </summary>
        /// <param name="userMenuAuthSearchT"></param>
        /// <returns></returns>
        public IList<string> SelectUserMenuAuthList(UserMenuAuthSearchT userMenuAuthSearchT)
        {
            return Js_Instance.QueryForList<string>("ProfileDac.SelectUserMenuAuthList", userMenuAuthSearchT);
        }
    }
}
