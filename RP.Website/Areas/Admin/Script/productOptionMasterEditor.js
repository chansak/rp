var productOptionMasterEditor = new function () {
    var _bindingProductCategories = function () {
        var selectedCategoryId = $("#productCategoryId").val();
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
            $("#productCategories").val(selectedCategoryId);
            _bindingProducts(selectedCategoryId);
        }
        var failure = function (jqXHR, textStatus, errorThrown) {
            //alert(errorThrown);
        }
        var xhr = RPService.GetProductCategories(success, failure);
    };
    var _bindingProducts = function (id) {
        var selectedProductId = $("#productId").val();
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
            $("#products").val(selectedProductId);
        }
        var failure = function (jqXHR, textStatus, errorThrown) {
            //alert(errorThrown);
        }
        var xhr = RPService.GetProductsByCategoryId(id, success, failure);
    };
    var _save = function (callback) {
        var data = {
            id: $("#id").val(),
            optionName: $("#optionName").val(),
            productId: $("#products").val()
        };
        var success = function (data, textStatus, jqXHR) {
            callback();
        }
        var failure = function (jqXHR, textStatus, errorThrown) {
        }
        var xhr = RPService.UpdateProductOption(data, success, failure);
    };
    var _getDetail = function (id) {
        var success = function (response, textStatus, jqXHR) {
            $("#productName").val(response.productName);
            $("#productCategoryId").val(response.productCategoryId);
            $("#productId").val(response.productId);
            _bindingProductCategories();
        }
        var failure = function (jqXHR, textStatus, errorThrown) {
        }
        var xhr = RPService.GetProductOptionById(id, success, failure);
    };
    return {
        init: function () {
            var id = $("#id").val();
            _getDetail(id);
        },

        Save: function (callback) {
            _save(callback);
        }
    }

};