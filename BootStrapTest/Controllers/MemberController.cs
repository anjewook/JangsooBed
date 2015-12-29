using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using JS.Boots.BizDac.Common;
using JS.Boots.BizDac.UserMng;
using JS.Boots.Data;
using JS.Boots.Data.Member;
using JS.Boots.Data.SystemMng;
using JS.Boots.Data.UserMng;
using BootStrapTest.Common;

namespace BootStrapTest.Controllers
{
    public class MemberController : BaseController
    {
        #region 로그인/로그아웃

        /// <summary>
        /// 로그인 화면
        /// </summary>
        /// <param name="returnUrl"></param>
        /// <returns></returns>
        [BootstrapAuthorize("00168", false)]
        [HttpGet]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        /// <summary>
        /// 로그인
        /// </summary>
        /// <param name="profileT"></param>
        /// <returns></returns>
        [BootstrapAuthorize("00168", false)]
        [HttpPost]
        public ActionResult Login(ProfileT profileT)
        {
            profileT.UserHostAddress = Request.UserHostAddress; //사용자 IP
            MessageT messageT = BootstrapCertification.SignOn(profileT);

            string passChangeElapseAt = "N"; //비밀번호변경 시간경과 여부
            if (BootstrapCertification.User.PassChangeElapseAt != null)
            {
                passChangeElapseAt = BootstrapCertification.User.PassChangeElapseAt;
            }
            return Json(new { Success = messageT.IsSuccess, Message = messageT.Message, PassChangeElapseAt = passChangeElapseAt });
        }

        /// <summary>
        /// 로그아웃
        /// </summary>
        /// <returns></returns>
        [BootstrapAuthorize("00168", true)]
        [HttpGet]
        public ActionResult LogOut()
        {
            BootstrapCertification.SignOut();
            return Redirect("/");
        }
        #endregion

        #region 회원가입

        /// <summary>
        /// 회원약관 보기 화면
        /// </summary>
        /// <returns></returns>
        [BootstrapAuthorize("00200", false)]
        public ActionResult StplatAgreView()
        {
            return View();
        }


        /// <summary>
        /// 약관동의 화면
        /// </summary>
        /// <returns></returns>
        [BootstrapAuthorize("00169", false)]
        public ActionResult StplatAgre()
        {
            //TODO tokenId 생성 후 리턴

            return View();
        }

        /// <summary>
        /// 약관동의      
        /// </summary>
        /// <returns></returns>
        [BootstrapAuthorize("00169", false)]
        public ActionResult StplatAgreAction()
        {
            //TODO tokenId 확인

            return RedirectToAction("LsftCnfirm");
        }

