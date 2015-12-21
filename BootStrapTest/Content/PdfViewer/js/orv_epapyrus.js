/******************************************************************************
 * �ý��۸� : ���ڼҼ۱�Ϻ��ý���(ERV) 
 * �� �� �� : orv.js
 * ��    �� : PDF ActiveX API�� ����ϴ� ���� JavaScript
 * �� �� �� : ��ö (UNIDOCS)
 * �� �� �� : 2010.11.24
 * History  : ��ö, 2010.11.24 [CJS2] ���� �ۼ�
 *            �ۺ��� , 2011.11.12 [CJS2-2] ezPDFBook_OpenPdf(),getDocLocation(),saveAs(),ezPDFBook_SetFooterText() �λ縸 ó���ϴ�  �б�κ� ���� ����ó�� 
 *            ��ö, 2011.11.17 [11LG-ERV516] ���ں���(PDF �ּ� ���� disable ó��)
 *            ���׸�, 2012.06.21 [12LG-ERV042] �ܺα�Ϻ�� ȣ�� �� ����ھ��̵��� ��ȣȭ ����-(����ھ��̵� ��ȣȭ��Ų��)
 ******************************************************************************/

// PDF ��� ȯ�� ���
var ID_HAND_TOOL=32842;        // PDF ���콺 Ŀ���� �� ������� �ٲٴ� Ŀ�ǵ� ID
var ID_TEXTSELECT_TOOL=32840;  // PDF ���콺 Ŀ���� �ؽ�Ʈ ���� ������� �ٲٴ� Ŀ�ǵ� ID
var ID_MENUFIT=32779;          // PDF ��ü ũ�⿡ �°� ���̱� Ŀ�ǵ� ID
var ID_MENU_FIT_WIDTH=32823;   // PDF �ʺ� �°� ���̱� Ŀ�ǵ� ID
var ID_MENU_FIT_HEIGHT=32851;  // PDF ���̿� �°� ���̱� Ŀ�ǵ� ID
var ID_VIEW_SINGLEPAGE=32803;  // PDF �ܸ麸�� Ŀ�ǵ� ID
var ID_VIEW_DOUBLEPAGE=32804;  // PDF ��麸�� Ŀ�ǵ� ID
var ID_VIEW_FULLSCREEN=32800;  // PDF ��üȭ�麸�� Ŀ�ǵ� ID

var updateVer = '5,0,0,4634';
var id='PapyrusObject';
var codeBase = './control/Papyrus-PlugIn.exe#Version=' + updateVer;

// ORV DOMAIN PREFIX
var PREFIX_URL = document.location.toString();

var ecm_prefix = '';
var orv_prefix = document.location.toString();
index = orv_prefix.indexOf('/', "http://".length);
orv_prefix = orv_prefix.substr(0, index);
index = orv_prefix.indexOf(':', "http://".length);
if (index > -1) {
	ecm_prefix = orv_prefix.substr(0, index) + ':21980';
} else {
	ecm_prefix = orv_prefix;
}

// working var
var hist_date = null;
var logTable = new Array();
var bub_cd = null;
var sa_no = null;
var user_id = null;
var prev_doc_id = null;
var prev_doc_ser = null;
var current_row = null;
var current_sjrow = null;

/**
 * @function
 * @desc PDF Reader ActiveX�� ��ġ�Ǿ� �ִ��� üũ�Ѵ�.
 * @return void
 */
function validatePdfCtrl() {
	/*
	if (jQuery.browser.msie) {
		if(!haveControl("EZPDFBOOKSCOURT.ezPDFBookScourtCtrl.1")) {
			alert("���(ezPDF Reader ActiveX Control)�� ��ġ���� ������ ������ �����Ͻ� �� �����ϴ�.\r\n\r\n��ġ�� ���������� ������� �����ô� ��� �Ʒ��� ��ġ ������ ������ �ּ���.\r\n\r\n1. Windows XP ������� ��� ��� �˾� ���ܵ� ���, ��ġ ȭ���� ���� ���� ���� �ֽ��ϴ�. Ȯ�� �ٶ��ϴ�.\r\n");
		}
	} else {
		var ezPDFPlugin = navigator.plugins["ezPDF Reader Scourt"];
		if (ezPDFPlugin == null ) {
			alert("���(ezPDF Reaader Plug-in)�� ��ġ���� ������ ������ �����Ͻ� �� �����ϴ�.\r\n\r\n��ġ�� ���������� ������� �����ô� ��� �Ʒ��� ��ġ ������ ������ �ּ���.\r\n");
		}
	}
	*/
	if(!haveControl("nppapyrus.PapyrusPlugIn.1")) {
		alert("�� ��ġ���� ������ ������ �����Ͻ� �� �����ϴ�.\r\n\r\n��ġ�� ���������� ������� �����ô� ��� �Ʒ��� ��ġ ������ ������ �ּ���.\r\n\r\n1. Windows XP ������� ��� ��� �˾� ���ܵ� ���, ��ġ ȭ���� ���� ���� ���� �ֽ��ϴ�. Ȯ�� �ٶ��ϴ�.\r\n");
	}
}

