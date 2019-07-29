var documentListForBackoffice = new function () {
    var documents = [];
    var message = {
        info: {
            noSelectedItemBeforeEdit: "กรุณาเลือกรายการ",
            notApprovedYet: "รายการนี้ยังไม่ได้รับการอนุมัติ"
        },
        error: {}
    };
    var _bindingYear = function () {
        var currentYear = new Date().getFullYear();
        min = currentYear - 5;
        max = currentYear + 5;

        $('#documentYear').empty();
        for (var i = min; i <= max; i++) {
            $('#documentYear').append($('<option>', {
                value: i,
                text: i
            }));
        }
        $("#documentYear").prepend("<option value='' selected='selected'>เลือกปี</option>");
            //$("#documentYear").val(currentYear);
    };
    var _bindingProductCategories = function () {
        var success = function (data, textStatus, jqXHR) {
            $('#productCategories').empty();
            $(data).each(function (index, item) {
                $('#productCategories').append($('<option>', {
                    value: item.id,
                    text: item.categoryName
                }));
            });
            $("#productCategories").prepend("<option value='' selected='selected'>เลือกประเภทสินค้า</option>");
            $("#productCategories").unbind();
        }
        var failure = function (jqXHR, textStatus, errorThrown) {
            //alert(errorThrown);
        }
        var xhr = RPService.GetProductCategories(success, failure);
    };
    var _edit = function () {
        var itemId = 0;
        var items = $("input:checkbox[name=documentId]:checked");
        if (items.length == 1) {
            itemId = $(items[0]).val();

        } else {
            toastr.info(message.info.noSelectedItemBeforeEdit, 'Infomration');
        }
        if (itemId != 0) {
            window.location.href = '../../Backoffice/Document/Edit/' + itemId;
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
                html += '   <td><button type="button" class="btn btn-primary btn-circle"></button></td>';
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
        var criteria = {
            documentCode: "",
            customerName: "",
            customerType: $("#customerType").val(),
            documentYear: $("#documentYear").val(),
            contactName: $("#contactName").val(),
            productCategoryId: $("#productCategories").val(),
            quotedPrice: $("#quotedPrice").val()
        };
        var quickSearch = $("#ddSearch").val();
        if (quickSearch != null && quickSearch != undefined) {
            if ($("customerName").val() != '') {
                criteria.customerName = $("#customerName").val();
            } else {
                if (quickSearch == "CustomerName") {
                    criteria.customerName = $("#keyword").val();
                } else if (quickSearch == "DocumentCode") {
                    criteria.documentCode = $("#keyword").val();
                } else { }
            }
        } else {
            criteria.customerName = $("#customerName").val();
        }
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
        var xhr = RPService.GetDocumentsListBySearchForBackoffice(criteria, success, failure);
    };
    var _request = function (callback) {
        var id = 0;
        var items = $("input:checkbox[name=documentId]:checked");
        if (items.length == 1) {
            id = $(items[0]).val();

        } else {
            toastr.info(message.info.noSelectedItemBeforeEdit, 'Infomration');
        }
        if (id != 0) {
            var success = function (data, textStatus, jqXHR) {
                callback();
            }

            var failure = function (jqXHR, textStatus, errorThrown) {
                //alert(errorThrown);
            }
            var xhr = RPService.RequestApprovalForBackoffice(id, success, failure);
        }
    };
    var _gotPOValidation = function (id, callback) {
        var success = function (result, textStatus, jqXHR) {
            //Approved =3,
            var documentStatusId = parseInt(result);
            if (documentStatusId == 50) {
                callback();
            } else {
                toastr.info(message.info.notApprovedYet, 'Infomration');
            }
        }
        var failure = function (jqXHR, textStatus, errorThrown) {
        }
        var xhr = RPService.GetCurrentWorkflowStatusForBackoffice(id, success, failure);
    };
    var _gotPO = function (callback) {
        var id = 0;
        var items = $("input:checkbox[name=documentId]:checked");
        if (items.length == 1) {
            id = $(items[0]).val();

        } else {
            toastr.info(message.info.noSelectedItemBeforeEdit, 'Infomration');
        }
        if (id != 0) {
            _gotPOValidation(id, function () {
                var success = function (data, textStatus, jqXHR) {
                    callback();
                }
                var failure = function (jqXHR, textStatus, errorThrown) {
                }
                var xhr = RPService.GotPOForBackoffice(id, success, failure);
            });

        }
    };
    return {
        init: function () {
            _bindingYear();
            _bindingProductCategories();
            _search();
        },
        edit: function () {
            _edit();
        },
        search: function () {
            _search();
        },
        requestApprove: function (callback) {
            _request(callback);
        },
        gotPO: function (callback) {
            _gotPO(callback);
        }
    }
};