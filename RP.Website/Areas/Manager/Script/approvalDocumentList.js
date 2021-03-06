﻿var approvalDocumentList = new function () {
    var documents = [];
    var _view = function () {
        var itemId = 0;
        var items = $("input:checkbox[name=documentId]:checked");
        if (items.length == 1) {
            itemId = $(items[0]).val();

        } else {
            toastr.info(message.info.noSelectedItemBeforeEdit, 'Infomration');
        }
        if (itemId != 0) {
            window.location.href = '../../Manager/ApprovalDocument/Read/' + itemId;
        }
    };
    var _render = function () {
        var html = '';
        $(documents).each(function (index, document) {
            html += '<tr>';
            html += '   <td><div class="checkbox i-checks"><label> <input type="checkbox" name="documentId" value=' + document.id + '> <i></i></label></div></td>';
            if (document.weightPoint > 0 && document.weightPoint <= 49) {
                html += '   <td><button type="button" class="btn btn-primary btn-circle"></button></td>';
            } else if (document.weightPoint >= 50 && document.weightPoint <= 69) {
                html += '   <td><button type="button" class="btn btn-warning btn-circle"></button></td>';
            } else if (document.weightPoint >= 70) {
                html += '   <td><button type="button" class="btn btn-danger btn-circle"></button></td>';
            } else {
                html += '   <td></td>';
            }
            html += '   <td>' + document.customerType + '</td>';
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
        var xhr = RPService.GetApprovalDocumentsListBySearch(searchBy, keyword, success, failure);
    };
    return {
        init: function () {
            _search();
        },
        view: function () {
            _view();
        },
        search: function () {
            _search();
        }
    }
};