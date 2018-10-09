var documentEditor = new function () {
    //variables
    var items = [];

    //properties

    //private function

    var _next = function () {
        $("#productList").hide();
        $("#productCreator").show();

    };
    var _back = function () {
        documentEditor.init();
        _renderProductItems();
    };
    var _renderProductItems = function () {
        var html = "";
        $(items).each(function (index, item) {
            html += '<tr>';
            //html += '   <td><div class="checkbox i - checks"><label> <input type="checkbox" value=""> <i></i></label></div></td>';
            html += '   <td>ITEM001</td>';
            html += '   <td>LG TV SE2345</td>';
            html += '   <td>เครื่อง</td>';
            html += '   <td>10</td>'
            html += '   <td>25,000</td>';
            html += '   <td>25,000</td>';
            html += '<td>200,000</td>';
            html += '</tr>';
        });
        $("#productItems").empty().html(html);

    };
    var _saveThenBack = function () {
        var item = {
            productCode: "ITEM001",
            productName: "Patient wear (ชุดคนไข้)",
            unitName: "ตัว",
            amount: 50,
            pricePerUnit: 450,
            discountAmount: 0,
            totalAmount: 22500
        };
        items.push(item);
        _back();
    };

    //all services
    return {
        init: function () {
            $("#productList").show();
            $("#productCreator").hide();
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