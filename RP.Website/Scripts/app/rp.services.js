var RPService = {
    GetSaleUsers: function (successCallback, errorCallback) {
        var XHR = $.ajax({
            type: "POST",
            url: "/common/GetSaleUsers",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data, textStatus, jqXHR) {
                successCallback(data, textStatus, jqXHR);
            },
            error: function (jqXHR, textStatus, errorThrown) {
                if (jqXHR.status == 401) {
                    Logout();
                } else {
                    errorCallback(jqXHR, textStatus, errorThrown);
                }
            }
        });

        return XHR;
    },
    GetCustomers: function (successCallback, errorCallback) {
        var XHR = $.ajax({
            type: "POST",
            url: "/common/GetCustomers",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data, textStatus, jqXHR) {
                successCallback(data, textStatus, jqXHR);
            },
            error: function (jqXHR, textStatus, errorThrown) {
                if (jqXHR.status == 401) {
                    Logout();
                } else {
                    errorCallback(jqXHR, textStatus, errorThrown);
                }
            }
        });

        return XHR;
    },
    GetContactByCustomerId: function (id, successCallback, errorCallback) {
        var XHR = $.ajax({
            type: "POST",
            url: "/common/GetContactByCustomerId",
            data: JSON.stringify({ id: id }),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data, textStatus, jqXHR) {
                successCallback(data, textStatus, jqXHR);
            },
            error: function (jqXHR, textStatus, errorThrown) {
                if (jqXHR.status == 401) {
                    Logout();
                } else {
                    errorCallback(jqXHR, textStatus, errorThrown);
                }
            }
        });
        return XHR;
    },
    GetProductCategories: function (successCallback, errorCallback) {
        var XHR = $.ajax({
            type: "POST",
            url: "/common/GetProductCategories",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data, textStatus, jqXHR) {
                successCallback(data, textStatus, jqXHR);
            },
            error: function (jqXHR, textStatus, errorThrown) {
                if (jqXHR.status == 401) {
                    Logout();
                } else {
                    errorCallback(jqXHR, textStatus, errorThrown);
                }
            }
        });

        return XHR;
    },
    GetProductsByCategoryId: function (id,successCallback, errorCallback) {
        var XHR = $.ajax({
            type: "POST",
            url: "/common/GetProductsByCategoryId",
            data: JSON.stringify({ id: id }),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data, textStatus, jqXHR) {
                successCallback(data, textStatus, jqXHR);
            },
            error: function (jqXHR, textStatus, errorThrown) {
                if (jqXHR.status == 401) {
                    Logout();
                } else {
                    errorCallback(jqXHR, textStatus, errorThrown);
                }
            }
        });

        return XHR;
    },
    GetOptionsByProductId: function (id, successCallback, errorCallback) {
        var XHR = $.ajax({
            type: "POST",
            url: "/common/GetOptionsByProductId",
            data: JSON.stringify({ id: id }),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data, textStatus, jqXHR) {
                successCallback(data, textStatus, jqXHR);
            },
            error: function (jqXHR, textStatus, errorThrown) {
                if (jqXHR.status == 401) {
                    Logout();
                } else {
                    errorCallback(jqXHR, textStatus, errorThrown);
                }
            }
        });

        return XHR;
    },
    GetMaterialStockCheck: function (id, productUnitId,amount, successCallback, errorCallback) {
        var XHR = $.ajax({
            type: "POST",
            url: "/common/GetMaterialStockCheck",
            data: JSON.stringify({ id: id, productUnitId: productUnitId,amount:amount }),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data, textStatus, jqXHR) {
                successCallback(data, textStatus, jqXHR);
            },
            error: function (jqXHR, textStatus, errorThrown) {
                if (jqXHR.status == 401) {
                    Logout();
                } else {
                    errorCallback(jqXHR, textStatus, errorThrown);
                }
            }
        });

        return XHR;
    },
    GetUnitsByProductId: function (id, successCallback, errorCallback) {
        var XHR = $.ajax({
            type: "POST",
            url: "/common/GetUnitsByProductId",
            data: JSON.stringify({ id: id }),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data, textStatus, jqXHR) {
                successCallback(data, textStatus, jqXHR);
            },
            error: function (jqXHR, textStatus, errorThrown) {
                if (jqXHR.status == 401) {
                    Logout();
                } else {
                    errorCallback(jqXHR, textStatus, errorThrown);
                }
            }
        });

        return XHR;
    },
    GetDocumentDetail: function (id, successCallback, errorCallback) {
        var XHR = $.ajax({
            type: "POST",
            url: "/sale/document/Edit",
            data: JSON.stringify({ id: id }),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data, textStatus, jqXHR) {
                successCallback(data, textStatus, jqXHR);
            },
            error: function (jqXHR, textStatus, errorThrown) {
                if (jqXHR.status == 401 || jqXHR.status == 12030 || jqXHR.status == 302) {
                    Logout();
                } else {
                    errorCallback(jqXHR, textStatus, errorThrown);
                }
            }
        });
        return XHR;
    },
    GetPatternImages: function (successCallback, errorCallback) {
        var XHR = $.ajax({
            type: "POST",
            url: "/common/GetPatternImages",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data, textStatus, jqXHR) {
                successCallback(data, textStatus, jqXHR);
            },
            error: function (jqXHR, textStatus, errorThrown) {
                if (jqXHR.status == 401) {
                    Logout();
                } else {
                    errorCallback(jqXHR, textStatus, errorThrown);
                }
            }
        });

        return XHR;
    },
    GetPatternPosition: function (successCallback, errorCallback) {
        var XHR = $.ajax({
            type: "POST",
            url: "/common/GetPatternPosition",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data, textStatus, jqXHR) {
                successCallback(data, textStatus, jqXHR);
            },
            error: function (jqXHR, textStatus, errorThrown) {
                if (jqXHR.status == 401) {
                    Logout();
                } else {
                    errorCallback(jqXHR, textStatus, errorThrown);
                }
            }
        });

        return XHR;
    },
    GetPatternColors: function (successCallback, errorCallback) {
        var XHR = $.ajax({
            type: "POST",
            url: "/common/GetPatternColors",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data, textStatus, jqXHR) {
                successCallback(data, textStatus, jqXHR);
            },
            error: function (jqXHR, textStatus, errorThrown) {
                if (jqXHR.status == 401) {
                    Logout();
                } else {
                    errorCallback(jqXHR, textStatus, errorThrown);
                }
            }
        });

        return XHR;
    },

}