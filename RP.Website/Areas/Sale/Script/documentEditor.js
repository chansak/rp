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
            $("#auto_customerId").val(data.id);
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
            if (item.printOption != null || item.screenOption != null || item.sewOption != null) {
                if (item.itemId != null) {
                    html += '<tr onclick="documentEditor.showItemDetail(' + id + ')">';
                    html += '   <td style="width:5%;" id="icon_' + item.itemId + '"><div class="checkbox i-checks"><label> <input type="checkbox" name="productItemId" value="' + item.itemId + '" > <i></i></label></div></td>';
                } else {
                    html += '<tr>';
                    html += '<td></td>';
                }
            } else {
                html += '<tr>';
                html += '   <td style="width:5%;" id="icon_' + item.itemId + '"><div class="checkbox i-checks"><label> <input type="checkbox" name="productItemId" value="' + item.itemId + '" > <i></i></label></div></td>';
            }
            html += '   <td style="width:25%;line-height:40px">' + item.productName + '</td>';
            html += '   <td style="width:15%;line-height:40px">' + item.productUnitName + '</td>';
            html += '   <td style="width:15%;line-height:40px">' + item.amount + '</td>';
            html += '   <td style="width:15%;line-height:40px">' + item.pricePerUnit + '</td>';
            html += '   <td style="width:15%;line-height:40px">' + currency(total).format() + '</td>';
            html += '<tr>';
            if (item.itemId != null) {
                html += '<tr id=' + item.itemId + ' style="background-color: #ffffff;display:none">'
                html += '   <td colspan="2" style="border-right:dashed 1px #e6e6e6">'
                html += '       <h4>พิมพ์</h4>';
                if (item.printOption != null) {
                    if (item.printOption.selectedOption == 1) {
                        html += '       <div class="list-group">';
                        html += '           <a href="#" class="list-group-item">';
                        html += '               <div class="d-flex justify-content-between">';
                        //html += '                   <h5 class="mb-1">ลายเก่า</h5>';
                        html += '                   <small>ชื่อลาย :' + item.printOption.patternName + '</small>';
                        html += '               </div>';
                        html += '               <img src="' + item.printOption.patternImagePath + '" class="thumb-image" />';
                        html += '           </a>'
                        html += '       </div>';
                    }
                    else if (item.printOption.selectedOption == 2) {
                        console.log(item.printOption);
                        html += '       <div class="list-group">';
                        html += '           <a href="#" class="list-group-item">';
                        html += '               <div class="d-flex justify-content-between">';
                        //html += '                   <h5 class="mb-1">ลายใหม่</h5>';
                        html += '                   <small>ชื่อลาย :' + item.printOption.patternName + '</small>';
                        html += '               </div>';
                        html += '               <img src="' + item.printOption.patternImagePath + '" class="thumb-image" />';
                        html += '           </a>'
                        html += '       </div>';
                    }
                    else { }
                }
                html += '   </td>';
                html += '   <td colspan="2" style="border-right:dashed 1px #e6e6e6">';
                html += '       <h4>สกรีน</h4>';
                if (item.screenOption != null) {
                    if (item.screenOption.selectedOption == 1) {
                        html += '       <div class="list-group">';
                        html += '           <a href="#" class="list-group-item">';
                        html += '               <div class="d-flex justify-content-between">';
                        //html += '                   <h5 class="mb-1">ลายเก่า</h5>';
                        html += '                   <small>ชื่อลาย :' + item.screenOption.patternName + '</small>';
                        html += '               </div>';
                        html += '               <img src="' + item.screenOption.patternImagePath + '" class="thumb-image" />';
                        html += '           </a>'
                        html += '       </div>';
                    }
                    else if (item.screenOption.selectedOption == 2) {
                        html += '       <div class="list-group">';
                        html += '           <a href="#" class="list-group-item">';
                        html += '               <div class="d-flex justify-content-between">';
                        //html += '                   <h5 class="mb-1">ลายใหม่</h5>';
                        html += '                   <small>ชื่อลาย :' + item.screenOption.patternName + '</small>';
                        html += '               </div>';
                        html += '               <img src="' + item.screenOption.patternImagePath + '" class="thumb-image" />';
                        html += '           </a>'
                        html += '       </div>';
                    }
                    else { }
                }
                html += '   </td>';
                html += '   <td colspan="2" style="border-right:dashed 0px #e6e6e6">';
                html += '       <h4>ปัก</h4>';
                if (item.sewOption != null) {
                    if (item.sewOption.selectedOption == 1) {
                        html += '       <div class="list-group">';
                        html += '           <a href="#" class="list-group-item">';
                        html += '               <div class="d-flex justify-content-between">';
                        //html += '                   <h5 class="mb-1">ลายเก่า</h5>';
                        html += '                   <small>ชื่อลาย :' + item.sewOption.patternName + '</small>';
                        html += '               </div>';
                        html += '               <img src="' + item.sewOption.patternImagePath + '" class="thumb-image" />';
                        html += '           </a>'
                        html += '       </div>';
                    }
                    else if (item.printOption.selectedOption == 2) {
                        html += '       <div class="list-group">';
                        html += '           <a href="#" class="list-group-item">';
                        html += '               <div class="d-flex justify-content-between">';
                        //html += '                   <h5 class="mb-1">ลายใหม่</h5>';
                        html += '                   <small>ชื่อลาย :' + item.sewOption.patternName + '</small>';
                        html += '               </div>';
                        html += '               <img src="' + item.sewOption.patternImagePath + '" class="thumb-image" />';
                        html += '           </a>'
                        html += '       </div>';
                    }
                    else { }
                }
                html += '   </td>';
                html += '</tr>'
            }
        });
        $("#productItems").empty().html(html);
        $('.i-checks').iCheck({
            checkboxClass: 'icheckbox_square-green',
            radioClass: 'iradio_square-green',
        });
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
                console.log(item);
                items.push(item);
            });
            _render(items);

        }
        var failure = function (jqXHR, textStatus, errorThrown) {
            //alert(errorThrown);
        }
        var xhr = RPService.GetDocumentDetail(id, success, failure);
    };
    var _updateItem = function (item) {
        $(items).each(function (index, value) {
            if (value.itemId == item.itemId) {
                value.productId = item.productId;
                value.productName = item.productName;
                value.productUnitId = item.productUnitId;
                value.productUnitName = item.productUnitName;
                value.amount = item.amount || 0;
                value.pricePerUnit = item.pricePerUnit || 0;
                value.file = null;
                value.remark = item.remark;
                if (value.print != null) {
                    value.print = item.print;
                }
                if (value.screen != null) {
                    value.screen = item.screen;
                }
                if (value.sew != null) {
                    value.sew = item.sew;
                }
            }
        });
    };
    var _openModelForEditing = function (customerId,itemId) {
        var success = function (result, textStatus, jqXHR) {
            if (result == undefined || result == false) {
                result = false;
            } else { result = true; }
            $("#editProductModal").modal({ backdrop: "static" });
            var selectedItem = utilities.FindObjectByKey(items, 'itemId', itemId);
            productEditor.edit(customerId, selectedItem, result);
        }
        var failure = function (jqXHR, textStatus, errorThrown) {
            //alert(errorThrown);
        }
        var xhr = RPService.IsExistingItem(itemId, success, failure);
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
                //var html = '<a class="collapse-link"><i class="fa fa-chevron-down"></i></a>';
                var html = '<div class="checkbox i-checks"><label> <input type="checkbox" name="productItemId" value="' + itemId + '" > <i></i></label></div>';

                $("#icon_" + itemId).html(html);
            } else {
                $("#" + itemId).show();
                //var html = '<a class="collapse-link"><i class="fa fa-chevron-up"></i></a>';var html = '<div class="checkbox i-checks"><label> <input type="checkbox" value="' + itemId +'" > <i></i></label></div>';
                $("#icon_" + itemId).html(html);
            }
            $('.i-checks').iCheck({
                checkboxClass: 'icheckbox_square-green',
                radioClass: 'iradio_square-green',
            });
        },
        getItemsById: function (itemId) {
            return utilities.FindObjectByKey(items, 'itemId', itemId);
        },
        RenderProducts: function () {
            var item = productEditor.GetItem();
            var mode = productEditor.getMode();
            if (mode == RpMode.addNew || mode == RpMode.copy) {
                items.push(item);
            } else {
                _updateItem(item);
            }
            _render(items);
        },
        IsExistingItem: function (itemId, callback) {
            _isExisingItem(itemId);
        },
        OpenEditor: function (customerId,itemId) {
            _openModelForEditing(customerId,itemId);
        },
    }
};