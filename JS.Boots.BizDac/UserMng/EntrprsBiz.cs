using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using JS.Boots.Data.UserMng;

namespace JS.Boots.BizDac.UserMng
{
    public class EntrprsBiz : BaseBiz
    {
        public IList<EntrprsT> SelectEntrprsList(EntrprsSearchT entrprsSearchT)
        {
            IList<EntrprsT> rtnList = new List<EntrprsT>();
            IList<EntrprsT> entrprsList = new EntrprsDac().SelectEntrprsList(entrprsSearchT);
            for (int i = 0; i < entrprsList.Count; i++)
            {
                EntrprsT entrprsT = entrprsList[i];

                //사업장주소 가져오기
                EntrprsAdresT entrprsAdresT = new EntrprsAdresT();
                entrprsAdresT.EntrprsSn = entrprsT.EntrprsSn;
                entrprsAdresT.EntrprsAdresSeCode = "AC002001"; //사업장주소
                entrprsAdresT = new EntrprsDac().SelectEntrprsAdresByEntrPrsAdresSeCode(entrprsAdresT);

                if (entrprsAdresT != null)
                {
                    entrprsT.BizEntrprsAdresT = entrprsAdresT;
                }
                else
                {
                    entrprsT.BizEntrprsAdresT = new EntrprsAdresT();
                }
                rtnList.Add(entrprsT);
            }
            return rtnList;
        }

        public long InsertEntrprs(EntrprsT entrprsT)
        {
            EntrprsDac entrprsDac = new EntrprsDac();

            long entrprsSn = 0;

            // 제조업여부
            entrprsT.MfcrtrAt = string.IsNullOrEmpty(entrprsT.MfcrtrAt) ? "N" : "Y";

            // 수입업여부
            entrprsT.IrtbAt = string.IsNullOrEmpty(entrprsT.IrtbAt) ? "N" : "Y";

            // 수리업여부
            entrprsT.RepairIndutyAt = string.IsNullOrEmpty(entrprsT.RepairIndutyAt) ? "N" : "Y";

            // 계량증명업여부
            entrprsT.MesurProofIndutyAt = string.IsNullOrEmpty(entrprsT.MesurProofIndutyAt) ? "N" : "Y";

            // 계량기사용자여부
            entrprsT.MrnrEmplyrAt = string.IsNullOrEmpty(entrprsT.MrnrEmplyrAt) ? "N" : "Y";

            BeginTran();

            try
            {
                //사업자번호 체크
                string existYn = new EntrprsBiz().SelectEntrprsBizrnoExistYn(entrprsT.Bizrno);
                if (existYn == "Y")
                {
                    throw new Exception("이미 등록된 사업자번호입니다.");
                }
                entrprsSn = entrprsDac.InsertEntrprs(entrprsT);

                //기업주소 정보 INSERT
                if (entrprsT.entrprsAdresList != null && entrprsT.entrprsAdresList.Count > 0)
                {
                    for (int i = 0; i < entrprsT.entrprsAdresList.Count; i++)
                    {
                        EntrprsAdresT entrprsAdresT = entrprsT.entrprsAdresList[i];
                        entrprsAdresT.EntrprsSn = entrprsSn;

                        entrprsDac.InsertEntrprsAdres(entrprsAdresT);
                    }
                }

                Commit();
            }
            catch (Exception e)
            {
                this.RollBack();
                throw e;
            }

            return entrprsSn;
        }