        /// <summary>
        /// 실명확인 화면
        /// </summary>
        /// <returns></returns>
        /*
        [BootstrapAuthorize("00169", false)]
        public ActionResult LsftCnfirm(MessageT messageT)
        {
            //TODO tokenId 확인
            string message = "";

            string sSiteCode = IpinInfo.IpinSiteCode;       // IPIN 서비스 사이트 코드		(NICE신용평가정보에서 발급한 사이트코드)
            string sSitePw = IpinInfo.IpinSitePw;           // IPIN 서비스 사이트 패스워드	(NICE신용평가정보에서 발급한 사이트패스워드)

            //┌ sReturnURL 변수에 대한 설명  ──────────────────────────────────────────────────
            //   NICE신용평가정보 팝업에서 인증받은 사용자 정보를 암호화하여 귀사로 리턴합니다.
            //   따라서 암호화된 결과 데이타를 리턴받으실 URL 정의해 주세요.

            //   * URL 은 http 부터 입력해 주셔야하며, 외부에서도 접속이 유효한 정보여야 합니다.
            //   * 당사에서 배포해드린 샘플페이지 중, ipin_process.aspx 페이지가 사용자 정보를 리턴받는 예제 페이지입니다.

            //   아래는 URL 예제이며, 귀사의 서비스 도메인과 서버에 업로드 된 샘플페이지 위치에 따라 경로를 설정하시기 바랍니다.
            //   예 - http://www.test.co.kr/ipin_process.aspx, https://www.test.co.kr/ipin_process.aspx, https://test.co.kr/ipin_process.aspx
            //└─────────────────────────────────────────────────────────────────
            //string sReturnURL = "http://....../ipin_process.aspx";
            string sReturnURL = IpinInfo.IpinSiteUrl + "/Member/IpinProcessPopup";

            //┌ sCPRequest 변수에 대한 설명  ──────────────────────────────────────────────────
            //   [CP 요청번호]로 귀사에서 데이타를 임의로 정의하거나, 당사에서 배포된 모듈로 데이타를 생성할 수 있습니다.

            //   CP 요청번호는 인증 완료 후, 암호화된 결과 데이타에 함께 제공되며
            //   데이타 위변조 방지 및 특정 사용자가 요청한 것임을 확인하기 위한 목적으로 이용하실 수 있습니다.

            //   따라서 귀사의 프로세스에 응용하여 이용할 수 있는 데이타이기에, 필수값은 아닙니다.
            //└─────────────────────────────────────────────────────────────────
            string sCPRequest = "";

            // IPIN 서비스 객체 생성
            IPINCLIENTLib.KisinfoClass clsIPINDll = new IPINCLIENTLib.KisinfoClass();

            // 앞서 설명드린 바와같이, CP 요청번호는 배포된 모듈을 통해 아래와 같이 생성할 수 있습니다.
            clsIPINDll.fnRequestSEQ(sSiteCode);
            sCPRequest = clsIPINDll.bstrRandomRequestSEQ;

            // CP 요청번호를 세션에 저장합니다.
            // 현재 예제로 저장한 세션은 ipin_result.aspx 페이지에서 데이타 위변조 방지를 위해 확인하기 위함입니다.
            // 필수사항은 아니며, 보안을 위한 권고사항입니다.
            Session["CPREQUEST"] = sCPRequest;

            // Method 결과값(iRtn)에 따라, 프로세스 진행여부를 파악합니다.
            int iRtn = clsIPINDll.fnRequest(sSiteCode, sSitePw, sCPRequest, sReturnURL);

            string sEncReqData = "";

            // Method 결과값에 따른 처리사항
            if (iRtn == 0)
            {
                // fnRequest 함수 처리시 업체정보를 암호화한 데이터를 추출합니다.
                // 추출된 암호화된 데이타는 당사 팝업 요청시, 귀사로 보내주셔야 합니다.
                // 클라이언트 요청정보 암호화
                sEncReqData = clsIPINDll.bstrRequestCipherData;
            }
            else if (iRtn == -9)
            {
                //입력값 오류
                message = "입력값 오류 : fnRequest 함수 처리시, 필요한 4개의 파라미터값의 정보를 정확하게 입력해 주시기 바랍니다";
            }
            else
            {
                //기타오류
                message = "iRtn 값 확인 후, NICE신용평가정보 전산 담당자에게 문의해 주세요";
            }

            ViewBag.IpinEncReqData = sEncReqData;
            ViewBag.IpinRtn = iRtn;
            ViewBag.IpinMessage = message;

            return View(messageT);
        }
         */

