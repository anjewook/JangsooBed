	var _os  = navigator.userAgent;  
	var _app = navigator.appName;
	if (_app == "Microsoft Internet Explorer") {
		document.writeln("<OBJECT ID='MAOnFPS_KTC'  WIDTH='0' HEIGHT='0' ");
		document.writeln("CLASSID='CLSID:F02D2F1D-96FF-47DD-AE93-66480D33C0C8' ");
		document.writeln("CODEBASE='MAePageSaferKTC.cab#version=2,5,0,1' >");
		document.writeln("</OBJECT>");	
	} else {	
	/*	navigator.plugins.refresh(false);
		if(!navigator.mimeTypes["application/markany_fps_rp_plugin/version=1,0,0,1"])
			window.location = "Install_Page.html";
	*/	
	}
	
	if((typeof(MAOnFPS_KTC) == "object") && (MAOnFPS_KTC.object != null)){
		document.writeln("ActiveX installed");
	}else{
		document.writeln("It doesn't install yet. Please install ActiveX.");
	}
