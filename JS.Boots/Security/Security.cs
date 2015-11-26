using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Neoplus.Cryptor;

namespace JS.Boots.Security
{
    public enum UserType { None, NormalUser, SiGunGuUser, OrganUser, EnterpriseUser, KtcUser, PblOfficialUser };
    public enum Authorize { None, Create, Read, Update, Delete, Print, Admin };

    public class Security
    {
        #region Auto Code 변환

        public static Authorize AuthorizeTypeChange(string authCode)
        {
            Authorize authorize = Authorize.None;

            switch (authCode)
            {
                case "AC006002":
                    authorize = Authorize.Create;
                    break;
                case "AC006001":
                    authorize = Authorize.Read;
                    break;
                case "AC006003":
                    authorize = Authorize.Update;
                    break;
                case "AC006004":
                    authorize = Authorize.Delete;
                    break;
                case "AC006005":
                    authorize = Authorize.Print;
                    break;
                case "AC006006":
                    authorize = Authorize.Admin;
                    break;
            }

            return authorize;
        }


        public static List<Authorize> AuthorizeTypeChange(List<string> authCodeList)
        {
            List<Authorize> authorizeList = new List<Authorize>();

            foreach (string str in authCodeList)
            {
                authorizeList.Add(AuthorizeTypeChange(str));
            }

            return authorizeList;
        }

        public static string AuthorizeTypeChange(Authorize authorize)
        {
            string authCode = "";

            switch (authorize)
            {
                case Authorize.Create:
                    authCode = "AC006002";
                    break;
                case Authorize.Read:
                    authCode = "AC006001";
                    break;
                case Authorize.Update:
                    authCode = "AC006003";
                    break;
                case Authorize.Delete:
                    authCode = "AC006004";
                    break;
                case Authorize.Admin:
                    authCode = "AC006005";
                    break;
            }

            return authCode;
        }


        public static List<string> AuthorizeTypeChange(List<Authorize> authorizeList)
        {
            List<string> authCodeList = new List<string>();

            foreach (Authorize authorize in authorizeList)
            {
                authCodeList.Add(AuthorizeTypeChange(authorize));
            }

            return authCodeList;
        }

        #endregion


        #region User Type 변환

        public static UserType UserTypeChange(string userSeCode)
        {
            UserType userType = UserType.None;

            switch (userSeCode)
            {
                case "AC007001":
                    userType = UserType.NormalUser;
                    break;
                case "AC007004":
                    userType = UserType.SiGunGuUser;
                    break;
                case "AC007003":
                    userType = UserType.OrganUser;
                    break;
                case "AC007002":
                    userType = UserType.EnterpriseUser;
                    break;
                case "AC007005":
                    userType = UserType.KtcUser;
                    break;
                case "AC007006":
                    userType = UserType.PblOfficialUser;
                    break;
            }

            return userType;
        }



        public static string UserTypeChange(UserType userType)
        {
            string userTypeCode = "";

            switch (userType)
            {
                case UserType.NormalUser:
                    userTypeCode = "AC007001";
                    break;
                case UserType.SiGunGuUser:
                    userTypeCode = "AC007004";
                    break;
                case UserType.OrganUser:
                    userTypeCode = "AC007003";
                    break;
                case UserType.EnterpriseUser:
                    userTypeCode = "AC007002";
                    break;
                case UserType.KtcUser:
                    userTypeCode = "AC007005";
                    break;
                case UserType.PblOfficialUser:
                    userTypeCode = "AC007006";
                    break;
            }

            return userTypeCode;
        }



        #endregion

        /// <summary>
        /// 임시 비밀번호 생성
        /// </summary>
        /// <returns></returns>
        public static string GetTempPassword()
        {
            return System.Web.Security.Membership.GeneratePassword(12, 0);
        }



        public static string Encrypt(string encryptTarget)
        {
            string result = "";

            try
            {
                if (encryptTarget.Length == 0)
                {
                    throw (new Exception("암호화할 문자열을 입력하세요."));
                }
                result = Encryptor.Encrypt(encryptTarget);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return result;
        }



        public static string Decrypt(string decryptTarget)
        {
            string result = "";

            if (decryptTarget.Length == 0)
            {
                throw (new Exception("복호화할 문자열을 입력하세요."));
            }
            result = Decryptor.Decrypt(decryptTarget);

            return result;
        }
    }
}
