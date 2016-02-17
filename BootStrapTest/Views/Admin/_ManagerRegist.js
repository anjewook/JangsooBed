
$(document).ready(function () {

    $("#frm").validate({
        onkeyup: false,
        onclick: false,
        onfocusout: false,
        rules: {
            ManagerNm: {
                required: true
            },
            ManagerRankNm: {
                required: true
            },
            ManagerPostNm: {
                required: true
            },
            ManagerID: {
                required: true,
                minlength: 6,
                maxlength: 12,
                engOrNumber: true
            },
            idChk: {
                required: true,
                chkYes: true
            },
            ManagerPw: {
                required: true,
                minlength: 10,
                passwordPattern: true
            },
            ManagerPwc: {
                required: true,
                equalTo: "#ManagerPw"
            },
            ManagerHp1: {
                required: true
            },
            ManagerHp2: {
                required: true,
                minlength: 3,
                maxlength: 4,
                number: true
            },
            ManagerHp3: {
                required: true,
                minlength: 4,
                maxlength: 4,
                number: true
            },
            ManagerEmail1: {
                required: true
            },
            ManagerEmail2: {
                required: true
            }
        },
        messages: {
            ManagerNm: {
                required: "이름을 입력하세요."
            },
            ManagerRankNm: {
                required: "직급을 선택하세요."
            },
            ManagerPostNm: {
                required: "부서를 선택하세요."
            },
            ManagerID: {
                required: "아이디를 입력하세요.",
                minlength: "아이디는 {0}자 이상 이어야 합니다.",
                maxlength: "아이디는 {0}자 이하 이어야 합니다.",
                engOrNumber: "영문 또는 숫자만 입력 가능 합니다."
            },
            idChk: {
                required: "아이디 중복체크를 하세요.",
                chkYes: "가능한 아이디를 입력하세요."
            },
            ManagerPw: {
                required: "비밀번호를 입력하세요.",
                minlength: "비밀번호는 {0}자 이상 이어야 합니다.",
                passwordPattern: "비밀번호는 영문,숫자를 포함해야 합니다."
            },
            ManagerPwc: {
                required: "비밀번호확인을 입력하세요.",
                equalTo: "비밀번호와 비밀번호 확인이 일치하지 않습니다."
            },
            ManagerHp1: {
                required: "핸드폰번호 식별번호를 선택하세요."
            },
            ManagerHp2: {
                required: "핸드폰 국번을 입력하세요",
                minlength: "핸드폰 국번은 3자리 이상 입력 해야 합니다.",
                maxlength: "핸드폰 국번은 4자리까지 입력 가능합니다.",
                number: "핸드폰 국번은 숫자만 입력 가능합니다."
            },
            ManagerHp3: {
                required: "핸드폰 개별번호을 입력하세요",
                minlength: "핸드폰 개별번호는 4자리입니다.",
                maxlength: "핸드폰 개별번호는 4자리까지 입력 가능합니다.",
                number: "핸드폰 국번은 숫자만 입력 가능합니다."
            },
            ManagerEmail1: {
                required: "이메일주소 아이디를 입력하세요"
            },
            ManagerEmail2: {
                required: "이메일을 선택하세요"
            }
        },
        errorPlacement: function (error, element) {
        },
        showErrors: function (errorMap, errorList) {
            if (errorList.length > 0)
                alert(errorList[0].message);
        }
    });

    $("#btnRegist").click(function () {

        if ($("#frm").valid()) {

            //전화번호 조합
            if ($("#ManagerTel1").val().length > 0 && $("#ManagerTel2").val().length > 2 && $("#ManagerTel3").val().length > 3) {
                $("#ManagerTel").val($("#ManagerTel1").val() + "-" + $("#ManagerTel2").val() + "-" + $("#ManagerTel3").val());
            }

            //핸드폰번호 조합
            $("#ManagerHp").val($("#ManagerHp1").val() + "-" + $("#ManagerHp2").val() + "-" + $("#ManagerHp3").val());

            //이메일주소 조합
            $("#ManagerEmail").val($("#ManagerEmail1").val() + "@" + $("#ManagerEmail2").val());

            $.ajax({
                type: "POST",
                async: false,
                url: "/Admin/ManagerRegistAction",
                data: $("#frm").serialize(),
                success: function (data) {
                    if (data.Success == true) {
                        //완료페이지 이동
                        alert("등록완료~!");
                        //$(location).attr("href", "/Member/MberSbscrbCompt");
                        var $modal = $('#myModal');

                        //when hidden
                        $modal.on('hidden.bs.modal', function (e) {
                            //return this.render(); //DOM destroyer
                        });

                        $modal.modal('hide'); //start hiding
                        location.reload();
                    }
                    else {
                        alert(data.Message);
                    }
                },
                error: function (xhr, status, error) {
                    alert(error);
                }
            });
        }
        return false;

    });

    $("#btnIDChk").click(function () {

        if ($("#ManagerID").val() == "") {
            alert("아이디를 입력하세요.");
            return false;
        } else {

            $.ajax({
                type: "POST",
                async: false,
                url: "/Admin/ManagerIDChk",
                data: $("#frm").serialize(),
                success: function (data) {
                    if (data.Success == true) {
                        //완료페이지 이동
                        //alert("success");
                        //$(location).attr("href", "/Member/MberSbscrbCompt");
                        $("#idChk").val("Y");
                        alert(data.Message);
                    }
                    else {
                        $("#idChk").val("N");
                        alert(data.Message);
                    }
                },
                error: function (xhr, status, error) {
                    alert(error);
                }
            });
        }
        return false;
    });

    $("#acSearchPost").click(function () {
        Common.ZipCodeOpen("zipCode", "fn_SetZipCode");
    });

    $("#acDuplicationCheck").click(function () {
        if ($.trim($("#userId").val()).length < 1) {
            alert("아이디를 입력하세요");
            $("#userId").focus();
            return false;
        }

        var url = "/Member/DuplicateUserIdPopup?userId=" + $("#userId").val() + "&returnHandler=fn_SetUserId";
        window.open(url, "DuplicateUserIdPopup", "width=500, height=400, scrollbars=yes, resizable=no, toolbar=no, status=yes");
    });

    $("#ManagerEmailco").change(function () {
        if ($("#ManagerEmailco").val() == "direct" || $("#ManagerEmailco").val() == "") {
            $("#ManagerEmail2").show();
            $("#ManagerEmail2").focus();
        } else {
            $("#ManagerEmail2").val($("#ManagerEmailco").val());
            $("#ManagerEmail2").hide();
        }
    });

    $("#acAddAdres").click(function () {
        fn_AddRow();
        return false;
    });

    jQuery('#telno2,#telno3,#mbtlnum2,#mbtlnum3,#reprsntTelno2,#reprsntTelno3,#tmpTelno2,#tmpTelno3,#tmpFxnum2,#tmpFxnum3').css('imeMode', 'disabled').keypress(function (event) {
        if (event.which && (event.which < 48 || event.which > 57)) {
            event.preventDefault();
        }
    }).keyup(function () {
        if (jQuery(this).val() != null && jQuery(this).val() != '') {
            jQuery(this).val(jQuery(this).val().replace(/[^0-9]/g, ''));
        }
    });

    $("#frm :input[name=tmpEntrprsAdresSeCode]").click(function () {
        $("#tmpEntrprsAdresNm").val($("label[for='" + $(this).attr("id") + "']").text());
    });

});

