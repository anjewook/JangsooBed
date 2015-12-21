function MarkanyPlugInCheck() {
    var _os = navigator.userAgent;
    var _app = navigator.appName;

    if (_app == "Microsoft Internet Explorer") {
        document.writeln("<OBJECT ID='MAOnFPS_KBIZRP'  WIDTH='0' HEIGHT='0' ");
        document.writeln("CLASSID='CLSID:F02D2F1D-96FF-47DD-AE93-66480D33C0C8' ");
        document.writeln("CODEBASE='MAePageSaferKTC.cab#version=2,5,0,1' >");
        document.writeln("</OBJECT>");
        /*
        if ((typeof (MAOnFPS_KBIZRP) == "object") && (MAOnFPS_KBIZRP.object != null)) {
        } else {
            document.location.href = "markanymanualInstall.html";
        }
        */
    } else {
    
        /*	navigator.plugins.refresh(false);
        if(!navigator.mimeTypes["application/markany_fps_rp_plugin/version=1,0,0,1"])
            window.location = "Install_Page.html";
        */
    }
}

