
$(document).ready(function () {

    $("#frmEdit").validate({
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
            ManagerPw: {
                required: true,
                minlength: 10,
                passwordPattern: true
            },
            ManagerPwc: {
                required: true,
                equalTo: "#ManagerPwE"
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

    $("#btnEdit").click(function () {

        if ($("#frmEdit").valid()) {

            //전화번호 조합
            if ($("#ManagerTel1E").val().length > 0 && $("#ManagerTel2E").val().length > 2 && $("#ManagerTel3E").val().length > 3) {
                $("#ManagerTelE").val($("#ManagerTel1E").val() + "-" + $("#ManagerTel2E").val() + "-" + $("#ManagerTel3E").val());
            }

            //핸드폰번호 조합
            $("#ManagerHpE").val($("#ManagerHp1E").val() + "-" + $("#ManagerHp2E").val() + "-" + $("#ManagerHp3E").val());

            //이메일주소 조합
            $("#ManagerEmailE").val($("#ManagerEmail1E").val() + "@" + $("#ManagerEmail2E").val());

            $.ajax({
                type: "POST",
                async: false,
                url: "/Admin/ManagerEditAction",
                data: $("#frmEdit").serialize(),
                success: function (data) {
                    if (data.Success == true) {
                        alert("수정완료~!");
                        var $modal = $('#viewModal');

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

    $("#ManagerEmailcoE").change(function () {
        if ($("#ManagerEmailcoE").val() == "direct" || $("#ManagerEmailcoE").val() == "") {
            $("#ManagerEmail2E").show();
            $("#ManagerEmail2E").focus();
        } else {
            $("#ManagerEmail2E").val($("#ManagerEmailcoE").val());
            $("#ManagerEmail2E").hide();
        }
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