        [BootstrapAuthorize("00169", false)]
        public ActionResult LsftCnfirmAction(string userSeCode, string bizrno, string ipinNo)
        {
            bool isSuccess = true;
            string strMessage = "";
            string entrprsExistYn = "N";    //기업존재여부 

            bizrno = bizrno.Replace("-", "");
            try
            {
                //TODO tokenId 확인

                if (userSeCode == "AC007001")
                {
                    //TODO IPIN 중복확인
                    string existYn = "N";
                    if (existYn == "Y")
                    {
                        throw new Exception("이미 가입한 회원입니다.");
                    }
                }
                else if (userSeCode == "AC007002")
                {
                    //기업회원
                    //----------------------------------------------------------------
                    // 사업자번호 체크하여 기존에 등록된 정보가 있는지 여부를 판별하여 
                    // 기존에 정보가 존대한다면 해당 정보가 회원으로 설정되어 있는지 여부를 판별한다.
                    //----------------------------------------------------------------
                    string existYn = new EntrprsBiz().SelectEntrprsBizrnoExistYn(bizrno);
                    if (existYn == "Y")
                    {
                        //기업정보 검색
                        EntrprsT entrprsT = new EntrprsBiz().SelectEntrprsOfBizrno(bizrno);
                        if (entrprsT != null)
                        {
                            //회원여부 체크
                            if (entrprsT.MberAt == "Y")
                            {
                                throw new Exception("이미 회원가입한 사업자번호 입니다.");
                            }
                            else
                            {
                                entrprsExistYn = "Y";
                            }
                        }
                    }
                }
                else if (userSeCode == "AC007003")
                {
                    //기관회원 사업자번호 체크
                    /*
                    string existYn = new InsttBiz().SelectInsttBizrnoExistYn(bizrno);
                    if (existYn == "Y")
                    {
                        throw new Exception("이미 회원가입한 사업자번호 입니다.");
                    }
                     */
                }

                //TODO session에 토큰값 저장 후 암호화 하여 리턴

            }
            catch (Exception ex)
            {
                isSuccess = false;
                strMessage = ex.Message;
            }

            return Json(new { Success = isSuccess, Message = strMessage, EntrprsExistYn = entrprsExistYn }, JsonRequestBehavior.AllowGet);
        }

        [BootstrapAuthorize("00169", false)]
        public ActionResult IpinProcessPopup()
        {
            // 수신받은 데이터(인증결과)를 메인화면으로 되돌려주고, close를 하는 역활을 합니다.


            // 사용자 정보 및 CP 요청번호를 암호화한 데이타입니다. (ipin_main.aspx 페이지에서 암호화된 데이타와는 다릅니다.)
            string sResponseData = Request["enc_data"];

            // ipin_main.asp 페이지에서 설정한 데이타가 있다면, 아래와 같이 확인가능합니다.
            string sReservedParam1 = Request["param_r1"];
            string sReservedParam2 = Request["param_r2"];
            string sReservedParam3 = Request["param_r3"];

            ViewBag.ResponseData = sResponseData;
            ViewBag.ReservedParam1 = sReservedParam1;
            ViewBag.ReservedParam2 = sReservedParam2;
            ViewBag.ReservedParam3 = sReservedParam3;
            ViewBag.ReturnURL = "/Member/IpinResult";

            return View();
        }

