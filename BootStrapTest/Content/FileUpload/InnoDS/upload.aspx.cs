using System;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using InnorixNET;

public partial class Upload : System.Web.UI.Page
{

    public void Page_Load(object sender, EventArgs e)
    {
        string saveDir = "./data/";		// 저장 위치(필요시 변경)
        long maxPostSize = 1024 * 1204 * 1024;

        InnorixTransfer innoTransfer = new InnorixTransfer(Request, Response, maxPostSize, Server.MapPath(saveDir));
        string retCode = innoTransfer.Save();
    }
}