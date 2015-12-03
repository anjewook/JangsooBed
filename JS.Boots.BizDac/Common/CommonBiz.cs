using ArchFx.ExtensionMethod;
using JS.Boots.Data.SystemMng;

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

using ClosedXML.Excel;
using JS.Boots.Data;
using System.IO;
using System.Text.RegularExpressions;

namespace JS.Boots.BizDac.Common
{
    public class CommonBiz : BaseBiz
    {
        /// <summary>
        /// 공통코드 목록 조회
        /// </summary>
        /// <remark>
        /// 상위기초코드에 해당하는 하위 공통코드 리스트를 가져온다.
        /// </remark>
        /// <param name="upperBsisCode"></param>
        /// <returns></returns>
        public IList<CmmnCodeT> SelectCmmnCodeList(String upperBsisCode)
        {
            return new CommonDac().SelectCmmnCodeList(upperBsisCode);
        }

        /// <summary>
        /// 추가상위코드 공통코드 목록 One
        /// </summary>
        /// <param name="upperCodeOne"></param>
        /// <returns></returns>
        public IList<CmmnCodeT> SelectCmmnCodeListByUpperCodeOne(String upperCodeOne)
        {
            return new CommonDac().SelectCmmnCodeListByUpperCodeOne(upperCodeOne);
        }

        /// <summary>
        /// 추가상위코드 공통코드 목록 Two
        /// </summary>
        /// <param name="upperCodeTwo"></param>
        /// <returns></returns>
        public IList<CmmnCodeT> SelectCmmnCodeListByUpperCodeTwo(String upperCodeTwo)
        {
            return new CommonDac().SelectCmmnCodeListByUpperCodeTwo(upperCodeTwo);
        }

        /// <summary>
        /// 추가상위코드 공통코드 목록 Three
        /// </summary>
        /// <param name="upperCodeThree"></param>
        /// <returns></returns>
        public IList<CmmnCodeT> SelectCmmnCodeListByUpperCodeThree(String upperCodeThree)
        {
            return new CommonDac().SelectCmmnCodeListByUpperCodeThree(upperCodeThree);
        }

        /// <summary>
        /// 공통코드명 매핑 공통코드 조회
        /// </summary>
        /// <param name="upperBsisCode"></param>
        /// <param name="bsisCodeNm"></param>
        /// <returns></returns>
        public string SelectCmmnCodeByCmmnCodeNm(string upperBsisCode, string bsisCodeNm)
        {
            CmmnCodeT cmmnCodeT = new CmmnCodeT();
            cmmnCodeT.UpperBsisCode = upperBsisCode;
            cmmnCodeT.BsisCodeNm = bsisCodeNm;
            return new CommonDac().SelectCmmnCodeByCmmnCodeNm(cmmnCodeT);
        }