/**
 * @function
 * @desc PDF Reader ActiveX�� �����ϰ� �ʿ��� �Ķ���͸� �����Ѵ�.
 * @return void
 */
function insertPdfReader() {
	if (jQuery.browser.msie) {
		/*
		var str = "<OBJECT ID='ezPDFBook' height='100%' width='100%' CLASSID='CLSID:00EF87B7-E901-4876-A1C7-628A9321B704'";
		str = str + " codebase='" + _pdfReaderOcxPath + "' ";
		str = str + " hspace='0' vspace='0' align='middle' VIEWASTEXT style='width: 100%'>";
		str = str + "<Param name='SecData' value='" + _secdata + "'/>";
		str = str + "<PARAM NAME='FileName' VALUE=''>"	// pdf���� ���
		str = str + "<PARAM NAME='ShowOutline' VALUE='0'>"	
		str = str + "<PARAM NAME='ShowBookMark' VALUE='0'>"	
		str = str + "<PARAM NAME='ShowPageThumb' VALUE='0'>"	
		str = str + "<PARAM NAME='ShowSearch' VALUE='0'>"	
		str = str + "<PARAM NAME='ShowAnnotation' VALUE='0'>"	
		str = str + "<PARAM NAME='ShowEmbeddedFile' VALUE='0'>"	
		str = str + "<PARAM NAME='ShowToolBar' VALUE='1'>"
		str = str + "<PARAM NAME='ShowFindToolBar' VALUE='0'>"
		str = str + "<PARAM NAME='ShowAnnotationToolbar' VALUE='0'>"
		str = str + "<PARAM NAME='ShowStampToolbar' VALUE='0'>"
		str = str + "<PARAM NAME='ShowContextMenu' VALUE='0'>"
		str = str + "<PARAM NAME='SaveUIState' VALUE='0'>"
		str = str + "<PARAM NAME='PageFace' VALUE='1'>";
		str = str + "<PARAM NAME='UseImageSafer' VALUE='1'>";
		str = str + "<PARAM NAME='ThumbnailSize' VALUE='200'>";
		str = str + "<PARAM NAME='PagePassNum' VALUE='10'>";
		str = str + "<PARAM NAME='EnableViewWatermark' VALUE='0'>";
		str = str + "<PARAM NAME='UseAnnotation' VALUE='0'>";
		str = str + "</OBJECT>";
		$("#pdfReader").html(str);
		*/
		
		var str = "<OBJECT ID='ezPDFBook' height='100%' width='100%' CLASSID='CLSID:C6B9FBE6-AC96-4bce-BCB3-D6E194565F0E'";
		str = str + " codebase='" + codeBase + "' ";
		str = str + " hspace='0' vspace='0' align='middle' VIEWASTEXT style='width: 100%'>";
		str = str + "</OBJECT>";
		$("#pdfReader").html(str);

	} else {
		// Mozilla Plugin Info. 
		var	ezPDF_PluginType = "application/ezpdfS";
		var	ezPDF_PluginName = "ezPDF Reader Scourt";
		var	ezPDF_PluginDescription = _pdfReaderMozillaVer;
		
		// Mozilla Plugin Check
		var	ezPDF_PluginOK = false;
		var	ezPDF_PluginVersionOK = false;
	
		var ezPDFPlugin = navigator.plugins[ezPDF_PluginName];
		if (ezPDFPlugin != null ) {
			ezPDF_PluginOK = true;
			if(ezPDFPlugin.description >= ezPDF_PluginDescription) {
				ezPDF_PluginVersionOK = true;
			}
		}
		
		var str = "";
		if (ezPDF_PluginOK) {
			if(ezPDF_PluginVersionOK) {
				str = str + "<embed type=\"application/ezpdfS\"  name=\"ezPDFBook\" id=\"EZPDFBOOK\" width=\"100%\" height=\"100%\" border=\"0\"/>"; 
			}else{
				str = str + "<table width=\"100%\" height=\"80%\" border=\"0\">"
				str = str + "<TR><TD>";
				str = str + "<center>�ֽŹ����� ezPDF Reader�� ��ġ�Ͻð� �������� ������Ͻñ� �ٶ��ϴ�.&nbsp;<A HREF=\"" + _pdfReaderMozillaPath + "\">Install ezPDF Reader Plug-in</A>";
				str = str + "</TD></TR>";
				str = str + "</table>";
			}
		}
		else {
			str = str + "<table width=\"100%\" height=\"80%\" border=\"0\">"
			str = str + "<TR><TD>";
			str = str + "<center>ezPDF Reader�� ��ġ�Ͻð� �������� ������Ͻñ� �ٶ��ϴ�.&nbsp;<A HREF=\"" + _pdfReaderMozillaPath + "\">Install ezPDF Reader Plug-in</A>";
			str = str + "</TD></TR>";
			str = str + "</table>";
		}
		$("#pdfReader").html(str);
		initReaderAtMozilla();
	}
	
	validatePdfCtrl();
}