        /*
        [BootstrapAuthorize("00169", false)]
        public ActionResult IpinResult()
        {
            bool isSuccess = false;
            string message = "";

            string sSiteCode    = IpinInfo.IpinSiteCode;		  // IPIN 서비스 사이트 코드		(NICE신용평가정보에서 발급한 사이트코드)
            string sSitePw      = IpinInfo.IpinSitePw;            // IPIN 서비스 사이트 패스워드	(NICE신용평가정보에서 발급한 사이트패스워드)

            string userNm = "";         //성명
            string ipinInnb = "";       //아이핀고유번호

            // 사용자 정보 및 CP 요청번호를 암호화한 데이타입니다.
            string sResponseData = Request["enc_data"];

            // CP 요청번호 : ipin_main.asp 에서 세션 처리한 데이타
            string sCPRequest = (string)Session["CPREQUEST"];

            // IPIN 서비스 객체 생성
            IPINCLIENTLib.KisinfoClass clsIPINDll = new IPINCLIENTLib.KisinfoClass();

            //┌ 복호화 함수 설명  ──────────────────────────────────────────────────────────
            //   Method 결과값(iRtn)에 따라, 프로세스 진행여부를 파악합니다.

            //   fnResponse 함수는 결과 데이타를 복호화 하는 함수이며,
            //   fnResponseExt 함수는 결과 데이타 복호화 및 CP 요청번호 일치여부도 확인하는 함수입니다. (세션에 넣은 sCPRequest 데이타로 검증)

            //   따라서 귀사에서 원하는 함수로 이용하시기 바랍니다.
            //└───────────────────────────────────────────────────────────────────
            //int iRtn = clsIPINDll.fnResponse(sSiteCode, sSitePw, sResponseData);
            int iRtn = clsIPINDll.fnResponseExt(sSiteCode, sSitePw, sResponseData, sCPRequest);

            // Method 결과값에 따른 처리사항
            if (iRtn == 1)
            {
                // 다음과 같이 사용자 정보를 추출할 수 있습니다.
                // 사용자에게 보여주는 정보는, '이름' 데이타만 노출 가능합니다.

                // 사용자 정보를 다른 페이지에서 이용하실 경우에는
                // 보안을 위하여 암호화 데이타(sResponseData)를 통신하여 복호화 후 이용하실것을 권장합니다. (현재 페이지와 같은 처리방식)

                // 만약, 복호화된 정보를 통신해야 하는 경우엔 데이타가 유출되지 않도록 주의해 주세요. (세션처리 권장)
                // form 태그의 hidden 처리는 데이타 유출 위험이 높으므로 권장하지 않습니다.
                string sVNumber = clsIPINDll.bstrVNumber;               // 가상주민번호 (13자리이며, 숫자 또는 문자 포함)
                string sName = clsIPINDll.bstrName;                  // 이름
                string sDupInfo = clsIPINDll.bstrDupInfo;               // 중복가입 확인값 (DI - 64 byte 고유값)
                string sAgeCode = clsIPINDll.bstrAgeCode;               // 연령대 코드 (개발 가이트 참조)
                string sGenderCode = clsIPINDll.bstrGenderCode;            // 성별 코드 (개발 가이트 참조)
                string sBirthDate = clsIPINDll.bstrBirthDate;             // 생년월일 (YYYYMMDD)
                string sNationalInfo = clsIPINDll.bstrNationalInfo;          // 내/외국인 정보 (개발 가이트 참조)
                string sCPRequestNum = clsIPINDll.bstrCPRequestNUM;          // CP 요청번호

                isSuccess = true;
                userNm = sName;
                ipinInnb = sDupInfo;
            }
            else if (iRtn == -9)
            {
                message = "iRtn : " + iRtn + " - 입력값 오류 : fnResponse 또는 fnResponseExt 함수 처리시, 필요한 파라미터값의 정보를 정확하게 입력해 주시기 바랍니다.";
            }
            else if (iRtn == -12)
            {
                message = "iRtn : " + iRtn + " - CP 비밀번호 불일치 : IPIN 서비스 사이트 패스워드를 확인해 주시기 바랍니다.";
            }
            else if (iRtn == -13)
            {
                message = "iRtn : " + iRtn + " - CP 요청번호 불일치 : 세션에 넣은 sCPRequest 데이타를 확인해 주시기 바랍니다.";
            }
            else
            {
                message = "iRtn : " + iRtn + " - iRtn 값 확인 후, NICE신용평가정보 전산 담당자에게 문의해 주세요.";
            }

            if (isSuccess)
            {
                return RedirectToAction("IndvdMemberRegist", new { userNm = userNm, ipinInnb = ipinInnb });
            }
            else
            {
                return RedirectToAction("LsftCnfirm", new { IsSuccess = isSuccess, Message = message });
            }
        }
        */

