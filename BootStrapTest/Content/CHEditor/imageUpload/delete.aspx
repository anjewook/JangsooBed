<%@ Page Language="C#" %>
<%@ import Namespace="System.IO" %>
<%@ Import Namespace="Ktc.Meter" %>

<script runat="server">
void Page_Load(Object sender, EventArgs e)
{
	string imgUrl = Request.QueryString["img"];
    try
    {
        imgUrl = imgUrl.Substring(imgUrl.IndexOf("encryptedText", System.StringComparison.Ordinal) + 14);
        string[] imgArray = Neoplus.Cryptor.Decryptor.Decrypt(imgUrl.Replace("_", "+").Replace("ktciris", "/")).Split(',');
        string deleteFile = Path.Combine(CHEditor.CHEditorImagePath, imgArray[0]);

		System.IO.File.Delete(deleteFile);
		Response.Write(" ");
	}
	catch (System.IO.IOException ex)
	{
		Response.Write("ERR: " + ex.Message);
	}
}
</script>