var utilities = new function () {
    var _timer = 2000;
    var _redirectToAction = function (url) {
        setTimeout(function () { window.location.href = url; }, _timer);
    }


    return {
        RedirectToAction: function (url) {
            _redirectToAction(url);
        }
    }
}