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

    return {
        RedirectToAction: function (url) {
            _redirectToAction(url);
        },
        ConvertToDate(strDate) {
            return _convertToDate(strDate);
        }
    }
}