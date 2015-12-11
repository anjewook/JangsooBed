

$(document).ready(function () {

    $("#userId").keydown(function () {
        if (event.keyCode == 13) {
            $("#password").focus();
        }
    });

    $("#password").keydown(function () {
        if (event.keyCode == 13) {
            $("#acLogin").click();
        }
    });

    $("#frmLogin").validate({

        onkeyup: false,
        onclick: false,
        onfocusout: false,
        debug: true,
        rules: {
            userId: {
                required: true,
                engOrNumber : true
            },
            password: {
                required: true
            }
        },
        messages: {
            userId: {
                required: "아이디를 입력하세요.",
                engOrNumber: "아이디는 영문 또는 숫자만 입력가능 합니다."
            },
            password: {
                required: "비밀번호를 입력하세요."
            }
        },
        errorPlacement: function (error, element) {
        },
        showErrors: function (errorMap, errorList) {
            if (errorList.length > 0)
                alert(errorList[0].message);
        }
    });

    $("#acLogin").click(function () {

        if ($("#frmLogin").valid()) {

            $("#userId").val($("#userId").val().replace(/ /g, ''));
            $("#password").val($("#password").val().replace(/ /g, ''));

            $.ajax({
                type: "POST",
                async: false,
                url: "/Admin/Login",
                data: $("#frmLogin").serialize(),
                success: function (data) {

                    if (data.Success == true) {

                        if ($("#idsave").is(":checked") == true) {
                            $.cookie("JS_BOOTS_LOGIN", $("#userId").val(), { expires: 7 });
                            //$.cookie("JS_BOOTS_LOGIN_CODE", $(':radio[name="userSeCode"]:checked').val(), { expires: 7 });AC007005
                            $.cookie("JS_BOOTS_LOGIN_CODE", "AC007005", { expires: 7 });
                        }

                        //var url = PORTAL_MAIN_URL;
                        var url = ADMIN_LOGIN_URL;
                        
                        if ($.trim($("#returnUrl").val()).length > 0) {
                            url = $("#returnUrl").val();
                        }

                        if (data.PassChangeElapseAt == "Y") { //비밀번호변경 시간경과여부
                            url = "/MyPage/MberPasswordEdit"; //비밀번호 변경 페이지 이동
                        }
                        //alert(url);
                        //return false;

                        $(location).attr("href", url);
                    }
                    else {
                        alert(data.Message);
                        //$("#acLogin").show();
                    }
                },
                error: function (xhr, status, error) {
                    if (error == "NetworkError") {
                        alert("올바를 입력정보가 아닙니다.");
                        $(location).attr("href", "/Admin/Login");
                    } else {
                        alert(error);
                    }
                    return false;
                }
            });
        }
        return false;
    });

    $("#acFindIdPw").click(function () {
        $(location).attr("href", "/Member/SearchIdPw");
        return false;
    });

    $("#acJoinMember").click(function () {
        $(location).attr("href", "/Member/StplatAgre");
        return false;
    });

    $("#userId").focusin(function () {
        if ($("#userId").val() == "로그인 ID") {
            $("#userId").val("");
        }
    });
    $("#userId").focusout(function () {
        if ($("#userId").val() == "") {
            $("#userId").val("로그인 ID");
        }
    });

    fn_SaveIdCheck();

});

function fn_SaveIdCheck() {

    if ($.cookie("JS_BOOTS_LOGIN") != null) {

        $("#userId").val($.cookie("JS_BOOTS_LOGIN"));
        $("#idsave").attr("checked", true);
        $("#password").val("");

        var ck_usercode = $.cookie("JS_BOOTS_LOGIN_CODE");

        $('input:radio[name=userSeCode]:input[value=' + ck_usercode + ']').attr("checked", true);

    }
}