        public EntrprsT SelectEntrprs(EntrprsT argsEntrprsT)
        {
            EntrprsDac entrprsDac = new EntrprsDac();
            EntrprsT entrprsT = entrprsDac.SelectEntrprs(argsEntrprsT);

            if (entrprsT != null)
            {
                EntrprsAdresT entrprsAdresT = new EntrprsAdresT();
                entrprsAdresT.EntrprsSn = argsEntrprsT.EntrprsSn;

                entrprsT.entrprsAdresList = entrprsDac.SelectEntrprsAdresList(entrprsAdresT);

                //사업장주소 가져오기
                EntrprsAdresT bizEntrprsAdresT = new EntrprsAdresT();
                bizEntrprsAdresT.EntrprsSn = entrprsT.EntrprsSn;
                bizEntrprsAdresT.EntrprsAdresSeCode = "AC002001"; //사업장주소
                bizEntrprsAdresT = new EntrprsDac().SelectEntrprsAdresByEntrPrsAdresSeCode(bizEntrprsAdresT);

                if (bizEntrprsAdresT != null)
                {
                    entrprsT.BizEntrprsAdresT = bizEntrprsAdresT;
                }
                else
                {
                    entrprsT.BizEntrprsAdresT = new EntrprsAdresT();
                }

            }

            return entrprsT;
        }

        /// <summary>
        /// 사업자번호의 기업상세 조회
        /// </summary>
        /// <param name="bizrno"></param>
        /// <returns></returns>
        public EntrprsT SelectEntrprsOfBizrno(string bizrno)
        {
            EntrprsDac entrprsDac = new EntrprsDac();
            EntrprsT entrprsT = entrprsDac.SelectEntrprsOfBizrno(bizrno);

            if (entrprsT != null)
            {
                EntrprsAdresT entrprsAdresT = new EntrprsAdresT();
                entrprsAdresT.EntrprsSn = entrprsT.EntrprsSn;

                entrprsT.entrprsAdresList = entrprsDac.SelectEntrprsAdresList(entrprsAdresT);

                //사업장주소 가져오기
                EntrprsAdresT bizEntrprsAdresT = new EntrprsAdresT();
                bizEntrprsAdresT.EntrprsSn = entrprsT.EntrprsSn;
                bizEntrprsAdresT.EntrprsAdresSeCode = "AC002001"; //사업장주소
                bizEntrprsAdresT = new EntrprsDac().SelectEntrprsAdresByEntrPrsAdresSeCode(bizEntrprsAdresT);

                if (bizEntrprsAdresT != null)
                {
                    entrprsT.BizEntrprsAdresT = bizEntrprsAdresT;
                }
                else
                {
                    entrprsT.BizEntrprsAdresT = new EntrprsAdresT();
                }
            }

            return entrprsT;
        }

        /// <summary>
        /// 기업정보 수정
        /// </summary>
        /// <param name="entrprsT"></param>
        /// <returns></returns>
        public long UpdateEntrprs(EntrprsT entrprsT)
        {
            EntrprsDac entrprsDac = new EntrprsDac();

            long entrprsSn = entrprsT.EntrprsSn;
            long updateCount = 0;

            // 제조업여부
            entrprsT.MfcrtrAt = string.IsNullOrEmpty(entrprsT.MfcrtrAt) ? "N" : entrprsT.MfcrtrAt;

            // 수입업여부
            entrprsT.IrtbAt = string.IsNullOrEmpty(entrprsT.IrtbAt) ? "N" : entrprsT.IrtbAt;

            // 수리업여부
            entrprsT.RepairIndutyAt = string.IsNullOrEmpty(entrprsT.RepairIndutyAt) ? "N" : entrprsT.RepairIndutyAt;

            // 계량증명업여부
            entrprsT.MesurProofIndutyAt = string.IsNullOrEmpty(entrprsT.MesurProofIndutyAt) ? "N" : entrprsT.MesurProofIndutyAt;

            // 계량기사용자여부
            entrprsT.MrnrEmplyrAt = string.IsNullOrEmpty(entrprsT.MrnrEmplyrAt) ? "N" : entrprsT.MrnrEmplyrAt;

            BeginTran();

            try
            {
                updateCount = entrprsDac.UpdateEntrprs(entrprsT);

                if (updateCount > 0)
                {
                    //기업주소 삭제
                    entrprsDac.DeleteEntrprsAdres(entrprsSn);

                    //기업주소 INSERT
                    if (entrprsT.entrprsAdresList != null && entrprsT.entrprsAdresList.Count > 0)
                    {
                        for (int i = 0; i < entrprsT.entrprsAdresList.Count; i++)
                        {
                            EntrprsAdresT entrprsAdresT = entrprsT.entrprsAdresList[i];
                            entrprsAdresT.EntrprsSn = entrprsSn;

                            entrprsDac.InsertEntrprsAdres(entrprsAdresT);
                        }
                    }
                    
                    //이력정보가 있는 경우 INSERT
                    if (!String.IsNullOrEmpty(entrprsT.changeDe) && !String.IsNullOrEmpty(entrprsT.changeCn))
                    {
                        EntrprsChghstT entrprsChghstT = new EntrprsChghstT();
                        entrprsChghstT.EntrprsSn = entrprsSn;
                        entrprsChghstT.ChangeDe = entrprsT.changeDe;
                        entrprsChghstT.ChangeCn = entrprsT.changeCn;
                        entrprsChghstT.RegisterSeCode = entrprsT.RegisterSeCode;
                        entrprsChghstT.RegisterId = entrprsT.RegisterId;

                        entrprsDac.InsertEntrprsChghst(entrprsChghstT);
                    }

                }

                Commit();
            }
            catch (Exception e)
            {
                this.RollBack();
                throw e;
            }

            return new EntrprsDac().UpdateEntrprs(entrprsT);
        }