function fn_IsEtcValid() {
    var tableRowLength = $("#tblArea tr").length;
    if (tableRowLength < 2) {
        alert("기업주소는 하나 이상 등록되어야 합니다.");
        return false;
    }
    return true;
}

function fn_SetZipCode(data) {
    $("#tmpAdresSeCode").val(data.Type);
    $("#tmpZip1").val(data.ZipCode01);
    $("#tmpZip2").val(data.ZipCode02);
    $("#tmpBassAdres").val(data.Address);
    $("#tmpDetailAdres").val(data.AddressDetail);
}

function fn_AddRow() {
    if (!fn_IsValid()) {
        return;
    }
    var tableRowLength = $("#tblArea tr").length;

    var telNo = "";
    if ($("#tmpTelno1").val().length > 0 && $("#tmpTelno2").val().length > 2 && $("#tmpTelno3").val().length > 3) {
        telNo = $("#tmpTelno1").val() + "-" + $("#tmpTelno2").val() + "-" + $("#tmpTelno3").val();
    }
    var fxnum = "";
    if ($("#tmpFxnum1").val().length > 0 && $("#tmpFxnum2").val().length > 2 && $("#tmpFxnum3").val().length > 3) {
        fxnum = $("#tmpFxnum1").val() + "-" + $("#tmpFxnum2").val() + "-" + $("#tmpFxnum3").val();
    }

    var tmpEntrprsAdresSeCode = $(":radio[name=tmpEntrprsAdresSeCode]:checked").attr("id").replace("tmpEntrprsAdresSeCode_", "");
    var tmpEntrprsAdresSeCodeNm = $("label[for=tmpEntrprsAdresSeCode_" + tmpEntrprsAdresSeCode + "]").text();
    var tmpDmstcAt = $(":radio[name=tmpDmstcAt]:checked").val();
    var tmpAdresSeCode = $("#tmpAdresSeCode").val();
    if (tmpDmstcAt == "N") {
        tmpAdresSeCode = "AC001001";
    }

    var str = "";
    str = str + "<tr>";
    str = str + "<td>" + tableRowLength + "</td>";
    str = str + "<td>" + tmpEntrprsAdresSeCodeNm;
    str = str + "    <input type=\"hidden\" name=\"entrprsAdresNm\" value=\"" + $("#tmpEntrprsAdresNm").val() + "\" />";
    str = str + "    <input type=\"hidden\" name=\"entrprsAdresSeCode\" value=\"" + tmpEntrprsAdresSeCode + "\" />";
    str = str + "    <input type=\"hidden\" name=\"adresTelno\" value=\"" + telNo + "\" />";
    str = str + "    <input type=\"hidden\" name=\"adresFxnum\" value=\"" + fxnum + "\" />";
    str = str + "    <input type=\"hidden\" name=\"adresSeCode\" value=\"" + tmpAdresSeCode + "\" />";
    str = str + "    <input type=\"hidden\" name=\"zip\" value=\"" + $("#tmpZip1").val() + $("#tmpZip2").val() + "\" />";
    if (tmpDmstcAt == "Y") {
        str = str + "    <input type=\"hidden\" name=\"bassAdres\" value=\"" + $("#tmpBassAdres").val() + "\" />";
    } else {
        str = str + "    <input type=\"hidden\" name=\"bassAdres\" value=\"" + $("#tmpOutnatnAdres").val() + "\" />";
    }
    str = str + "    <input type=\"hidden\" name=\"detailAdres\" value=\"" + $("#tmpDetailAdres").val() + "\" />";
    str = str + "    <input type=\"hidden\" name=\"dmstcAt\" value=\"" + tmpDmstcAt + "\" />";
    str = str + "</td>";
    str = str + "<td>" + $("#tmpEntrprsAdresNm").val() + "</td>";
    if (tmpDmstcAt == "Y") {
        str = str + "<td class=\"tl\">" + $("#tmpBassAdres").val() + " " + $("#tmpDetailAdres").val() + "</td>";
    } else {
        str = str + "<td class=\"tl\">" + $("#tmpOutnatnAdres").val() + "</td>";
    }
    str = str + "<td>" + telNo + "</td>";
    str = str + "<td>" + fxnum + "</td>";
    str = str + "<td><a href=\"#\" onclick=\"fn_DelRow(this);return false;\">삭제</a></td>";
    str = str + "</tr>";

    $("#tblArea").append(str);

    fn_ClearEntrprsAdres();

    return false;
}

