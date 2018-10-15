var productCreator = new function () {
    //variables

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
                var selectedCategoryId = $('#productCategories').val();
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
                var selectedProductId = $('#products').val();
                if (selectedProductId != '') {
                    _bindingProductOptions(selectedProductId);
                    _bindingProductUnits(selectedProductId);
                } else {
                    $("#productOptions").find('option').remove().end();
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
                var selectedProductId = $('#productsUnit').val();
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
                var selectedProductOptionsId = $('#productOptions').val();
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
                html += '           <input type="text" id="materialName" class="form-control">';
                html += '       </div>';
                html += '   </div>';
                html += '   <div class="col-sm-3">';
                html += '       <div class="form-group">';
                html += '           <label>จำนวนผ้าในสต๊อค</label>';
                html += '           <input type="text" id="materialInStock" class="form-control">';
                html += '       </div>';
                html += '   </div>';
                html += '   <div class="col-sm-3">';
                html += '       <div class="form-group">';
                html += '           <label>ผ้าที่ต้องใช้</label>';
                html += '           <input type="text" id="materialUsaged" class="form-control">';
                html += '       </div>';
                html += '   </div>';
                html += '   <div class="col-sm-3">';
                html += '       <div class="form-group">';
                html += '           <label>ผ้าคงเหลือ</label>';
                html += '           <input type="text" id="materialInStockAfterWithdraw" class="form-control">';
                html += '       </div>';
                html += '   </div>';
                html += '</div>';
            });
            $("#materialStockCheck").empty().html(html);
        }
        var failure = function (jqXHR, textStatus, errorThrown) {
            //alert(errorThrown);
        }
        var xhr = RPService.GetMaterialStockCheck(id, success, failure);
    }
    //all services
    return {
        init: function () {
            $("#productCategories").find('option').remove().end();
            $("#products").find('option').remove().end();
            $("#productOptions").find('option').remove().end();
            _bindingProductCategories();
        },
    }
};