function init()
{
	//http://ecfs.scourt.go.kr/ecf/ecf/ECF000/SearchInsideEDMSCmd.dev?doc_id=F3615132AC100C115B95C8B17E855414&doc_ser=1&file_ser=&user_id=31%2BXG%2BUyBUUdPH%2B6kqpjTw%3D%3D&_userMetaToken=GTTgpRjKbwEzwGYt48ezKSCLT4TyjfT/oQsYslBblMT2AYUVEqmY4LgT2ZyM3iwc&applyWM=Y&sysCd=ORV&readYn=Y&wmType=I
	ezPDFBook.openUrl("ecfs.scourt.go.kr", "/ecf/ecf/ECF000/SearchInsideEDMSCmd.dev?doc_id=F3615132AC100C115B95C8B17E855414&doc_ser=1&file_ser=&user_id=31%2BXG%2BUyBUUdPH%2B6kqpjTw%3D%3D&_userMetaToken=GTTgpRjKbwEzwGYt48ezKSCLT4TyjfT/oQsYslBblMT2AYUVEqmY4LgT2ZyM3iwc&applyWM=Y&sysCd=ORV&readYn=Y&wmType=I", 80);
}

/**
 * @function
 * @desc PDF Download ActiveX�� �����ϰ� �ʿ��� �Ķ���͸� �����Ѵ�.
 * @return void
 */
 // ���� ��� ����.
function insertPdfDownloader() {
	if (jQuery.browser.msie) {
		var str = "<OBJECT CLASSID='CLSID:8F87C6F0-CBA6-4A90-9E4B-FC764650D147' id='ezPDFDownload' CodeBase='" + _pdfDownloadOcxPath + "' width='0' height='0' border='0'></OBJECT>";
		$("#pdfDownload").html(str);
	}
}

/**
 * @function
 * @desc ezPDF TransFilesAX ActiveX�� �����ϰ� �ʿ��� �Ķ���͸� �����Ѵ�.
 * @return void
 */
function insertPdfDownloader2() {
  if (jQuery.browser.msie) {
    var str = "<OBJECT CLASSID='CLSID:2C07B89D-5281-4CB3-AB19-0DEAAF6502A2' id='ezPDFTransFilesAX' CodeBase='" + _pdfTransOcxPath + "' width='0' height='0' border='0'></OBJECT>";
    $("#pdfDownload2").html(str);
  }
}

/**
 * @function
 * @desc ezPDF TransFilesAX ActiveX�� ��ȯ�Ѵ�.
 * @return ezPDFTransFilesAX ��ü
 */
function getPdfDownloader() {
  return document.getElementById('ezPDFTransFilesAX');
}

/**
 * @function
 * @desc ezPDFReader ActiveX�� ��ȯ�Ѵ�.
 * @return ezPDFBook ��ü
 */
function ervjf_GetPdfReader() {
  return document.getElementById("ezPDFBook");
}

/**
 * @function
 * @desc Mozilla�� ezPDFBook ActiveX�� �����Ѵ�.
 * @return void
 */
function initReaderAtMozilla() {
	if (! jQuery.browser.msie) {
		if (document.ezPDFBook != null) {
			document.ezPDFBook.SecData = _secdata;
			document.ezPDFBook.FileName = "";
			document.ezPDFBook.FastOpen = "0";  // ��ö, 2011.05.23 [CJS2] ���� �ý��ۻ� FastOpen�� ���� �ȵǴµ� true�� �����Ǿ� �־ 2�� ȣ��ȴٰ� ��. 0(false)���� ����
			document.ezPDFBook.ShowUI = true;
			document.ezPDFBook.ShowOutline = "0";
			document.ezPDFBook.ShowBookMark = "0";
			document.ezPDFBook.ShowPageThumb = "0";
			document.ezPDFBook.ShowSearch = "0";
			document.ezPDFBook.ShowAnnotation = "0";
			document.ezPDFBook.ShowEmbeddedFile = "0";
			document.ezPDFBook.SaveUIState = "0";   // Reader Toolbar ȯ������
			document.ezPDFBook.PageFace = "1";      // �ܸ麸��
			document.ezPDFBook.UseImageSafer='1'; 	// '0' (ȭ��ĸ�����) , '1'(ȭ��ĸ�Ĺ���)
			document.ezPDFBook.InitParam();
		}
	}
}

