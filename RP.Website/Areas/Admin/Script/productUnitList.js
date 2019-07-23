var productUnitList = new function () {
    var datas = [];
    var message = {
        info: {
            noSelectedItemBeforeEdit: "กรุณาเลือกรายการ",
        },
        error: {}
    };
    var _edit = function () {
        var itemId = 0;
        var items = $("input:checkbox[name=id]:checked");
        if (items.length == 1) {
            itemId = $(items[0]).val();

        } else {
            toastr.info(message.info.noSelectedItemBeforeEdit, 'Infomration');
        }
        if (itemId != 0) {
            window.location.href = '../../Admin/Product/EditProductUnit/' + itemId;
        }
    };
    var _delete = function (id,callback) {
        var success = function (response, textStatus, jqXHR) {
            callback();
        }
        var failure = function (jqXHR, textStatus, errorThrown) {
        }
        var xhr = RPService.DeleteCategory(id, success, failure);
    }
    var _render = function () {
        var html = '';
        $(datas).each(function (index, data) {
            html += '<tr>';
            html += '   <td><div class="checkbox i-checks"><label> <input type="checkbox" name="id" value=' + data.id + '> <i></i></label></div></td>';
            html += '   <td>' + data.productName + '</td>';
            html += '   <td>' + data.unitName + '</td>';
            html += '</tr>';
        });
        $("#table-data tbody").empty().html(html);
        $('.i-checks').iCheck({
            checkboxClass: 'icheckbox_square-green',
            radioClass: 'iradio_square-green',
        });
    };
    var _search = function () {
        var searchBy = $("#ddSearch").val();
        var keyword = $("#keyword").val();
        var success = function (response, textStatus, jqXHR) {
            datas = [];
            $(response.data).each(function (index, data) {
                datas.push(data)
            });
            _render();
        }
        var failure = function (jqXHR, textStatus, errorThrown) {
            //alert(errorThrown);
        }
        var xhr = RPService.GetProductUnitBySearch(searchBy, keyword, success, failure);
    };
    return {
        init: function () {
            _search();
        },
        edit: function () {
            _edit();
        },
        delete: function (id,callback) {
            _delete(id, callback);
        },
        search: function () {
            _search();
        },
        noSelectedItemBeforeEdit: function () {
            return message.info.noSelectedItemBeforeEdit;
        }
    }
};