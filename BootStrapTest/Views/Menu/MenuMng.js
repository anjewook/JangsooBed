
var setting = {
    data: {
        simpleData: {
            enable: true
        }
    },
    callback: {
        onClick: onClick
    }
};

$(document).ready(function () {

    $("#frm").validate({
        onkeyup: false,
        onclick: false,
        onfocusout: false,
        rules: {
            upperMenuCode: {
                required: true
            },
            menuNm: {
                required: true
            },
            sortOrdr: {
                required: true,
                minlength: 1,
                maxlength: 3,
                number: true
            }
        },
        messages: {
            upperMenuCode: {
                required: "상위메뉴를 선택하세요."
            },
            menuNm: {
                required: "메뉴명을 입력하세요."
            },
            sortOrdr: {
                required: "정렬순서를 입력하세요.",
                minlength: "정렬순서는 {0}자리 이상이어야 합니다.",
                maxlength: "정렬순서는 {0}자리 이하이어야 합니다.",
                number: "정렬순서는 숫자만 입력 가능 합니다."
            }
        },
        errorPlacement: function (error, element) {
        },
        showErrors: function (errorMap, errorList) {
            if (errorList.length > 0)
                alert(errorList[0].message);
        }
    });


    $("#acRegist").click(function () {
        fn_SetDefault();
        return false;
    });

    $("#acSave").click(function () {
        if ($("#frm").valid()) {
            $.ajax({
                type: "POST",
                async: false,
                url: "/SystemMng/Menu/MenuProcess",
                data: $("#frm").serialize(),
                success: function (data) {
                    if (data.Success == true) {
                        alert("처리완료 되었습니다.");
                        fn_Init($("#menuTree"));
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

    $("#btnSearchUpperMenu").click(function () {
        fn_Init($("#menuSelectTree"));
        showMenu();
        return false;
    });

    $("#searchUpperMenuCode").change(function () {
        fn_Init($("#menuTree"));
    });

    fn_Init($("#menuTree"));

});

function onClick(event, treeId, treeNode, clickFlag) {
    if (treeId == "menuTree") {
        $.ajax({
            type: "GET",
            async: false,
            url: "/SystemMng/Menu/MenuView",
            data: { searchMenuCode: treeNode.menuCode },
            success: function (data) {
                $("#menuCode").attr("value", data.MenuCode);
                $("#menuNm").attr("value", data.MenuNm);
                $("#upperMenuCode").attr("value", data.UpperMenuCode);
                $("#upperMenuNm").attr("value", data.UpperMenuNm);
                $(':radio[name="menuTyCode"]:input[value=' + data.MenuTyCode + ']').attr("checked", true);
                $(':radio[name="cntntsTyCode"]:input[value=' + data.CntntsTyCode + ']').attr("checked", true);
                $(':radio[name="linkTyCode"]:input[value=' + data.LinkTyCode + ']').attr("checked", true);
                $("#menuUrl").attr("value", data.MenuUrl);
                $("#sortOrdr").attr("value", data.SortOrdr);
                $(':radio[name="useAt"]:input[value=' + data.UseAt + ']').attr("checked", true);
                $("#menuDc").attr("value", data.MenuDc);
                $("#mode").attr("value", "U");

            },
            error: function (xhr, status, error) {
                alert(error);
            }
        });

    } else if (treeId == "menuSelectTree") {

        if (treeNode.menuTycode != "AC009001") {
            alert("메뉴유형이 폴더인 경우만 선택가능합니다.");
            return;
        }

        var zTree = $.fn.zTree.getZTreeObj("menuSelectTree"),
        nodes = zTree.getSelectedNodes(),
        vCode = "";
        vName = "";

        nodes.sort(function compare(a, b) { return a.id - b.id; });

        for (var i = 0, l = nodes.length; i < l; i++) {
            vCode += nodes[i].menuCode;
            vName += nodes[i].name;
        }

        $("#upperMenuCode").attr("value", vCode);
        $("#upperMenuNm").attr("value", vName);

        hideMenu();
    }
}

function showMenu() {

    var targetObj = $("#upperMenuCode");
    var targetOffset = $("#upperMenuNm").offset();

    $("#menuContent").css({ left: targetOffset.left + "px", top: targetOffset.top + targetObj.outerHeight() - $("#divColumnSubRight").offset().top + "px" }).slideDown("fast");

    $("body").bind("mousedown", onBodyDown);
}

function hideMenu() {

    $("#menuContent").fadeOut("fast");

    $("body").unbind("mousedown", onBodyDown);

}

function onBodyDown(event) {

    if (!(event.target.id == "menuBtn" || event.target.id == "menuContent" || $(event.target).parents("#menuContent").length > 0)) {
        hideMenu();
    }

}

function fn_Init(objTree) {

    $.ajax({
        type: "GET",
        async: false,
        url: "/SystemMng/Menu/MenuTreeList",
        data: { searchUpperMenuCode: $("#searchUpperMenuCode").val() },
        success: function (data) {
            var zNodes = data;
            $.fn.zTree.init(objTree, setting, zNodes);

            fn_SetDefault(); //default 셋팅
        },
        error: function (xhr, status, error) {
            alert("error : " + error);
        }
    });

}

function fn_SetDefault() {

    $("#menuCode").attr("value", "");
    $("#menuNm").attr("value", "");
    $("#upperMenuCode").attr("value", $("#searchUpperMenuCode").val());
    $("#upperMenuNm").attr("value", $("#searchUpperMenuCode > option:selected").text());
    $(':radio[name="menuTyCode"]:input[value=AC009001]').attr("checked", true);
    $(':radio[name="cntntsTyCode"]:input[value=AC010001]').attr("checked", true);
    $(':radio[name="linkTyCode"]:input[value=AC011001]').attr("checked", true);
    $("#menuUrl").attr("value", "");
    $("#sortOrdr").attr("value", "1");
    $(':radio[name="useAt"]:input[value=Y]').attr("checked", true);
    $("#menuDc").attr("value", "");
    $("#mode").attr("value", "I");

}
