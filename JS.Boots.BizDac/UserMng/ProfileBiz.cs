using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using JS.Boots.Data;
using JS.Boots.Data.UserMng;

namespace JS.Boots.BizDac.UserMng
{
    public class ProfileBiz : BaseBiz
    {
        /// <summary>
        /// 로그인 체크
        /// </summary>
        /// <param name="profileT"></param>
        /// <returns></returns>
        public ProfileT LoginCheck(ProfileT profileT)
        {
            ProfileT resultProfileT = null;

            //사용자구분별 사용자정보 조회
            profileT.UserTypeCode = profileT.UserSeCode;
            if (profileT.UserType == Security.UserType.JsUser)
            {
                //Js담당자인 경우
                resultProfileT = new ProfileDac().SelectJsUser(profileT);

            }
            else
            {
                //Js담당자가 아닌 경우
                resultProfileT = new ProfileDac().SelectUser(profileT);
            }

            if (resultProfileT != null)
            {
                //비밀번호 비교 (암호화 후 비교)
                if (resultProfileT.Password == Security.Security.Encrypt(profileT.Password))
                {
                    resultProfileT.UserId = profileT.UserId;
                    resultProfileT.UserSeCode = profileT.UserSeCode;
                    resultProfileT.UserTypeCode = profileT.UserSeCode;
                    resultProfileT.UserHostAddress = profileT.UserHostAddress;

                    // 회원 구분별 추가정보 조회
                    if (resultProfileT.UserType == Security.UserType.JsUser)
                    {
                        EmplT emplT = new EmplBiz().SelectEmpl(resultProfileT.EmplCode);

                        resultProfileT.UserNm = emplT.UserNm;               //사용자명
                        resultProfileT.TelNumber = emplT.Telno;             //전화번호
                        resultProfileT.MobileNumber = emplT.Mbtlnum;        //핸드폰
                        resultProfileT.Email = emplT.EmailAdres;            //이메일
                        resultProfileT.DuzonDeptCode = emplT.DuzonDeptCode; //더존부서코드
                        resultProfileT.DuzonEmplCode = emplT.DuzonEmplCode; //더존사원코드

                        //Js사용자 권한그룹 목록 조회
                        resultProfileT.AuthorGroupList = new ProfileBiz().SelectJsUserAuthGroupList(resultProfileT.EmplCode);

                        //권한그룹 설정
                        resultProfileT.IsK0001 = resultProfileT.AuthorGroupList.Contains("K0001"); //접수담당자 여부
                        resultProfileT.IsK0002 = resultProfileT.AuthorGroupList.Contains("K0002"); //회계담당자 여부
                        resultProfileT.IsK0003 = resultProfileT.AuthorGroupList.Contains("K0003"); //접수승인자 여부
                        resultProfileT.IsK0004 = resultProfileT.AuthorGroupList.Contains("K0004"); //검정담당자 여부
                        resultProfileT.IsK0005 = resultProfileT.AuthorGroupList.Contains("K0005"); //검정책임자 여부
                        resultProfileT.IsK0006 = resultProfileT.AuthorGroupList.Contains("K0006"); //형식승인담당자 여부
                        resultProfileT.IsK0007 = resultProfileT.AuthorGroupList.Contains("K0007"); //형식승인책임자 여부
                        resultProfileT.IsK0008 = resultProfileT.AuthorGroupList.Contains("K0008"); //총괄책임자 여부
                        resultProfileT.IsK0009 = resultProfileT.AuthorGroupList.Contains("K0009"); //시스템관리자 여부

                    }
                    else if (resultProfileT.UserType == Security.UserType.NormalUser)
                    {
                        //개인사용자 상세 조회
                        IndvdlUserT indvdlUserT = new IndvdlUserDac().SelectIndvdlUser(resultProfileT.UserId);
                        if (indvdlUserT != null)
                        {
                            //개인사용자 상태 체크
                            if (indvdlUserT.IndvdlUserSttusCode != "AC023001")
                            {
                                throw new Exception("개인사용자 상태가 미사용 상태입니다. 시스템관리자에게 문의하세요");
                            }
                            resultProfileT.UserNm = indvdlUserT.UserNm;               //사용자명
                            resultProfileT.TelNumber = indvdlUserT.Telno;             //전화번호
                            resultProfileT.MobileNumber = indvdlUserT.Mbtlnum;        //핸드폰
                            resultProfileT.Email = indvdlUserT.EmailAdres;            //이메일
                            resultProfileT.SmsRecptnAt = indvdlUserT.SmsRecptnAt;     //sms수신여부
                            resultProfileT.EmailRecptnAt = indvdlUserT.EmailRecptnAt; //이메일수신여부

                            //권한그룹 설정
                            IList<string> AuthorGroupList = new List<string>();
                            resultProfileT.IsA0001 = true; //개인회원 여부
                            AuthorGroupList.Add("A0001");
                            resultProfileT.AuthorGroupList = AuthorGroupList;
                        }
                        else
                        {
                            throw new Exception("개인사용자 정보 조회 오류");
                        }

                    }
                    else if (resultProfileT.UserType == Security.UserType.EnterpriseUser)
                    {
                        //기업사용자 상세 조회
                        EntrprsUserT entrprsUserT = new EntrprsUserDac().SelectEntrprsUser(resultProfileT.UserId);
                        if (entrprsUserT != null)
                        {
                            //기업사용자 상태 체크
                            if (entrprsUserT.EntrprsUserSttusCode == "AC019003")
                            {
                                throw new Exception("기업사용자 상태가 승인대기 상태입니다. 시스템관리자 또는 기업사용 담당자에게 문의하세요");
                            }

                            resultProfileT.UserNm = entrprsUserT.UserNm;          //사용자명
                            resultProfileT.TelNumber = entrprsUserT.Telno;        //전화번호
                            resultProfileT.MobileNumber = entrprsUserT.Mbtlnum;   //핸드폰
                            resultProfileT.Email = entrprsUserT.EmailAdres;       //이메일
                            resultProfileT.MngrAt = entrprsUserT.MngrAt;          //관리자여부

                            //기업정보 상세 조회
                            EntrprsT searchEntrprsT = new EntrprsT();
                            searchEntrprsT.EntrprsSn = entrprsUserT.EntrprsSn;
                            EntrprsT entrprsT = new EntrprsDac().SelectEntrprs(searchEntrprsT);
                            if (entrprsT != null)
                            {
                                resultProfileT.EntrprsSn = entrprsT.EntrprsSn;                            //기업일련번호
                                resultProfileT.Bizrno = entrprsT.Bizrno;                                  //사업자등록번호
                                resultProfileT.EntrprsNm = entrprsT.EntrprsNm;                            //기업명
                                resultProfileT.MfcrtrAt = entrprsT.MfcrtrAt;                              //제조업여부
                                resultProfileT.IrtbAt = entrprsT.IrtbAt;                                  //수입업여부
                                resultProfileT.RepairIndutyAt = entrprsT.RepairIndutyAt;                  //수리업여부
                                resultProfileT.MesurProofIndutyAt = entrprsT.MesurProofIndutyAt;          //계량증명업여부
                                resultProfileT.MrnrEmplyrAt = entrprsT.MrnrEmplyrAt;                      //계량기사용자여부
                                resultProfileT.EnterpriseSectionName = entrprsT.EnterpriseSectionName;    //업체구분명
                                resultProfileT.MnfcturRegistNoNm = entrprsT.MnfcturRegistNoNm;            //제조등록번호명
                                resultProfileT.MnfcturRegistDe = entrprsT.MnfcturRegistDe;                //제조등록일자
                                resultProfileT.MesurProofRegistNoNm = entrprsT.MesurProofRegistNoNm;      //계량증명업등록번호명
                                resultProfileT.MesurProofRegistDe = entrprsT.MesurProofRegistDe;          //계량증명업등록일자
                                resultProfileT.RprsntvNm = entrprsT.RprsntvNm;                            //대표자명
                                resultProfileT.ReprsntTelno = entrprsT.ReprsntTelno;                      //대표전화번호
                                //profileT.ReprsntFxnum = entrprsT.ReprsntFxnum; //대표팩스번호

                                //권한그룹 설정
                                IList<string> AuthorGroupList = new List<string>();
                                if (entrprsT.MfcrtrAt == "Y" || entrprsT.IrtbAt == "Y" || entrprsT.RepairIndutyAt == "Y" || entrprsT.MesurProofIndutyAt == "Y")
                                {
                                    resultProfileT.IsE0001 = true;	//등록업체 여부
                                    AuthorGroupList.Add("E0001");
                                }
                                if (entrprsT.MrnrEmplyrAt == "Y")
                                {
                                    resultProfileT.IsE0002 = true;	//계량기사용자 여부
                                    AuthorGroupList.Add("E0002");
                                }
                                resultProfileT.AuthorGroupList = AuthorGroupList;

                                //기업 사업장주소 목록 조회
                                EntrprsAdresT entrprsAdresT = new EntrprsAdresT();
                                entrprsAdresT.EntrprsSn = entrprsT.EntrprsSn;
                                entrprsAdresT.EntrprsAdresSeCode = "AC002001"; //사업장주소
                                IList<EntrprsAdresT> entrprsBplcAdresList = new EntrprsDac().SelectEntrprsAdresList(entrprsAdresT);
                                if (entrprsBplcAdresList != null && entrprsBplcAdresList.Count > 0)
                                {
                                    resultProfileT.EntrprsBplcAdresList = entrprsBplcAdresList; //기업 사업장주소 목록
                                }
                                else
                                {
                                    resultProfileT.EntrprsBplcAdresList = new List<EntrprsAdresT>();
                                }

                                //기업 공장주소 목록 조회
                                entrprsAdresT.EntrprsAdresSeCode = "AC002002"; //공장주소
                                IList<EntrprsAdresT> entrprsFctryAdresList = new EntrprsDac().SelectEntrprsAdresList(entrprsAdresT);
                                if (entrprsFctryAdresList != null && entrprsBplcAdresList.Count > 0)
                                {
                                    resultProfileT.EntrprsFctryAdresList = entrprsFctryAdresList; //기업 공장주소 목록
                                }
                                else
                                {
                                    resultProfileT.EntrprsFctryAdresList = new List<EntrprsAdresT>();
                                }
                            }
                            else
                            {
                                throw new Exception("기업정보 조회 오류");
                            }
                        }
                        else
                        {
                            throw new Exception("기업사용자 조회 오류");
                        }
                    }
                    /*
                    else if (resultProfileT.UserType == Security.UserType.SiGunGuUser)
                    {
                        //시군구사용자 상세 조회
                        SignguUserT signguUserT = new SignguUserDac().SelectSignguUser(resultProfileT.UserId);
                        if (signguUserT != null)
                        {
                            //시군구사용자 상태 체크
                            if (signguUserT.SignguUserSttusCode != "AC022001")
                            {
                                throw new Exception("계량공무원 상태가 미사용 상태입니다. 시스템관리자에게 문의하세요");
                            }
                            resultProfileT.UserNm = signguUserT.UserNm;               //사용자명
                            resultProfileT.TelNumber = signguUserT.Telno;             //전화번호
                            resultProfileT.MobileNumber = signguUserT.Mbtlnum;        //핸드폰
                            resultProfileT.Email = signguUserT.EmailAdres;            //이메일
                            resultProfileT.AtptSeCode = signguUserT.AtptSeCode;       //시도구분코드
                            resultProfileT.GuGunSeCode = signguUserT.GuGunSeCode;     //구군구분코드
                            resultProfileT.AdmnstmachNm = signguUserT.AdmnstmachNm;   //행정기관명

                            //권한그룹 설정
                            IList<string> AuthorGroupList = new List<string>();
                            resultProfileT.IsS0001 = true; //계량공무원 여부
                            AuthorGroupList.Add("S0001");
                            resultProfileT.AuthorGroupList = AuthorGroupList;
                        }
                        else
                        {
                            throw new Exception("시군구사용자 조회 오류");
                        }
                    }
                     */
                    else if (resultProfileT.UserType == Security.UserType.PblOfficialUser)
                    {
                        //권한그룹 설정
                        IList<string> AuthorGroupList = new List<string>();
                        resultProfileT.IsR0001 = true; //중앙공무원 여부
                        AuthorGroupList.Add("R0001");
                        resultProfileT.AuthorGroupList = AuthorGroupList;
                    }
                }
                else
                {
                    throw new Exception("비밀번호를 확인하세요!");
                }
            }
            else
            {
                throw new Exception("존재하지 않는 사용자ID입니다. 사용자 정보를 확인하세요!");
            }
            return resultProfileT;
        }