/**
 * @function
 * @desc ���� ���� ���� �̹� ���� �̷¿� ���� �ٽ� ������ �̷��� ������ �ʵ��� �ϱ� ���� �����ϴ� �̷� �α� ��ü
 * @param doc_id      (����ID)
 * @param doc_hist_cd (�����̷��ڵ�)
 * @return void
 */
function logData(doc_id, doc_hist_cd) {
  this.doc_id = doc_id;
  this.doc_hist_cd = doc_hist_cd;
}

/**
 * @function
 * @desc ��Ƽ�̵�� ������ ���÷� �ٿ�ε��Ѵ�.
 * @param doc_id   (����ID)
 * @param doc_ser  (�����Ϸù�ȣ)
 * @param file_ser (�����Ϸù�ȣ)
 * @param user_id  (�����ID)
 * @return void
 */
function ervjf_DownloadFile(doc_id, doc_ser, file_ser, user_id) {
	
  var DOWNLOAD_URL = getFileURL(doc_id, doc_ser, file_ser);
    if(DOWNLOAD_URL != null && DOWNLOAD_URL != '') {
      if (document.hiddenFrame != null) {
      document.hiddenFrame.location = DOWNLOAD_URL;
    }
  }
}

/**
 * @function
 * @desc ���� �̷��� EDM DB�� �����Ѵ�.
 * @param doc_id   (����ID)
 * @return void
 */
function insertOpenLog(doc_id)
{
  if (doc_id == null || doc_id.length < 32) {
    return;
  }
  var doc_hist_cd = "2";
  var insertedLog = false;
  for (i = 0; i < logTable.length; i++) {
    if (logTable[i].doc_id == doc_id && logTable[i].doc_hist_cd == doc_hist_cd) {
      insertedLog = true;
      break;
    }
  }
  
  if (insertedLog == false) {
	du.ajax.addParam("user_id", user_id);
	du.ajax.addParam("doc_id", doc_id);
	du.ajax.addParam("doc_hist_cd", doc_hist_cd);
	du.ajax.addParam("hist_date", hist_date);
	du.ajax.addParam("outuser_yn", "Y");
    du.ajax.send( "/orv/ERV000/ERV000u01Cmd.ajax" );
    logTable.push(new logData(doc_id, doc_hist_cd));
  }
}

/**
 * @function
 * @desc �纻���� �̷��� EDM DB�� �����Ѵ�.
 * @param doc_id   (����ID)
 * @return void
 */
function insertSaveLog(doc_id)
{
  if (doc_id == null || doc_id.length < 32) {
    return;
  }
  var doc_hist_cd = "5";
  var insertedLog = false;
  for (i = 0; i < logTable.length; i++) {
    if (logTable[i].doc_id == doc_id && logTable[i].doc_hist_cd == doc_hist_cd) {
      insertedLog = true;
      break;
    }
  }
  
  if (insertedLog == false) {
	du.ajax.addParam("user_id", user_id);
	du.ajax.addParam("doc_id", doc_id);
	du.ajax.addParam("doc_hist_cd", doc_hist_cd);
	du.ajax.addParam("hist_date", hist_date);
	du.ajax.addParam("outuser_yn", "Y");
    du.ajax.send( "/orv/ERV000/ERV000u01Cmd.ajax" );
    logTable.push(new logData(doc_id, doc_hist_cd));
  }
}

/**
 * @function
 * @desc PDF �μ� �̷��� EDM DB�� �����Ѵ�.
 * @param doc_id   (����ID)
 * @return void
 */
function insertPrintLog(doc_id)
{
  if (doc_id == null || doc_id.length < 32) {
    return;
  }
  var doc_hist_cd = "4";
  var insertedLog = false;
  for (i = 0; i < logTable.length; i++) {
    if (logTable[i].doc_id == doc_id && logTable[i].doc_hist_cd == doc_hist_cd) {
      insertedLog = true;
      break;
    }
  }
  
  if (insertedLog == false) {
	du.ajax.addParam("user_id", user_id);
	du.ajax.addParam("doc_id", doc_id);
	du.ajax.addParam("doc_hist_cd", doc_hist_cd);
	du.ajax.addParam("hist_date", hist_date);
	du.ajax.addParam("outuser_yn", "Y");
    du.ajax.send( "/orv/ERV000/ERV000u01Cmd.ajax" );
    logTable.push(new logData(doc_id, doc_hist_cd));
  }
}

