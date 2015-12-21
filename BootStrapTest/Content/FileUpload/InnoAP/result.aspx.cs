using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;

public partial class _Default : System.Web.UI.Page
{
    public void Page_Load(object sender, EventArgs e)
    {
        string strHtml = "";

        strHtml = "<font size='5'><b>전송결과</b></font> - <a href='javascript:;' onclick='history.back();'>다른파일 전송하기</a><br /><br />";
		Response.Write(strHtml);

        strHtml = "";
        strHtml += "test1 : " + Request.Form["test1"] + "<br /><br />";
		Response.Write(strHtml);
	
        // 업로드 결과 출력
		// array 로 전달
        string[] strOrigfilename;
        string[] strSavefilename;
        string[] strSavepath;
        string[] strFilesize;
        string[] strCustomvalue;
        string[] strFolder;
        string[] strComponentname;

        strOrigfilename = Request.Form.GetValues("_innorix_origfilename"); 	    // 원본 파일명
        strSavefilename = Request.Form.GetValues("_innorix_savefilename");  	// 저장 파일명
        strSavepath = Request.Form.GetValues("_innorix_savepath");	            // 파일 저장경로
        strFilesize = Request.Form.GetValues("_innorix_filesize");			    // 파일 사이즈
        strCustomvalue = Request.Form.GetValues("_innorix_customvalue"); 	    // 개발자 정의값
        strFolder = Request.Form.GetValues("_innorix_folder"); 			        // 폴더정보(폴더 업로드시만)   
        strComponentname = Request.Form.GetValues("_innorix_componentname");    // 컴포넌트 이름

        strHtml = "";
 
        strHtml += "<table width='570' border='0' cellspacing='1' cellpadding='3' bgcolor='#c0c0c0'>";
        strHtml += "<tr bgcolor='#ebe8d6' align='center' height='25'>";
        strHtml += "    <td nowrap>원본 파일명</td>";
        strHtml += "    <td nowrap>저장 파일명</td>";
        strHtml += "    <td nowrap>저장 폴더명</td>";
        strHtml += "    <td nowrap>파일 사이즈</td>";
        strHtml += "    <td nowrap>개발자 정의값</td>";
        strHtml += "    <td nowrap>컴포넌트 ID</td>";
        strHtml += "</tr>";

 		Response.Write(strHtml);

        if (Request.Form.GetValues("_innorix_origfilename") != null)
        {
            strHtml = "";

            for (int i = 0; i < strOrigfilename.Length; i++)
            {
                strHtml += "<tr bgcolor='#ffffff' align='left' height='22'>";
                strHtml += "    <td nowrap>" + strOrigfilename[i] + "</td>";
                strHtml += "    <td nowrap>" + strSavefilename[i] + "</td>";
                strHtml += "    <td nowrap>" + strSavepath[i] + "</td>";
                strHtml += "    <td nowrap align='right'>" + strFilesize[i] + "</td>";
                strHtml += "    <td nowrap>" + strCustomvalue[i] + "</td>";
                strHtml += "    <td nowrap>" + strComponentname[i] + "</td>";
                strHtml += "</tr>";
            }
            Response.Write(strHtml);
        }

        strHtml = "</table><br/>";
        Response.Write(strHtml);

        // 수정 모드에서 존재하는 파일 출력
        string[] strExistID;
        string[] strExistName;
        string[] strExistSize;

        strExistID = Request.Form.GetValues("_innorix_exist_id");           // 존재 파일ID
        strExistName = Request.Form.GetValues("_innorix_exist_name");       // 존재 파일이름
        strExistSize = Request.Form.GetValues("_innorix_exist_size");       // 존재 파일용량

        if (Request.Form.GetValues("_innorix_exist_id") != null)
        {
            strHtml = "";
            strHtml += "<table width='570' border='0' cellspacing='1' cellpadding='3' bgcolor='#c0c0c0'>";
            strHtml += "<tr bgcolor='#ebe8d6' align='center' height='25'>";
            strHtml += "    <td nowrap>존재 파일ID</td>";
            strHtml += "    <td nowrap>존재 파일명</td>";
            strHtml += "    <td nowrap>존재 사이즈</td>";
            strHtml += "</tr>";

            for (int i = 0; i < strExistID.Length; i++)
            {
                strHtml += "<tr bgcolor='#ffffff' align='left' height='22'>";
                strHtml += "    <td nowrap>" + strExistID[i] + "</td>";
                strHtml += "    <td nowrap>" + strExistName[i] + "</td>";
                strHtml += "    <td nowrap align=right>" + strExistSize[i] + "</td>";
                strHtml += "</tr>";
            }

            strHtml += "</table><br/>";

            Response.Write(strHtml);
        }

        // 수정 모드에서 삭제된 파일 출력
        string[] strDeletedID;
        string[] strDeletedName;
        string[] strDeletedSize;

        strDeletedID = Request.Form.GetValues("_innorix_deleted_id");           // 삭제 파일ID
        strDeletedName = Request.Form.GetValues("_innorix_deleted_name");       // 삭제 파일이름
        strDeletedSize = Request.Form.GetValues("_innorix_deleted_size");       // 삭제 파일용량

        if (Request.Form.GetValues("_innorix_deleted_id") != null)
        {
            strHtml = "";
            strHtml += "<table width='570' border='0' cellspacing='1' cellpadding='3' bgcolor='#c0c0c0'>";
            strHtml += "<tr bgcolor='#ebe8d6' align='center' height='25'>";
            strHtml += "    <td nowrap>삭제 파일ID</td>";
            strHtml += "    <td nowrap>삭제 파일명</td>";
            strHtml += "    <td nowrap>삭제 사이즈</td>";
            strHtml += "</tr>";

            for (int i = 0; i < strDeletedID.Length; i++)
            {
                strHtml += "<tr bgcolor='#ffffff' align='left' height='22'>";
                strHtml += "    <td nowrap>" + strDeletedID[i] + "</td>";
                strHtml += "    <td nowrap>" + strDeletedName[i] + "</td>";
                strHtml += "    <td nowrap align=right>" + strDeletedSize[i] + "</td>";
                strHtml += "</tr>";
            }

            strHtml += "</table><br/>";

            Response.Write(strHtml);
        }
	}
}