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
    GetProductsByCategoryId: function (id, successCallback, errorCallback) {
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
    GetMaterialStockCheck: function (productId, productUnitId,materialId, amount, successCallback, errorCallback) {
        var XHR = $.ajax({
            type: "POST",
            url: "/common/GetMaterialStockCheck",
            data: JSON.stringify({ productId: productId, productUnitId: productUnitId, materialId: materialId, amount: amount }),
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
    CreateDocument: function (formData, successCallback, errorCallback) {
        var XHR = $.ajax({
            type: "POST",
            url: "/Sale/document/CreateDocument",
            data: formData,
            cache: false,
            contentType: false,
            processData: false,
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
            url: "/document/GetDocumentDetail",
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
    GetCustomerById: function (id, successCallback, errorCallback) {
        var XHR = $.ajax({
            type: "POST",
            url: "/common/GetCustomerById",
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
    GetContactById: function (id, successCallback, errorCallback) {
        var XHR = $.ajax({
            type: "POST",
            url: "/common/GetContactById",
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
    GetSaleUserById: function (id, successCallback, errorCallback) {
        var XHR = $.ajax({
            type: "POST",
            url: "/common/GetSaleUserById",
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
    GetDocumentsListBySearch: function (searchBy, keyword, successCallback, errorCallback) {
        var XHR = $.ajax({
            type: "POST",
            url: "/document/Search",
            data: JSON.stringify({ searchBy: searchBy, keyword: keyword }),
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
    GetMaterials: function(successCallback, errorCallback) {
        var XHR = $.ajax({
            type: "POST",
            url: "/common/GetMaterials",
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
    GetProductItemByItemId: function (itemId, successCallback, errorCallback) {
        var XHR = $.ajax({
            type: "POST",
            url: "/common/GetProductItemByItemId",
            data: JSON.stringify({ id: itemId }),
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