/**
 * @function
 * @desc ���� ��ġ URL�� �����Ͽ� ��ȯ�Ѵ�.
 * @param doc_id   (����ID)
 * @param doc_ser  (�����Ϸù�ȣ)
 * @param file_ser (�����Ϸù�ȣ)
 * @return void
 */
//���׸�, 2012.06.21 [12LG-ERV042] �ܺα�Ϻ�� ȣ�� �� ����ھ��̵��� ��ȣȭ ����
function getFileURL(doc_id, doc_ser, file_ser) {

	//var open_url = _fileServer + "/ecf/ecf/ECF000/SearchInsideEDMSCmd.dev?doc_id=" + doc_id + "&doc_ser=" + doc_ser + "&file_ser=" + file_ser + "&user_id=" + user_id;
	var open_url = _fileServer + "/ecf/ecf/ECF000/SearchInsideEDMSCmd.dev?doc_id=" + doc_id + "&doc_ser=" + doc_ser + "&file_ser=" + file_ser + "&user_id=" + encUser_id;
		open_url += '&_userMetaToken=' + du.xecure._escape(du.c.TOKEN);
	return open_url;
}

/**
 * @function
 * @desc PDF ������ LOCAL PC�� �����Ѵ�.
 * @return void
 * [CJS2-2] DPS 2011.11.12 �ۺ��� �ý��� �߰������� �λ� �б����.
 */
//���׸�, 2012.06.21 [12LG-ERV042] �ܺα�Ϻ�� ȣ�� �� ����ھ��̵��� ��ȣȭ ����
function saveAs() {
	var docid = prev_doc_id;
	var docser = prev_doc_ser;
	
	if (docid == '' || docser == '') {
		return;
	}
	
	// �ؽ�Ʈ ���͸�ũ ����  
	var wmTextLog = '';
	if (current_row != null ) {
	  row = current_row;
	  if (row.doc_kindcd != null && row.doc_kindcd == '11') {
	    wmTextLog += "������:" + row.crj_nm + ", �����Ͻ�:" + row.flng_std_day + ' ' + row.flng_std_sibun;
	  } else {
	    wmTextLog += "�����:" + row.crj_nm + ", ����Ͻ�:" + row.flng_std_day + ' ' + row.flng_std_sibun;
	  }
      if (user_nm != null) {
        wmTextLog += ", �����:" + user_nm;
      }
      wmTextLog += ", �ٿ�ε��Ͻ�:" + hist_date;     
      wmTextLog = encryptString(wmTextLog);
	} else {
	  wmTextLog = encryptString(hist_date + "[" + user_id + "] �� ������ �������Դϴ�.");
	}

	// �ٿ�ε� URL ���� 
	var open_url = null;
	if (current_row != null && current_row.sys_cd != null &&  current_sjrow != null) {
	  open_url = getDocLocation(docid, docser, wmTextLog, current_row, current_sjrow, 'saveas');
	} else {
	  //���׸�, 2012.06.21 [12LG-ERV042] �ܺα�Ϻ�� ȣ�� �� ����ھ��̵��� ��ȣȭ ����
	  //open_url = _fileServer + "/ecf/ecf/ECF000/SearchInsideEDMSCmd.dev?doc_id=" + docid + "&doc_ser=" + docser + "&file_ser=&user_id=" + user_id;
	  open_url = _fileServer + "/ecf/ecf/ECF000/SearchInsideEDMSCmd.dev?doc_id=" + docid + "&doc_ser=" + docser + "&file_ser=&user_id=" + encUser_id;
	  open_url += '&_userMetaToken=' + du.xecure._escape(du.c.TOKEN);
	  open_url += '&applyWM=Y&sysCd=ORV&readYn=Y&wmType=I&viewFlag=3&wmTextLog=' + wmTextLog;
	}
	
    if (open_url == null) {
      return;
    }
    // prompt('open_url', open_url);

	document.location.href=open_url;
	insertSaveLog(docid);
//	alert('�ٿ�ε� �ޱ���� �ټ� �ð��� �ҿ�˴ϴ�.\n��� ��ٷ��ֽñ� �ٶ��ϴ�.');
}

/**
 * @function
 * @desc PDF ������ �μ� �α׸� �����.
 * @return void
 */
function ezPDFBook_DocPrinted()
{
	var docid = prev_doc_id;
	var docser = prev_doc_ser;
	
	if (docid == '' || docser == '') {
		return;
	}
	
	insertPrintLog(docid);
}

