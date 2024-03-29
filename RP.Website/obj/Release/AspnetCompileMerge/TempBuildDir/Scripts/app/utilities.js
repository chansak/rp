﻿var utilities = new function () {
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
    var S4=function() {
        return (((1 + Math.random()) * 0x10000) | 0).toString(16).substring(1);
    }
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
        },
        RemoveByAttr : function (arr, attr, value) {
            var i = arr.length;
            while (i--) {
                if (arr[i]
                    && arr[i].hasOwnProperty(attr)
                    && (arguments.length > 2 && arr[i][attr] === value)) {

                    arr.splice(i, 1);

                }
            }
            return arr;
        },
        GuId: function () {
            return (S4() + S4() + "-" + S4() + "-4" + S4().substr(0, 3) + "-" + S4() + "-" + S4() + S4() + S4()).toLowerCase();
        }
    }
}