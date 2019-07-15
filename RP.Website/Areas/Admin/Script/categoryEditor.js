var categoryEditor = new function () {
    var _save = function (callback) {
        var data = {
            id:$("#id").val(),
            name: $("#categoryName").val()
        };
        var success = function (data, textStatus, jqXHR) {
            callback();
        }
        var failure = function (jqXHR, textStatus, errorThrown) {
        }
        var xhr = RPService.UpdateCategory(data, success, failure);
    };
    var _getDetail = function (id) {
        var success = function (response, textStatus, jqXHR) {
            $("#categoryName").val(response.name);
        }
        var failure = function (jqXHR, textStatus, errorThrown) {
        }
        var xhr = RPService.GetCategoryById(id, success, failure);
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