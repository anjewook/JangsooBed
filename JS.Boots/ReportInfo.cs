using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections;
using System.IO;

using com.clipsoft.rextoolkit;
using com.clipsoft.rextoolkit.enumtype;
using com.clipsoft.rextoolkit.oof;
using com.clipsoft.rextoolkit.oof.enumtype;
using com.clipsoft.rextoolkit.parameter;
using com.clipsoft.rextoolkit.parameter.enumtype;
using File = com.clipsoft.rextoolkit.oof.File;

namespace JS.Boots
{
    /// <summary>
    /// 리포트처리 공통클래스
    /// </summary>
    public class ReportInfo
    {
        public class PdfMakeResult
        {
            public bool IsResult = false;
            public string makePdfFileFullPath = "";
            public string makePdfFilePath = "";
            public string makePdfFileName = "";
            public string ErrorMsg = "";
        }


        public static string ReportServerConnPath
        {
            get
            {
                return System.Configuration.ConfigurationManager.AppSettings["ReportServerConnPath"];
            }
        }

        public static string ReportServerReportPath
        {
            get
            {
                return System.Configuration.ConfigurationManager.AppSettings["ReportServerReportPath"];
            }
        }

        public static string RexEspUrl
        {
            get
            {
                return System.Configuration.ConfigurationManager.AppSettings["RexEspUrl"];
            }
        }

        public static string ReportPdfFilePathTemp
        {
            get
            {
                return System.Configuration.ConfigurationManager.AppSettings["ReportPdfFilePathTemp"];
            }
        }

        //public static string ReportPdfFilePath
        //{
        //    get
        //    {
        //        return System.Configuration.ConfigurationManager.AppSettings["ReportPdfFilePath"];
        //    }
        //}


        /// <summary>
        /// 리포트 생성용 타이틀문구
        /// </summary>
        public string ReportTitle { get; set; }

        /// <summary>
        /// 서버에 있는 리포트 파일명 (확장자제외)
        /// </summary>
        public string ReportFile { get; set; }

        /// <summary>
        /// 리포트 문서에 전달할 파라미터들
        /// </summary>
        public Dictionary<String, String> Parameters { get; set; }

        /// <summary>
        /// 로컬로 결과물을 옮겨올 경우의 로컬 경로
        /// </summary>
        public string OutputPath { get; set; }

        /// <summary>
        /// 로컬로 결과물을 옮겨올 경우의 로컬 파일명 (확장자포함)
        /// </summary>
        public string OutputFileName { get; set; }