        public long DeleteEntrprs(EntrprsT entrprsT)
        {
            return new EntrprsDac().DeleteEntrprs(entrprsT);
        }

        public IList<EntrprsAdresT> SelectEntrprsAdresList(EntrprsAdresT entrprsAdresT)
        {
            return new EntrprsDac().SelectEntrprsAdresList(entrprsAdresT);
        }

        /// <summary>
        /// 기업주소구분코드별 기업주소 상세 조회(최초등록된 단건조회용)
        /// </summary>
        /// <param name="entrprsAdresT"></param>
        /// <returns></returns>
        public EntrprsAdresT SelectEntrprsAdresByEntrPrsAdresSeCode(EntrprsAdresT entrprsAdresT)
        {
            return new EntrprsDac().SelectEntrprsAdresByEntrPrsAdresSeCode(entrprsAdresT);
        }


        /// <summary>
        /// 기업회원가입 등록
        /// </summary>
        /// <param name="entrprsT"></param>
        public void JoinEntrprsMember(EntrprsT entrprsT)
        {
            EntrprsDac entrprsDac = new EntrprsDac();

            long entrprsSn = 0;

            // 제조업여부
            entrprsT.MfcrtrAt = string.IsNullOrEmpty(entrprsT.MfcrtrAt) ? "N" : "Y";

            // 수입업여부
            entrprsT.IrtbAt = string.IsNullOrEmpty(entrprsT.IrtbAt) ? "N" : "Y";

            // 수리업여부
            entrprsT.RepairIndutyAt = string.IsNullOrEmpty(entrprsT.RepairIndutyAt) ? "N" : "Y";

            // 계량증명업여부
            entrprsT.MesurProofIndutyAt = string.IsNullOrEmpty(entrprsT.MesurProofIndutyAt) ? "N" : "Y";

            // 계량기사용자여부
            entrprsT.MrnrEmplyrAt = string.IsNullOrEmpty(entrprsT.MrnrEmplyrAt) ? "N" : "Y";

            BeginTran();

            try
            {
                //기업정보 등록
                entrprsSn = entrprsDac.InsertEntrprs(entrprsT);

                if (entrprsT.entrprsAdresList != null && entrprsT.entrprsAdresList.Count > 0)
                {
                    for (int i = 0; i < entrprsT.entrprsAdresList.Count; i++)
                    {
                        EntrprsAdresT entrprsAdresT = entrprsT.entrprsAdresList[i];
                        entrprsAdresT.EntrprsSn = entrprsSn;

                        //기업주소정보 등록
                        entrprsDac.InsertEntrprsAdres(entrprsAdresT);
                    }
                }

                EntrprsUserT entrprsUserT = new EntrprsUserT();
                entrprsUserT.EntrprsSn = entrprsSn;
                entrprsUserT.UserId = entrprsT.UserId;
                entrprsUserT.UserNm = entrprsT.UserNm;
                entrprsUserT.Telno = entrprsT.Telno;
                entrprsUserT.Mbtlnum = entrprsT.Mbtlnum;
                entrprsUserT.EmailAdres = entrprsT.EmailAdres;
                entrprsUserT.MngrAt = "Y"; //관리자여부
                entrprsUserT.EntrprsUserSttusCode = "AC019003"; //기업사용자상태코드(승인대기로 설정)
                entrprsUserT.RegisterSeCode = "AC007002";   //등록자구분코드( 기업사용자: AC007002)
                entrprsUserT.RegisterId = entrprsT.UserId;
                entrprsUserT.UpdusrSeCode = "AC007002";     //수정자구분코드( 기업사용자: AC007002)
                entrprsUserT.UpdusrId = entrprsT.UserId;


                //기업사용자 ID 중복체크
                string existYn = new UserDac().SelectUserExistYn(entrprsUserT.UserId);
                if (existYn == "Y")
                {
                    // 사용자 ID 중복체크
                    throw new Exception("해당 사용자ID 는 이미 사용중입니다.");
                }

                // 사용자 생성 
                UserT userT = new UserT();
                userT.UserId = entrprsUserT.UserId;
                userT.Password = Security.Security.Encrypt(entrprsT.Password);
                userT.UserSeCode = "AC007002"; //사용자구분코드( 기업사용자: AC007002)

                new UserBiz().InsertUser(userT, "N");

                // 기업사용자 INSERT
                new EntrprsUserDac().InsertEntrprsUser(entrprsUserT);

                Commit();
            }
            catch (Exception e)
            {
                this.RollBack();
                throw e;
            }
        }

