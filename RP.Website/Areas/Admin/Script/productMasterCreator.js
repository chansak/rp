var productMasterCreator = new function () {
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
    var _save = function (callback) {
        var data = {
            productName: $("#productName").val(),
            productCategoryId: $("#productCategories").val()
        };
        var success = function (data, textStatus, jqXHR) {
            callback();
        }
        var failure = function (jqXHR, textStatus, errorThrown) {
        }
        var xhr = RPService.CreateProduct(data, success, failure);
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