using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using JS.Boots.Data;
using JS.Boots.Data.AdminMain;

namespace JS.Boots.BizDac.AdminMain
{
    public class ManagerBiz : BaseBiz
    {

        /// <summary>
        /// 관리자 정보 리스트
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        public IList<ManagerT> SelectAtManagerList(ManagerSearchT searchT)
        {
            return new ManagerDac().SelectAtManagerList(searchT);
        }

        /// <summary>
        /// 관리자 정보 가져오기
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        public ManagerT SelectAtManager(string ManagerID)
        {
            return new ManagerDac().SelectAtManager(ManagerID);
        }

        public void JoinManagerMember(ManagerT managerT)
        {
            ManagerDac managerDac = new ManagerDac();
            //long managerSn = 0;

            managerT.RightUse = string.IsNullOrEmpty(managerT.RightUse) ? "false" : "true";         // 권한정상여부
            managerT.RightRegi = string.IsNullOrEmpty(managerT.RightRegi) ? "false" : "true";       // 상세보기여부
            managerT.UseAt = string.IsNullOrEmpty(managerT.UseAt) ? "false" : "true";               // 사용여부
            managerT.SclsrtAt = string.IsNullOrEmpty(managerT.SclsrtAt) ? "false" : "true";         // 계층여부
            managerT.OthbcAt = string.IsNullOrEmpty(managerT.OthbcAt) ? "false" : "true";           // 공개여부

            BeginTran();
            try
            {

                //ID 중복체크
                string existYn = new ManagerBiz().SelectManagerExistYn(managerT.ManagerID);
                if (existYn == "Y")
                {
                    throw new Exception("해당 ID 는 이미 사용중입니다.");
                }

                //관리자정보 등록
                //managerSn = managerDac.InsertManager(managerT);
                managerDac.InsertManager(managerT);
                /*
                // 참고 KTC 로직 EntrprsBiz.JoinEntrprsMember 모듈 소스 참고
                // 사용자 생성 
                UserT userT = new UserT();
                userT.UserId = entrprsUserT.UserId;
                userT.Password = Security.Security.Encrypt(entrprsT.Password);
                userT.UserSeCode = "AC007002"; //사용자구분코드( 기업사용자: AC007002)

                new UserBiz().InsertUser(userT, "N");

                // 기업사용자 INSERT
                new EntrprsUserDac().InsertEntrprsUser(entrprsUserT);
                */

                Commit();
            }
            catch (Exception e)
            {
                this.RollBack();
                throw e;
            }
        }

        public void UpdateMangerMember(ManagerT managerT)
        {
            ManagerDac managerDac = new ManagerDac();

            long managerSn = managerT.ManagerSn;
            //long updateCount = 0;
            //string EntrprsAuthCD = "AC019003";

            managerT.RightUse = string.IsNullOrEmpty(managerT.RightUse) ? "false" : "true";         // 권한정상여부
            managerT.RightRegi = string.IsNullOrEmpty(managerT.RightRegi) ? "false" : "true";       // 상세보기여부
            managerT.UseAt = string.IsNullOrEmpty(managerT.UseAt) ? "false" : "true";               // 사용여부
            managerT.SclsrtAt = string.IsNullOrEmpty(managerT.SclsrtAt) ? "false" : "true";         // 계층여부
            managerT.OthbcAt = string.IsNullOrEmpty(managerT.OthbcAt) ? "false" : "true";           // 공개여부

            BeginTran();

            try
            {
                string existYn = new ManagerBiz().SelectManagerExistYn(managerT.ManagerID);

                // 관리자 UPDATE
                new ManagerDac().UpdateManager(managerT);

                Commit();
            }
            catch (Exception e)
            {
                this.RollBack();
                throw e;
            }
        }

        /// <summary>
        /// 관리자ID 존재여부 판별
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public string SelectManagerExistYn(string managerId)
        {
            return new ManagerDac().SelectManagerExistYn(managerId);
        }

        public void CheckManagerID(string ManagerID)
        {
            throw new NotImplementedException();
        }
    }
}