/**
 * @function
 * @desc PDF ������ Ư�� ���ڿ��� �����Ѵ�.
 * @param row   (������)
 * @return void 
 * [CJS2-2] DPS 2011.11.12 �ۺ��� �ý��� �߰������� �λ� �б����.
 */
function ezPDFBook_SetFooterText(row) {
	if (row != null ) {
	  var wmTextLog = "";
	  if (row.doc_kindcd != null && row.doc_kindcd == '11') {
	    wmTextLog += "������:" + row.crj_nm + ", �����Ͻ�:" + row.flng_std_day + ' ' + row.flng_std_sibun;
	  } else {
	    wmTextLog += "�����:" + row.crj_nm + ", ����Ͻ�:" + row.flng_std_day + ' ' + row.flng_std_sibun;
	  }
      if (user_nm != null) {
        wmTextLog += ", �����:" + user_nm;
      }
      wmTextLog += ", �ٿ�ε��Ͻ�:" + hist_date;
      var re = document.ezPDFBook.SetDuplicateMark("����", 10, "#000000", wmTextLog, 00, 0, 0, 0);
	} else {
	  var wmTextLog = hist_date + "[" + user_id + "] �� ������ �������Դϴ�.";
	  var re = document.ezPDFBook.SetDuplicateMark("����", 10, "#000000", wmTextLog, 2, 0, 0, 0);
	}
}

/**
 * @function
 * @desc PDF ȭ�� ũ�⸦ PDF �ʺ� �����.
 * @return void
 */
function ezPDFBook_FitWidth() {
	
    if(pgm_id != null && (pgm_id == "erv801" || pgm_id == "ERV801")) {
      //document.ezPDFBook.PostMenuCommand(ID_MENUFIT);
	  PapyrusObject.fitWidthHeight();
    } else {
	  //document.ezPDFBook.PostMenuCommand(ID_MENU_FIT_WIDTH);
	  PapyrusObject.fitWidth();
	}
	
	
}

/**
 * @function
 * @desc ezPDFBook ȭ�� UI�� �����Ѵ�.
 * @return void
 */
function ezPDFBook_Redraw() {
	//document.ezPDFBook.ShowUI(1);
}

/**
 * @function
 * @desc PDF ������ �����Ѵ�.
 * @param doc_id   (����ID)
 * @param doc_ser  (�����Ϸù�ȣ)
 * @param user_id  (�����ID)
 * @param row      (���� ��� ������)
 * @param sjrow    (���� ���� ������)
 * @return PDF ���� ���� ����
 * [CJS2-2] DPS 2011.11.12 �ۺ��� �ý��� �߰������� �б����.
 */
//���׸�, 2012.06.21 [12LG-ERV042] �ܺα�Ϻ�� ȣ�� �� ����ھ��̵��� ��ȣȭ ����
function ezPDFBook_OpenPdf(doc_id, doc_ser, user_id, row, sjrow) {
	var open_url = null;
	var _urlServer = null;
	if (row != null && sjrow != null) {
		_urlServer = _edmsServer;
		open_url = getDocLocation(doc_id, doc_ser, null, row, sjrow);  // null �Ķ���ʹ� wmTextLog
	} else {
		//���׸�, 2012.06.21 [12LG-ERV042] �ܺα�Ϻ�� ȣ�� �� ����ھ��̵��� ��ȣȭ ����
		//open_url = _fileServer + "/ecf/ecf/ECF000/SearchInsideEDMSCmd.dev?doc_id=" + doc_id + "&doc_ser=" + doc_ser + "&file_ser=&user_id=" + user_id;
		_urlServer = _fileServer;
		open_url = /*_fileServer*/ + "/ecf/ecf/ECF000/SearchInsideEDMSCmd.dev?doc_id=" + doc_id + "&doc_ser=" + doc_ser + "&file_ser=&user_id=" + encUser_id;
		open_url += '&_userMetaToken=' + du.xecure._escape(du.c.TOKEN);
		open_url += '&applyWM=Y&sysCd=ORV&readYn=Y&wmType=I';
	}
	if (open_url == null) {
	    return 0;
	}
	
	if (sjrow != null && sjrow != undefined) {
  	  if (sjrow.seoj_statcd != null && sjrow.seoj_statcd == '05') {
  	    alert('�Ⱒ�� ������ ��ȸ�� �Ұ��� �մϴ�.');
  	    notifyOpened(doc_id, doc_ser, sjrow);
	    return 0;
	  }
	}

	var result = '0';
	/*
	if (jQuery.browser.msie) {
		result = document.ezPDFBook.OpenUrl(open_url);
	} else {
		result = document.ezPDFBook.OpenURL(open_url);
	}
	*/

	PapyrusObject.OpenUrl(_urlServer, open_url, 0);
	
	//if (result == '1') {
		hist_date = getCurrentHistDate();    // util.js method
		ezPDFBook_FitWidth();
		//ezPDFBook_SetFooterText(row);
		insertOpenLog(doc_id);
	    current_row = row;
	    current_sjrow = sjrow;
		prev_doc_id = doc_id;
		prev_doc_ser = doc_ser;
		try {
          notifyOpened(doc_id, doc_ser, sjrow);
        } catch (e) {}
	//}
	
	return result;
}

