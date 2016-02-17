
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

    $("#btnReset").click(function () {
        $("#SearchArea :input").val("");
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

    var url = baseUrl + "/ManagerAuth";

    url += "?page=1";
    url += "&SearchType=" + $("#SearchType").val();
    url += "&SearchText=" + $("#SearchText").val();

    $(location).attr("href", url);
}

function fn_View(BbscttSn) {

    var url = baseUrl + "/ManagerDetail";

    // 모달 처리
    url += "?page=" + page;
    url += "&BbsSn=" + BbsSn;
    url += "&BbscttSn=" + BbscttSn;
    url += "&SearchStartDate=" + $("#SearchStartDate").val();
    url += "&SearchEndDate=" + $("#SearchEndDate").val();
    url += "&SearchType=" + $("#SearchType").val();
    url += "&SearchText=" + $("#SearchText").val();
    url += "&SearchBbsMrnrSeCode=" + $("#SearchBbsMrnrSeCode").val();
    url += "&menuCode=" + menuCode;

    $(location).attr("href", url);

}