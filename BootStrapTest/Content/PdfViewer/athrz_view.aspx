﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="athrz_view.aspx.cs" Inherits="Ktc.Meter.FrontWeb.Content.PdfViewer.view" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" xml:lang="ko">
<head>
<title></title>
<meta http-equiv="Content-Type" content="text/html; charset=UTF-8"/>
<link href="css/style.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="js/papyrusPlugin-1.0.js"></script>
<script type="text/javascript" src="js/Markany.js?2013051111111882"></script>
<script type="text/javascript" src="js/jquery-1.7.1.min.js"></script>
<script type="text/javascript">
    //var FileRootPath = "E:/web_file/KtcRepository/";
    //var FileRootPath = "D:/Temp/KtcRepository/";
    //var RootUrl = "http://118.46.174.184/";
    var RootUrl = "http://118.46.174.184/";
</script>
</head>
<body class="body">
    <input type="hidden" name="athrzSn" id="athrzSn" value="<%= Request["athrzSn"] %>" />
    <input type="hidden" name="athrzCnfrmnIssuSn" id="athrzCnfrmnIssuSn" value="<%= Request["athrzCnfrmnIssuSn"] %>" />
    <input type="hidden" name="athrzCnfrmnIssuDetailSn" id="athrzCnfrmnIssuDetailSn" value="<%=Request["athrzCnfrmnIssuDetailSn"] %>" />
	<table width="100%" height="100%" border="0">
		<tr>
			<td id="listBoxTd" height="30px" class="toolbar" align="left" style="border-top:0px;">
				<img src="images/seperator.gif">
                <!--
				<img src="images/open.png" title="열기" id="pdfOpen">
				<img src="images/save.png" title="저장" id="save">
                -->
				<img src="images/print.png" title="인쇄" id="print">
				<img src="images/seperator.gif">
				<img src="images/zoomin.png" title="확대" id="zoomIn">
				<img src="images/zoomout.png" title="축소" id="zoomOut">
				<img src="images/fit_actual.png" title="실제크기" id="fitActualSize">
				<img src="images/fit_width.png" title="폭맞춤" id="fitWidth">
				<img src="images/fit_height.png" title="높이맞춤" id="fitHeight">
				<img src="images/seperator.gif">
				<img src="images/onepage.png" title="단면 보기" class="changeDisplayMode" alt="0">
				<img src="images/onepage_c.png" title="연속 보기" class="changeDisplayMode" alt="1">
				<img src="images/twopage.png" title="양면 보기" class="changeDisplayMode" alt="2">
				<img src="images/twopage_c.png" title="연속 양면 보기" class="changeDisplayMode" alt="3">
				<img src="images/seperator.gif">
				<img src="images/rotateccw.png" title="반시계방향향회전" id="rotateCCW">
				<img src="images/rotatecw.png" title="시계방향회전" id="rotateCW">

			</td>
		</tr>
		<tr>
			<td style="display:block" height="100%">
				<script type="text/javascript">
				    MarkanyPlugInCheck();
				    epapyrus_control();
				</script>
			</td>
		</tr>
		<tr>
			<td height="30px" id="Td1" height="30px" class="toolbar" align=center>
				<img src="images/first-page.png" border="0" align="absmiddle" style="cursor:pointer;" alt="첫 페이지" id="goToFirstPage">
				<img src="images/prev-page.png" border="0" align="absmiddle" style="cursor:pointer" alt="이전 페이지" id="goToPreviousPage">
				<input type="text" name="currentPage" id="currentPage" style="width:50px;border:none;">
				/ <input type="text" name="pageCount" id="pageCount" style="width:50px;border:none;" readonly>
				<img src="images/next-page.png" border="0" align="absmiddle" style="cursor:pointer" alt="다음 페이지" id="goToNextPage">
				<img src="images/last-page.png" border="0" align="absmiddle" style="cursor:pointer" alt="마지막 페이지" id="goToLastPage">
			</td>
		</tr>
	</table>