/**
 * @function
 * @desc ������ ���� ��� ��� �޽����� �����ش�.
 * @return void
 */
function warnEmptyFile() {
	du.msg.alert("erv.wrn.0001");
}

/**
 * @function
 * @desc PDF Reader ActiveX�� �ش� ������ �޸𸮿� �ٿ�ε��Ͽ� �����ش�.
 * @param edms_id   (EDMSID)
 * @return PDF ���� ���� ����
 */
function ezPDFBook_OpenExDoc(edms_id) {
    var result = '';
	var open_url = /*_edmsServer +*/ "/Ex_EdmsDownload.jsp?job_kind=ECF&user_id=" + user_id + "&edms_gbncd=TP&edms_id=" + edms_id;
	/*
	if (jQuery.browser.msie) {	
		result = document.ezPDFBook.OpenUrl(open_url);
	} else {
		result = document.ezPDFBook.OpenURL(open_url);
	}
	*/
	PapyrusObject.openUrlWithMemory(_edmsServer, open_url, 0);
	
	//if (result == '1') {
		ezPDFBook_FitWidth();
	//}
	return result;
}

/**
 * @function
 * @desc �ӽ� EDMS�� ���� ���� �ٿ�ε� URL�� �����Ͽ� ��ȯ�Ѵ�.
 * @param edms_id   (EDMSID)
 * @return �ܺ� �ӽ� EDMS �ٿ�ε� URL
 */
function downloadExOrigDoc(edms_id) {
	var down_url = _edmsServer + "/Ex_EdmsDownload.jsp?job_kind=ECF&user_id=" + user_id + "&edms_gbncd=TP&edms_id=" + edms_id;
	return down_url;
}

/**
 * @function
 * @desc PDF ���� �ٿ�ε� URL�� ��ȸ�Ѵ�.
 * @param doc_id     (����ID)
 * @param doc_ser    (�����Ϸù�ȣ)
 * @param wmTextLog  (�ؽ�Ʈ ���͸�ũ)
 * @param row        (���� ��� ������)
 * @param sjrow      (���� ���� ������)
 * @param use        (�뵵)
 * @return PDF ���� URL
 * [CJS2-2] DPS 2011.11.12 �ۺ��� �ý��� �߰������� �λ� �б����.
 */
