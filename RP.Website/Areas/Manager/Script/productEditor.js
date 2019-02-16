var productEditorForManager = new function () {
    var item;
    var rowItem;
    var customerId = '';
    var images = [];
    var items = [];
    var colors = [];
    var positions = [];
    var materials = [];
    //1= addNew , 2= edit
    var mode = null;
    var _bindingProductCategories = function () {
        var success = function (data, textStatus, jqXHR) {
            $('#editProductCategories').empty();
            $(data).each(function (index, item) {
                $('#editProductCategories').append($('<option>', {
                    value: item.id,
                    text: item.categoryName
                }));
            });
            $("#editProductCategories").prepend("<option value='' selected='selected'>เลือกประเภทสินค้า</option>");
            $("#editProductCategories").unbind();
            $("#editProductCategories").change(function () {
                var selectedCategoryId = '';
                selectedCategoryId = $('#editProductCategories').val();
                if (selectedCategoryId != '') {
                    _bindingProducts(selectedCategoryId);
                } else {
                    $("#editProducts").find('option').remove().end();
                    $("#editProductOptions").find('option').remove().end();
                }
            });
            if (mode == RpMode.edit || mode == RpMode.copy) {
                $("#editProductCategories").val(rowItem.productCategoryId).change();
            }
        }
        var failure = function (jqXHR, textStatus, errorThrown) {
            //alert(errorThrown);
        }
        var xhr = RPService.GetProductCategories(success, failure);
    };
    var _bindingProducts = function (id) {
        var success = function (data, textStatus, jqXHR) {
            $('#editProducts').empty();
            $(data).each(function (index, item) {
                $('#editProducts').append($('<option>', {
                    value: item.id,
                    text: item.productName
                }));
            });
            $("#editProducts").prepend("<option value='' selected='selected'>เลือกสินค้า</option>");
            $("#editProducts").unbind();
            $("#editProducts").change(function () {
                var selectedProductId = '';
                selectedProductId = $('#editProducts').val();
                if (selectedProductId != '') {
                    _bindingProductOptions(selectedProductId);
                    _bindingProductUnits(selectedProductId);
                } else {
                    $("#editProductOptions").find('option').remove().end();
                    $("#editProductsUnit").find('option').remove().end();
                }
            });
            if (mode == RpMode.edit || mode == RpMode.copy)
                $("#editProducts").val(rowItem.productId).change();
        }
        var failure = function (jqXHR, textStatus, errorThrown) {
            //alert(errorThrown);
        }
        var xhr = RPService.GetProductsByCategoryId(id, success, failure);
    };
    var _bindingProductUnits = function (id) {
        var success = function (data, textStatus, jqXHR) {
            $('#editProductsUnit').empty();
            $(data).each(function (index, item) {
                $('#editProductsUnit').append($('<option>', {
                    value: item.id,
                    text: item.unitName
                }));
            });
            $("#editProductsUnit").prepend("<option value='' selected='selected'>เลือกหน่วยนับ</option>");
            $("#editProductsUnit").unbind();
            $("#editProductsUnit").change(function () {
                _materialStockCheck()
            });
            if (mode == RpMode.edit || mode == RpMode.copy) {
                $("#editProductsUnit").val(rowItem.productUnitId).change();
            }
        }
        var failure = function (jqXHR, textStatus, errorThrown) {
            //alert(errorThrown);
        }
        var xhr = RPService.GetUnitsByProductId(id, success, failure);
    };
    var _bindingProductOptions = function (id) {
        var success = function (data, textStatus, jqXHR) {
            $('#editProductOptions').empty();
            $(data).each(function (index, item) {
                $('#editProductOptions').append($('<option>', {
                    value: item.id,
                    text: item.optionName
                }));
            });
            $("#editProductOptions").prepend("<option value='' selected='selected'>เลือกรายละเอียด</option>");
            $("#editProductOptions").unbind();
            $("#editProductOptions").change(function () {
                var selectedProductOptionsId = '';
                selectedProductOptionsId = $('#editProductOptions').val();
            });
            if (mode == RpMode.edit || mode == RpMode.copy) {
                $("#editProductOptions").val(rowItem.productOptionId).change();
            }

        }
        var failure = function (jqXHR, textStatus, errorThrown) {
            //alert(errorThrown);
        }
        var xhr = RPService.GetOptionsByProductId(id, success, failure);
    };
    var _bindingPatternImage = function (callback) {
        var success = function (data, textStatus, jqXHR) {
            $('#editPrint-pattern').empty();
            $('#editScreen-pattern').empty();
            $('#editSew-pattern').empty();
            $(data).each(function (index, item) {
                images.push(item);
                $('#editPrint-pattern').append($('<option>', {
                    value: item.id,
                    text: item.patternName
                }));
                $('#editScreen-pattern').append($('<option>', {
                    value: item.id,
                    text: item.patternName
                }));
                $('#editSew-pattern').append($('<option>', {
                    value: item.id,
                    text: item.patternName
                }));

                $("#editPrint-pattern").change(function () {
                    var selectedImageId = $('#editPrint-pattern').val();
                    var image = utilities.FindObjectByKey(images, 'id', selectedImageId);
                    $("#editPrint-patternImage").html("<img src='../../FileUpload/pattern/" + image.imagePath + "' class='thumb-image' />");
                });
                $("#editScreen-pattern").change(function () {
                    var selectedImageId = $('#editScreen-pattern').val();
                    var image = utilities.FindObjectByKey(images, 'id', selectedImageId);
                    $("#editScreen-patternImage").html("<img src='../../FileUpload/pattern/" + image.imagePath + "' class='thumb-image' />");
                });
                $("#editSew-pattern").change(function () {
                    var selectedImageId = $('#editSew-pattern').val();
                    var image = utilities.FindObjectByKey(images, 'id', selectedImageId);
                    $("#editSew-patternImage").html("<img src='../../FileUpload/pattern/" + image.imagePath + "'  class='thumb-image'/>");
                });
            });
            $("#editPrint-pattern").prepend("<option value='' selected='selected'>เลือกลาย</option>");
            $("#editScreen-pattern").prepend("<option value='' selected='selected'>เลือกลาย</option>");
            $("#editSew-pattern").prepend("<option value='' selected='selected'>เลือกลาย</option>");
            if (callback != null) {
                callback();
            }

        }
        var failure = function (jqXHR, textStatus, errorThrown) {
            //alert(errorThrown);
        }
        var xhr = RPService.GetPatternImages(success, failure);
    };
    var _bindingPatternPosition = function (callback) {
        var success = function (data, textStatus, jqXHR) {
            $('#print-position').empty();
            $('#screen-position').empty();
            $('#sew-position').empty();
            $(data).each(function (index, item) {
                positions.push(item);
                $('#print-position').append($('<option>', {
                    value: item.id,
                    text: item.positionName
                }));
                $('#screen-position').append($('<option>', {
                    value: item.id,
                    text: item.positionName
                }));
                $('#sew-position').append($('<option>', {
                    value: item.id,
                    text: item.positionName
                }));
            });
            $("#print-position").prepend("<option value='' selected='selected'>เลือกตำแหน่ง</option>");
            $("#screen-position").prepend("<option value='' selected='selected'>เลือกตำแหน่ง</option>");
            $("#sew-position").prepend("<option value='' selected='selected'>เลือกตำแหน่ง</option>");
            if (callback != null) {
                callback();
            }
        }
        var failure = function (jqXHR, textStatus, errorThrown) {
            //alert(errorThrown);
        }
        var xhr = RPService.GetPatternPosition(success, failure);
    };
    var _bindingPatternColor = function (callback) {
        var success = function (data, textStatus, jqXHR) {
            $('#print-color').empty();
            $('#screen-color').empty();
            $('#sew-color').empty();
            $(data).each(function (index, item) {
                $('#print-color').append($('<option>', {
                    value: item.id,
                    text: item.colorName
                }));
                $('#screen-color').append($('<option>', {
                    value: item.id,
                    text: item.colorName
                }));
                $('#sew-color').append($('<option>', {
                    value: item.id,
                    text: item.colorName
                }));
            });
            $("#print-color").prepend("<option value='' selected='selected'>เลือกสี</option>");
            $("#screen-color").prepend("<option value='' selected='selected'>เลือกสี</option>");
            $("#sew-color").prepend("<option value='' selected='selected'>เลือกสี</option>");
            if (callback != null) {
                callback();
            }
        }
        var failure = function (jqXHR, textStatus, errorThrown) {
            //alert(errorThrown);
        }
        var xhr = RPService.GetPatternColors(success, failure);
    };
    var _bindingMaterial = function () {
        var success = function (data, textStatus, jqXHR) {
            $('#editMaterials').empty();
            $(data).each(function (index, item) {
                materials.push(item);
                $('#editMaterials').append($('<option>', {
                    value: item.id,
                    text: item.materialName
                }));
            });
            $("#editMaterials").prepend("<option value='' selected='selected'>เลือกผ้า</option>");
        }
        var failure = function (jqXHR, textStatus, errorThrown) {
        }
        var xhr = RPService.GetMaterials(success, failure);
    };

    var _materialStockCheck = function () {
        var success = function (data, textStatus, jqXHR) {
            var html = "";
            $(data).each(function (index, item) {
                html += '<div class="row">';
                html += '   <div class="col-sm-3">';
                html += '       <div class="form-group">';
                html += '           <label>ผ้า</label>';
                html += '           <input type="text" id="materialName" class="form-control" disabled value="' + item.materialName + '">';
                html += '       </div>';
                html += '   </div>';
                if (item.materialInStock <= 0) {
                    html += '   <div class="col-sm-3">';
                    html += '       <div class="form-group">';
                    html += '           <label>จำนวนผ้าในสต๊อค</label>';
                    html += '           <input type="text" id="materialInStock" class="form-control" style="color:red" disabled value="' + item.materialInStock + '">';
                    html += '       </div>';
                    html += '   </div>';
                } else {
                    html += '   <div class="col-sm-3">';
                    html += '       <div class="form-group">';
                    html += '           <label>จำนวนผ้าในสต๊อค</label>';
                    html += '           <input type="text" id="materialInStock" class="form-control" disabled value="' + item.materialInStock + '">';
                    html += '       </div>';
                    html += '   </div>';
                }
                html += '   <div class="col-sm-3">';
                html += '       <div class="form-group">';
                html += '           <label>ผ้าที่ต้องใช้</label>';
                html += '           <input type="text" id="materialUsaged" class="form-control" disabled value="' + item.materialUsaged + '">';
                html += '       </div>';
                html += '   </div>';
                if (item.materialInStockAfterWithdraw <= 0) {
                    html += '   <div class="col-sm-3">';
                    html += '       <div class="form-group">';
                    html += '           <label>ผ้าคงเหลือ</label>';
                    html += '           <input type="text" id="materialInStockAfterWithdraw" class="form-control" style="color:red" disabled value="' + item.materialInStockAfterWithdraw + '">';
                    html += '       </div>';
                    html += '   </div>';
                    html += '</div>';
                } else {
                    html += '   <div class="col-sm-3">';
                    html += '       <div class="form-group">';
                    html += '           <label>ผ้าคงเหลือ</label>';
                    html += '           <input type="text" id="materialInStockAfterWithdraw" class="form-control" disabled value="' + item.materialInStockAfterWithdraw + '">';
                    html += '       </div>';
                    html += '   </div>';
                    html += '</div>';
                }
            });
            $("#materialStockCheck").empty().html(html);
        }
        var failure = function (jqXHR, textStatus, errorThrown) {
            //alert(errorThrown);
        }
        var productId = $("#editProducts").val();
        var amount = parseInt($("#editProductNumberOfProducts").val());
        var productUnitId = '';
        productUnitId = $('#editProductsUnit').val();
        var materialId = '';
        materialId = $('#editMaterials').val();
        if (amount < 0) { amount = 0; }
        if (productUnitId != '' && materialId != '') {
            var xhr = RPService.GetMaterialStockCheck(productId, productUnitId, materialId, amount, success, failure);
        }
    }
    var _getProductItemDetail = function(selectedItem) {
        var success = function (data, textStatus, jqXHR) {
            rowItem = data;
            item = data;
            $("#editProductNumberOfProducts").val(item.amount);
            $("#editProductPricePerUnit").val(item.pricePerUnit);
            _bindingProductCategories();
            _bindingPatternImage(function () {
                if (item.printOption.id != null) {
                    $("#editPrint-pattern").val(item.printOption.patternId);
                    $("#editPrint-option1-section").show();
                    $("#editPrint-option2-section").hide();
                    $("#editPrint-option3-section").hide();
                    $("#editPrint-optional1").parent().removeClass("iradio_square-green").addClass("iradio_square-green checked");
                    $("#editPrint-optional2").parent().removeClass("iradio_square-green checked").addClass("iradio_square-green");
                    $("#editPrint-optional3").parent().removeClass("iradio_square-green checked").addClass("iradio_square-green");
                }
            });
            _bindingPatternPosition(function () {
                if (item.screenOption.id != null) {
                    $("#editScreen-pattern").val(item.screenOption.patternId);
                    $("#editScreen-option1-section").show();
                    $("#editScreen-option2-section").hide();
                    $("#editScreen-option3-section").hide();
                    $("#editScreen-optional1").parent().removeClass("iradio_square-green").addClass("iradio_square-green checked");
                    $("#editScreen-optional2").parent().removeClass("iradio_square-green checked").addClass("iradio_square-green");
                    $("#editScreen-optional3").parent().removeClass("iradio_square-green checked").addClass("iradio_square-green");
                }
            });
            _bindingPatternColor(function () {
                if (item.sewOption.id != null) {
                    $("#editScreen-pattern").val(item.sewOption.patternId);
                    $("#editSew-option1-section").show();
                    $("#editSew-option2-section").hide();
                    $("#editSew-option3-section").hide();
                    $("#editSew-optional1").parent().removeClass("iradio_square-green").addClass("iradio_square-green checked");
                    $("#editSew-optional2").parent().removeClass("iradio_square-green checked").addClass("iradio_square-green");
                    $("#editSew-optional3").parent().removeClass("iradio_square-green checked").addClass("iradio_square-green");
                }
            });
            _bindingMaterial();
        }
        var failure = function (jqXHR, textStatus, errorThrown) { }
        var xhr = RPService.GetProductItemByItemId(selectedItem.itemId, success, failure);
    };
    var _getSelectedProductItemDetail = function (data) {
        rowItem = data;
        item = data;
        $("#editProductNumberOfProducts").val(item.amount);
        $("#editProductPricePerUnit").val(item.pricePerUnit);
        _bindingProductCategories();
        _bindingPatternImage(function () {
            if (item.printOption != null) {
                $("#editPrint-pattern").val(item.printOption.patternId);
                $("#editPrint-option1-section").show();
                $("#editPrint-option2-section").hide();
                $("#editPrint-option3-section").hide();
                $("#editPrint-optional1").parent().removeClass("iradio_square-green").addClass("iradio_square-green checked");
                $("#editPrint-optional2").parent().removeClass("iradio_square-green checked").addClass("iradio_square-green");
                $("#editPrint-optional3").parent().removeClass("iradio_square-green checked").addClass("iradio_square-green");
            }
        });
        _bindingPatternPosition(function () {
            if (item.screenOption != null) {
                $("#editScreen-pattern").val(item.screenOption.patternId);
                $("#editScreen-option1-section").show();
                $("#editScreen-option2-section").hide();
                $("#editScreen-option3-section").hide();
                $("#editScreen-optional1").parent().removeClass("iradio_square-green").addClass("iradio_square-green checked");
                $("#editScreen-optional2").parent().removeClass("iradio_square-green checked").addClass("iradio_square-green");
                $("#editScreen-optional3").parent().removeClass("iradio_square-green checked").addClass("iradio_square-green");
            }
        });
        _bindingPatternColor(function () {
            if (item.sewOption != null) {
                $("#editScreen-pattern").val(item.sewOption.patternId);
                $("#editSew-option1-section").show();
                $("#editSew-option2-section").hide();
                $("#editSew-option3-section").hide();
                $("#editSew-optional1").parent().removeClass("iradio_square-green").addClass("iradio_square-green checked");
                $("#editSew-optional2").parent().removeClass("iradio_square-green checked").addClass("iradio_square-green");
                $("#editSew-optional3").parent().removeClass("iradio_square-green checked").addClass("iradio_square-green");
            }
        });
        _bindingMaterial();
    };
    var _registerStartupInitScript = function () {
        $(".iCheck-helper").click(function () {
            var id = $(this).prev().prop("id");
            switch (id) {
                case "editPrint-optional1":
                    {
                        $("#editPrint-option1-section").show();
                        $("#editPrint-option2-section").hide();
                        $("#editPrint-option3-section").hide();
                        $("#editPrint-optional1").parent().removeClass("iradio_square-green checked").addClass("iradio_square-green checked");
                        $("#editPrint-optional2").parent().removeClass("iradio_square-green checked").addClass("iradio_square-green");
                        $("#editPrint-optional3").parent().removeClass("iradio_square-green checked").addClass("iradio_square-green");


                        $("#print-pattern").val($("#print-pattern option:first").val());
                        $("#editPrint-patternImage").html("");
                        break;
                    }
                case "editPrint-optional2":
                    {
                        $("#editPrint-option1-section").hide();
                        $("#editPrint-option2-section").show();
                        $("#editPrint-option3-section").hide();
                        $("#editPrint-optional1").parent().removeClass("iradio_square-green checked").addClass("iradio_square-green");
                        $("#editPrint-optional2").parent().removeClass("iradio_square-green checked").addClass("iradio_square-green checked");
                        $("#editPrint-optional3").parent().removeClass("iradio_square-green checked").addClass("iradio_square-green");
                        $("#editPrint-patternImage").html("");
                        break;
                    }
                case "editPrint-optional3":
                    {
                        $("#editPrint-option1-section").hide();
                        $("#editPrint-option2-section").hide();
                        $("#editPrint-option3-section").show();
                        $("#editPrint-optional1").parent().removeClass("iradio_square-green checked").addClass("iradio_square-green");
                        $("#editPrint-optional2").parent().removeClass("iradio_square-green checked").addClass("iradio_square-green");
                        $("#editPrint-optional3").parent().removeClass("iradio_square-green checked").addClass("iradio_square-green checked");
                        $("#editPrint-patternImage").html("");
                        break;
                    }
                case "editScreen-optional1":
                    {
                        $("#editScreen-option1-section").show();
                        $("#editScreen-option2-section").hide();
                        $("#editScreen-option3-section").hide();
                        $("#editScreen-optional1").parent().removeClass("iradio_square-green checked").addClass("iradio_square-green checked");
                        $("#editScreen-optional2").parent().removeClass("iradio_square-green checked").addClass("iradio_square-green");
                        $("#editScreen-optional3").parent().removeClass("iradio_square-green checked").addClass("iradio_square-green");

                        $("#editScreen-pattern").val($("#editScreen-pattern option:first").val());
                        $("#editScreen-patternImage").html("");
                        break;
                    }
                case "editScreen-optional2":
                    {
                        $("#editScreen-option1-section").hide();
                        $("#editScreen-option2-section").show();
                        $("#editScreen-option3-section").hide();
                        $("#editScreen-optional1").parent().removeClass("iradio_square-green checked").addClass("iradio_square-green");
                        $("#editScreen-optional2").parent().removeClass("iradio_square-green checked").addClass("iradio_square-green checked");
                        $("#editScreen-optional3").parent().removeClass("iradio_square-green checked").addClass("iradio_square-green");
                        $("#editScreen-patternImage").html("");
                        break;
                    }
                case "editScreen-optional3":
                    {
                        $("#editScreen-option1-section").hide();
                        $("#editScreen-option2-section").hide();
                        $("#editScreen-option3-section").show();
                        $("#editScreen-optional1").parent().removeClass("iradio_square-green checked").addClass("iradio_square-green");
                        $("#editScreen-optional2").parent().removeClass("iradio_square-green checked").addClass("iradio_square-green");
                        $("#editScreen-optional3").parent().removeClass("iradio_square-green checked").addClass("iradio_square-green checked");
                        $("#editScreen-patternImage").html("");
                        break;
                    }
                case "editSew-optional1":
                    {
                        $("#editSew-option1-section").show();
                        $("#editSew-option2-section").hide();
                        $("#editSew-option3-section").hide();
                        $("#editSew-optional1").parent().removeClass("iradio_square-green checked").addClass("iradio_square-green checked");
                        $("#editSew-optional2").parent().removeClass("iradio_square-green checked").addClass("iradio_square-green");
                        $("#editSew-optional3").parent().removeClass("iradio_square-green checked").addClass("iradio_square-green");
                        $("#editSew-pattern").val($("#editSew-pattern option:first").val());
                        $("#editSew-patternImage").html("");
                        break;
                    }
                case "editSew-optional2":
                    {
                        $("#editSew-option1-section").hide();
                        $("#editSew-option2-section").show();
                        $("#editSew-option3-section").hide();
                        $("#editSew-optional1").parent().removeClass("iradio_square-green checked").addClass("iradio_square-green");
                        $("#editSew-optional2").parent().removeClass("iradio_square-green checked").addClass("iradio_square-green checked");
                        $("#editSew-optional3").parent().removeClass("iradio_square-green checked").addClass("iradio_square-green");
                        $("#editSew-patternImage").html("");
                        break;
                    }
                case "editSew-optional3":
                    {
                        $("#editSew-option1-section").hide();
                        $("#editSew-option2-section").hide();
                        $("#editSew-option3-section").show();
                        $("#editSew-optional1").parent().removeClass("iradio_square-green checked").addClass("iradio_square-green");
                        $("#editSew-optional2").parent().removeClass("iradio_square-green checked").addClass("iradio_square-green");
                        $("#editSew-optional3").parent().removeClass("iradio_square-green checked").addClass("iradio_square-green checked");
                        $("#editSew-patternImage").html("");
                        break;
                    }
            }
        });
    };
    var _init = function () {
        _setDefault();
        $("#productCategories").find('option').remove().end();
        $("#products").find('option').remove().end();
        $("#productOptions").find('option').remove().end();
        $("#productsUnit").find('option').remove().end();
        $("#materials").find('option').remove().end();

        $("#print-pattern").find('option').remove().end();
        $("#screen-pattern").find('option').remove().end();
        $("#sew-pattern").find('option').remove().end();

        $("#print-color").find('option').remove().end();
        $("#screen-color").find('option').remove().end();
        $("#screen-position").find('option').remove().end();
        $("#sew-position").find('option').remove().end();

        $("#print-optional2").iCheck('check');
        $("#screen-optional2").iCheck('check');
        $("#sew-optional2").iCheck('check');

        $("#print-option1-section").hide();
        $("#print-option2-section").show();
        $("#print-option3-section").hide();
        $("#print-patternImage").html("");
        $("#screen-option1-section").hide();
        $("#screen-option2-section").show();
        $("#screen-option3-section").hide();
        $("#screen-patternImage").html("");
        $("#sew-option1-section").hide();
        $("#sew-option2-section").show();
        $("#sew-option3-section").hide();
        $("#sew-patternImage").html("");

        $("#print-file").val('');
        $("#screen-file").val('');
        $("#sew-file").val('');
        $(".fileinput-filename").empty()
        $("#sew-remark").val('');
    };
    var _setDefault = function () {
        items = [];
        $("#editProductCategories").find('option').remove().end();
        $("#editPoducts").find('option').remove().end();
        $("#editProductOptions").find('option').remove().end();
        $("#editProductsUnit").find('option').remove().end();
        $("#editMaterials").find('option').remove().end();

        $("#editPrint-pattern").find('option').remove().end();
        $("#editScreen-pattern").find('option').remove().end();
        $("#editSew-pattern").find('option').remove().end();

        $("#editPrint-color").find('option').remove().end();
        $("#editScreen-color").find('option').remove().end();
        $("#editScreen-position").find('option').remove().end();
        $("#editSew-position").find('option').remove().end();
    };
    return {
        init: function (cid) {
            customerId = cid;
            _init();
            var title = $("#modalTitle");
            var btnSaveTitle = $("#btnAddNewItem");
            if (mode == RpMode.addNew) {
                title.html("เพิ่มรายการ");
                btnSaveTitle.html("เพิ่มรายการ");
            } else if (mode == RpMode.edit) {
                title.html("แก้ไขรายการ");
                btnSaveTitle.html("ปรับปรุงรายการ");
            } else if (mode == RpMode.copy) {
                title.html("คัดลอกรายการ");
                btnSaveTitle.html("คัดลอกรายการ");
            } else { }
        },
        getMode: function () {
            return mode;
        },
        getSelectedItem: function () {
            return item;
        },
        addNew: function (cid) {
            mode = RpMode.addNew;
            productEditor.init(cid);
            _bindingProductCategories();
            _bindingPatternImage();
            _bindingPatternPosition();
            _bindingPatternColor();
            _bindingMaterial();
        },
        edit: function (cid, item, isExist) {
            if (isExist) {
                mode = RpMode.edit;
            } else {
                rowItem = item;
                mode = RpMode.copy;
            }
            productEditor.init(cid);
            if (isExist) {
                _getProductItemDetail(item);
            } else {
                _getSelectedProductItemDetail(rowItem);
            }
            _registerStartupInitScript();
        },
        copy: function (cid, item) {
            mode = RpMode.copy;
            productEditor.init(cid);
            rowItem = item;
            if (rowItem.itemId != null) {
                _getProductItemDetail(rowItem);
            }
            _registerStartupInitScript();
        },
        MaterialStockCheck: function () {
            _materialStockCheck();
        },
        AddNewItem: function () {
            var selectedPrintOption = $("input[name='editPrint-optional']:checked").val();
            var selectedScreenOption = $("input[name='editScreen-optional']:checked").val();
            var selectedSewOption = $("input[name='editSew-optional']:checked").val();
            var printFile = $("#editPrint-file").get(0).files[0];
            var printPatternId = $("#editPrint-pattern").val();
            var _printPatternName = utilities.FindObjectByKey(images, 'id', printPatternId);
            var printPatternName = _printPatternName != null ? _printPatternName.patternName : '';
            var printColorId = $("#editPrint-color").val();
            var _printColorName = utilities.FindObjectByKey(colors, 'id', printColorId);
            var printColorName = _printColorName != null ? _printColorName.colorName : '';
            var screenFile = $("#editScreen-file").get(0).files[0];
            var screenPatternId = $("#editScreen-pattern").val();
            var _screenPatternName = utilities.FindObjectByKey(images, 'id', screenPatternId);
            var screenPatternName = _screenPatternName != null ? _screenPatternName.patternName : '';
            var screenColorId = $("#editScreen-color").val();
            var _screenColorName = utilities.FindObjectByKey(colors, 'id', screenColorId);
            var screenColorName = _screenColorName != null ? _screenColorName.colorName : '';
            var screenPositionId = $("#editScreen-position").val();
            var _screenPositionName = utilities.FindObjectByKey(positions, 'id', screenPositionId);
            var screenPositionName = _screenPositionName != null ? _screenPositionName.positionName : '';
            var sewFile = $("#editSew-file").get(0).files[0];
            var sewPatternId = $("#editSew-pattern").val();
            var _sewPatternName = utilities.FindObjectByKey(images, 'id', sewPatternId);
            var sewPatternName = _sewPatternName != null ? _sewPatternName.patternName : '';
            var sewPositionId = $("#editSew-position").val();
            var _sewPositionName = utilities.FindObjectByKey(positions, 'id', sewPositionId);
            var sewPositionName = _sewPositionName != null ? _sewPositionName.positionName : '';
            var remark = $("#editSew-remark").val();
            var printPatternimage = utilities.FindObjectByKey(images, 'id', printPatternId);
            var screenPatternimage = utilities.FindObjectByKey(images, 'id', screenPatternId);
            var sewPatternimage = utilities.FindObjectByKey(images, 'id', sewPatternId);
            var item = {
                itemId: utilities.GuId(),
                productCategoryId: $("#editProductCategories option:selected").val(),
                productId: $("#editProducts option:selected").val(),
                productName: $("#editProducts option:selected").text(),
                productUnitId: $("#editProductsUnit option:selected").val(),
                productUnitName: $("#editProductsUnit option:selected").text(),
                amount: parseFloat($("#editProductNumberOfProducts").val()) || 0,
                pricePerUnit: parseFloat($("#editProductPricePerUnit").val()) || 0,
                file: null,
                remark: $("#editProductRemark").val(),
                print: {
                    selectedOption: selectedPrintOption,
                    options1: {
                        patternId: printPatternId,
                        patternName: printPatternName,
                        patternImage: printPatternimage
                    },
                    options2: {
                        file: printFile,
                        colorId: printColorId,
                        colorName: printColorName
                    },
                    options3: {
                    },
                },
                screen: {
                    selectedOption: selectedScreenOption,
                    options1: {
                        patternId: screenPatternId,
                        patternName: screenPatternName,
                        patternImage: screenPatternimage
                    },
                    options2: {
                        file: screenFile,
                        colorId: screenColorId,
                        colorName: screenColorName,
                        positionId: screenPositionId,
                        positionName: screenPositionName
                    },
                    options3: {
                    },
                },
                sew: {
                    selectedOption: selectedSewOption,
                    options1: {
                        patternId: sewPatternId,
                        patternName: sewPatternName,
                        patternImage: sewPatternimage

                    },
                    options2: {
                        file: sewFile,
                        positionId: sewPositionId,
                        positionName: sewPositionName,
                        remark: remark
                    },
                    options3: {
                    },
                }
            };
            items.push(item);
        },
        UpdateItem: function (itemId) {
            var selectedPrintOption = $("input[name='editPrint-optional']:checked").val();
            var selectedScreenOption = $("input[name='editScreen-optional']:checked").val();
            var selectedSewOption = $("input[name='editSew-optional']:checked").val();
            var printFile = $("#editPrint-file").get(0).files[0];
            var printPatternId = $("#editPrint-pattern").val();
            var _printPatternName = utilities.FindObjectByKey(images, 'id', printPatternId);
            var printPatternName = _printPatternName != null ? _printPatternName.patternName : '';
            var printColorId = $("#editPrint-color").val();
            var _printColorName = utilities.FindObjectByKey(colors, 'id', printColorId);
            var printColorName = _printColorName != null ? _printColorName.colorName : '';
            var screenFile = $("#editScreen-file").get(0).files[0];
            var screenPatternId = $("#editScreen-pattern").val();
            var _screenPatternName = utilities.FindObjectByKey(images, 'id', screenPatternId);
            var screenPatternName = _screenPatternName != null ? _screenPatternName.patternName : '';
            var screenColorId = $("#editScreen-color").val();
            var _screenColorName = utilities.FindObjectByKey(colors, 'id', screenColorId);
            var screenColorName = _screenColorName != null ? _screenColorName.colorName : '';
            var screenPositionId = $("#editScreen-position").val();
            var _screenPositionName = utilities.FindObjectByKey(positions, 'id', screenPositionId);
            var screenPositionName = _screenPositionName != null ? _screenPositionName.positionName : '';
            var sewFile = $("#editSew-file").get(0).files[0];
            var sewPatternId = $("#editSew-pattern").val();
            var _sewPatternName = utilities.FindObjectByKey(images, 'id', sewPatternId);
            var sewPatternName = _sewPatternName != null ? _sewPatternName.patternName : '';
            var sewPositionId = $("#editSew-position").val();
            var _sewPositionName = utilities.FindObjectByKey(positions, 'id', sewPositionId);
            var sewPositionName = _sewPositionName != null ? _sewPositionName.positionName : '';
            var remark = $("#editSew-remark").val();
            var printPatternimage = utilities.FindObjectByKey(images, 'id', printPatternId);
            var screenPatternimage = utilities.FindObjectByKey(images, 'id', screenPatternId);
            var sewPatternimage = utilities.FindObjectByKey(images, 'id', sewPatternId);
            var item = {
                itemId: rowItem.itemId,
                productId: $("#editProducts option:selected").val(),
                productName: $("#editProducts option:selected").text(),
                productUnitId: $("#editProductsUnit option:selected").val(),
                productUnitName: $("#editProductsUnit option:selected").text(),
                amount: parseFloat($("#editProductNumberOfProducts").val()) || 0,
                pricePerUnit: parseFloat($("#editProductPricePerUnit").val()) || 0,
                file: null,
                remark: $("#editProductRemark").val(),
                print: {
                    selectedOption: selectedPrintOption,
                    options1: {
                        patternId: printPatternId,
                        patternName: printPatternName,
                        patternImage: printPatternimage
                    },
                    options2: {
                        file: printFile,
                        colorId: printColorId,
                        colorName: printColorName
                    },
                    options3: {
                    },
                },
                screen: {
                    selectedOption: selectedScreenOption,
                    options1: {
                        patternId: screenPatternId,
                        patternName: screenPatternName,
                        patternImage: screenPatternimage
                    },
                    options2: {
                        file: screenFile,
                        colorId: screenColorId,
                        colorName: screenColorName,
                        positionId: screenPositionId,
                        positionName: screenPositionName
                    },
                    options3: {
                    },
                },
                sew: {
                    selectedOption: selectedSewOption,
                    options1: {
                        patternId: sewPatternId,
                        patternName: sewPatternName,
                        patternImage: sewPatternimage

                    },
                    options2: {
                        file: sewFile,
                        positionId: sewPositionId,
                        positionName: sewPositionName,
                        remark: remark
                    },
                    options3: {
                    },
                }
            };
            items.push(item);
        },
        CopyItem: function (itemId) {
            var selectedPrintOption = $("input[name='editPrint-optional']:checked").val();
            var selectedScreenOption = $("input[name='editScreen-optional']:checked").val();
            var selectedSewOption = $("input[name='editSew-optional']:checked").val();
            var printFile = $("#editPrint-file").get(0).files[0];
            var printPatternId = $("#editPrint-pattern").val();
            var _printPatternName = utilities.FindObjectByKey(images, 'id', printPatternId);
            var printPatternName = _printPatternName != null ? _printPatternName.patternName : '';
            var printColorId = $("#editPrint-color").val();
            var _printColorName = utilities.FindObjectByKey(colors, 'id', printColorId);
            var printColorName = _printColorName != null ? _printColorName.colorName : '';
            var screenFile = $("#editScreen-file").get(0).files[0];
            var screenPatternId = $("#editScreen-pattern").val();
            var _screenPatternName = utilities.FindObjectByKey(images, 'id', screenPatternId);
            var screenPatternName = _screenPatternName != null ? _screenPatternName.patternName : '';
            var screenColorId = $("#editScreen-color").val();
            var _screenColorName = utilities.FindObjectByKey(colors, 'id', screenColorId);
            var screenColorName = _screenColorName != null ? _screenColorName.colorName : '';
            var screenPositionId = $("#editScreen-position").val();
            var _screenPositionName = utilities.FindObjectByKey(positions, 'id', screenPositionId);
            var screenPositionName = _screenPositionName != null ? _screenPositionName.positionName : '';
            var sewFile = $("#editSew-file").get(0).files[0];
            var sewPatternId = $("#editSew-pattern").val();
            var _sewPatternName = utilities.FindObjectByKey(images, 'id', sewPatternId);
            var sewPatternName = _sewPatternName != null ? _sewPatternName.patternName : '';
            var sewPositionId = $("#editSew-position").val();
            var _sewPositionName = utilities.FindObjectByKey(positions, 'id', sewPositionId);
            var sewPositionName = _sewPositionName != null ? _sewPositionName.positionName : '';
            var remark = $("#editSew-remark").val();
            var printPatternimage = utilities.FindObjectByKey(images, 'id', printPatternId);
            var screenPatternimage = utilities.FindObjectByKey(images, 'id', screenPatternId);
            var sewPatternimage = utilities.FindObjectByKey(images, 'id', sewPatternId);
            var item = {
                itemId: utilities.GuId(),
                productCategoryId: $("#editProductCategories option:selected").val(),
                productId: $("#editProducts option:selected").val(),
                productName: $("#editProducts option:selected").text(),
                productUnitId: $("#editProductsUnit option:selected").val(),
                productUnitName: $("#editProductsUnit option:selected").text(),
                amount: parseFloat($("#editProductNumberOfProducts").val()) || 0,
                pricePerUnit: parseFloat($("#editProductPricePerUnit").val()) || 0,
                file: null,
                remark: $("#editProductRemark").val(),
                print: {
                    selectedOption: selectedPrintOption,
                    options1: {
                        patternId: printPatternId,
                        patternName: printPatternName,
                        patternImage: printPatternimage
                    },
                    options2: {
                        file: printFile,
                        colorId: printColorId,
                        colorName: printColorName
                    },
                    options3: {
                    },
                },
                screen: {
                    selectedOption: selectedScreenOption,
                    options1: {
                        patternId: screenPatternId,
                        patternName: screenPatternName,
                        patternImage: screenPatternimage
                    },
                    options2: {
                        file: screenFile,
                        colorId: screenColorId,
                        colorName: screenColorName,
                        positionId: screenPositionId,
                        positionName: screenPositionName
                    },
                    options3: {
                    },
                },
                sew: {
                    selectedOption: selectedSewOption,
                    options1: {
                        patternId: sewPatternId,
                        patternName: sewPatternName,
                        patternImage: sewPatternimage

                    },
                    options2: {
                        file: sewFile,
                        positionId: sewPositionId,
                        positionName: sewPositionName,
                        remark: remark
                    },
                    options3: {
                    },
                }
            };
            items.push(item);
        },
        GetItem: function () {
            return items[0];
        }
    }
};