</body>
<script type="text/javascript">
    $(document).ready(function () {
        init();
    });

    /* 일반 API 함수 Start */
    $(function () {
        $('#textWatermark').click(function () {
            PapyrusObject.addTextWatermark("TEXT_WARTERMARK!!!", "Tahoma", 30, 3, 0.0, 0.0, 50, true, true, 0, 0, 0, 1);
            PapyrusObject.addTextWatermark("TEXT_WARTERMARK!!!", "Tahoma", 30, 6, 0.0, 0.0, 50, true, true, 0, 0, 0, 1);
        });

        $('#imageWatermark').click(function () {
            PapyrusObject.addImageWatermark('C:/papyrus-plugin_sample/sample_PDF/logo.jpg', 0, 0.0, 0.0, 50, 30, true, true, 1);
        });

        $('#lockOn').click(function () {
            PapyrusObject.lockAnnots(0, true);
        });

        $('#lockOff').click(function () {
            PapyrusObject.lockAnnots(0, false);
        });

        //////////////////////////////

        $('#pdfOpen').click(function () {
            //PapyrusObject.open();
            PapyrusObject.enableFullScreenWin32(true);
        });

        $('#save').click(function () {
            //save();
            PapyrusObject.enableFullScreenWin32(false);
        });

        $('#print').click(function () {
            //PapyrusObject.addTextWatermark("원본", "궁서체", 30, 3, 0.0, 0.0, 50, true, true, 0, 0, 0, 1);
            //PapyrusObject.setProperty("security-handler:pcpandcp-data","img01KTC.dat,MaPrintInfoStd.dat,,궁서체,본,2");
            var result = PapyrusObject.print();

            // 출력하면 출력여부 업데이트 (-1이 아닌 경우만 인쇄 성공)
            if (result != -1) {
                $.ajax({
                    type: "POST",
                    async: false,
                    url: "/Ipt/UpdateInspectionCnfrmnIssuPrintState",
                    data: { "athrzSn": $("#athrzSn").val(), "athrzCnfrmnIssuSn": $("#athrzCnfrmnIssuSn").val(), "athrzCnfrmnIssuDetailSn": $("#athrzCnfrmnIssuDetailSn").val() },
                    dataType: "JSON",
                    success: function (data) {
                        opener.document.location.reload();
                        window.close();
                    },
                    error: function (xhr, status, error) {
                        alert(error);
                    }
                });
            }
        });

        $('#zoomIn').click(function () {
            PapyrusObject.zoomIn();
        });

        $('#zoomOut').click(function () {
            PapyrusObject.zoomOut();
        });

        $('#fitActualSize').click(function () {
            PapyrusObject.fitActualSize();
        });


        $('#fitWidth').click(function () {
            PapyrusObject.fitWidth();
        });

        $('#fitHeight').click(function () {
            PapyrusObject.fitHeight();
        });

        $('.changeDisplayMode').click(function () {
            PapyrusObject.changeDisplayMode($(this).attr('alt'));
        });

        $('#rotateCW').click(function () {
            PapyrusObject.rotateCW();
        });

        $('#rotateCCW').click(function () {
            PapyrusObject.rotateCCW();
        });

        $('.setTool').click(function () {
            PapyrusObject.setTool($(this).attr('alt'));
        });

        $('#enableBookMark').click(function () {
            PapyrusObject.enableBookMark(true);
        });

        $('#enableThumbnail').click(function () {
            PapyrusObject.enableThumbnail(true);
        });

        $('#goToFirstPage').click(function () {
            PapyrusObject.goToFirstPage();
        });

        $('#goToLastPage').click(function () {
            PapyrusObject.goToLastPage();
        });

        $('#goToPreviousPage').click(function () {
            PapyrusObject.goToPreviousPage();
        });

        $('#goToNextPage').click(function () {
            PapyrusObject.goToNextPage();
        });

        $('#currentPage').keydown(function (event) {
            if (event.keyCode == 13) {
                var pageNum = $('#currentPage').val();
                PapyrusObject.goToPage(pageNum - 1);
            }
        });

    });

    function init() {
        window.focus();

        loadDoc();
    }

    function loadDoc() {
        //loadPdfFile();
        PapyrusObject.openUrl(RootUrl, '<%= Request["atchmnflClCode"] %>' + '<%= Request["filePath"] %>', 80);
    }

    function loadPdfFile() {
        PapyrusObject.setProperty("security-handler:drm-captureMode", "1");	// 화면 캡처 방지 기능 작동

        PapyrusObject.setProperty("security-handler:drm-onlyprintscreen", "1");	// 화면 캡처 방지 기능 작동.

        //alert(FileRootPath);
        //alert('<%= Request["atchmnflClCode"] %>');
        //alert('<%= Request["filePath"] %>');
        var loadFilePathName = FileRootPath + '<%= Request["atchmnflClCode"] %>' + '<%= Request["filePath"] %>';
        //alert(loadFilePathName);
        PapyrusObject.loadPdfFile(loadFilePathName);
}

function openUrl() {
    PapyrusObject.openUrl("211.174.156.100", "/sdp7/test.dap", 8080);
}

function save() {
    var ret = PapyrusObject.countWordInEachPage("D:\\temp\\test.dap", "한차임");

    alert(ret);
}

function saveAs() {
    PapyrusObject.saveAs();
}

function saveAsFile() {
    PapyrusObject.saveAsFile('C:/papyrus-plugin_sample/saveAs.pdf');
}

function closeDoc() {
    PapyrusObject.closeDoc();
}

function fitWidthHeight() {
    // 화면크기에 맞춤
    PapyrusObject.fitWidthHeight();
}

function search() {
    var keyword = $('#text_box1').val();
    if (keyword == '' || keyword == null) {
        alert('검색어를 입력해 주십시오.');
        return;
    } else {
        var result = PapyrusObject.find(keyword);
        alert(result);
    }
}

