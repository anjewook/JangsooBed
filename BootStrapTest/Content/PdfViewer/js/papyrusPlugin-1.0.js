var updateVer = '5,0,4,7075';
var id = 'PapyrusObject';
var codeBase = './control/Papyrus-PlugIn.exe#Version=' + updateVer;
var classId = 'CLSID:C6B9FBE6-AC96-4bce-BCB3-D6E194565F0E';
//var classId = 'CLSID:984C16FF-BD1A-4443-8C3B-D3709DD4835A';
var appType = 'application/vnd.epapyrus.pdf';
var eformWidth = '100%';
var eformHeight = '100%';

function epapyrus_control(){
	var browserCheck = getNavigatorInfoStr();
	if (browserCheck == 1) {
		document.writeln("<object classid='" + classId + "' id='" + id + "' name='" + id + "'");
		document.writeln(" width='"+eformWidth+"', height='"+eformHeight+"'");
		document.writeln(" CODEBASE='" + codeBase + "'");
		document.writeln("> </object>");

	} else if (browserCheck == 2) {
		epapyrus_plugin_ctrl();
	} else {
		alert("지원 할 수 없는 브라우저 입니다.\n 지원가능 브라우저 : IE, Chrome, FireFox, Safari, Netscape ");
	}
}

function epapyrus_plugin_ctrl(){
	var pluginVer = getPluginVersion();
	updateVer = updateVer.replace(/\,/g, ".");
	//alert('Papyrus Plug-In' + '\n' + '버전체크 : '+pluginVer +'\n'+ '설치할 버전 : ' + updateVer);
	if (pluginVer < updateVer && pluginVer != '') {
		alert('Papyrus Plug-In' + '\n' + '플러그인 버전이 업데이트 되었습니다.\n설치 페이지로 이동합니다.');
		setupPluginsPage();
	} else if (pluginVer == '') {
		alert('Papyrus Plug-In이 설치되지 않았습니다.' + '\n' + '설치 페이지로 이동합니다.');
		setupPluginsPage();			
	} else {
		//alert('Papyrus Plug-In이 설치 되었습니다.');
		document.writeln("<embed id='" + id + "' TYPE='" + appType + "'");
		document.writeln(" width='"+eformWidth+"', height='"+eformHeight+"'");
		document.writeln(" text='Papyrus Reader Control' ");
		document.writeln("> </embed>");
	}
}

function setupPluginsPage() {
	$(location).attr('href','manualInstall.html');
}

function getPluginVersion() {
	var pluginChk = (navigator.mimeTypes[appType] != null);
	//alert('Papyrus Plug-In 체크 : '+pluginChk);
	if (pluginChk) {
		var plugin = navigator.mimeTypes[appType];
		var version = plugin.enabledPlugin.description;

		return version;
	} else {
		return '';
	}
}

function getNavigatorInfoStr() {
	if ($.browser.msie==true) {
		//alert("IE");
		browserCheck = 1;
	} else  {
		//alert("OTHER");
		browserCheck = 2;
	}

	return browserCheck;
}