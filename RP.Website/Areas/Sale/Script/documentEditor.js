var documentEditor = new function () {
    var _getCustomerDetail = function (id) {
        var success = function (data, textStatus, jqXHR) {
            $("#auto_customerName").val(data.name);
            $("#auto_customerType").val(data.customerTypeName);
            $("#auto_customerHospitalName").val(data.hospitalName);
        }
        var failure = function (jqXHR, textStatus, errorThrown) {
            //alert(errorThrown);
        }
        var xhr = RPService.GetCustomerById(id, success, failure);
    };
    var _getContactDetail = function (id) {
        var success = function (data, textStatus, jqXHR) {
            $("#auto_contactName").val(data.name);
            $("#auto_contactPhone").val(data.phone);
            $("#auto_contactFax").val(data.fax);
            $("#auto_contactMobile").val(data.mobile);
        }
        var failure = function (jqXHR, textStatus, errorThrown) {
            //alert(errorThrown);
        }
        var xhr = RPService.GetContactById(id, success, failure);
    };
    var _getDeliveryContactDetail = function (id) {
        var success = function (data, textStatus, jqXHR) {
            $("#auto_deliveryContactName").val(data.name);
            $("#auto_deliveryContactPhone").val(data.phone);
            $("#auto_deliveryContactFax").val(data.fax);
            $("#auto_deliveryContactMobile").val(data.mobile);
        }
        var failure = function (jqXHR, textStatus, errorThrown) {
            //alert(errorThrown);
        }
        var xhr = RPService.GetContactById(id, success, failure);
    };
    var _getSaleDetail = function (id) {
        var success = function (data, textStatus, jqXHR) {
            $("#auto_saleName").val(data.name);
            $("#auto_saleCode").val(data.code);
            $("#auto_saleBranch").val(data.branch);
        }
        var failure = function (jqXHR, textStatus, errorThrown) {
            //alert(errorThrown);
        }
        var xhr = RPService.GetSaleUserById(id, success, failure);
    };
    var _getDocumentDetail = function (id) {
        var success = function (data, textStatus, jqXHR) {
            console.log(data);
            var issuedDate = utilities.ConvertToDate(data.issuedDate);
            var expirationDate = utilities.ConvertToDate(data.expirationDate);
            var expectedDeliveryDate = utilities.ConvertToDate(data.expectedDeliveryDate);
            $("#documentCode").val(data.documentCode);
            $("#issuedDate").datepicker('setDate', issuedDate);
            $("#expirationDate").datepicker('setDate', expirationDate);
            $("#expectedDeliveryDate").datepicker('setDate', expectedDeliveryDate);
            _getCustomerDetail(data.customerId);
            _getContactDetail(data.contactId);
            _getSaleDetail(data.saleUserId);
            _getDeliveryContactDetail(data.deliveryContactId);
        }
        var failure = function (jqXHR, textStatus, errorThrown) {
            //alert(errorThrown);
        }
        var xhr = RPService.GetDocumentDetail(id, success, failure);
    };
    return {
        init: function () {
            var id = $("#documentId").val();
            _getDocumentDetail(id);
        },
    }
};