var documentCreator = new function () {
    //variables
    var sales = [];
    var customers = [];
    var contacts = [];
    var items = [];
    var files = [];
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
    var _render = function (items) {
        var html = '';
        $(items).each(function (index, item) {
            var total = parseFloat((item.amount * item.pricePerUnit));
            html += '<tr>';
            html += '   <td>' + item.productName + '</td>';
            html += '   <td>' + item.productUnitName + '</td>';
            html += '   <td>' + item.amount + '</td>';
            html += '   <td>' + item.pricePerUnit + '</td>';
            html += '   <td>' + currency(total).format() + '</td>';
            html += '<tr>';
        });
        $("#productItems").empty().html(html);
    };
    var _save = function (callback) {
        var allItems = [];
        var formData = new FormData();

        $(items).each(function (index, item) {
            allItems.push(
                {
                    productId: item.productId,
                    productUnitId: item.productUnitId,
                    amount: item.amount,
                    pricePerUnit: item.pricePerUnit,
                }
            );
        });
        var document = {
            //documentCode: $("#DocumentCode").val(),
            issuedDate: $("#issuedDate").val(),//Date.parse($("#issuedDate").val()),
            expirationDate: $("#expirationDate").val(),//Date.parse($("#expirationDate").val()),
            expectedDeliveryDate: $("#expectedDeliveryDate").val(),//Date.parse($("#expectedDeliveryDate").val()),
            saleUserId: $("#auto_saleId").val(),
            customerId: $("#auto_customerId").val(),
            contactId: $("#auto_contactId").val(),
            items: allItems,
            deliveryAddress: $("#deliveryAddress").val(),
            deliveryContactId: $("#auto_deliveryContactId").val(),
            remark: $("#documentRemark").val()
        };
        formData.append("document", JSON.stringify(document));
        //for (var i = 0; i < files.length; i++) {
        //    formData.append(files[i].name, files[i]);
        //}
        var success = function (data, textStatus, jqXHR) {
            callback();
        }
        var failure = function (jqXHR, textStatus, errorThrown) {
        }
        var xhr = RPService.CreateDocument(formData, success, failure);
    };
    //all services
    return {
        init: function () {
            _bindingSale();
            _bindingCustomer();
        },
        RenderProducts: function () {
            items = [];
            items = productCreator.GetItems();
            _render(items);
        },
        SaveDocument: function (callback) {
            _save(callback);
        }
    }
};