        /// <summary>
        /// 이메일 발송
        /// </summary>
        /// <param name="fromMailAddress"></param>
        /// <param name="arrToMailAddress"></param>
        /// <param name="subject"></param>
        /// <param name="body"></param>
        /// <param name="isHtml"></param>
        public void SendMail(string fromMailAddress, string[] arrToMailAddress, string subject, string body, bool isHtml)
        {
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress(fromMailAddress);
            for (int i = 0; i < arrToMailAddress.Length; i++)
            {
                mailMessage.To.Add(new MailAddress(arrToMailAddress[i]));
            }
            mailMessage.Subject = subject;
            mailMessage.Body = body;
            mailMessage.IsBodyHtml = isHtml;

            SmtpClient smtpClient = new SmtpClient(EmailInfo.EmailServerHost, 25);
            try
            {
                smtpClient.Send(mailMessage);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 이메일 템플릿 읽기
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public string ReadEmailTemplete(string filePath)
        {
            string str = "";
            FileInfo file = new FileInfo(filePath);
            if (file.Exists)
            {
                StreamReader streamReader = new StreamReader(filePath, Encoding.UTF8);
                str = streamReader.ReadToEnd();
                streamReader.Close();
            }
            return str;
        }

        /// <summary>
        /// 엑셀파일 읽기
        /// </summary>
        /// <param name="filepath"></param>
        /// <returns></returns>
        public DataTable ReadExcel(string filePath)
        {
            DataTable dtTable = new DataTable();
            try
            {
                XLWorkbook wb = new XLWorkbook(filePath);
                IXLWorksheet worksheet = wb.Worksheets.First();
                IXLRange range = worksheet.RangeUsed();
                int colCount = range.ColumnCount();
                for (int i = 1; i <= range.Rows().Count(); i++)
                {
                    var row = range.Row(i);
                    object[] rowData = new object[colCount];
                    for (int j = 1; j <= colCount; j++)
                    {
                        var cellValue = row.Cell(j).Value;
                        rowData[j - 1] = cellValue;
                        if (i == 1)
                        {
                            dtTable.Columns.Add(cellValue.ToString());
                        }
                    }
                    dtTable.Rows.Add(rowData);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtTable;
        }

        /// <summary>
        /// 엑셀 오류메세지 쓰기
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="errList"></param>
        /// <returns></returns>
        public bool WriteExcelByErrMsg(string filePath, IList<string> errList)
        {
            bool isSuccess = true;
            try
            {
                XLWorkbook wb = new XLWorkbook(filePath);
                IXLWorksheet worksheet = wb.Worksheets.First();
                int colCount = worksheet.RangeUsed().ColumnCount();

                for (int i = 0; i < errList.Count; i++)
                {
                    worksheet.Cell(i + 1, colCount + 1).SetValue(errList[i]);
                }
                wb.Save();
            }
            catch (Exception ex)
            {
                isSuccess = false;
            }
            return isSuccess;
        }

        /// <summary>
        /// 엑셀데이터 validation 검사
        /// </summary>
        /// <param name="data"></param>
        /// <param name="name"></param>
        /// <param name="arrRule"></param>
        /// <returns></returns>
        public MessageT ValidExcelData(string data, string name, string[] arrRule)
        {
            MessageT messageT = new MessageT();
            bool isSuccess = true;
            string errMessage = "";

            if (String.IsNullOrEmpty(data))
            {
                data = "";
            }

            //validate Rule에 의한 검사
            for (int i = 0; i < arrRule.Length; i++)
            {
                string strRule = "";
                string strValue = "";

                string[] arr = arrRule[i].Split(':');
                if (arr.Length > 0)
                {
                    strRule = arr[0];
                    if (arr.Length > 1)
                    {
                        strValue = arr[1];
                    }
                }

                //필수입력 검사
                if (strRule == "required")
                {
                    if (String.IsNullOrEmpty(data))
                    {
                        isSuccess = false;
                        errMessage = "[" + name + " 필수입력오류]";
                        break;
                    }
                }

                //공통코드 매핑 검사
                if (strRule == "mapping")
                {
                    string mappingCode = SelectCmmnCodeByCmmnCodeNm(strValue, data);
                    if (String.IsNullOrEmpty(mappingCode))
                    {
                        isSuccess = false;
                        errMessage = "[" + name + " 매핑오류]";
                        break;
                    }
                    else
                    {
                        messageT.MappingCode = mappingCode;
                    }
                }

                //최대길이 검사
                if (strRule == "maxlength")
                {
                    if (arrRule[i].ArchSplit(':', 1).Length > Convert.ToInt32(strValue))
                    {
                        isSuccess = false;
                        errMessage = "[" + name + " 최대길이오류(" + strValue + ")]";
                        break;
                    }
                }

                //데이터타입 변환 검사
                if (strRule == "datatype")
                {
                    string dataType = strValue;
                    if (dataType == "int")
                    {
                        try
                        {
                            int intData = Convert.ToInt32(data);
                        }
                        catch (Exception ex)
                        {
                            errMessage = "[정수형 변환오류] ";
                        }
                    }
                    else if (dataType == "long")
                    {
                        try
                        {
                            long longData = Convert.ToInt64(data);
                        }
                        catch (Exception ex)
                        {
                            errMessage = "[정수형 변환오류] ";
                        }
                    }
                    else if (dataType == "double")
                    {
                        try
                        {
                            double doubleData = Convert.ToDouble(data);
                        }
                        catch (Exception ex)
                        {
                            errMessage = "[실수형 변환오류] ";
                        }
                    }
                }

            }

            messageT.IsSuccess = isSuccess;
            messageT.Message = errMessage;

            return messageT;
        }

        /// <summary>
        /// 숫자만 있는지 확인
        /// </summary>
        /// <param name="ss"></param>
        /// <returns></returns>
        public bool isNumber(String ss)
        {
            Regex regex = new Regex("[0-9]");

            if (regex.IsMatch(ss))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 사업자등록번호 정합성 확인
        /// </summary>
        /// <param name="ss"></param>
        /// <returns></returns>
        public bool isCompanyNo(String ss)
        {
            if (String.IsNullOrWhiteSpace(ss) || ss.Replace("-", "").Length != 10 || !isNumber(ss.Replace("-", "")))
            {
                return false;
            }
            else
            {
                string menno;

                int no, c1, c2, c3, c4, c5, c6, c7, c8, c9, c10, c9_1, c9_2;

                menno = ss.Replace("-", "");

                c1 = int.Parse(menno.Substring(0, 1));
                c2 = int.Parse(menno.Substring(1, 1));
                c3 = int.Parse(menno.Substring(2, 1));
                c4 = int.Parse(menno.Substring(3, 1));
                c5 = int.Parse(menno.Substring(4, 1));
                c6 = int.Parse(menno.Substring(5, 1));
                c7 = int.Parse(menno.Substring(6, 1));
                c8 = int.Parse(menno.Substring(7, 1));
                c9 = int.Parse(menno.Substring(8, 1));
                c10 = int.Parse(menno.Substring(9, 1));

                c1 = c1 * 1;
                c1 = c1 % 10;

                c2 = c2 * 3;
                c2 = c2 % 10;

                c3 = c3 * 7;
                c3 = c3 % 10;

                c4 = c4 * 1;
                c4 = c4 % 10;

                c5 = c5 * 3;
                c5 = c5 % 10;

                c6 = c6 * 7;
                c6 = c6 % 10;

                c7 = c7 * 1;
                c7 = c7 % 10;

                c8 = c8 * 3;
                c8 = c8 % 10;

                c9 = c9 * 5;
                c9_2 = c9 % 10;
                c9_1 = c9 - c9_2;
                c9_1 = c9_1 / 10;

                no = c1 + c2 + c3 + c4 + c5 + c6 + c7 + c8 + c9_1 + c9_2;

                no = (no % 10);

                no = (10 - no) % 10;

                if (no != c10)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }


    }
}