function pdfLoaded() {
    var pageCount = PapyrusObject.pageCount();
    $('#pageCount').val(pageCount);
}

function broadcastCurrentPageNumber(pageNum) {
    $('#currentPage').val(pageNum);
}

function currentPage() {
    var pageNum = PapyrusObject.currentPage();
    alert(pageNum);
}

function setPanelWidth() {
    PapyrusObject.setPanelWidth(100);
}

function deleteOpenedFile() {
    PapyrusObject.deleteOpenedFile();
}

function windowsTempFolderPath() {
    var rst = PapyrusObject.windowsTempFolderPath();
    alert(rst);
}
/* 일반 API 함수 End */

/* 서식 API 함수 Start */
function widgetValue() {
    alert("1page의 성명(업체명)란에 입력된 값을 취득하여 텍스트박스에 나타냅니다.");
    var result = PapyrusObject.widgetValue('TF_NAME_KR');
    document.getElementById('text_box1').value = result;
}

function setFormValue() {
    alert("텍스트박스에 입력한 값을 1page의 성명(업체명)란에 설정합니다.");
    var rst = $('#text_box1').val();
    PapyrusObject.setFormValue('TF_NAME_KR', rst);
}

function checkRequiredFields() {

    alert("붉은색 테두리가 있는 항목은 모두 필수 항목입니다");
    var result = PapyrusObject.checkRequiredFields();
    if (result == true) {
        alert("필수항목체크 OK");
    } else {
        alert("1개 이상의 필수항목 값이 설정되어있지않습니다.");
    }
}

function setFormValueForPage() {
    var rst = $('#text_box1').val();
    PapyrusObject.setFormValueForPage('TF_NAME_KR', rst, 2);
}

function flattenFormFields() {
    alert("현재 열려있는 PDF의 서식필드를 모두 제거하고 일반PDF로 저장시킵니다.");
    PapyrusObject.flattenFormFields();
    PapyrusObject.saveAs();
}

function insertSignature() {
    alert("PKI서명 인증창을 오픈시킵니다");
    var rst = PapyrusObject.insertSignature(100, 100, 100, 1);
}

function executeJavaScript() {
    alert("1page의 e-mail 수신여부의 승낙여부에 따라 e-mail 주소 입력란을 필수항목 여부를 바꾸어 줌");

    var string = "var ch = this.getField('EMAIL_CHECK');" +
			 "var adr1 = this.getField('TF_USER_EMO');" +
			 "if (ch.value == 'On')" +
			"{" +
			" adr1.required = true;" +
			"}" +
			"else" +
			"{" +
			" adr1.required = false;" +
			"}" +
			"pdfDoc.update()";

    PapyrusObject.executeJavaScript(string);
}

function widgetCenterOn() {
    alert("지정한 서식필드(1page의 직장전화)로 화면을 이동시킵니다.");
    PapyrusObject.widgetCenterOn("TF_CORP_TELO", -1);
}

function exportXmlData() {
    alert("C:/papyrus-plugin_sample/export_data.xml이 생성됩니다.");
    PapyrusObject.exportXmlData('C:/papyrus-plugin_sample/export_data.xml');
}

function appendPdfFile() {
    alert("현재 열려있는 PDF파일의 뒤에 C:/papyrus-plugin_sample/sample_PDF/append_test.pdf을 이어붙입니다");
    PapyrusObject.appendPdfFile("C:/papyrus-plugin_sample/sample_PDF/append_test.pdf");
}

/* 서식 API 함수 End */

/* 프로퍼티  Start */
function propertySet() {
    PapyrusObject.setProperty("msgbox:notify-read-only-mode", "false");
}

function propertySet2() {
    PapyrusObject.setProperty("msgbox:notify-read-only-mode", "true");
}
/* 프로퍼티  End */

//signals
PapyrusObject.pdfLoaded = function () {
    pdfLoaded();
}

PapyrusObject.broadcastCurrentPageNumber = function (pageNum) {
    broadcastCurrentPageNumber(pageNum);
}
</script>

<script>
    //signals for ie

    function PapyrusObject::pdfLoaded() {
        pdfLoaded();
    }

    function PapyrusObject::broadcastCurrentPageNumber(pageNum) {
        broadcastCurrentPageNumber(pageNum);
    }

    function PapyrusObject::Downloaded(docId, docSer) {
        alert("Downloaded");
        PapyrusObject.openScourtDocument(docId, docSer);
    }

    function PapyrusObject::Opened(docId, docSer) {
        alert("Opened" + docId + docSer);
    }

    function PapyrusObject::Downloaded(docId, docSer) {
        alert("Downloaded");
        PapyrusObject.openScourtDocument(docId, docSer);
    }

</script>

<script type="text/javascript">

</script>


</html>