        /// <summary>
        /// 사용자의 메뉴별 권한 목록 조회
        /// </summary>
        /// <param name="userMenuAuthSearchT"></param>
        /// <returns></returns>
        public IList<string> SelectUserMenuAuthList(UserMenuAuthSearchT userMenuAuthSearchT)
        {
            IList<string> authList = null;
            if (userMenuAuthSearchT.UserSeCode == "AC007005")
            {
                //Js사용자 메뉴별 권한 목록 조회
                authList = new ProfileDac().SelectJsUserMenuAuthList(userMenuAuthSearchT);
            }
            else
            {
                //사용자 메뉴별 권한 목록 조회
                authList = new ProfileDac().SelectUserMenuAuthList(userMenuAuthSearchT);
            }
            return authList;
        }

        /// <summary>
        /// Js사용자 권한그룹 목록 조회
        /// </summary>
        /// <param name="emplCode"></param>
        /// <returns></returns>
        public IList<string> SelectJsUserAuthGroupList(string emplCode)
        {
            return new ProfileDac().SelectJsUserAuthGroupList(emplCode);
        }

        /// <summary>
        /// 로그인 사용자 정보 가져오기(회원정보 수정 후 session값 reset에 이용)
        /// </summary>
        /// <param name="profileT"></param>
        /// <returns></returns>
        public ProfileT getUserInfo(ProfileT profileT)
        {
            ProfileT resultProfileT = null;

            //사용자구분별 사용자정보 조회
            profileT.UserTypeCode = profileT.UserSeCode;
            if (profileT.UserType == Security.UserType.JsUser)
            {
                //Js담당자인 경우
                resultProfileT = new ProfileDac().SelectJsUser(profileT);

            }
            else
            {
                //Js담당자가 아닌 경우
                resultProfileT = new ProfileDac().SelectUser(profileT);
            }

            if (resultProfileT != null)
            {
                resultProfileT.UserId = profileT.UserId;
                resultProfileT.UserSeCode = profileT.UserSeCode;
                resultProfileT.UserTypeCode = profileT.UserSeCode;
                resultProfileT.UserHostAddress = profileT.UserHostAddress;

                // 회원 구분별 추가정보 조회
                if (resultProfileT.UserType == Security.UserType.JsUser)
                {
                    EmplT emplT = new EmplBiz().SelectEmpl(resultProfileT.EmplCode);
                    resultProfileT.UserNm = emplT.UserNm;               //사용자명
                    resultProfileT.TelNumber = emplT.Telno;             //전화번호
                    resultProfileT.MobileNumber = emplT.Mbtlnum;        //핸드폰
                    resultProfileT.Email = emplT.EmailAdres;            //이메일
                    resultProfileT.DuzonDeptCode = emplT.DuzonDeptCode; //더존부서코드
                    resultProfileT.DuzonEmplCode = emplT.DuzonEmplCode; //더존사원코드

                    //Js사용자 권한그룹 목록 조회
                    resultProfileT.AuthorGroupList = new ProfileBiz().SelectJsUserAuthGroupList(resultProfileT.EmplCode);

                    //권한그룹 설정
                    resultProfileT.IsK0001 = resultProfileT.AuthorGroupList.Contains("K0001"); //접수담당자 여부
                    resultProfileT.IsK0002 = resultProfileT.AuthorGroupList.Contains("K0002"); //회계담당자 여부
                    resultProfileT.IsK0003 = resultProfileT.AuthorGroupList.Contains("K0003"); //접수승인자 여부
                    resultProfileT.IsK0004 = resultProfileT.AuthorGroupList.Contains("K0004"); //검정담당자 여부
                    resultProfileT.IsK0005 = resultProfileT.AuthorGroupList.Contains("K0005"); //검정책임자 여부
                    resultProfileT.IsK0006 = resultProfileT.AuthorGroupList.Contains("K0006"); //형식승인담당자 여부
                    resultProfileT.IsK0007 = resultProfileT.AuthorGroupList.Contains("K0007"); //형식승인책임자 여부
                    resultProfileT.IsK0008 = resultProfileT.AuthorGroupList.Contains("K0008"); //총괄책임자 여부
                    resultProfileT.IsK0009 = resultProfileT.AuthorGroupList.Contains("K0009"); //시스템관리자 여부

                }
                else if (resultProfileT.UserType == Security.UserType.NormalUser)
                {
                    //개인사용자 상세 조회
                    IndvdlUserT indvdlUserT = new IndvdlUserDac().SelectIndvdlUser(resultProfileT.UserId);
                    if (indvdlUserT != null)
                    {
                        resultProfileT.UserNm = indvdlUserT.UserNm;               //사용자명
                        resultProfileT.TelNumber = indvdlUserT.Telno;             //전화번호
                        resultProfileT.MobileNumber = indvdlUserT.Mbtlnum;        //핸드폰
                        resultProfileT.Email = indvdlUserT.EmailAdres;            //이메일
                        resultProfileT.SmsRecptnAt = indvdlUserT.SmsRecptnAt;     //sms수신여부
                        resultProfileT.EmailRecptnAt = indvdlUserT.EmailRecptnAt; //이메일수신여부

                        //권한그룹 설정
                        IList<string> AuthorGroupList = new List<string>();
                        resultProfileT.IsA0001 = true; //개인회원 여부
                        AuthorGroupList.Add("A0001");
                        resultProfileT.AuthorGroupList = AuthorGroupList;
                    }
                    else
                    {
                        throw new Exception("개인사용자 정보 조회 오류");
                    }

                }
                else if (resultProfileT.UserType == Security.UserType.EnterpriseUser)
                {
                    //기업사용자 상세 조회
                    EntrprsUserT entrprsUserT = new EntrprsUserDac().SelectEntrprsUser(resultProfileT.UserId);
                    if (entrprsUserT != null)
                    {
                        resultProfileT.UserNm = entrprsUserT.UserNm;          //사용자명
                        resultProfileT.TelNumber = entrprsUserT.Telno;        //전화번호
                        resultProfileT.MobileNumber = entrprsUserT.Mbtlnum;   //핸드폰
                        resultProfileT.Email = entrprsUserT.EmailAdres;       //이메일
                        resultProfileT.MngrAt = entrprsUserT.MngrAt;          //관리자여부

                        //기업정보 상세 조회
                        EntrprsT searchEntrprsT = new EntrprsT();
                        searchEntrprsT.EntrprsSn = entrprsUserT.EntrprsSn;
                        /*
                         */
                        EntrprsT entrprsT = new EntrprsDac().SelectEntrprs(searchEntrprsT);
                        if (entrprsT != null)
                        {
                            resultProfileT.EntrprsSn = entrprsT.EntrprsSn;                            //기업일련번호
                            resultProfileT.Bizrno = entrprsT.Bizrno;                                  //사업자등록번호
                            resultProfileT.EntrprsNm = entrprsT.EntrprsNm;                            //기업명
                            resultProfileT.MfcrtrAt = entrprsT.MfcrtrAt;                              //제조업여부
                            resultProfileT.IrtbAt = entrprsT.IrtbAt;                                  //수입업여부
                            resultProfileT.RepairIndutyAt = entrprsT.RepairIndutyAt;                  //수리업여부
                            resultProfileT.MesurProofIndutyAt = entrprsT.MesurProofIndutyAt;          //계량증명업여부
                            resultProfileT.MrnrEmplyrAt = entrprsT.MrnrEmplyrAt;                      //계량기사용자여부
                            resultProfileT.EnterpriseSectionName = entrprsT.EnterpriseSectionName;    //업체구분명
                            resultProfileT.MnfcturRegistNoNm = entrprsT.MnfcturRegistNoNm;            //제조등록번호명
                            resultProfileT.MnfcturRegistDe = entrprsT.MnfcturRegistDe;                //제조등록일자
                            resultProfileT.MesurProofRegistNoNm = entrprsT.MesurProofRegistNoNm;      //계량증명업등록번호명
                            resultProfileT.MesurProofRegistDe = entrprsT.MesurProofRegistDe;          //계량증명업등록일자
                            resultProfileT.RprsntvNm = entrprsT.RprsntvNm;                            //대표자명
                            resultProfileT.ReprsntTelno = entrprsT.ReprsntTelno;                      //대표전화번호
                            //profileT.ReprsntFxnum = entrprsT.ReprsntFxnum; //대표팩스번호

                            //권한그룹 설정
                            IList<string> AuthorGroupList = new List<string>();
                            if (entrprsT.MfcrtrAt == "Y" || entrprsT.IrtbAt == "Y" || entrprsT.RepairIndutyAt == "Y" || entrprsT.MesurProofIndutyAt == "Y")
                            {
                                resultProfileT.IsE0001 = true;	//등록업체 여부
                                AuthorGroupList.Add("E0001");
                            }
                            if (entrprsT.MrnrEmplyrAt == "Y")
                            {
                                resultProfileT.IsE0002 = true;	//계량기사용자 여부
                                AuthorGroupList.Add("E0002");
                            }
                            resultProfileT.AuthorGroupList = AuthorGroupList;

                            //기업 사업장주소 목록 조회
                            EntrprsAdresT entrprsAdresT = new EntrprsAdresT();
                            entrprsAdresT.EntrprsSn = entrprsT.EntrprsSn;
                            entrprsAdresT.EntrprsAdresSeCode = "AC002001"; //사업장주소
                            IList<EntrprsAdresT> entrprsBplcAdresList = new EntrprsDac().SelectEntrprsAdresList(entrprsAdresT);
                            if (entrprsBplcAdresList != null && entrprsBplcAdresList.Count > 0)
                            {
                                resultProfileT.EntrprsBplcAdresList = entrprsBplcAdresList; //기업 사업장주소 목록
                            }
                            else
                            {
                                resultProfileT.EntrprsBplcAdresList = new List<EntrprsAdresT>();
                            }

                            //기업 공장주소 목록 조회
                            entrprsAdresT.EntrprsAdresSeCode = "AC002002"; //공장주소
                            IList<EntrprsAdresT> entrprsFctryAdresList = new EntrprsDac().SelectEntrprsAdresList(entrprsAdresT);
                            if (entrprsFctryAdresList != null && entrprsBplcAdresList.Count > 0)
                            {
                                resultProfileT.EntrprsFctryAdresList = entrprsFctryAdresList; //기업 공장주소 목록
                            }
                            else
                            {
                                resultProfileT.EntrprsFctryAdresList = new List<EntrprsAdresT>();
                            }
                        }
                        else
                        {
                            throw new Exception("기업정보 조회 오류");
                        }
                    }
                    else
                    {
                        throw new Exception("기업사용자 조회 오류");
                    }
                }
                else if (resultProfileT.UserType == Security.UserType.PblOfficialUser)
                {
                    //권한그룹 설정
                    IList<string> AuthorGroupList = new List<string>();
                    resultProfileT.IsR0001 = true; //중앙공무원 여부
                    AuthorGroupList.Add("R0001");
                    resultProfileT.AuthorGroupList = AuthorGroupList;
                }

            }
            else
            {
                throw new Exception("존재하지 않는 사용자ID입니다. 사용자 정보를 확인하세요!");
            }
            return resultProfileT;
        }
    }
}
