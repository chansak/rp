var productUnitCreator = new function () {
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
            $('#products').empty();
            $(data).each(function (index, item) {
                $('#products').append($('<option>', {
                    value: item.id,
                    text: item.productName
                }));
            });
            $("#products").prepend("<option value='' selected='selected'>เลือกสินค้า</option>");
            $("#products").unbind();
        }
        var failure = function (jqXHR, textStatus, errorThrown) {
            //alert(errorThrown);
        }
        var xhr = RPService.GetProductsByCategoryId(id, success, failure);
    };
    var _save = function (callback) {
        var data = {
            unitName: $("#unitName").val(),
            productId: $("#products").val()
        };
        var success = function (data, textStatus, jqXHR) {
            callback();
        }
        var failure = function (jqXHR, textStatus, errorThrown) {
        }
        var xhr = RPService.CreateProductUnit(data, success, failure);
    };
    return {
        init: function () {
            _bindingProductCategories();
        },

        Save: function (callback) {
            _save(callback);
        }
    }
};