        /// <summary>
        /// 개인회원 등록 화면
        /// </summary>
        /// <returns></returns>
        [BootstrapAuthorize("00169", false)]
        public ActionResult IndvdMemberRegist(string userNm, string ipinInnb)
        {
            IndvdlUserT indvdlUserT = new IndvdlUserT();
            indvdlUserT.UserNm = userNm;
            indvdlUserT.IpinInnb = ipinInnb;

            //비밀번호힌트[AC024000] 공통코드 조회
            IList<CmmnCodeT> passwordHintSeCodeList = new CommonBiz().SelectCmmnCodeList("AC024000");

            //지역전화번호[AC016000] 공통코드 조회
            IList<CmmnCodeT> telnoList = new CommonBiz().SelectCmmnCodeList("AC016000");

            //핸드폰번호[AC017000] 공통코드 조회
            IList<CmmnCodeT> mbtlnumList = new CommonBiz().SelectCmmnCodeList("AC017000");

            //이메일종류[AC018000] 공통코드 조회
            IList<CmmnCodeT> emailList = new CommonBiz().SelectCmmnCodeList("AC018000");

            JoinMembPageT joinMembPageT = new JoinMembPageT();
            joinMembPageT.PasswordHintSeCodeList = passwordHintSeCodeList;
            joinMembPageT.TelnoList = telnoList;
            joinMembPageT.MbtlnumList = mbtlnumList;
            joinMembPageT.EmailList = emailList;
            joinMembPageT.IndvdlUserT = indvdlUserT;

            return View(joinMembPageT);
        }

        /// <summary>
        /// 개인회원 등록
        /// </summary>
        /// <param name="indvdlUserT"></param>
        /// <returns></returns>
        [BootstrapAuthorize("00169", false)]
        public ActionResult IndvdMemberRegistAction(IndvdlUserT indvdlUserT)
        {
            string userId = indvdlUserT.UserId;
            string userSeCode = "AC007001"; //개인사용자

            indvdlUserT.RegisterId          = userId;
            indvdlUserT.RegisterSeCode      = userSeCode;
            indvdlUserT.UpdusrId            = userId;
            indvdlUserT.UpdusrSeCode        = userSeCode;
            indvdlUserT.IndvdlUserSttusCode = "AC023001"; //개인사용자상태코드 설정(AC023001: 사용)

            bool isSuccess = false;
            string strMessage = "";

            try
            {
                new IndvdlUserBiz().InsertIndvdlUser(indvdlUserT);

                isSuccess = true;

                //회원가입 이메일 발송
                new EmailSendBiz().SendJoinMember(indvdlUserT.UserId, userSeCode, indvdlUserT.EmailAdres);
            }
            catch (Exception ex)
            {
                strMessage = ex.Message;
            }
            return Json(new { Success = isSuccess, Message = strMessage }, JsonRequestBehavior.AllowGet);

        }


        /// <summary>
        /// 기업회원가입 등록 화면
        /// </summary>
        /// <returns></returns>
        [BootstrapAuthorize("00169", false)]
        public ActionResult EntrprsMemberRegist(string companyNm, string bizrno, string existYn)
        {
            EntrprsT entrprsT = null;
            bizrno = bizrno.Replace("-", "");
            if (existYn == "Y")
            {
                entrprsT = new EntrprsBiz().SelectEntrprsOfBizrno(bizrno);
            }
            else
            {
                entrprsT = new EntrprsT();
                entrprsT.EntrprsNm = companyNm;
                entrprsT.Bizrno = bizrno;
            }

            //지역전화번호[AC016000] 공통코드 조회
            IList<CmmnCodeT> telnoList = new CommonBiz().SelectCmmnCodeList("AC016000");

            //핸드폰번호[AC017000] 공통코드 조회
            IList<CmmnCodeT> mbtlnumList = new CommonBiz().SelectCmmnCodeList("AC017000");

            //이메일종류[AC018000] 공통코드 조회
            IList<CmmnCodeT> emailList = new CommonBiz().SelectCmmnCodeList("AC018000");

            //기업주소구분코드[AC002000] 공통코드 조회
            IList<CmmnCodeT> entrprsAdresSeCodeList = new CommonBiz().SelectCmmnCodeList("AC002000");

            JoinMembPageT joinMembPageT = new JoinMembPageT();
            joinMembPageT.TelnoList = telnoList;
            joinMembPageT.MbtlnumList = mbtlnumList;
            joinMembPageT.EmailList = emailList;
            joinMembPageT.EntrprsAdresSeCodeList = entrprsAdresSeCodeList;
            joinMembPageT.EntrprsT = entrprsT;

            return View(joinMembPageT);
        }

