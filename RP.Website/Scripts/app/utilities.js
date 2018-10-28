var utilities = new function () {
    var _timer = 1000;
    var _redirectToAction = function (url) {
        setTimeout(function () { window.location.href = url; }, _timer);
    };
    var _convertToDate = function (strDate) {
        var milli = strDate.replace(/\/Date\((-?\d+)\)\//, '$1');
        var d = new Date(milli);
        return moment(d).format("DD/MM/YYYY");
    };
    var findObjectByKey = function (array, key, value) {
        for (var i = 0; i < array.length; i++) {
            if (array[i][key] === value) {
                return array[i];
            }
        }
    };
    return {
        RedirectToAction: function (url) {
            _redirectToAction(url);
        },
        ConvertToDate(strDate) {
            return _convertToDate(strDate);
        },
        GetFileName(fullPath) {
            return fullPath.replace(/^.*(\\|\/|\:)/, '');
        },
        FindObjectByKey: function (array, key, value) {
            return findObjectByKey(array, key, value);
        }
    }
}