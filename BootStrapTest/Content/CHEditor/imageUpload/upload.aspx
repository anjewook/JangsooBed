<%@ Page Language="C#" %>
<%@ Import Namespace="System.Globalization" %>
<%@ import Namespace="System.IO" %>
<%@ import Namespace="System.Configuration" %>
<%@ import Namespace="System.Text" %>
<%@ import Namespace="System.Security.Cryptography" %>
<%@ Import Namespace="Ktc.Meter" %>
<%@ Import Namespace="Neoplus.Cryptor" %>

<script runat="server">
void Page_Load(Object sender, EventArgs e)
{
    if (Request.ContentType.IndexOf("multipart/form-data") < 0)
        return;
	
    for (int i = 0; i < Request.Files.Count; i++)
    {
    	string szRandomName;
    	int maxSize = 20;
    	char[] chars = new char[62];
    	chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890".ToCharArray();
    	byte[] data = new byte[1];
    	RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider();
    	crypto.GetNonZeroBytes(data);
    	data = new byte[maxSize];
		crypto.GetNonZeroBytes(data);
		StringBuilder result = new StringBuilder(maxSize);
		
		foreach (byte b in data)
		{
			result.Append(chars[b%(chars.Length - 1)]);
		}
		
		szRandomName = result.ToString();
		
    	string szRdata = "{";
        HttpPostedFile objFile = Request.Files[i];
        string szFileName = System.IO.Path.GetFileName(objFile.FileName);
        szRandomName += System.IO.Path.GetExtension(szFileName);

        if (!Directory.Exists(Path.Combine(CHEditor.CHEditorImagePath, DateTime.Now.Year.ToString(CultureInfo.InvariantCulture), DateTime.Now.Month.ToString(CultureInfo.InvariantCulture))))
        {
            Directory.CreateDirectory(Path.Combine(CHEditor.CHEditorImagePath, DateTime.Now.Year.ToString(CultureInfo.InvariantCulture), DateTime.Now.Month.ToString(CultureInfo.InvariantCulture)));
        }

        szRandomName = Path.Combine(DateTime.Now.Year.ToString(CultureInfo.InvariantCulture), DateTime.Now.Month.ToString(CultureInfo.InvariantCulture), szRandomName);

        string szPath = Path.Combine(CHEditor.CHEditorImagePath, szRandomName);
        //string szUrl = string.Format("http://{0}/Common/FileStorge/FileUrl?encryptedText={1}", Request.Url.Authority, Encryptor.Encrypt(string.Format("{0},{1},{2},V", szRandomName, DateTime.Now.ToString(CultureInfo.InvariantCulture), "Cheditor")).Replace("+", "_").Replace( "/", "ktciris"));
        string szUrl = string.Format("/Home/FileUrl?encryptedText={0}", Encryptor.Encrypt(string.Format("{0},{1},{2},V", szRandomName, DateTime.Now.ToString(CultureInfo.InvariantCulture), "Cheditor")).Replace("+", "_").Replace("/", "ktciris"));
        
        int nFileSize = objFile.ContentLength;
    	
    	szRdata += ("fileUrl:'" + szUrl + "',filePath:'" + szPath + "',origName:'" + szFileName);
    	szRdata += ("',fileName:'" + szRandomName + "',fileSize:'" + nFileSize);
        
        szRdata += "'}";
        
        try
        {
        	objFile.SaveAs(szPath);
       	 	Response.Write(szRdata);
       	 }
       	 catch (System.IO.IOException ex)
       	 {
       	 	Response.Write("ERR: " + ex.Message);
       	 }
    }
}
</script>