        /// <summary>
        /// 기업회원가입 등록
        /// </summary>
        /// <param name="entrprsT"></param>
        /// <returns></returns>
        [BootstrapAuthorize("00169", false)]
        public ActionResult EntrprsMemberRegistAction(EntrprsT entrprsT)
        {
            string userId = entrprsT.UserId;
            string userSeCode = "AC007002"; //기업사용자

            //수정자,수정자구분코드 설정
            entrprsT.RegisterId = userId;
            entrprsT.RegisterSeCode = userSeCode;
            entrprsT.UpdusrId = userId;
            entrprsT.UpdusrSeCode = userSeCode;

            entrprsT.AtptRceptAt = "N";		            //시도접수여부
            entrprsT.MberAt = "Y";                      //회원여부 설정

            // 기업주소(다중값)
            string[] entrprsAdresNm = Request.Form.GetValues("entrprsAdresNm");
            string[] entrprsAdresSeCode = Request.Form.GetValues("entrprsAdresSeCode");
            string[] adresTelno = Request.Form.GetValues("adresTelno");
            string[] adresFxnum = Request.Form.GetValues("adresFxnum");
            string[] adresSeCode = Request.Form.GetValues("adresSeCode");
            string[] zip = Request.Form.GetValues("zip");
            string[] bassAdres = Request.Form.GetValues("bassAdres");
            string[] detailAdres = Request.Form.GetValues("detailAdres");
            string[] dmstcAt = Request.Form.GetValues("dmstcAt");

            if (entrprsAdresNm != null && entrprsAdresNm.Length > 0)
            {
                List<EntrprsAdresT> entrprsAdresList = new List<EntrprsAdresT>();

                for (int i = 0; i < entrprsAdresNm.Length; i++)
                {
                    EntrprsAdresT entrprsAdresT = new EntrprsAdresT();
                    entrprsAdresT.EntrprsAdresNm = entrprsAdresNm[i];
                    entrprsAdresT.EntrprsAdresSeCode = entrprsAdresSeCode[i];
                    entrprsAdresT.AdresTelno = adresTelno[i];
                    entrprsAdresT.AdresFxnum = adresFxnum[i];
                    entrprsAdresT.AdresSeCode = adresSeCode[i];
                    entrprsAdresT.Zip = zip[i];
                    entrprsAdresT.BassAdres = bassAdres[i];
                    entrprsAdresT.DetailAdres = detailAdres[i];

                    if (dmstcAt == null || dmstcAt.Length == 0)
                    {
                        entrprsAdresT.DmstcAt = "Y";
                    }
                    else
                    {
                        entrprsAdresT.DmstcAt = dmstcAt[i];
                    }

                    entrprsAdresList.Add(entrprsAdresT);
                }

                entrprsT.entrprsAdresList = entrprsAdresList;
            }

            bool isSuccess = false;
            string strMessage = "";

            try
            {
                if (entrprsT.EntrprsSn == 0)
                {
                    new EntrprsBiz().JoinEntrprsMember(entrprsT);
                }
                else
                {
                    new EntrprsBiz().UpdateEntrprsMember(entrprsT);
                }

                //회원가입 이메일 발송
                new EmailSendBiz().SendJoinMember(userId, userSeCode, entrprsT.EmailAdres);

                isSuccess = true;
            }
            catch (Exception ex)
            {
                strMessage = ex.Message;
            }
            return Json(new { Success = isSuccess, Message = strMessage }, JsonRequestBehavior.AllowGet);

        }


