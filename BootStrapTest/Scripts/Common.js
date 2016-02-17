
// 메인URL
var SHOP_MAIN_URL = "/Shop/Main";

var BOOT_TEST_URL = "/Home/Index";

var ADMIN_MAIN_URL = "/Admin/Main";

var ADMIN_LOGIN_URL = "/Admin/Login";

function CommonClass() {

    //** 브라우저명
    var m_AppName = navigator.appName;

    //** 브라우저 버전
    var m_AppVersion = parseFloat(navigator.appVersion.split("MSIE")[1]);

    // 기본 웹루트 입니다.
    var m_WebRoot = '';


    /************************************************************************
    함수명		: fn_IsTrustedIE
    작성목적	: ie일때 신뢰할 수 있는 사이트인지
    Parameter	: 
    Return		: 
    작 성 자	: 안제욱
    최초작성일	: 2015.12.08
    최종작성일	:
    수정내역	:
    *************************************************************************/
    function fn_IsTrustedIE() {
        try {
            var test = new ActiveXObject("Scripting.FileSystemObject");
        }
        catch (e) {
            return false;
        }

        return true;
    }

    /************************************************************************
    함수명		: fn_GetIEVersion
    작성목적	: ie 버전을 체크한다.
    Parameter	: 
    Return		: 브라우져 버전
    작 성 자	: 안제욱
    최초작성일	: 2015.12.08
    최종작성일	:
    수정내역	:
    *************************************************************************/
    this.GetIEVersion = function fn_GetIEVersion(width) {
        var iVersion = 0;
        if (m_AppName == "Microsoft Internet Explorer") {
            iVersion = m_AppVersion;
        }

        return iVersion;
    }

    /************************************************************************
    함수명		: fn_GetWidth
    작성목적	: 팝업창 실행시 IE의 종류에 따라 넓이를 계산해 준다.
    Parameter	: width -> 
    Return		: 브라우져 버전에 따른 창의 크기 반환
    작 성 자	: 안제욱
    최초작성일	: 2015.12.08
    최종작성일	:
    수정내역	:
    *************************************************************************/
    function fn_GetWidth(width) {

        var iWidth;
        iWidth = width;

        // IE6, 5.5 이면 +8을 한다.
        if ((m_AppName == "Microsoft Internet Explorer") && (m_AppVersion < 7)) {
            iWidth = parseInt(iWidth) + 8;
        }

        return iWidth;
    }

    /************************************************************************
    함수명		: fn_GetHeight
    작성목적	: 팝업창 실행시 IE의 종류에 따라 높이를 계산해 준다.
    Parameter	: height -> 
    Return		: IE에 따라 창의 크기 반환
    작 성 자	: 안제욱
    최초작성일	: 2015.12.08
    최종작성일	:
    수정내역	:
    *************************************************************************/
    function fn_GetHeight(height) {

        var iHeight;
        iHeight = height;

        // IE6,5.5 이면 +40을 한다.
        if ((m_AppName == "Microsoft Internet Explorer") && (m_AppVersion < 7)) {
            iHeight = parseInt(iHeight) + 35;//40
        }


        return iHeight;
    }

    /************************************************************************
    함수명		: fn_ModalOpen
    작성목적	: 모달 팝업창을 실행한다.(var params = window.dialogArguments;)
    Parameter	: 

    Return		: 모달창의 결과값 반환
    작 성 자	: 안제욱
    최초작성일	: 2015.12.08
    최종작성일	:
    수정내역	:
    *************************************************************************/
    this.ModalOpen = function fn_ModalOpen(callUrl, argument, width, height) {

        var strReturn;

        var strWidth = fn_GetWidth(width).toString();
        var strHeight = fn_GetHeight(height).toString();

        var strUrl = m_WebRoot + "/Common/Popup/Modal.htm";
        var arrArgument = new Array(self, callUrl, argument);

        var strFeature = "status:no;dialogWidth:" + strWidth + "px;dialogHeight:" + strHeight + "px;help:no;scroll:no;resizable:no;center:yes";

        strReturn = window.showModalDialog(strUrl, arrArgument, strFeature);

        return strReturn;

    }

    /************************************************************************
    함수명		: fn_ModalOpenScroll
    작성목적	: 모달 팝업창을 실행한다.(var params = window.dialogArguments;)
    Parameter	: 

    Return		: 모달창의 결과값 반환
    작 성 자	: 안제욱
    최초작성일	: 2015.12.08
    최종작성일	:
    수정내역	:
    *************************************************************************/
    this.ModalOpenScroll = function fn_ModalOpenScroll(callUrl, argument, width, height) {

        var strReturn;

        var strWidth = fn_GetWidth(width).toString();
        var strHeight = fn_GetHeight(height).toString();

        var strUrl = m_WebRoot + "/Common/Popup/ModalScroll.htm";
        var arrArgument = new Array(self, callUrl, argument);

        var strFeature = "status:no;dialogWidth:" + strWidth + "px;dialogHeight:" + strHeight + "px;help:no;scroll:yes;resizable:no;center:yes";

        strReturn = window.showModalDialog(strUrl, arrArgument, strFeature);

        return strReturn;

    }


    /************************************************************************
    함수명		: fn_ModelessPopup ShowModalessDialog
    작성목적	: 모달리스 팝업창을 실행한다.
    Parameter	: 

    Return		: 모달리스창의 결과값 반환
    작 성 자	: 안제욱
    최초작성일	: 2015.12.08
    최종작성일	:
    수정내역	:
    *************************************************************************/
    this.ModelessOpen = function fn_ModelessOpen(callUrl, argument, width, height) {

        var strReturn;

        var strWidth = fn_GetWidth(width).toString();
        var strHeight = fn_GetHeight(height).toString();

        var strUrl = m_WebRoot + "/Common/Popup/Modal.htm";
        var arrArgument = new Array(self, callUrl);

        var strFeature = "status:no;dialogWidth:" + strWidth + "px;dialogHeight:" + strHeight + "px;help:no;scroll:yes;resizable:no;center:yes ";

        strReturn = window.showModelessDialog(strUrl, arrArgument, strFeature);

        return strReturn;

    }

    /************************************************************************
    함수명		: fn_WindowOpen
    작성목적	: 일반 팝업창을 실행한다.
    Parameter	: 
    Return		: 일반창 오픈 후 결과값 반환
    작 성 자	: 안제욱
    최초작성일	: 2015.12.08
    최종작성일	:
    수정내역	:
    *************************************************************************/
    this.WindowOpen = function fn_WindowOpen(url, formNm, width, height, x, y) {

        var wHeight = window.screen.availHeight;
        var wWidth = window.screen.availWidth;

        //var strWidth = fn_GetWidth(width).toString();
        //var strHeight = fn_GetHeight(height).toString();

        var strWidth = width;
        var strHeight = height;

        var ileft = 0;
        var itop = 0;

        if (x == undefined || y == undefined) {
            ileft = parseInt((parseInt(wWidth) - parseInt(strWidth)) / 2);
            itop = parseInt((parseInt(wHeight) - parseInt(strHeight)) / 2);
        } else {
            ileft = x;
            itop = y;
        }
        if (ileft < 0) ileft = 0;
        if (itop < 0) itop = 0;

        var strFeature = "toolbar=no,menubar=no,statusbar=no,scrollbars=no,resizable=no,";

        var form = window.open(url, formNm, strFeature + "height=" + strHeight + ",width=" + strWidth + ",top=" + itop + ",left = " + ileft);
        try {
            form.focus();
        } catch (e) { }

    }


    /************************************************************************
    함수명		: fn_WindowOpenScroll
    작성목적	: 스크롤이 가능한 일반 팝업창을 실행한다. 
    Parameter	: 
    Return		: 스크롤이 가능한 일반창 오픈 후 결과값 반환
    작 성 자	: 안제욱
    최초작성일	: 2015.12.08
    최종작성일	:
    수정내역	:
    *************************************************************************/
    this.WindowOpenScroll = function fn_WindowOpenScroll(url, formNm, width, height, x, y) {

        var wHeight = window.screen.availHeight;
        var wWidth = window.screen.availWidth;

        //var strWidth = fn_GetWidth(width).toString();
        //var strHeight = fn_GetHeight(height).toString();

        var strWidth = width;
        var strHeight = height;

        var ileft = 0;
        var itop = 0;

        if (x == undefined || y == undefined) {
            ileft = parseInt((parseInt(wWidth) - parseInt(strWidth)) / 2);
            itop = parseInt((parseInt(wHeight) - parseInt(strHeight)) / 2);
        } else {
            ileft = x;
            itop = y;
        }
        if (ileft < 0) ileft = 0;
        if (itop < 0) itop = 0;

        var strFeature = "toolbar=no,menubar=no,statusbar=no,scrollbars=yes,resizable=no,";

        var form = window.open(url, formNm, strFeature + "height=" + strHeight + ",width=" + strWidth + ",top=" + itop + ",left = " + ileft);
        try {
            form.focus();
        } catch (e) { }

    }

    /************************************************************************
    함수명		: fn_WindowOpenResize
    작성목적	: 일반 팝업창을 실행한다. 스크롤과 리사이즈가 가능.
    Parameter	: 
    Return		: 일반창 오픈 후 결과값 반환
    작 성 자	: 안제욱
    최초작성일	: 2015.12.08
    최종작성일	:
    수정내역	:
    *************************************************************************/
    this.WindowOpenResize = function fn_WindowOpenResize(url, formNm, width, height) {

        var wHeight = window.screen.availHeight;
        var wWidth = window.screen.availWidth;

        //var strWidth = fn_GetWidth(width).toString();
        //var strHeight = fn_GetHeight(height).toString();

        var strWidth = width;
        var strHeight = height;

        var ileft = 0;
        var itop = 0;

        ileft = parseInt((parseInt(wWidth) - parseInt(strWidth)) / 2);
        itop = parseInt((parseInt(wHeight) - parseInt(strHeight)) / 2);

        if (ileft < 0) ileft = 0;
        if (itop < 0) itop = 0;

        var strFeature = "toolbar=no,menubar=no,statusbar=no,scrollbars=yes,resizable=yes,";

        var form = window.open(url, formNm, strFeature + "height=" + strHeight + ",width=" + strWidth + ",top=" + itop + ",left = " + ileft);
        try {
            form.focus();
        } catch (e) { }

    }

    /************************************************************************
    함수명		: fn_WindowOpenBlank
    작성목적	: 새창을 실행한다.
    Parameter	: 
    Return		: 
    작 성 자	: 안제욱
    최초작성일	: 2015.12.08
    최종작성일	:
    수정내역	:
    *************************************************************************/
    this.WindowOpenBlank = function fn_WindowOpenBlank(url, formNm, width, height) {

        var wHeight = window.screen.availHeight;
        var wWidth = window.screen.availWidth;

        //var strWidth = fn_GetWidth(width).toString();
        //var strHeight = fn_GetHeight(height).toString();

        var strWidth = width;
        var strHeight = height;

        var ileft = 0;
        var itop = 0;

        ileft = parseInt((parseInt(wWidth) - parseInt(strWidth)) / 2);
        itop = parseInt((parseInt(wHeight) - parseInt(strHeight)) / 2);

        if (ileft < 0) ileft = 0;
        if (itop < 0) itop = 0;

        var strFeature = "toolbar=yes,menubar=yes,statusbar=yes,scrollbars=yes,resizable=yes,";

        var form = window.open(url, formNm, strFeature + "height=" + strHeight + ",width=" + strWidth + ",top=" + itop + ",left = " + ileft);
        try {
            form.focus();
        } catch (e) { }

    }


    /************************************************************************
    함수명		: RenderNode
    작성목적	: Xml 문자열과 Xsl을 transform 하여 div의 innerHTML로 넣어준다.
    Parameter 	: xmlStr : xml문자열, xslUrl : xsl주소, paneId : 결과를 넣을 div 아이디
    Return		: void
    작 성 자	: 안제욱
    최초작성일	: 2015.12.08
    최종작성일	:
    수정내역	:
    *************************************************************************/
    this.RenderNode = function fn_RenderNode(xmlStr, xslUrl, paneId) {
        try {
            if (window.ActiveXObject) {
                var xmlDoc;
                var xslDoc;

                xmlDoc = new ActiveXObject("Microsoft.XMLDOM");
                xmlDoc.async = false;
                xmlDoc.loadXML(xmlStr);

                xslDoc = new ActiveXObject("Microsoft.XMLDOM");
                xslDoc.async = false;
                xslDoc.load(xslUrl);

                document.getElementById(paneId).innerHTML = "";
                document.getElementById(paneId).innerHTML = xmlDoc.transformNode(xslDoc);
            } else if (document.implementation.createDocument) {
                // 파이어폭스, 크롬, 사파리에서는 아래의 코드를 사용한다.
                $('#' + paneId).getTransform(
                    xslUrl,
                    xmlStr.replace("<!--[CDATA[", "<![CDATA[").replace("]]-->", "]]>")
                );
                //                var xmlParser = new DOMParser();
                //                var xmlDoc = xmlParser.parseFromString(xmlStr, "text/xml");
                //                xmlDoc.setProperty("SelectionLanguage", "XPath");

                //                var xslDoc = Sarissa.getDomDocument();
                //                xslDoc.loadXML(xmlStr);
                //                // the following two lines are needed for IE
                //                xslDoc.setProperty("SelectionLanguage", "XPath");

                //                document.getElementById(paneId).innerHTML = xmlDoc.transformNode(xslDoc);
            } else {
                alert("Your browser cannot handle this script");
            }
        } catch (exception) {
            alert("시스템 오류입니다. " + exception.description);
        }
    }

    /************************************************************************
    함수명		: DelComma
    작성목적	: 콤마 제거하기
    Parameter 	:
    Return		: void
    작 성 자	: 안제욱
    최초작성일	: 2015.12.08
    최종작성일	:
    수정내역	:
    *************************************************************************/
    this.DelComma = function DelComma(value, obj) {
        var result = value.replace(/,/gi, "");
        if (obj != null) {
            obj.value = result;
        }
        return result;
    }

    /************************************************************************
    함수명		: AddComma
    작성목적	: 콤마 추가하기
    Parameter 	:
    Return		: void
    작 성 자	: 안제욱
    최초작성일	: 2015.12.08
    최종작성일	:
    수정내역	:
    *************************************************************************/
    this.AddComma = function AddComma(value, obj) {
        var loop = /^\$|,/g;
        var result = "0";
        //콤마제거
        value = (value + '').replace(loop, "");

        if (isNaN(value)) {
            if (obj != null) {
                obj.value = "0";
            }
            return "0";
        }
        else {
            var comma = new RegExp('([0-9])([0-9][0-9][0-9][,.])');
            var data = value.split('.');
            data[0] += '.';
            do {
                data[0] = data[0].replace(comma, '$1,$2');
            } while (comma.test(data[0]));

            if (data.length > 1) {
                result = data.join('');
            }
            else {
                result = data[0].split('.')[0];
            }
            if (obj != null) {
                obj.value = result;
            }
            return result;
        }
    }

    /************************************************************************
    함수명		: XmlUpdate
    작성목적	: xml 내용 업데이트
    Parameter 	:
    Return		: void
    작 성 자	: 안제욱
    최초작성일	: 2015.12.08
    최종작성일	:
    수정내역	:
    *************************************************************************/
    this.XmlUpdate = function XmlUpdate(xmlData, xpath, fieldObj, type) {
        var value = "";
        if (type == "number") {
            var number = new Number(fieldObj.value);
            if (isNaN(number)) {
                alert("숫자 표현이 올바르지 않습니다.");
                return false;
            }
            if (fieldObj.value == "") {
                fieldObj.value = "0";
            }
            if (number < 0) {
                alert("양수만 입력 가능합니다.");
                return false;
            }
            value = fieldObj.value;
        } else if (type == "date") {
            var dateexp = new RegExp(/\d{4}-(0[0-9]|1[0-2])-([0-3][0-9])/);
            if (!dateexp.test(fieldObj.value)) {
                alert("날짜 형식만 입력가능합니다.");
                $(fieldObj).addClass("invalidinput")
                return false;
            }
            value = fieldObj.value;
        }
        else if (type == "select") {
            value = $(fieldObj).find(":selected").attr("value");
        } else {
            value = fieldObj.value;
        }

        $(fieldObj).removeClass("invalidinput")

        var bodyNode = xmlData;
        var dataNode = bodyNode.selectSingleNode(xpath);

        if (dataNode == null) {
            alert("관리자에게 문의하세요.\n문서노드:" + dataNode + "(xpath:" + xpath + ")\n필드노드:" + fieldObj);
            return false;
        }

        if (dataNode.nodeType == 2) //node가 attribute일 때
        {
            dataNode.value = value;
        }
        else {
            var cdata = xmlData.createCDATASection(value);
            dataNode.text = "";
            dataNode.appendChild(cdata);
        }

        //현재노드 값 변경 확인하기
        //alert(bodyNode.selectSingleNode(xpath).text);
    }



    /************************************************************************
    함수명		: EnableTableHeader
    작성목적	: 스크롤 고정하기 활성화
    Parameter 	:
    Return		: void
    작 성 자	: 안제욱
    최초작성일	: 2015.12.08
    최종작성일	:
    수정내역	:
    *************************************************************************/
    var cloneTable = null;
    this.EnableTableHeader = function fn_EnableTableHeader(targetTableId) {
        if (m_AppName != "Netscape") {
            if (cloneTable == null) {
                cloneTable = $("#" + targetTableId).clone();
                cloneTable.find("tbody").remove();
                cloneTable.css("position", "absolute");
                cloneTable.css("width", $("#" + targetTableId).width());
                $('body').append(cloneTable);
                cloneTable.hide();
            }

            $(window).on("scroll", function () {
                if ($(window).scrollTop() > $("#" + targetTableId).position().top
                && $(window).scrollTop() < $("#" + targetTableId).position().top + $("#" + targetTableId).height()) {
                    cloneTable.show();
                    cloneTable.css("top", $(window).scrollTop());
                    cloneTable.css("left", $("#" + targetTableId).position().left + $("#wrap").position().left);
                } else {
                    if (cloneTable != null) {
                        cloneTable.hide();
                    }
                }
            });
        }
    }

    /************************************************************************
    함수명		: fn_ZipCodeOpen
    작성목적 	: 우편번호 팝업
    Parameter	: closeHandler - 완료시 실행될 함수
    Return		: 
    작 성 자	: 안제욱
    최초작성일	: 2015.12.08
    최종작성일	:
    수정내역	:
    *************************************************************************/
    this.ZipCodeWindowId = "";
    this.ZipCodeOpen = function fn_ZipCodeOpen(windowid, closeHandler) {
        this.ZipCodeWindowId = windowid;

        /*
        //팝업 생성
        $("#" + windowid).kendoWindow(
        {
            modal: true,
            iframe: true,
            draggable: true,
            title: "우편번호 찾기",
            resizable: false,
            content: "/ZipCode/ZipCode/ZipCodePop?closeHandler=" + closeHandler,
            width: 570,
            height: 440//,
            //actions: ["Close"]
        });

        var kendoWindow = $("#" + windowid).data("kendoWindow");
        kendoWindow.open();
        kendoWindow.center();
        */

        window.open("/ZipCode/ZipCode/ZipCodePop?closeHandler=" + closeHandler, "ZipCodePopup", "width=570, height=440, scrollbars=yes, resizable=no, toolbar=no, status=yes");
    }

    //닫기 함수는 내부적으로 실행됨
    this.ZipCodeClose = function fn_ZipCodeClose() {
        //var kendoWindow = $("#" + this.ZipCodeWindowId).data("kendoWindow");
        //kendoWindow.close();

        window.close();
    }



    /************************************************************************
    함수명		: fn_ReportOpenResize, fn_ReportOpenResizeSized
    작성목적 	: 리포트뷰어 팝업
    Parameter	: report - 리포트파일명 (경로가 있을 경우 경로/파일명, 경로/경로/파일명...)
                    params - 리포트파일에 전달할 파라미터 (코드=값&코드=값& ... 형식)
                    width - 팝업에 쓰일 창의 가로 사이즈
                    Height - 팝업에 쓰일 창의 세로 사이즈
    Return		: 
    작 성 자	: 안제욱
    최초작성일	: 2015.12.08
    최종작성일	:
    수정내역	:
    *************************************************************************/
    this.ReportOpenResize = function fn_ReportOpenResize(report, params, width, height) {
        var url = "http://192.168.2.11:8088/viewer.aspx?rptname=KTCmeter/{1}&rptdb=Ora2&{2}";
        url = url.replace("{1}", report);
        url = url.replace("{2}", params);
        this.WindowOpenResize(url, "Report", width, height);
    };

    this.ReportOpenResizeSized = function fn_ReportOpenResizeSized(report, params) {
        //alert(params);
        this.ReportOpenResize(report, params, 1024, 768);
    };

    this.PdfOpen = function fn_PdfOpen(atchmnflClCode, filePath) {
        var strFeature = "toolbar=no,menubar=no,statusbar=no,scrollbars=no,resizable=no,height=700,width=900";
        var form = window.open("/Content/PdfViewer/onlyview.aspx?atchmnflClCode=" + atchmnflClCode + "&filePath=" + filePath, "PdfViewer", strFeature);
        form.focus();
    };

    this.PdfOpen2 = function fn_PdfOpen(atchmnflClCode, filePath, fomConfmSn, fomConfmIssuSn) {
        var strFeature = "toolbar=no,menubar=no,statusbar=no,scrollbars=no,resizable=no,height=700,width=900";
        var form = window.open("/Content/PdfViewer/view.aspx?atchmnflClCode=" + atchmnflClCode + "&filePath=" + filePath + "&fomConfmSn=" + fomConfmSn + "&fomConfmIssuSn=" + fomConfmIssuSn, "PdfViewer", strFeature);
        form.focus();
    };
}

