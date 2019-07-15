var categoryCreator = new function () {
    var _save = function (callback) {
        var data = {
            name: $("#categoryName").val()
        };
        var success = function (data, textStatus, jqXHR) {
            callback();
        }
        var failure = function (jqXHR, textStatus, errorThrown) {
        }
        var xhr = RPService.CreateCategory(data, success, failure);
    };
    return {
        init: function () {
        },
        
        Save: function (callback) {
            _save(callback);
        }
    }
};