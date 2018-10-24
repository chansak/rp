var documentList = new function () {
    var documents = [];
    var message = {
        info: {
            noSelectedItemBeforeEdit: "Please select document"
        },
        error: {}
    };

    var _edit = function () {
        var itemId = 0;
        var items = $("input:checkbox[name=documentId]:checked");
        if (items.length == 1) {
            itemId = $(items[0]).val();

        } else {
            toastr.info(message.info.noSelectedItemBeforeEdit, 'Infomration')
        }
        if (itemId != 0) {
            window.location.href = '../../Sale/Document/Edit/' + itemId;
        }
    };
    var _render = function () {
        var html = '';
        $(documents).each(function (index, document) {
            html += '<tr>';
            html += '   <td><div class="checkbox i-checks"><label> <input type="checkbox" name="documentId" value='+ document.id +'> <i></i></label></div></td>';
            html += '   <td><button type="button" class="btn btn-primary btn-circle"></button></td>';
            html += '   <td>' + document.customerType +'</td>';
            html += '   <td>' + document.customerName + '</td>';
            html += '   <td>' + document.documentCode + '</td>';
            html += '   <td>' + document.saleUserName + '</td>';
            html += '   <td>' + document.workflowStatusName + '</td>';
            html += '   <td><span class="badge badge-primary">' + document.biddingStatusName + '</span></td>';
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
            documents = [];
            $(response.data).each(function (index, document) {
                documents.push(document)
            });
            _render();
        }
        var failure = function (jqXHR, textStatus, errorThrown) {
            //alert(errorThrown);
        }
        var xhr = RPService.GetDocumentsListBySearch(searchBy, keyword, success, failure);
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
        }
    }
};