        /// <summary>
        /// 기업회원정보 수정
        /// </summary>
        /// <param name="entrprsT"></param>
        public void UpdateEntrprsMember(EntrprsT entrprsT)
        {
            EntrprsDac entrprsDac = new EntrprsDac();

            long entrprsSn = entrprsT.EntrprsSn;
            long updateCount = 0;
            string EntrprsAuthCD = "AC019003";

            // 제조업여부
            entrprsT.MfcrtrAt = string.IsNullOrEmpty(entrprsT.MfcrtrAt) ? "N" : "Y";

            // 수입업여부
            entrprsT.IrtbAt = string.IsNullOrEmpty(entrprsT.IrtbAt) ? "N" : "Y";

            // 수리업여부
            entrprsT.RepairIndutyAt = string.IsNullOrEmpty(entrprsT.RepairIndutyAt) ? "N" : "Y";

            // 계량증명업여부
            entrprsT.MesurProofIndutyAt = string.IsNullOrEmpty(entrprsT.MesurProofIndutyAt) ? "N" : "Y";

            // 계량기사용자여부
            entrprsT.MrnrEmplyrAt = string.IsNullOrEmpty(entrprsT.MrnrEmplyrAt) ? "N" : "Y";

            //계량기사용자여부 판별후 승인대기or승인
            if (entrprsT.MfcrtrAt == "N" && entrprsT.IrtbAt == "N" && entrprsT.RepairIndutyAt == "N" && entrprsT.MesurProofIndutyAt == "N")
            {
                if (entrprsT.MrnrEmplyrAt == "Y")
                {
                    EntrprsAuthCD = "AC019001"; //기업사용자상태코드(승인 설정)
                }
                else
                {
                    EntrprsAuthCD = "AC019003"; //기업사용자상태코드(승인 설정)
                }
            }

            BeginTran();

            try
            {
                //회원여부 상태 업데이트 - 기존입력된 회원업체 DB 때문
                entrprsT.MberAt = "Y";

                //기업정보 수정
                updateCount = entrprsDac.UpdateEntrprs(entrprsT);

                if (updateCount > 0)
                {
                    entrprsDac.DeleteEntrprsAdres(entrprsSn);

                    if (entrprsT.entrprsAdresList != null && entrprsT.entrprsAdresList.Count > 0)
                    {
                        for (int i = 0; i < entrprsT.entrprsAdresList.Count; i++)
                        {
                            EntrprsAdresT entrprsAdresT = entrprsT.entrprsAdresList[i];
                            entrprsAdresT.EntrprsSn = entrprsSn;

                            entrprsDac.InsertEntrprsAdres(entrprsAdresT);
                        }
                    }
                }

                EntrprsUserT entrprsUserT = new EntrprsUserT();
                entrprsUserT.EntrprsSn = entrprsSn;
                entrprsUserT.UserId = entrprsT.UserId;
                entrprsUserT.UserNm = entrprsT.UserNm;
                entrprsUserT.Telno = entrprsT.Telno;
                entrprsUserT.Mbtlnum = entrprsT.Mbtlnum;
                entrprsUserT.EmailAdres = entrprsT.EmailAdres;
                entrprsUserT.MberAt = entrprsT.MberAt;

                //TODO 변경사항
                entrprsUserT.MngrAt = "Y"; //관리자여부
                //entrprsUserT.EntrprsUserSttusCode = "AC019003";   //기업사용자상태코드(승인대기)
                entrprsUserT.EntrprsUserSttusCode = EntrprsAuthCD;  //기업사용자상태코드
                entrprsUserT.RegisterSeCode = "AC007002";   //등록자구분코드( 기업사용자: AC007002)
                entrprsUserT.RegisterId = entrprsT.UserId;
                entrprsUserT.UpdusrSeCode = "AC007002";     //수정자구분코드( 기업사용자: AC007002)
                entrprsUserT.UpdusrId = entrprsT.UserId;

                /**/
                string existYn = new UserBiz().SelectUserExistYn(entrprsT.UserId);
                if (existYn == "Y")
                {
                    // 기업사용자 UPDATE
                    new EntrprsUserDac().UpdateEntrprsUser(entrprsUserT);
                }
                else
                {
                    // 사용자 생성 
                    UserT userT = new UserT();
                    userT.UserId = entrprsUserT.UserId;
                    userT.Password = Security.Security.Encrypt(entrprsT.Password);
                    userT.UserSeCode = "AC007002"; //사용자구분코드( 기업사용자: AC007002)

                    new UserBiz().InsertUser(userT, "N");

                    // 기업사용자 INSERT
                    new EntrprsUserDac().InsertEntrprsUser(entrprsUserT);
                }

                Commit();
            }
            catch (Exception e)
            {
                this.RollBack();
                throw e;
            }
        }

        /// <summary>
        /// 기업 사업자등록번호 존재여부 조회
        /// </summary>
        /// <param name="bizrno"></param>
        /// <returns></returns>
        public string SelectEntrprsBizrnoExistYn(string bizrno)
        {
            return new EntrprsDac().SelectEntrprsBizrnoExistYn(bizrno);
        }


        /// <summary> 
        /// 기업변경이력 목록 
        /// </summary>  
        /// <param name="searchT">기업변경이력 검색조건</param> 
        /// <returns>기업변경이력 목록</returns> 
        public IList<EntrprsChghstT> SelectEntrprsChghstList(long entrprsSn)
        {
            return new EntrprsDac().SelectEntrprsChghstList(entrprsSn);
        }

        /// <summary> 
        /// 기업변경이력 생성 
        /// </summary>  
        /// <param name="entrprsChghstT">기업변경이력 정보</param> 
        /// <returns>생성된 Row의 Key값</returns> 
        public object InsertEntrprsChghst(EntrprsChghstT entrprsChghstT)
        {
            return new EntrprsDac().InsertEntrprsChghst(entrprsChghstT);
        }
    }
}
