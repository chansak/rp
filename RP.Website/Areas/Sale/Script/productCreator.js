var productCreator = new function () {
    //variables
    var images = [];

    var _bindingProductCategories = function () {
        var success = function (data, textStatus, jqXHR) {
            $(data).each(function (index, item) {
                $('#productCategories').append($('<option>', {
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
                $('#products').append($('<option>', {
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
                    _materialStockCheck(selectedProductId);
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
                $('#productsUnit').append($('<option>', {
                    value: item.id,
                    text: item.unitName
                }));
            });
            $("#productsUnit").prepend("<option value='' selected='selected'>เลือกหน่วยนับ</option>");
            $("#productsUnit").unbind();
            $("#productsUnit").change(function () {
                if (id != '') {
                    _materialStockCheck(id);
                }

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
                $('#productOptions').append($('<option>', {
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
    var _materialStockCheck = function (id) {
        var success = function (data, textStatus, jqXHR) {
            var html = "";
            $(data).each(function (index, item) {
                html += '<div class="row">';
                html += '   <div class="col-sm-3">';
                html += '       <div class="form-group">';
                html += '           <label>รหัสผ้า</label>';
                html += '           <input type="text" id="materialName" class="form-control" disabled value="' + item.materialName + '">';
                html += '       </div>';
                html += '   </div>';
                html += '   <div class="col-sm-3">';
                html += '       <div class="form-group">';
                html += '           <label>จำนวนผ้าในสต๊อค</label>';
                html += '           <input type="text" id="materialInStock" class="form-control" disabled value="' + item.materialInStock + '">';
                html += '       </div>';
                html += '   </div>';
                html += '   <div class="col-sm-3">';
                html += '       <div class="form-group">';
                html += '           <label>ผ้าที่ต้องใช้</label>';
                html += '           <input type="text" id="materialUsaged" class="form-control" disabled value="' + item.materialUsaged + '">';
                html += '       </div>';
                html += '   </div>';
                html += '   <div class="col-sm-3">';
                html += '       <div class="form-group">';
                html += '           <label>ผ้าคงเหลือ</label>';
                html += '           <input type="text" id="materialInStockAfterWithdraw" class="form-control" disabled value="' + item.materialInStockAfterWithdraw + '">';
                html += '       </div>';
                html += '   </div>';
                html += '</div>';
            });
            $("#materialStockCheck").empty().html(html);
        }
        var failure = function (jqXHR, textStatus, errorThrown) {
            //alert(errorThrown);
        }
        var amount = parseInt($("#productNumberOfProducts").val());
        var productUnitId = '';
        productUnitId = $('#productsUnit').val();
        if (amount < 0) { amount = 0; }
        if (productUnitId != '') {
            var xhr = RPService.GetMaterialStockCheck(id, productUnitId, amount, success, failure);
        }
    }
    var _bindingPatternImage = function () {
        var success = function (data, textStatus, jqXHR) {
            $(data).each(function (index, item) {
                images.push(item);
                $('#print-pattern').append($('<option>', {
                    value: item.id,
                    text: item.patternName
                }));
                $('#screen-pattern').append($('<option>', {
                    value: item.id,
                    text: item.patternName
                }));
                $('#sew-pattern').append($('<option>', {
                    value: item.id,
                    text: item.patternName
                }));

                $("#print-pattern").change(function () {
                    var selectedImageId = $('#print-pattern').val();
                    var image = findObjectByKey(images, 'id', selectedImageId);
                    $("#print-patternImage").html("<img src='../../FileUpload/pattern/" + image.imagePath + "' />");
                });
                $("#screen-pattern").change(function () {
                    var selectedImageId = $('#screen-pattern').val();
                    var image = findObjectByKey(images, 'id', selectedImageId);
                    $("#screen-patternImage").html("<img src='../../FileUpload/pattern/" + image.imagePath + "' />");
                });
                $("#sew-pattern").change(function () {
                    var selectedImageId = $('#sew-pattern').val();
                    var image = findObjectByKey(images, 'id', selectedImageId);
                    $("#sew-patternImage").html("<img src='../../FileUpload/pattern/" + image.imagePath + "' />");
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
        }
        var failure = function (jqXHR, textStatus, errorThrown) {
            //alert(errorThrown);
        }
        var xhr = RPService.GetPatternPosition(success, failure);
    };
    var _bindingPatternColor = function () {
        var success = function (data, textStatus, jqXHR) {
            $(data).each(function (index, item) {
                $('#sew-color').append($('<option>', {
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
        }
        var failure = function (jqXHR, textStatus, errorThrown) {
            //alert(errorThrown);
        }
        var xhr = RPService.GetPatternPosition(success, failure);
    };

    function findObjectByKey(array, key, value) {
        for (var i = 0; i < array.length; i++) {
            if (array[i][key] === value) {
                return array[i];
            }
        }
        return null;
    }
    //all services
    return {
        init: function () {
            $("#productCategories").find('option').remove().end();
            $("#products").find('option').remove().end();
            $("#productOptions").find('option').remove().end();
            _bindingProductCategories();
            _bindingPatternImage();
            _bindingPatternPosition();
            _bindingPatternColor();
        },
        MaterialStockCheck: function () {
            var selectedProductId = $('#products').val();
            _materialStockCheck(selectedProductId);
        }
    }
};