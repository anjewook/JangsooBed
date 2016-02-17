
var baseUrl = "/Admin";

$(document).ready(function () {

    if (SearchType == "") {
        SearchType = "01";
    }

    $("#SearchType").val(SearchType);
    $("#SearchText").val(SearchText);
    
    $("#SearchText").keypress(function (event) {
        if (event.which == 13) {
            fn_Search();
        }
    });

    $("#btnSearch2").click(function () {
        fn_Order();
    });

    $("#btnReset").click(function () {
        $("#SearchArea :input").val("");
    });

    $("#btnCreate").click(function () {
        // $(location).attr("href", baseUrl + "/BbscttRegist?BbsSn=" + BbsSn + "&menuCode=" + menuCode);
        // 관리자 등록시 레이어팝
    });
    
    $("#btnRegistPop").click(function () {
        var html = $(this).parent().html();
        //html = cleanSource(html);
        //$("#modal pre").text(html);
        $("#viewModal").removeAttr();
        $("#myModal").modal();
    });

    // 관리자목록
    $("#mgrList").click(function () {
        fn_mgrList();
    });

    // 권한목록
    $("#mgrAuthList").click(function () {
        fn_mgrAuthList();
    });
    
});

function fn_mgrList() {

    var url = baseUrl + "/Main";

    url += "?page=1";
    url += "&SearchType=" + $("#SearchType").val();
    url += "&SearchText=" + $("#SearchText").val();
    //url += "&BbsSn=" + BbsSn;
    //url += "&OrderColumn=" + OrderColumn;
    //url += "&OrderType=" + OrderType;

    $(location).attr("href", url);
}

function fn_mgrAuthList() {

    var url = baseUrl + "/ManagerAuth";

    url += "?page=1";
    url += "&SearchType=" + $("#SearchType").val();
    url += "&SearchText=" + $("#SearchText").val();

    $(location).attr("href", url);
}

function fn_Search() {

    var url = baseUrl + "/Main";

    url += "?page=1";
    //url += "&BbsSn=" + BbsSn;
    url += "&SearchType=" + $("#SearchType").val();
    url += "&SearchText=" + $("#SearchText").val();
    //url += "&OrderColumn=" + OrderColumn;
    //url += "&OrderType=" + OrderType;

    $(location).attr("href", url);
}

function fn_Order(OrderColumn, OrderType) {
    //alert("OrderColumn : " + OrderColumn);
    //alert("OrderType : " + OrderType);

    var url = baseUrl + "/Main";

    url += "?page=" + page;
    url += "&BbsSn=" + BbsSn;
    url += "&SearchStartDate=" + $("#SearchStartDate").val();
    url += "&SearchEndDate=" + $("#SearchEndDate").val();
    url += "&SearchType=" + $("#SearchType").val();
    url += "&SearchText=" + $("#SearchText").val();
    url += "&SearchBbsMrnrSeCode=" + $("#SearchBbsMrnrSeCode").val();
    url += "&OrderColumn=" + OrderColumn;
    url += "&OrderType=" + OrderType;
    url += "&menuCode=" + menuCode;

    document.location.href = url;
}

function fn_View(ManagerID) {
    //alert("ManagerID : " + ManagerID);

    //$("#viewModal").modal();
    //$("#viewModal").data(ManagerID);

    var managerDataUrl = '@Url.Action("managerJsonData", "Json")';
    var chartDataUrl = '@Url.Action("flotJsonData", "Json")';
    var tableDataUrl = '@Url.Action("tableJsonData", "Json")';

    $.post("managerJsonData", { managerID: ManagerID }, function (data) {

        var message = data.Message;
        var txtEmail = data.managerT.ManagerEmail;

        /*
        */
        if (data.managerT.ManagerEmail != "null" || data.managerT.ManagerEmail != undefined) {
        }
        //alert(message);
        //alert(data.managerT.ManagerID);
        //$("#resultMessage").html(message);
        $("#myModal").removeAttr();
        $("#viewModal").modal();
        $("#ManagerNmE").val(data.managerT.ManagerNm);
        $("#ManagerRankNmE").val(data.managerT.ManagerRank);
        $("#ManagerPostNmE").val(data.managerT.ManagerPost);
        $("#ManagerIDE").html(data.managerT.ManagerID);
        $("#ManagerIDH").val(data.managerT.ManagerID);
        $("#ManagerPwE").val(data.managerT.ManagerPw);
        $("#ManagerPwcE").val(data.managerT.ManagerPw);
        $("#ManagerHp1E").val(data.managerT.ManagerHp1);
        $("#ManagerHp2E").val(data.managerT.ManagerHp2);
        $("#ManagerHp3E").val(data.managerT.ManagerHp3);
        $("#ManagerTelE").val(data.managerT.ManagerTel);
        $("#ManagerTel1E").val(data.managerT.ManagerTel1);
        $("#ManagerTel2E").val(data.managerT.ManagerTel2);
        $("#ManagerTel3E").val(data.managerT.ManagerTel3);

        txtEmail = txtEmail.split("@");
        $("#ManagerEmail1E").val(txtEmail[0]);
        $("#ManagerEmail2E").val(txtEmail[1]);
        $("#ManagerEmailcoE").val(txtEmail[1]);
    });


    /*
    $.ajax({
        url: chartDataUrl,
        method: 'GET',
        dataType: 'json',
        success: function (data) {
            $.plot($("#flot-bar-chart"), [data], barOptions);
        }
    });
    */

}