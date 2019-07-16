var productMasterEditor = new function () {
    var _bindingProductCategories = function (selectedCategoryId) {
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
        }
        var failure = function (jqXHR, textStatus, errorThrown) {
            //alert(errorThrown);
        }
        var xhr = RPService.GetProductCategories(success, failure);
    };
    var _save = function (callback) {
        var data = {
            id: $("#id").val(),
            productName: $("#productName").val(),
            productCategoryId: $("#productCategories").val()
        };
        console.log(data);
        var success = function (data, textStatus, jqXHR) {
            callback();
        }
        var failure = function (jqXHR, textStatus, errorThrown) {
        }
        var xhr = RPService.UpdateProduct(data, success, failure);
    };
    var _getDetail = function (id) {
        var success = function (response, textStatus, jqXHR) {
            $("#productName").val(response.productName);
            _bindingProductCategories(response.productCategoryId);
        }
        var failure = function (jqXHR, textStatus, errorThrown) {
        }
        var xhr = RPService.GetProductById(id, success, failure);
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