// 스크립트 선언
var Common = new CommonClass();

// 문자열 함수 확장하기
String.format = function (text) {
    if (arguments.length <= 1) {
        return text;
    }
    var tokenCount = arguments.length - 2;
    for (var token = 0; token <= tokenCount; token++) {
        text = text.replace(new RegExp("\\{" + token + "\\}", "gi"), arguments[token + 1]);
    }
    return text;
};

String.prototype.ltrim = function () {
    var re = /\s*((\S+\s*)*)/;
    return this.replace(re, "$1");
}

String.prototype.rtrim = function () {
    var re = /((\s*\S+)*)\s*/;
    return this.replace(re, "$1");
}

String.prototype.trim = function () {
    return this.ltrim().rtrim();
}

String.prototype.padleft = function (len, str) {
    var s = this, str = str || '0';
    while (s.length < len) {
        s = str + s;
    }
    return s;
}

Number.prototype.padleft = function (len, str) {
    var s = String(this), str = str || '0';
    while (s.length < len) {
        s = str + s;
    }
    return s;
}

jQuery.fn.xml = function (s) {
    return this[0].xml || (new XMLSerializer()).serializeToString(this[0]).replace(' xmlns="http://www.w3.org/1999/xhtml"', '');
}

//사이트 선택, 컨텍스트 메뉴 막기
$(function () {
    //    document.onkeydown = function(){
    //        if(event.srcElement.type != "text" && event.srcElement.type != "textarea")
    //        {
    //            if(event.keyCode == 116){
    //                event.keyCode = 2;
    //                return false;
    //            }else if(event.ctrlKey && (event.keyCode == 78 || event.keyCode == 82)){
    //                return false;
    //            }else if(event.keyCode == 8){
    //                return false;
    //            }
    //        }
    //    }
    //    document.ondragstart = function(){
    //        if(event.srcElement.type != "text" && event.srcElement.type != "textarea")
    //        {
    //            return false;
    //        }
    //    }
    //    document.onselectstart = function(){
    //        if(event.srcElement.type != "text" && event.srcElement.type != "textarea"){
    //            return false;
    //        }
    //    }
    //    document.oncontextmenu = function(){
    //        if(event.srcElement.type != "text" && event.srcElement.type != "textarea"){
    //            return false;
    //        }
    //    }
});


