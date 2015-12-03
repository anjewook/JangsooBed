using JS.Boots.Data.UserMng;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JS.Boots.BizDac.UserMng
{
    public class UserDac : BaseDac
    {
        /// <summary>
        /// 사용자ID 존재여부 조회
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public string SelectUserExistYn(string userId)
        {
            return Js_Instance.QueryForObject<string>("UserDac.SelectUserExistYn", userId);
        }

        /// <summary>
        /// 사용자ID 조회
        /// </summary>
        /// <param name="userT"></param>
        /// <returns></returns>
        public string SelectUserId(UserT userT)
        {
            return Js_Instance.QueryForObject<string>("UserDac.SelectUserId", userT);
        }

        /// <summary>
        /// 사용자 등록
        /// </summary>
        /// <param name="userT"></param>
        public void InsertUser(UserT userT)
        {
            Js_Instance.Insert("UserDac.InsertUser", userT);
        }

        /// <summary>
        /// 사용자 비밀번호 수정
        /// </summary>
        /// <param name="userT"></param>
        public void UpdateUserPassword(UserT userT)
        {
            Js_Instance.Update("UserDac.UpdateUserPassword", userT);
        }

        /// <summary>
        /// 사용자 삭제(물리삭제)
        /// </summary>
        /// <param name="userId"></param>
        public void DeleteUser(string userId)
        {
            Js_Instance.Delete("UserDac.DeleteUser", userId);
        }
    }
}