        /// <summary>
        /// 리포트 생성 및 로컬 저장
        /// </summary>
        /// <param name="reportInfo">리포트 객체</param>
        /// <returns></returns>
        public static PdfMakeResult MakeReport(ReportInfo reportInfo)
        {
            PdfMakeResult pdfMakeResult = new PdfMakeResult();
            pdfMakeResult.IsResult = false;

            DateTime nowDateTime = DateTime.Now;
            string yyyyMM = nowDateTime.ToString("yyyyMM");

            string pdfFolderPathTemp = ReportPdfFilePathTemp + "AC003002/" + yyyyMM + "/";
            string pdfFolderPath = AttachFile.AttachFilePath + "AC003002/" + yyyyMM + "/";

            //// 폴더에 존재하지 않으면 폴더생성
            //if (System.IO.Directory.Exists(pdfFolderPath) == false)
            //{
            //    System.IO.Directory.CreateDirectory(pdfFolderPath);
            //}

            String randomStrig = new Random((int)DateTime.Now.Ticks & 0x0000FFFF).Next(10000000, 99999999).ToString();

            // 파일명 : 년월일-시분초-랜덤.확장자
            // 예 : 20151122-18214632-75068418.pdf
            string pdfFileName = nowDateTime.ToString("yyyyMMdd-HHmmssff-") + randomStrig + ".pdf";


            string connectPath  = ReportServerConnPath;         // "http://192.168.2.101:8085/rexservice.aspx";
            string reportPath   = ReportServerReportPath;       // "http://192.168.2.101:8085/rebfiles/KTCmeter/{0}.reb";
            string reportServer = RexEspUrl;                    // "http://192.168.2.101:8088/RexESP/RexSOPServer";

            try
            {
                #region Report 생성
                var toolkit = RexToolkitModule.createRexSOPToolkit();

                //OOF 객체 생성
                var oof = new Oof();

                oof.setTitle(reportInfo.ReportTitle);
                oof.setEnableLog(true);
                oof.setEnableThread(true);

                //CSV 설정
                var csvContent = (CsvContent)ContentFactory.createContent(com.clipsoft.rextoolkit.oof.enumtype.ContentType.CSV);

                csvContent.setRowDelim("|#|");
                csvContent.setColDelim("|*|");
                csvContent.setDataSetDelim("|@|");
                csvContent.setEncoding(EncodingType.UTF_8);

                //컨넥션 설정
                var httpConnection = (HttpConnection)ConnectionFactory.createConnection(ConnectionType.HTTP);

                httpConnection.setPath(connectPath);
                httpConnection.setMethod("post");
                httpConnection.setNameSpace("*");

                httpConnection.addHttpParam(new HttpParam("designtype", "run"));
                httpConnection.addHttpParam(new HttpParam("datatype", "CSV"));
                httpConnection.addHttpParam(new HttpParam("sql", OofSpecialField.AUTO.getValue()));
                httpConnection.addHttpParam(new HttpParam("split", ""));
                httpConnection.addHttpParam(new HttpParam("userservice", "Ora2"));
                httpConnection.addHttpParam(new HttpParam("image", ""));
                httpConnection.addHttpParam(new HttpParam("rex_param_sql", ""));
                httpConnection.addHttpParam(new HttpParam("presql", "{%dataset.ado.pre.sql%}"));
                httpConnection.addHttpParam(new HttpParam("postsql", "{%dataset.ado.pre.sql%}"));

                httpConnection.addContent(csvContent);


                //리포트 파일 설정
                var file = new File();

                file.setType(FileType.REB);
                file.setPath(String.Format(reportPath, reportInfo.ReportFile.Replace(".reb", "")));
                file.setShowParameterDialog(true);

                //파라미터
                foreach (var p in reportInfo.Parameters)
                {
                    oof.addField(new Field(p.Key, p.Value));
                }
                //oof.addField(new Field("SN", "1"));

                //OOF객체에 리포트 파일,컨넥션 적용
                oof.addFile(file);
                oof.addConnection(httpConnection);

                //변환서버 설정
                toolkit.setRexEspUrl(reportServer);
                toolkit.setSubmitEncodingType(SubmitEncodingType.EUC_KR);

                //var pdfExportParameter = ParameterFactory.createPdfExportParameter();
                //pdfExportParameter.setOof(oof.createOof());
                //pdfExportParameter.setOofProcessType(OofProcessType.PATH);
                //pdfExportParameter.setFilePath("D:\\_NeoPlus\\");
                //pdfExportParameter.setFileName("sample.pdf");

                //var result = toolkit.export(pdfExportParameter);

                var pdfExportParameter = ParameterFactory.createPdfExportParameter();

                pdfExportParameter.setOof(oof.createOof());
                pdfExportParameter.setOofProcessType(OofProcessType.PATH);
                pdfExportParameter.setFilePath(pdfFolderPathTemp/*"d:/temp/Report/export/"*/);
                pdfExportParameter.setFileName(pdfFileName/*"sample22.pdf"*/);
                pdfExportParameter.setDocumentTitle(reportInfo.ReportTitle);

                var result = toolkit.export(pdfExportParameter);

                if (result.isResult() == false)
                {
                    pdfMakeResult.ErrorMsg = result.getMessage();
                }

                if (String.IsNullOrEmpty(reportInfo.OutputFileName) ||
                    String.IsNullOrEmpty(reportInfo.OutputPath))
                {
                    pdfMakeResult.ErrorMsg = String.Empty;
                }

                // 로컬가져오기
                Hashtable infoMap = result.getInfoMap();

                Stream stream = toolkit.fileStream(
                    (String)infoMap["filePath"]
                    , (String)infoMap["fileName"]
                    , ExportType.PDF.getValue()
                    , false
                    );

                var rexToolkitUtility = new RexToolkitUtility();

                rexToolkitUtility.fileSave(stream, reportInfo.OutputPath, reportInfo.OutputFileName);

                #endregion

                if (System.IO.Directory.Exists(pdfFolderPath) == false)
                {
                    System.IO.Directory.CreateDirectory(pdfFolderPath);
                }

                using (var fileStream = System.IO.File.Create(pdfFolderPath + pdfFileName))
                {
                    stream.CopyTo(fileStream);
                }

                //System.IO.File.Move(pdfFolderPathTemp + pdfFileName,pdfFolderPath + pdfFileName );

                pdfMakeResult.IsResult              = result.isResult();//저장 후 리턴값
                pdfMakeResult.makePdfFileFullPath   = pdfFolderPath + pdfFileName;
                pdfMakeResult.makePdfFilePath       = "/" + yyyyMM + "/" + pdfFileName;
                pdfMakeResult.makePdfFileName       = pdfFileName;
            }
            catch (Exception ex)
            {
                throw;
            }

            return pdfMakeResult;
        }


        public static void CopyStream(Stream input, Stream output)
        {
            byte[] buffer = new byte[8 * 1024];
            int len;
            while ((len = input.Read(buffer, 0, buffer.Length)) > 0)
            {
                output.Write(buffer, 0, len);
            }
        }
    }
}
