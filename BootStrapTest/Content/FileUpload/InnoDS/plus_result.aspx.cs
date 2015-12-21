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

public partial class _plus_Default : System.Web.UI.Page
{

    public void Page_Load(object sender, EventArgs e)
    {
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

        if (Request.Form.GetValues("_innorix_origfilename") != null)
        {
            for (int i = 0; i < strOrigfilename.Length; i++)
            {
                // 여기에 업로드 파일 정보를 DB에 입력하는 코드를 작성 합니다. 

                // strOrigfilename[i]
                // strSavefilename[i]
                // strSavepath[i]
                // strFilesize[i]
                // strCustomvalue[i]
                // strComponentname[i]
            }
        }
    }
}