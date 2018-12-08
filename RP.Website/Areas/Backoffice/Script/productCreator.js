var productCreatorForBackoffice = new function () {
    var customerId = '';
    var images = [];
    var items = [];
    var colors = [];
    var positions = [];
    var materials = [];

    var _bindingProductCategories = function () {
        var success = function (data, textStatus, jqXHR) {
            $(data).each(function (index, item) {
                $('#productCategories').empty().append($('<option>', {
                    value: item.id,
                    text: item.categoryName
                }));
            });
            $("#productCategories").prepend("<option value='' selected='selected'>เลือกประเภทสินค้า</option>");
            $("#productCategories").unbind();
            $("#productCategories").change(function () {
                var selectedCategoryId = '';
                selectedCategoryId = $('#productCategories').val();
                if (selectedCategoryId != '') {
                    _bindingProducts(selectedCategoryId);
                } else {
                    $("#products").find('option').remove().end();
                    $("#productOptions").find('option').remove().end();
                }
            });
        }
        var failure = function (jqXHR, textStatus, errorThrown) {
            //alert(errorThrown);
        }
        var xhr = RPService.GetProductCategories(success, failure);
    };
    var _bindingProducts = function (id) {
        var success = function (data, textStatus, jqXHR) {
            $(data).each(function (index, item) {
                $('#products').empty().append($('<option>', {
                    value: item.id,
                    text: item.productName
                }));
            });
            $("#products").prepend("<option value='' selected='selected'>เลือกสินค้า</option>");
            $("#products").unbind();
            $("#products").change(function () {
                var selectedProductId = '';
                selectedProductId = $('#products').val();
                if (selectedProductId != '') {
                    _bindingProductOptions(selectedProductId);
                    _bindingProductUnits(selectedProductId);
                } else {
                    $("#productOptions").find('option').remove().end();
                    $("#productsUnit").find('option').remove().end();
                }
            });
        }
        var failure = function (jqXHR, textStatus, errorThrown) {
            //alert(errorThrown);
        }
        var xhr = RPService.GetProductsByCategoryId(id, success, failure);
    };
    var _bindingProductUnits = function (id) {
        var success = function (data, textStatus, jqXHR) {
            $(data).each(function (index, item) {
                $('#productsUnit').empty().append($('<option>', {
                    value: item.id,
                    text: item.unitName
                }));
            });
            $("#productsUnit").prepend("<option value='' selected='selected'>เลือกหน่วยนับ</option>");
            $("#productsUnit").unbind();
            $("#productsUnit").change(function () {
                _materialStockCheck()
            });
        }
        var failure = function (jqXHR, textStatus, errorThrown) {
            //alert(errorThrown);
        }
        var xhr = RPService.GetUnitsByProductId(id, success, failure);
    };
    var _bindingProductOptions = function (id) {
        var success = function (data, textStatus, jqXHR) {
            $(data).each(function (index, item) {
                $('#productOptions').empty().append($('<option>', {
                    value: item.id,
                    text: item.optionName
                }));
            });
            $("#productOptions").prepend("<option value='' selected='selected'>เลือกรายละเอียด</option>");
            $("#productOptions").unbind();
            $("#productOptions").change(function () {
                var selectedProductOptionsId = '';
                selectedProductOptionsId = $('#productOptions').val();
            });
        }
        var failure = function (jqXHR, textStatus, errorThrown) {
            //alert(errorThrown);
        }
        var xhr = RPService.GetOptionsByProductId(id, success, failure);
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
        var productId = $("#products").val();
        var amount = parseInt($("#productNumberOfProducts").val());
        var productUnitId = '';
        productUnitId = $('#productsUnit').val();
        var materialId = '';
        materialId = $('#materials').val();
        if (amount < 0) { amount = 0; }
        if (productUnitId != '' && materialId != '') {
            var xhr = RPService.GetMaterialStockCheck(productId, productUnitId, materialId, amount, success, failure);
        }
    }
    var _bindingPatternImage = function () {
        var success = function (data, textStatus, jqXHR) {
            $(data).each(function (index, item) {
                images.push(item);
                $('#print-pattern').empty().append($('<option>', {
                    value: item.id,
                    text: item.patternName
                }));
                $('#screen-pattern').empty().append($('<option>', {
                    value: item.id,
                    text: item.patternName
                }));
                $('#sew-pattern').empty().append($('<option>', {
                    value: item.id,
                    text: item.patternName
                }));

                $("#print-pattern").change(function () {
                    var selectedImageId = $('#print-pattern').val();
                    var image = utilities.FindObjectByKey(images, 'id', selectedImageId);
                    $("#print-patternImage").html("<img src='../../FileUpload/pattern/" + image.imagePath + "' class='thumb-image' />");
                });
                $("#screen-pattern").change(function () {
                    var selectedImageId = $('#screen-pattern').val();
                    var image = utilities.FindObjectByKey(images, 'id', selectedImageId);
                    $("#screen-patternImage").html("<img src='../../FileUpload/pattern/" + image.imagePath + "' class='thumb-image' />");
                });
                $("#sew-pattern").change(function () {
                    var selectedImageId = $('#sew-pattern').val();
                    var image = utilities.FindObjectByKey(images, 'id', selectedImageId);
                    $("#sew-patternImage").html("<img src='../../FileUpload/pattern/" + image.imagePath + "'  class='thumb-image'/>");
                });
            });
            $("#print-pattern").prepend("<option value='' selected='selected'>เลือกลาย</option>");
            $("#screen-pattern").prepend("<option value='' selected='selected'>เลือกลาย</option>");
            $("#sew-pattern").prepend("<option value='' selected='selected'>เลือกลาย</option>");
        }
        var failure = function (jqXHR, textStatus, errorThrown) {
            //alert(errorThrown);
        }
        var xhr = RPService.GetPatternImages(success, failure);
    };
    var _bindingPatternPosition = function () {
        var success = function (data, textStatus, jqXHR) {
            $(data).each(function (index, item) {
                positions.push(item);
                $('#print-position').empty().append($('<option>', {
                    value: item.id,
                    text: item.positionName
                }));
                $('#screen-position').empty().append($('<option>', {
                    value: item.id,
                    text: item.positionName
                }));
                $('#sew-position').empty().append($('<option>', {
                    value: item.id,
                    text: item.positionName
                }));
            });
            $("#print-position").prepend("<option value='' selected='selected'>เลือกตำแหน่ง</option>");
            $("#screen-position").prepend("<option value='' selected='selected'>เลือกตำแหน่ง</option>");
            $("#sew-position").prepend("<option value='' selected='selected'>เลือกตำแหน่ง</option>");
        }
        var failure = function (jqXHR, textStatus, errorThrown) {
            //alert(errorThrown);
        }
        var xhr = RPService.GetPatternPosition(success, failure);
    };
    var _bindingPatternColor = function () {
        var success = function (data, textStatus, jqXHR) {
            $(data).each(function (index, item) {
                colors.push(item);
                $('#print-color').empty().append($('<option>', {
                    value: item.id,
                    text: item.colorName
                }));
                $('#screen-color').empty().append($('<option>', {
                    value: item.id,
                    text: item.colorName
                }));
                $('#sew-color').empty().append($('<option>', {
                    value: item.id,
                    text: item.colorName
                }));
            });
            $("#print-color").prepend("<option value='' selected='selected'>เลือกสี</option>");
            $("#screen-color").prepend("<option value='' selected='selected'>เลือกสี</option>");
            $("#sew-color").prepend("<option value='' selected='selected'>เลือกสี</option>");
        }
        var failure = function (jqXHR, textStatus, errorThrown) {
            //alert(errorThrown);
        }
        var xhr = RPService.GetPatternColors(success, failure);
    };
    var _bindingMaterial = function () {
        var success = function (data, textStatus, jqXHR) {
            $(data).each(function (index, item) {
                materials.push(item);
                $('#materials').append($('<option>', {
                    value: item.id,
                    text: item.materialName
                }));
            });
            $("#materials").prepend("<option value='' selected='selected'>เลือกผ้า</option>");
        }
        var failure = function (jqXHR, textStatus, errorThrown) {
        }
        var xhr = RPService.GetMaterials(success, failure);
    };
    var _setDefault = function () {
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
    };
    var _init = function () {
        _setDefault();

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
    return {
        init: function (cid) {
            customerId = cid;
            _init();
            _bindingProductCategories();
            _bindingPatternImage();
            _bindingPatternPosition();
            _bindingPatternColor();
            _bindingMaterial();
        },
        MaterialStockCheck: function () {
            _materialStockCheck();
        },
        AddNewItem: function () {
            var selectedPrintOption = $("input[name='print-optional']:checked").val();
            var selectedScreenOption = $("input[name='screen-optional']:checked").val();
            var selectedSewOption = $("input[name='sew-optional']:checked").val();
            //print option
            var printFile = $("#print-file").get(0).files[0];
            var printPatternId = $("#print-pattern").val();
            var _printPatternName = utilities.FindObjectByKey(images, 'id', printPatternId);
            var printPatternName = _printPatternName != null ? _printPatternName.patternName : '';
            var printColorId = $("#print-color").val();
            var _printColorName = utilities.FindObjectByKey(colors, 'id', printColorId);
            var printColorName = _printColorName != null ? _printColorName.colorName : '';

            //screen option
            var screenFile = $("#screen-file").get(0).files[0];
            var screenPatternId = $("#screen-pattern").val();
            var _screenPatternName = utilities.FindObjectByKey(images, 'id', screenPatternId);
            var screenPatternName = _screenPatternName != null ? _screenPatternName.patternName : '';
            var screenColorId = $("#screen-color").val();
            var _screenColorName = utilities.FindObjectByKey(colors, 'id', screenColorId);
            var screenColorName = _screenColorName != null ? _screenColorName.colorName : '';
            var screenPositionId = $("#screen-position").val();
            var _screenPositionName = utilities.FindObjectByKey(positions, 'id', screenPositionId);
            var screenPositionName = _screenPositionName != null ? _screenPositionName.positionName : '';

            //sew option
            var sewFile = $("#sew-file").get(0).files[0];
            var sewPatternId = $("#sew-pattern").val();
            var _sewPatternName = utilities.FindObjectByKey(images, 'id', sewPatternId);
            var sewPatternName = _sewPatternName != null ? _sewPatternName.patternName : '';
            var sewPositionId = $("#sew-position").val();
            var _sewPositionName = utilities.FindObjectByKey(positions, 'id', sewPositionId);
            var sewPositionName = _sewPositionName != null ? _sewPositionName.positionName : '';
            var remark = $("#sew-remark").val();


            var printPatternimage = utilities.FindObjectByKey(images, 'id', printPatternId);
            var screenPatternimage = utilities.FindObjectByKey(images, 'id', screenPatternId);
            var sewPatternimage = utilities.FindObjectByKey(images, 'id', sewPatternId);

            var item = {
                productId: $("#products option:selected").val(),
                productName: $("#products option:selected").text(),
                productUnitId: $("#productsUnit option:selected").val(),
                productUnitName: $("#productsUnit option:selected").text(),
                amount: parseFloat($("#productNumberOfProducts").val()||0),
                pricePerUnit: parseFloat($("#productPricePerUnit").val()||0),
                file: null,
                remark: $("#productRemark").val(),
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
        GetItems: function () {
            return items;
        }
    }
};