        /// <summary>
        /// 기관회원가입 등록 화면
        /// </summary>
        /// <returns></returns>
        [BootstrapAuthorize("00169", false)]
        public ActionResult InsttMemberRegist(string companyNm, string bizrno)
        {
            InsttT insttT = new InsttT();
            insttT.InsttNm = companyNm;
            insttT.Bizrno = bizrno;

            //지역전화번호[AC016000] 공통코드 조회
            IList<CmmnCodeT> telnoList = new CommonBiz().SelectCmmnCodeList("AC016000");

            //핸드폰번호[AC017000] 공통코드 조회
            IList<CmmnCodeT> mbtlnumList = new CommonBiz().SelectCmmnCodeList("AC017000");

            //이메일종류[AC018000] 공통코드 조회
            IList<CmmnCodeT> emailList = new CommonBiz().SelectCmmnCodeList("AC018000");

            //기관구분코드[AC025000] 공통코드 조회
            IList<CmmnCodeT> insttSeCodeList = new CommonBiz().SelectCmmnCodeList("AC025000");

            JoinMembPageT joinMembPageT = new JoinMembPageT();
            joinMembPageT.TelnoList = telnoList;
            joinMembPageT.MbtlnumList = mbtlnumList;
            joinMembPageT.EmailList = emailList;
            joinMembPageT.InsttSeCodeList = insttSeCodeList;
            joinMembPageT.InsttT = insttT;

            return View(joinMembPageT);
        }

        /// <summary>
        /// 기관회원가입 등록
        /// </summary>
        /// <param name="insttT"></param>
        /// <returns></returns>
        [BootstrapAuthorize("00169", false)]
        public ActionResult InsttMemberRegistAction(InsttT insttT)
        {

            string userId = insttT.UserId;
            string userSeCode = "AC007003"; //기관사용자

            //등록자, 수정자 설정
            insttT.RegisterId = userId;
            insttT.RegisterSeCode = userSeCode;
            insttT.UpdusrId = userId;
            insttT.UpdusrSeCode = userSeCode;

            bool isSuccess = false;
            string strMessage = "";

            try
            {
                //new InsttBiz().JoinInsttMember(insttT);

                //회원가입 이메일 발송
                new EmailSendBiz().SendJoinMember(userId, userSeCode, insttT.EmailAdres);

                isSuccess = true;
            }
            catch (Exception ex)
            {
                strMessage = ex.Message;
            }
            return Json(new { Success = isSuccess, Message = strMessage }, JsonRequestBehavior.AllowGet);

        }

        /// <summary>
        /// 회원가입완료 화면
        /// </summary>
        /// <returns></returns>
        [BootstrapAuthorize("00169", false)]
        public ActionResult MberSbscrbCompt()
        {
            return View();
        }

        #endregion

        #region ID/PW찾기

        /// <summary>
        /// ID,비밀번호 찾기 화면
        /// </summary>
        /// <returns></returns>
        [BootstrapAuthorize("00171", false)]
        public ActionResult SearchIdPw()
        {
            //비밀번호힌트[AC024000] 공통코드 조회
            IList<CmmnCodeT> passwordHintSeCodeList = new CommonBiz().SelectCmmnCodeList("AC024000");

            ViewBag.PasswordHintSeCodeList = passwordHintSeCodeList;

            return View();
        }

        /// <summary>
        /// ID,비밀번호 찾기결과 팝업 화면
        /// </summary>
        /// <param name="userT"></param>
        /// <returns></returns>
        public ActionResult SearchIdPwPopup(UserT userT)
        {
            userT = new UserBiz().FindIdPw(userT);
            return View(userT);
        }

        #endregion

        #region ID중복확인

        /// <summary>
        /// 아이디 중복확인 팝업 화면
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public ActionResult DuplicateUserIdPopup(string userId, string returnHandler)
        {
            string existYn = new UserBiz().SelectUserExistYn(userId);

            ViewBag.UserId = userId;
            ViewBag.ReturnHandler = returnHandler;
            ViewBag.ExistYn = existYn;

            return View();
        }

        #endregion
	}
}