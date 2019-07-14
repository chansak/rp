var documentEditorForBackoffice = new function () {
    var message = {
        info: {
            permissionDinyToSave: "รายการนี้ไม่สามารถแก้ไขได้เนื่องจากอยู่ขั้นตอนการขออนุมัติ",
        },
        error: {}
    };

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
            $("#auto_contactId").val(data.id);
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
            $("#auto_saleId").val(data.id);
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
            if (item.print != null || item.screen != null || item.sew != null) {
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
                if (item.print != null) {
                    if (item.print.selectedOption == 1) {
                        html += '       <div class="list-group">';
                        html += '           <a href="#" class="list-group-item">';
                        html += '               <div class="d-flex justify-content-between">';
                        //html += '                   <h5 class="mb-1">ลายเก่า</h5>';
                        html += '                   <small>ชื่อลาย :' + item.print.options1.patternName + '</small>';
                        html += '               </div>';
                        html += '               <img src="' + item.print.options1.patternImage + '" class="thumb-image" />';
                        html += '           </a>'
                        html += '       </div>';
                    }
                    else if (item.print.selectedOption == 2) {
                        html += '       <div class="list-group">';
                        html += '           <a href="#" class="list-group-item">';
                        html += '               <div class="d-flex justify-content-between">';
                        //html += '                   <h5 class="mb-1">ลายใหม่</h5>';
                        html += '                   <small>ชื่อลาย :' + item.print.options2.patternName + '</small>';
                        html += '               </div>';
                        html += '               <img src="' + item.print.options2.patternImage + '" class="thumb-image" />';
                        html += '           </a>'
                        html += '       </div>';
                    }
                    else { }
                }
                html += '   </td>';
                html += '   <td colspan="2" style="border-right:dashed 1px #e6e6e6">';
                html += '       <h4>สกรีน</h4>';
                if (item.screen != null) {
                    if (item.screen.selectedOption == 1) {
                        html += '       <div class="list-group">';
                        html += '           <a href="#" class="list-group-item">';
                        html += '               <div class="d-flex justify-content-between">';
                        //html += '                   <h5 class="mb-1">ลายเก่า</h5>';
                        html += '                   <small>ชื่อลาย :' + item.screen.options1.patternName + '</small>';
                        html += '               </div>';
                        html += '               <img src="' + item.screen.options1.patternImage + '" class="thumb-image" />';
                        html += '           </a>'
                        html += '       </div>';
                    }
                    else if (item.screen.selectedOption == 2) {
                        html += '       <div class="list-group">';
                        html += '           <a href="#" class="list-group-item">';
                        html += '               <div class="d-flex justify-content-between">';
                        //html += '                   <h5 class="mb-1">ลายใหม่</h5>';
                        html += '                   <small>ชื่อลาย :' + item.screen.options2.patternName + '</small>';
                        html += '               </div>';
                        html += '               <img src="' + item.screen.options2.patternImage + '" class="thumb-image" />';
                        html += '           </a>'
                        html += '       </div>';
                    }
                    else { }
                }
                html += '   </td>';
                html += '   <td colspan="2" style="border-right:dashed 0px #e6e6e6">';
                html += '       <h4>ปัก</h4>';
                if (item.sew != null) {
                    if (item.sew.selectedOption == 1) {
                        html += '       <div class="list-group">';
                        html += '           <a href="#" class="list-group-item">';
                        html += '               <div class="d-flex justify-content-between">';
                        //html += '                   <h5 class="mb-1">ลายเก่า</h5>';
                        html += '                   <small>ชื่อลาย :' + item.sew.options1.patternName + '</small>';
                        html += '               </div>';
                        html += '               <img src="' + item.sew.options1.patternImage + '" class="thumb-image" />';
                        html += '           </a>'
                        html += '       </div>';
                    }
                    else if (item.sew.selectedOption == 2) {
                        html += '       <div class="list-group">';
                        html += '           <a href="#" class="list-group-item">';
                        html += '               <div class="d-flex justify-content-between">';
                        //html += '                   <h5 class="mb-1">ลายใหม่</h5>';
                        html += '                   <small>ชื่อลาย :' + item.sew.options2.patternName + '</small>';
                        html += '               </div>';
                        html += '               <img src="' + item.sew.options2.patternImage + '" class="thumb-image" />';
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
            if (data.documentStatusId == 6) {
                $("#gotPO").show();
                $("#poNumber").val(data.poNumber);
            }
            //var issuedDate = utilities.ConvertToDate(data.issuedDate);
            //var expirationDate = utilities.ConvertToDate(data.expirationDate);
            //var expectedDeliveryDate = utilities.ConvertToDate(data.expectedDeliveryDate);
            $("#documentCode").val(data.documentCode);
            //$("#issuedDate").datepicker('setDate', issuedDate);
            //$("#expirationDate").datepicker('setDate', expirationDate);
            //$("#expectedDeliveryDate").datepicker('setDate', expectedDeliveryDate);
            $("#priceValidityDays").val(data.confirmPriceDays);
            $("#numberOfDeliveryDays").val(data.deliveryDays);
            $("#deliveryAddress").val(data.deliveryAddress);
            $("#documentRemark").val(data.remark);
            _getCustomerDetail(data.customerId);
            _getContactDetail(data.contactId);
            _getSaleDetail(data.saleUserId);
            _getDeliveryContactDetail(data.deliveryContactId);
            $(data.items).each(function (index, data) {
                var printOption = data.printOption;
                var screenOption = data.screenOption;
                var sewOption = data.sewOption;

                var o1 = null;
                var o2 = null;
                var o3 = null;
                if (printOption != null) {
                    o1 = {
                        selectedOption: data.printOption.selectedOption,
                        options1: {
                            patternId: printOption.patternId,
                            patternName: printOption.patternName,
                            patternImage: printOption.patternImagePath
                        },
                        options2: {
                            patternId: printOption.patternId,
                            patternName: printOption.patternName,
                            patternImage: printOption.patternImagePath

                        },
                        options3: {
                        },
                    };
                }
                if (screenOption != null) {
                    o2 = {
                        selectedOption: data.screenOption.selectedOption,
                        options1: {
                            patternId: screenOption.patternId,
                            patternName: screenOption.patternName,
                            patternImage: screenOption.patternImagePath
                        },
                        options2: {
                            patternId: screenOption.patternId,
                            patternName: screenOption.patternName,
                            patternImage: screenOption.patternImagePath

                        },
                        options3: {
                        },
                    };
                }
                if (sewOption != null) {
                    o3 = {
                        selectedOption: data.sewOption.selectedOption,
                        options1: {
                            patternId: sewOption.patternId,
                            patternName: sewOption.patternName,
                            patternImage: sewOption.patternImagePath
                        },
                        options2: {
                            patternId: sewOption.patternId,
                            patternName: sewOption.patternName,
                            patternImage: sewOption.patternImagePath

                        },
                        options3: {
                        },
                    };
                }
                var item = {
                    itemId: data.itemId,
                    productId: data.productId,
                    productName: data.productName,
                    productUnitId: data.productUnitId,
                    productUnitName: data.productUnitName,
                    amount: parseFloat(data.amount),
                    pricePerUnit: parseFloat(data.pricePerUnit),
                    remark: data.remark,
                    print: o1,
                    screen: o2,
                    sew: o3
                };
                items.push(item);
            });
            _render(items);

        }
        var failure = function (jqXHR, textStatus, errorThrown) {
            //alert(errorThrown);
        }
        var xhr = RPService.GetDocumentDetailForBackoffice(id, success, failure);
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
    var _openModalForEditing = function (customerId, itemId) {
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
        var xhr = RPService.IsExistingItemForBackoffice(itemId, success, failure);
    };
    var _validation = function (id, callback) {
        var success = function (result, textStatus, jqXHR) {
            //RequestedForApproval = 2,
            var documentStatusId = parseInt(result);
            if (documentStatusId == 2) {
                toastr.info(message.info.permissionDinyToSave, 'Infomration');
            } else {
                callback();
            }
        }
        var failure = function (jqXHR, textStatus, errorThrown) {
        }
        var xhr = RPService.GetCurrentWorkflowStatusForBackoffice(id, success, failure);
    };
    var _save = function (callback) {
        var allItems = [];
        var formData = new FormData();
        $(items).each(function (index, item) {
            var printOptions = item.print;
            var screenOptions = item.screen;
            var sewOptions = item.sew;

            //print options
            var printData = {};
            if (printOptions != null) {
                if (printOptions.selectedOption == 1) {
                    printData = {
                        selectedOption: printOptions.selectedOption,
                        patternId: printOptions.options1.patternId || 0,
                        colorId: 0
                    };
                } else if (printOptions.selectedOption == 2) {
                    printData = {
                        selectedOption: printOptions.selectedOption,
                        patternId: 0,
                        colorId: printOptions.options2.colorId || 0
                    };
                    formData.append("printFile", printOptions.options2.file);
                } else {
                    printData = {
                        selectedOption: printOptions.selectedOption,
                        patternId: 0,
                        colorId: 0
                    };
                }
            }

            //screen options
            var screenData = {};
            if (screenOptions != null) {
                if (screenOptions.selectedOption == 1) {
                    screenData = {
                        selectedOption: screenOptions.selectedOption,
                        patternId: screenOptions.options1.patternId || 0,
                        colorId: 0,
                        positionId: 0,
                    }
                } else if (screenOptions.selectedOption == 2) {
                    screenData = {
                        selectedOption: screenOptions.selectedOption,
                        patternId: 0,
                        colorId: screenOptions.options2.colorId || 0,
                        positionId: screenOptions.options2.positionId || 0,
                    };
                    formData.append("screenFile", screenOptions.options2.file);
                } else {
                    screenData = {
                        selectedOption: screenOptions.selectedOption,
                        patternId: 0,
                        colorId: 0,
                        positionId: 0,
                    };
                }
            }

            //sew options
            var sewData = {};
            if (sewOptions != null) {
                if (sewOptions.selectedOption == 1) {
                    sewData = {
                        selectedOption: sewOptions.selectedOption,
                        patternId: sewOptions.options1.patternId || 0,
                        positionId: 0,
                        remark: ''
                    };
                } else if (sewOptions.selectedOption == 2) {
                    sewData = {
                        selectedOption: sewOptions.selectedOption,
                        patternId: 0,
                        positionId: sewOptions.options2.positionId || 0,
                        remark: sewOptions.options2.remark
                    };
                    formData.append("sewFile", sewOptions.options2.file);
                } else {
                    sewData = {
                        selectedOption: sewOptions.selectedOption,
                        patternId: 0,
                        positionId: 0,
                        remark: ''
                    };
                }
            }
            allItems.push(
                {
                    productId: item.productId,
                    productUnitId: item.productUnitId,
                    amount: item.amount,
                    pricePerUnit: item.pricePerUnit || 0,
                    printOption: printData,
                    screenOption: screenData,
                    sewOption: sewData
                }
            );
        });
        var documentId = $("#documentId").val();
        if (_validation(documentId, function () {
            var document = {
                id: documentId,
                poNumber: $("#poNumber").val(),
                //issuedDate: $("#issuedDate").val(),
                //createdDate: $("#createdDate").val(),
                expirationDate: $("#expirationDate").val(),
                //expectedDeliveryDate: $("#expectedDeliveryDate").val(),
                saleUserId: $("#auto_saleId").val(),
                customerId: $("#auto_customerId").val(),
                contactId: $("#auto_contactId").val(),
                items: allItems,
                deliveryAddress: $("#deliveryAddress").val(),
                //deliveryContactId: $("#auto_deliveryContactId").val(),
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
            var xhr = RPService.UpdateDocumentForBackoffice(formData, success, failure);
        }));
    };
    var _saveWithComments = function (callback) {
        var allItems = [];
        var formData = new FormData();
        $(items).each(function (index, item) {
            var printOptions = item.print;
            var screenOptions = item.screen;
            var sewOptions = item.sew;

            var printData = {};
            if (printOptions != null) {
                if (printOptions.selectedOption == 1) {
                    printData = {
                        selectedOption: printOptions.selectedOption,
                        patternId: printOptions.options1.patternId || 0,
                        colorId: 0
                    };
                } else if (printOptions.selectedOption == 2) {
                    printData = {
                        selectedOption: printOptions.selectedOption,
                        patternId: 0,
                        colorId: printOptions.options2.colorId || 0
                    };
                    formData.append("printFile", printOptions.options2.file);
                } else {
                    printData = {
                        selectedOption: printOptions.selectedOption,
                        patternId: 0,
                        colorId: 0
                    };
                }
            }
            var screenData = {};
            if (screenOptions != null) {
                if (screenOptions.selectedOption == 1) {
                    screenData = {
                        selectedOption: screenOptions.selectedOption,
                        patternId: screenOptions.options1.patternId || 0,
                        colorId: 0,
                        positionId: 0,
                    }
                } else if (screenOptions.selectedOption == 2) {
                    screenData = {
                        selectedOption: screenOptions.selectedOption,
                        patternId: 0,
                        colorId: screenOptions.options2.colorId || 0,
                        positionId: screenOptions.options2.positionId || 0,
                    };
                    formData.append("screenFile", screenOptions.options2.file);
                } else {
                    screenData = {
                        selectedOption: screenOptions.selectedOption,
                        patternId: 0,
                        colorId: 0,
                        positionId: 0,
                    };
                }
            }
            var sewData = {};
            if (sewOptions != null) {
                if (sewOptions.selectedOption == 1) {
                    sewData = {
                        selectedOption: sewOptions.selectedOption,
                        patternId: sewOptions.options1.patternId || 0,
                        positionId: 0,
                        remark: ''
                    };
                } else if (sewOptions.selectedOption == 2) {
                    sewData = {
                        selectedOption: sewOptions.selectedOption,
                        patternId: 0,
                        positionId: sewOptions.options2.positionId || 0,
                        remark: sewOptions.options2.remark
                    };
                    formData.append("sewFile", sewOptions.options2.file);
                } else {
                    sewData = {
                        selectedOption: sewOptions.selectedOption,
                        patternId: 0,
                        positionId: 0,
                        remark: ''
                    };
                }
            }
            allItems.push(
                {
                    productId: item.productId,
                    productUnitId: item.productUnitId,
                    amount: item.amount,
                    pricePerUnit: item.pricePerUnit || 0,
                    printOption: printData,
                    screenOption: screenData,
                    sewOption: sewData
                }
            );
        });
        var documentId = $("#documentId").val();
        _validation(documentId, function () {
            var document = {
                id: documentId,
                poNumber: $("#poNumber").val(),
                //issuedDate: $("#issuedDate").val(),
                //createdDate: $("#createdDate").val(),
                expirationDate: $("#expirationDate").val(),
                //expectedDeliveryDate: $("#expectedDeliveryDate").val(),
                saleUserId: $("#auto_saleId").val(),
                customerId: $("#auto_customerId").val(),
                contactId: $("#auto_contactId").val(),
                items: allItems,
                deliveryAddress: $("#deliveryAddress").val(),
                //deliveryContactId: $("#auto_deliveryContactId").val(),
                remark: $("#documentRemark").val(),
                comments: $("#comments").val()
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
            var xhr = RPService.UpdateDocumentWithCommentsForBackoffice(formData, success, failure);
        });
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
                var html = '<a class="collapse-link"><i class="fa fa-chevron-up"></i></a>'; var html = '<div class="checkbox i-checks"><label> <input type="checkbox" value="' + itemId + '" > <i></i></label></div>';
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
        OpenEditor: function (customerId, itemId) {
            _openModalForEditing(customerId, itemId);
        },
        SaveDocument: function (callback) {
            _save(callback);
        },
        SaveDocumentWithComments: function (callback) {
            _saveWithComments(callback);
        },
    }
};