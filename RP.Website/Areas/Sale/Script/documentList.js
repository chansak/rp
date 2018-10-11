var documentList = new function () {
    //variables

    var message = {
        info: {
            noSelectedItemBeforeEdit: "Please select document"
        },
        error: {}
    };
    //properties

    //private function
    var _edit = function () {
        var itemId = 0;
        var items = $("input:checkbox[name=documentId]:checked");
        if (items.length == 1) {
            itemId = $(items[0]).val();

        } else {
            toastr.info(message.info.noSelectedItemBeforeEdit, 'Infomration')
        }
        if (itemId != 0) {
            window.location.href = 'Document/Edit/' + itemId;
        }
    };

    //all services
    return {
        init: function () {
        },
        edit: function () {
            _edit();
        },
    }
};