//-------------------------------------------
// jquery validate 추가 메소드
//-------------------------------------------

//사업자번호 유효성 체크
jQuery.validator.addMethod("bssn", function (value, element) {
    value = value.replace("-", "");
    value = value.replace("-", "");

    var sum = 0;
    var chkValue = new Array(10);
    for (var i = 0; i < 10; i++) chkValue[i] = parseInt(value.charAt(i));
    var multipliers = [1, 3, 7, 1, 3, 7, 1, 3];

    for (i = 0; i < 8; i++) sum += (chkValue[i] *= parseInt(multipliers[i]));

    var chkTemp = chkValue[8] * 5 + '0';
    chkValue[8] = parseInt(chkTemp.charAt(0)) + parseInt(chkTemp.charAt(1));
    var chkLastid = (10 - (((sum % 10) + chkValue[8]) % 10)) % 10;

    if (chkValue[9] != chkLastid) {
        return false;
    }
    return true;
}, "유효하지 않은 사업자등록번호 입니다.");

//비밀번호 패턴 체크 (영문, 특수문자, 숫자포함 체크)
jQuery.validator.addMethod("passwordPattern", function (value, element) {
    /*
    var special_pattern = /[`~!@+_#$%^&*|\\\'\";:\/?]/gi;
    if( special_pattern.test(value) == false ){
        return false;
    }
    */
    var special_pattern = /[0-9]/gi;
    if (special_pattern.test(value) == false) {
        return false;
    }
    special_pattern = /[a-zA-Z]/gi;
    if (special_pattern.test(value) == false) {
        return false;
    }
    return true;
}, "비밀번호는 영문,숫자,특수문자를 포함해야 합니다.");

//영문,숫자만 입력가능
jQuery.validator.addMethod("engOrNumber", function (value, element) {
    var special_pattern = /^[0-9a-zA-Z]+$/gi;
    if (special_pattern.test(value) == false) {
        return false;
    }
    return true;
}, "영문 또는 숫자만 입력 가능 합니다.");

//날짜 전 확인
jQuery.validator.addMethod("beforedate", function (value, element, param) {
    //뒷날짜에 지정하기
    return value >= $(param).val();
}, "날짜가 올바르게 입력되지 않았습니다.");

// 입력값 Y 체크
jQuery.validator.addMethod("chkYes", function (value, element) {

    var chkPattern = "Y";

    if (chkPattern.test(value) == false) {
        return false;
    }
    return true;
}, "입력값 확인해주세요.");
