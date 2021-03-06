﻿var userList = new function () {
    var users = [];
    var message = {
        info: {
            noSelectedItemBeforeEdit: "กรุณาเลือกรายการ",
        },
        error: {}
    };
    var _edit = function () {
        var itemId = 0;
        var items = $("input:checkbox[name=userId]:checked");
        if (items.length == 1) {
            itemId = $(items[0]).val();

        } else {
            toastr.info(message.info.noSelectedItemBeforeEdit, 'Infomration');
        }
        if (itemId != 0) {
            window.location.href = '../../Admin/UserAccount/EditUser/' + itemId;
        }
    };
    var _render = function () {
        var html = '';
        $(users).each(function (index, user) {
            html += '<tr>';
            html += '   <td><div class="checkbox i-checks"><label> <input type="checkbox" name="userId" value=' + user.id + '> <i></i></label></div></td>';
            html += '   <td>' + user.userName + '</td>';
            html += '   <td>' + user.displayName + '</td>';
            html += '   <td>' + user.roleName + '</td>';
            html += '</tr>';
        });
        $("#table-quotation tbody").empty().html(html);
        $('.i-checks').iCheck({
            checkboxClass: 'icheckbox_square-green',
            radioClass: 'iradio_square-green',
        });
    };
    var _search = function () {
        var searchBy = $("#ddSearch").val();
        var keyword = $("#keyword").val();
        var success = function (response, textStatus, jqXHR) {
            users = [];
            $(response.data).each(function (index, user) {
                users.push(user)
            });
            _render();
        }
        var failure = function (jqXHR, textStatus, errorThrown) {
            //alert(errorThrown);
        }
        var xhr = RPService.GetUsersList(searchBy, keyword, success, failure);
    };
    
    return {
        init: function () {
            _search();
        },
        edit: function () {
            _edit();
        },
        search: function () {
            _search();
        },
    }
};