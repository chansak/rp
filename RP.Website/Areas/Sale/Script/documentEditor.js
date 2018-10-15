var documentEditor = new function () {
    //variables
    var items = [];

    //properties

    //private function
    //var _renderProductItems = function () {
    //    var html = "";
    //    $(items).each(function (index, item) {
    //        html += '<tr>';
    //        html += '   <td><div class="checkbox i - checks"><label> <input type="checkbox" value=""> <i></i></label></div></td>';
    //        html += '   <td>ITEM001</td>';
    //        html += '   <td>LG TV SE2345</td>';
    //        html += '   <td>เครื่อง</td>';
    //        html += '   <td>10</td>'
    //        html += '   <td>25,000</td>';
    //        html += '   <td>25,000</td>';
    //        html += '<td>200,000</td>';
    //        html += '</tr>';
    //    });
    //    $("#productItems").empty().html(html);

    //};

    //all services
    return {
        init: function () {
        },
        nextForAddItem: function () {
            _next();
        },
        back: function () {
            _back();
        },
        saveItemAndBack: function () {
            _saveThenBack();
        }
    }
};