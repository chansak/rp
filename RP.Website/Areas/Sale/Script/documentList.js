var documentList = new function () {
    //variables
    //properties

    //private function
    var _edit = function () {
        var itemId = 0;
        var items = $("input:checkbox[name=documentId]:checked");
        if (items.length == 1) {
            itemId = $(items[0]).val();
            
        } else {
            console.log("Selected items is invalid")
        }
        if (itemId != 0) {
            //var success = function (data, textStatus, jqXHR) {

            //}
            //var failure = function (jqXHR, textStatus, errorThrown) {

            //}
            //var xhr = RPService.GetDocumentDetail(itemId, success, failure);
            window.location.href = 'Document/Edit/' + itemId;
        }
    };

    //all services
    return {
        init: function () {
        },
        edit: function () {
            _edit();
        }
    }
};