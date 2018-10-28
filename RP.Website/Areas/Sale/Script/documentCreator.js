﻿var documentCreator = new function () {
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
                    printOption: {},
                    screenOption: {},
                    sewOption: {}
                }
            );
        });
        var document = {
            issuedDate: $("#issuedDate").val(),
            expirationDate: $("#expirationDate").val(),
            expectedDeliveryDate: $("#expectedDeliveryDate").val(),
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
    var _renderPreviewImage = function () {
        $(items).each(function (index, item) {
            if (item.print.selectedOption == 2) {
                var image_holder = $("#printNewFileImage");
                image_holder.empty();
                if (typeof (FileReader) != "undefined") {
                    var reader = new FileReader();
                    reader.onload = function (e) {
                        $("<img />", {
                            "src": e.target.result,
                            "class": "thumb-image"
                        }).appendTo(image_holder);
                    }
                    reader.readAsDataURL(item.print.options2.file);

                } else {
                    alert("This browser does not support FileReader.");
                }
            }
            if (item.screen.selectedOption == 2) {
                var image_holder = $("#screenNewFileImage");
                image_holder.empty();
                if (typeof (FileReader) != "undefined") {
                    var reader = new FileReader();
                    reader.onload = function (e) {
                        $("<img />", {
                            "src": e.target.result,
                            "class": "thumb-image"
                        }).appendTo(image_holder);
                    }
                    reader.readAsDataURL(item.screen.options2.file);

                } else {
                    alert("This browser does not support FileReader.");
                }
            }
            if (item.sew.selectedOption == 2) {
                var image_holder = $("#sewNewFileImage");
                image_holder.empty();
                if (typeof (FileReader) != "undefined") {
                    var reader = new FileReader();
                    reader.onload = function (e) {
                        $("<img />", {
                            "src": e.target.result,
                            "class": "thumb-image"
                        }).appendTo(image_holder);
                    }
                    reader.readAsDataURL(item.sew.options2.file);

                } else {
                    alert("This browser does not support FileReader.");
                }
            }
        });
    }
    var _render = function (items) {
        var html = '';
        $(items).each(function (index, item) {
            var total = parseFloat((item.amount * item.pricePerUnit));
            if (item.print.selectedOption > 0 || item.screen.selectedOption > 0 || item.sew.selectedOption > 0) {
                html += '<tr onclick="documentCreator.showItemDetail(' + index + ')">';
                html += '   <td style="width:15%" id="icon_' + index + '"><a class="collapse-link"><i class="fa fa-chevron-down"></i></a></td>';
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
            if (item.print.selectedOption > 0 || item.screen.selectedOption > 0 || item.sew.selectedOption > 0) {
                html += '<tr id=' + index + ' style="background-color: #ffffff;display:none">'
                html += '   <td colspan="2" style="border-right:dashed 1px #e6e6e6">'
                html += '       <h4>พิมพ์</h4>';
                if (item.print.selectedOption == 1) {
                    var option = item.print.options1;
                    html += '       <div class="list-group">';
                    html += '           <a href="#" class="list-group-item">';
                    html += '               <div class="d-flex justify-content-between">';
                    html += '                   <h5 class="mb-1">ลายเก่า</h5>';
                    html += '                   <small>ชื่อลาย :' + option.patternName +'</small>';
                    html += '               </div>';
                    html += '               <img src="../../FileUpload/pattern/' + option.patternImage.imagePath + '" />';
                    html += '           </a>'
                    html += '       </div>';
                }
                else if (item.print.selectedOption == 2) {
                    var option = item.print.options2;
                    html += '       <div class="list-group">';
                    html += '           <a href="#" class="list-group-item">';
                    html += '               <div class="d-flex justify-content-between">';
                    html += '                   <h5 class="mb-1">ลายใหม่</h5>';
                    html += '                   <small>พิมพ์สี :' + option.colorName + '</small>';
                    html += '               </div>';
                    html += '               <div id="printNewFileImage" />';
                    html += '           </a>'
                    html += '       </div>';
                }
                else { }
                html += '   </td>';
                html += '   <td colspan="2" style="border-right:dashed 1px #e6e6e6">';
                html += '       <h4>สกรีน</h4>';
                if (item.screen.selectedOption == 1) {
                    var option = item.screen.options1;
                    html += '       <div class="list-group">';
                    html += '           <a href="#" class="list-group-item">';
                    html += '               <div class="d-flex justify-content-between">';
                    html += '                   <h5 class="mb-1">ลายเก่า</h5>';
                    html += '                   <small>ชื่อลาย :' + option.patternName + '</small>';
                    html += '               </div>';
                    html += '               <img src="../../FileUpload/pattern/' + option.patternImage.imagePath + '" />';
                    html += '           </a>'
                    html += '       </div>';
                }
                else if (item.screen.selectedOption == 2) {
                    var option = item.screen.options2;
                    html += '       <div class="list-group">';
                    html += '           <a href="#" class="list-group-item">';
                    html += '               <div class="d-flex justify-content-between">';
                    html += '                   <h5 class="mb-1">ลายใหม่</h5>';
                    html += '                   <small>พิมพ์สี :' + option.colorName + '</small>';
                    html += '                   <small>ตำแหน่ง :' + option.positionName + '</small>';
                    html += '               </div>';
                    html += '               <div id="screenNewFileImage" />';
                    html += '           </a>'
                    html += '       </div>';
                }
                else { }
                html += '   </td>';
                html += '   <td colspan="2" style="border-right:dashed 0px #e6e6e6">';
                html += '       <h4>ปัก</h4>';
                if (item.sew.selectedOption == 1) {
                    var option = item.sew.options1;
                    html += '       <div class="list-group">';
                    html += '           <a href="#" class="list-group-item">';
                    html += '               <div class="d-flex justify-content-between">';
                    html += '                   <h5 class="mb-1">ลายเก่า</h5>';
                    html += '                   <small>ชื่อลาย :' + option.patternName + '</small>';
                    html += '               </div>';
                    html += '               <img src="../../FileUpload/pattern/' + option.patternImage.imagePath + '" />';
                    html += '           </a>'
                    html += '       </div>';
                }
                else if (item.sew.selectedOption == 2) {
                    var option = item.sew.options2;
                    html += '       <div class="list-group">';
                    html += '           <a href="#" class="list-group-item">';
                    html += '               <div class="d-flex justify-content-between">';
                    html += '                   <h5 class="mb-1">ลายใหม่</h5>';
                    html += '                   <small>ตำแหน่ง :' + option.positionName + '</small>';
                    html += '                   <small>เพิ่มเติม :' + option.remark + '</small>';
                    html += '               </div>';
                    html += '               <div id="sewNewFileImage" />';
                    html += '           </a>'
                    html += '       </div>';
                }
                else { }
                html += '   </td>';
                html += '</tr>'
            }
        });
        $("#productItems").empty().html(html);
        _renderPreviewImage();
    };

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
        },
        showItemDetail: function (itemId) {
            var isVisible = $("#" + itemId).is(":visible");
            if (isVisible) {
                $("#" + itemId).hide();
                var html = '<a class="collapse-link"><i class="fa fa-chevron-down"></i></a>';
                $("#icon_" + itemId).html(html);
            } else {
                $("#" + itemId).show();
                var html = '<a class="collapse-link"><i class="fa fa-chevron-up"></i></a>';
                $("#icon_" + itemId).html(html);
            }

        }
    }
};