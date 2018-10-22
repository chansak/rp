var documentEditor = new function () {
    var items = [];
    var sales = [];
    var customers = [];
    var contacts = [];
    var _bindingSale = function () {
        var success = function (data, textStatus, jqXHR) {
            $(data).each(function (index, value) {
                sales.push(value);
            });
            $('#auto_saleName').typeahead({
                source: sales,
                updater: function (item) {
                    $("#auto_saleId").val(item.id);
                    $("#auto_saleCode").val(item.code);
                    $("#auto_saleBranch").val(item.branch);
                    return item;
                }
            });
        }

        var failure = function (jqXHR, textStatus, errorThrown) {
            //alert(errorThrown);
        }
        var xhr = RPService.GetSaleUsers(success, failure);
    };
    var _bindingCustomer = function () {
        var success = function (data, textStatus, jqXHR) {
            $(data).each(function (index, value) {
                customers.push(value);
            });
            $('#auto_customerName').typeahead({
                source: customers,
                updater: function (item) {
                    $("#auto_customerId").val(item.id);
                    $("#auto_customerType").val(item.customerTypeName);
                    $("#auto_customerHospitalName").val(item.hospitalName);
                    _bindingContact(item.id);
                    return item;
                }
            });
        }

        var failure = function (jqXHR, textStatus, errorThrown) {
            //alert(errorThrown);
        }
        var xhr = RPService.GetCustomers(success, failure);
    };
    var _bindingContact = function (id) {
        contacts = [];
        $('#auto_contactName').val('');
        $("#auto_contactId").val('');
        var success = function (data, textStatus, jqXHR) {
            $(data).each(function (index, value) {
                contacts.push(value);
            });
            $('#auto_contactName').typeahead({
                source: contacts,
                updater: function (item) {
                    $("#auto_contactId").val(item.id);
                    $("#auto_contactPhone").val(item.phone);
                    $("#auto_contactFax").val(item.fax);
                    $("#auto_contactMobile").val(item.mobile);
                    return item;
                }
            });
            $('#auto_deliveryContactName').typeahead({
                source: contacts,
                updater: function (item) {
                    $("#auto_deliveryContactId").val(item.id);
                    $("#auto_deliveryContactPhone").val(item.phone);
                    $("#auto_deliveryContactFax").val(item.fax);
                    $("#auto_deliveryContactMobile").val(item.mobile);
                    return item;
                }
            });
        }

        var failure = function (id, jqXHR, textStatus, errorThrown) {
            //alert(errorThrown);
        }
        var xhr = RPService.GetContactByCustomerId(id, success, failure);
    }
    var _getCustomerDetail = function (id) {
        var success = function (data, textStatus, jqXHR) {
            $("#auto_customerName").val(data.name);
            $("#auto_customerType").val(data.customerTypeName);
            $("#auto_customerHospitalName").val(data.hospitalName);
        }
        var failure = function (jqXHR, textStatus, errorThrown) {
            //alert(errorThrown);
        }
        var xhr = RPService.GetCustomerById(id, success, failure);
    };
    var _getContactDetail = function (id) {
        var success = function (data, textStatus, jqXHR) {
            $("#auto_contactName").val(data.name);
            $("#auto_contactPhone").val(data.phone);
            $("#auto_contactFax").val(data.fax);
            $("#auto_contactMobile").val(data.mobile);
        }
        var failure = function (jqXHR, textStatus, errorThrown) {
            //alert(errorThrown);
        }
        var xhr = RPService.GetContactById(id, success, failure);
    };
    var _getDeliveryContactDetail = function (id) {
        var success = function (data, textStatus, jqXHR) {
            $("#auto_deliveryContactName").val(data.name);
            $("#auto_deliveryContactPhone").val(data.phone);
            $("#auto_deliveryContactFax").val(data.fax);
            $("#auto_deliveryContactMobile").val(data.mobile);
        }
        var failure = function (jqXHR, textStatus, errorThrown) {
            //alert(errorThrown);
        }
        var xhr = RPService.GetContactById(id, success, failure);
    };
    var _getSaleDetail = function (id) {
        var success = function (data, textStatus, jqXHR) {
            $("#auto_saleName").val(data.name);
            $("#auto_saleCode").val(data.code);
            $("#auto_saleBranch").val(data.branch);
        }
        var failure = function (jqXHR, textStatus, errorThrown) {
            //alert(errorThrown);
        }
        var xhr = RPService.GetSaleUserById(id, success, failure);
    };
    var _render = function (items) {
        var html = '';
        $(items).each(function (index, item) {
            var total = parseFloat((item.amount * item.pricePerUnit));
            var id = "'" + item.itemId + "'";
            if (item.printOptions.length > 0 || item.screenOptions.length > 0 || item.sewOptions.length > 0) {
                if (item.itemId != null) {
                    html += '<tr onclick="documentEditor.showItemDetail(' + id + ')">';
                    html += '   <td style="width:15%" id="icon_' + item.itemId + '"><a class="collapse-link"><i class="fa fa-chevron-down"></i></a></td>';
                } else {
                    html += '<tr>';
                    html += '<td></td>';
                }
            } else {
                html += '<tr>';
                html += '<td></td>';
            }
            html += '   <td style="width:15%">' + item.productName + '</td>';
            html += '   <td style="width:15%">' + item.productUnitName + '</td>';
            html += '   <td style="width:15%">' + item.amount + '</td>';
            html += '   <td style="width:15%">' + item.pricePerUnit + '</td>';
            html += '   <td style="width:15%">' + currency(total).format() + '</td>';
            html += '<tr>';
            if (item.itemId != null) {
                html += '<tr id=' + item.itemId + ' style="background-color: #ffffff;display:none">'
                html += '   <td colspan="2" style="border-right:dashed 1px #e6e6e6">'
                html += '       <h4>พิมพ์</h4>';
                $(item.printOptions).each(function (index, i) {
                    html += '       <div><ul<li>' + utilities.GetFileName(i.patternImagePath) + '</li></ul></div>';
                });
                html += '   </td>';
                html += '   <td colspan="2" style="border-right:dashed 1px #e6e6e6">';
                html += '       <h4>สกรีน</h4>';
                $(item.screenOptions).each(function (index, i) {
                    html += '       <div><ul<li>' + utilities.GetFileName(i.patternImagePath) + '</li></ul></div>';
                });
                html += '   </td>';
                html += '   <td colspan="2" style="border-right:dashed 0px #e6e6e6">';
                html += '       <h4>ปัก</h4>';
                $(item.sewOptions).each(function (index, i) {
                    html += '       <div><ul<li>' + utilities.GetFileName(i.patternImagePath) + '</li></ul></div>';
                });
                html += '   </td>';
                html += '</tr>'
            }
        });
        $("#productItems").empty().html(html);
    };
    var _getDocumentDetail = function (id) {
        var success = function (data, textStatus, jqXHR) {
            var issuedDate = utilities.ConvertToDate(data.issuedDate);
            var expirationDate = utilities.ConvertToDate(data.expirationDate);
            var expectedDeliveryDate = utilities.ConvertToDate(data.expectedDeliveryDate);
            $("#documentCode").val(data.documentCode);
            $("#issuedDate").datepicker('setDate', issuedDate);
            $("#expirationDate").datepicker('setDate', expirationDate);
            $("#expectedDeliveryDate").datepicker('setDate', expectedDeliveryDate);
            _getCustomerDetail(data.customerId);
            _getContactDetail(data.contactId);
            _getSaleDetail(data.saleUserId);
            _getDeliveryContactDetail(data.deliveryContactId);
            $(data.items).each(function (index, item) {
                items.push(item);
            });
            _render(items);

        }
        var failure = function (jqXHR, textStatus, errorThrown) {
            //alert(errorThrown);
        }
        var xhr = RPService.GetDocumentDetail(id, success, failure);
    };
    return {
        init: function () {
            var id = $("#documentId").val();
            _bindingSale();
            _bindingCustomer();
            _getDocumentDetail(id);
        },
        showItemDetail: function (itemId) {
            var isVisible = $("#" + itemId).is(":visible");
            if (isVisible) {
                $("#" + itemId).hide();
                var html = '<a class="collapse-link"><i class="fa fa-chevron-down"></i></a>';
                $("#icon_c1cc1b71-fa86-46c4-9972-024fe14bdc3f").html(html);
            } else {
                $("#" + itemId).show();
                var html = '<a class="collapse-link"><i class="fa fa-chevron-up"></i></a>';
                $("#icon_c1cc1b71-fa86-46c4-9972-024fe14bdc3f").html(html);
            }

        }
    }
};