function fn_DelRow(obj) {
    var tableRowLength = $("#tblArea tr").length;

    if (tableRowLength > 1) {
        $(obj).parent().parent().remove();

        // 다시 넘버링
        fn_DisplaySn();

    } else {
        alert("더이상 삭제할 행이 없습니다.");
    }
}

function fn_DisplaySn() {
    $("#tblArea tr").each(function (index, item) {
        if (index > 0) {
            $(item).children("td:first").text(index);
        }
    });
}

function fn_ClearEntrprsAdres() {
    $("#tmpEntrprsAdresNm,#tmpTelno1,#tmpTelno2,#tmpTelno3,#tmpFxnum1,#tmpFxnum2,#tmpFxnum3,#tmpZip1,#tmpZip2,#tmpBassAdres,#tmpDetailAdres,#tmpOutnatnAdres").attr("value", "");
    $(":radio[name='tmpEntrprsAdresSeCode']:input[value=AC002001]").attr("checked", true);
    $(":radio[name='tmpDmstcAt']:input[value=Y]").attr("checked", true);
    $("#tmpAdresSeCode").val("AC001001");
}

function fn_IsValid() {
    if ($.trim($("#tmpEntrprsAdresNm").val()).length < 1) {
        alert("주소키워드를 입력하세요");
        $("#tmpEntrprsAdresNm").focus();
        return false;
    }
    if ($(":radio[name=tmpDmstcAt]:checked").val() == "Y") {
        if ($.trim($("#tmpBassAdres").val()).length < 1) {
            alert("주소를 입력하세요");
            return false;
        }
        //if ($.trim($("#tmpDetailAdres").val()).length < 1) {
        //    alert("상세주소를 입력하세요");
        //    return false;
        //}
    } else {
        if ($.trim($("#tmpOutnatnAdres").val()).length < 1) {
            alert("주소를 입력하세요");
            return false;
        }
    }
    return true;
}

function fn_SetUserId(userId) {
    $("#userId").val(userId);
}