function getDocLocation(doc_id, doc_ser, wmTextLog, row, sjrow, use) {

	if (doc_id == null || doc_id == '' || doc_ser == null || doc_ser == '') {
		return null;
	}
	
    var viewFlag = "3";
    var param = null;
	
	if (wmTextLog != null) {
		param = {"doc_id":doc_id,"doc_ser":doc_ser,"user_id":user_id,"read_lmt_yn":"N"
				,"applyWM":"Y","sysCd":"ORV","readYn":"Y","wmType":"I","applyDRM":"N"
				,"bub_nm":"","bub_cd":bub_cd,"sa_no":sa_no,"doc_no":""
				,"viewFlag":viewFlag, "wmTextLog":wmTextLog};
    } else {
		param = {"doc_id":doc_id,"doc_ser":doc_ser,"user_id":user_id,"read_lmt_yn":"N"
				,"applyWM":"Y","sysCd":"ORV","readYn":"Y","wmType":"I","applyDRM":"N"
				,"bub_nm":"","bub_cd":bub_cd,"sa_no":sa_no,"doc_no":""
				,"viewFlag":viewFlag};
    }
	du.ajax.addParam( "doc_id"     , param["doc_id"]);
    du.ajax.addParam( "doc_ser"    , param["doc_ser"]);
    du.ajax.addParam( "user_id"    , param["user_id"]);
    du.ajax.addParam( "read_lmt_yn", param["read_lmt_yn"]);
    du.ajax.addParam( "applyWM"    , param["applyWM"]);
    du.ajax.addParam( "sysCd"      , param["sysCd"]);
    du.ajax.addParam( "readYn"     , param["readYn"]);
    du.ajax.addParam( "wmType"     , param["wmType"]);
    du.ajax.addParam( "applyDRM"   , param["applyDRM"]);
    du.ajax.addParam( "bub_nm"     , param["bub_nm"]);
    du.ajax.addParam( "bub_cd"     , param["bub_cd"]);
    du.ajax.addParam( "sa_no"      , param["sa_no"]);
    du.ajax.addParam( "doc_no"     , param["doc_no"]);
    du.ajax.addParam( "viewFlag"   , param["viewFlag"]);
    du.ajax.send("/orv/ERV000/SearchInsideEFMCmd.ajax", {method:'POST'});
    if (du.ajax.resMeta.err == "false") {    
		var file_ser = new Array();
		var edms_gbncd = new Array();
		var job_kind = new Array();
		var edms_id = new Array();
//		var signed_val = new Array();
		
		for (var i=0; i<du.ajax.res.srhData.length; i++) {
			file_ser[i]   = du.ajax.res.srhData[i].file_ser;
			edms_gbncd[i] = du.ajax.res.srhData[i].edms_gbncd,
			job_kind[i]   = du.ajax.res.srhData[i].job_kind,
			edms_id[i]    = du.ajax.res.srhData[i].edms_id;
//			signed_val[i] = du.ajax.res.srhData[i].signed_val;
		}

		var qs = "";
	  	for(var key in param) {
			qs += key+"="+encodeURI(param[key]+"&");
	  	}
	  	
		qs += "CountRow="+du.ajax.res.srhData.length+"&file_ser="+file_ser+"&edms_gbncd="+edms_gbncd+
			"&job_kind="+job_kind+"&edms_id="+edms_id;
		if (row != null  && use != null && use == 'saveas') {
		  qs += "&wm_text_pos=20";
		}
			
		if (sjrow != null) {
		  sPg = sjrow.start_page_no;
		  ePg = sjrow.lst_page_no;
		  qs += "&docu_seoj_yn=Y&docu_start_page_no="+sPg+"&docu_lst_page_no="+ePg;
		  if (use != null && use == 'saveas') {
		    var sjcolor = '';
		    var sjimage = '';
		    wp_cd = sjrow.jchulj_gbncd =! null ? sjrow.jchulj_gbncd.substr(0, 1) : '';
            if (wp_cd == '1') {
              sjcolor = "255,17,17";
              sjimage = 'P';
            } else if (wp_cd == '2') {
              sjcolor = "17,17,255";
              sjimage = 'D';
            }
		    qs += "&docu_seoj_wm_text_yn=Y&docu_seoj_wm_text="+encryptString(sjrow.seoj_no)+"&docu_seoj_wm_text_color="+sjcolor;
		    if (sjimage != '') {
		      qs += "&docu_seoj_wm_image_yn=Y&docu_seoj_wm_image_type="+sjimage;
		    } else {
		      qs += "&docu_seoj_wm_image_yn=N";
		    }
		  }
		}
		var url = /*_edmsServer*/ + "/Ex_DocuDown.jsp?"+qs;
		return url;
	} else {
		return null;
	}
}

/**
 * @function
 * @desc ���� ���� PDF ������ Ư�� ���ڿ��� �����Ѵ�.
 * @param color   (�÷�)
 * @param text    (�ؽ�Ʈ)
 * @return void
 */

function HexToR(h) { return parseInt((cutHex(h)).substring(0,2),16) }
function HexToG(h) { return parseInt((cutHex(h)).substring(2,4),16) }
function HexToB(h) { return parseInt((cutHex(h)).substring(4,6),16) }
function cutHex(h) { return (h.charAt(0)=="#") ? h.substring(1,7) : h}

function ervjf_SetText(color, text) {
	/*
  totalPage = ervjf_GetPdfReader().GetNumPages();
  ervjf_GetPdfReader().SetTxt("����ü", 24, color, 1, 1, 0, color, text, 1, totalPage, 12, 0, 30);
  */
  totalPage = PapyrusObject.pageCount();
  pageRange = 1 + "-" + totalPage;
  PapyrusObject.addTextWatermark(text, "����ü", 24, 7, 0, 0, HexToR(color), HexToG(color), HexToB(color), pageRange);
}

/**
 * @function
 * @desc ���� ���� PDF ������ Ư�� �̹����� �����Ѵ�.
 * @param imagePath    (�̹��� ���)
 * @return void
 */
function ervjf_SetImage(imagePath) {
	/*
  totalPage = ervjf_GetPdfReader().GetNumPages();
  ervjf_GetPdfReader().SetImage(orv_prefix + imagePath, 1, totalPage, 21, 0, 0);
  */
  totalPage = PapyrusObject.pageCount();
  pageRange = 1 + "-" + totalPage;
  PapyrusObject.addImageWatermark(orv_prefix + imagePath, 5, 0, 0, 60, 100, true, true, pageRange);
}