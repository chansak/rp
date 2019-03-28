var userEditor = new function () {
    var _userId;
    var _getUserDetail = function (id) {
        var success = function (data, textStatus, jqXHR) {
            console.log(data);
        }
        var failure = function (jqXHR, textStatus, errorThrown) {
            //alert(errorThrown);
        }
        var xhr = RPService.GetUserById(id, success, failure);
    };
    return {
        init: function () {
            _userId = $("#userId").val();
            _getUserDetail(_userId);
        }
    }
};
