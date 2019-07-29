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
    GetDefaultUser: function (successCallback, errorCallback) {
        var XHR = $.ajax({
            type: "GET",
            url: "/common/GetDefaultUser",
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
    CreateDraftDocument: function (formData, successCallback, errorCallback) {
        var XHR = $.ajax({
            type: "POST",
            url: "/Sale/document/CreateDraftDocument",
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
    UpdateDocument: function (formData, successCallback, errorCallback) {
        var XHR = $.ajax({
            type: "POST",
            url: "/Sale/document/UpdateDocument",
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
    UpdateDocumentWithComments: function (formData, successCallback, errorCallback) {
        var XHR = $.ajax({
            type: "POST",
            url: "/Sale/document/UpdateDocumentWithComments",
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
    UpdateDraftDocumentWithComments: function (formData, successCallback, errorCallback) {
        var XHR = $.ajax({
            type: "POST",
            url: "/Sale/document/UpdateDraftDocumentWithComments",
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
            url: "/Sale/document/GetDocumentDetail",
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
            url: "/Sale/document/Search",
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
    GetDocumentsListBySearch: function (criteria, successCallback, errorCallback) {
        var XHR = $.ajax({
            type: "POST",
            url: "/Sale/document/Search",
            data: JSON.stringify(criteria),
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
    GetUsersListBySearch: function (searchBy, keyword, successCallback, errorCallback) {
        var XHR = $.ajax({
            type: "POST",
            url: "/Admin/common/searchUser",
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
    IsExistingItem: function (itemId, successCallback, errorCallback) {
        var XHR = $.ajax({
            type: "POST",
            url: "/Sale/document/IsExistingItem",
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
    RequestApproval: function (id, successCallback, errorCallback) {
        var XHR = $.ajax({
            type: "POST",
            url: "/Sale/Document/RequestApprove",
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
    GetApprovalDocumentsListBySearch: function (searchBy, keyword, successCallback, errorCallback) {
        var XHR = $.ajax({
            type: "POST",
            url: "/ApprovalDocument/Search",
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
    ApprovedRequest: function (id, successCallback, errorCallback) {
        var XHR = $.ajax({
            type: "POST",
            url: "/Manager/ApprovalDocument/ApprovedRequest",
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
    RejectedRequestToSale: function (id, successCallback, errorCallback) {
        var XHR = $.ajax({
            type: "POST",
            url: "/Manager/ApprovalDocument/RejectedRequestToSale",
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
    RejectedRequestToBackOffice: function (id, successCallback, errorCallback) {
        var XHR = $.ajax({
            type: "POST",
            url: "/Manager/ApprovalDocument/RejectedRequestToBackOffice",
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
    GotPO: function (id, successCallback, errorCallback) {
        var XHR = $.ajax({
            type: "POST",
            url: "/Sale/Document/GotPO",
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
    GetCurrentWorkflowStatus : function (id, successCallback, errorCallback) {
        var XHR = $.ajax({
            type: "POST",
            url: "/Sale/Document/GetCurrentWorkflowStatus",
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
    GetCustomerBranchByCustomerId: function (id, successCallback, errorCallback) {
        var XHR = $.ajax({
            type: "POST",
            url: "/common/GetCustomerBranchByCustomerId",
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

    CreateDocumentForBackoffice: function (formData, successCallback, errorCallback) {
        var XHR = $.ajax({
            type: "POST",
            url: "/Backoffice/document/CreateDocument",
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
    CreateDraftDocumentForBackoffice: function (formData, successCallback, errorCallback) {
        var XHR = $.ajax({
            type: "POST",
            url: "/Backoffice/document/CreateDraftDocument",
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
    UpdateDocumentForBackoffice: function (formData, successCallback, errorCallback) {
        var XHR = $.ajax({
            type: "POST",
            url: "/Backoffice/document/UpdateDocument",
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
    UpdateDocumentWithCommentsForBackoffice: function (formData, successCallback, errorCallback) {
        var XHR = $.ajax({
            type: "POST",
            url: "/Backoffice/document/UpdateDocumentWithComments",
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
    UpdateDraftDocumentWithCommentsForBackoffice: function (formData, successCallback, errorCallback) {
        var XHR = $.ajax({
            type: "POST",
            url: "/Backoffice/document/UpdateDraftDocumentWithComments",
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
    GetDocumentDetailForBackoffice: function (id, successCallback, errorCallback) {
        var XHR = $.ajax({
            type: "POST",
            url: "/Backoffice/document/GetDocumentDetail",
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
    GetDocumentsListBySearchForBackoffice: function (searchBy, keyword, successCallback, errorCallback) {
        var XHR = $.ajax({
            type: "POST",
            url: "/Backoffice/document/Search",
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
    GetDocumentsListBySearchForBackoffice: function (criteria, successCallback, errorCallback) {
        var XHR = $.ajax({
            type: "POST",
            url: "/Backoffice/document/Search",
            data: JSON.stringify(criteria),
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
    IsExistingItemForBackoffice: function (itemId, successCallback, errorCallback) {
        var XHR = $.ajax({
            type: "POST",
            url: "/Backoffice/document/IsExistingItem",
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
    RequestApprovalForBackoffice: function (id, successCallback, errorCallback) {
        var XHR = $.ajax({
            type: "POST",
            url: "/Backoffice/Document/RequestApprove",
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
    PrintQuotationForBackoffice: function (id, successCallback, errorCallback) {
        var XHR = $.ajax({
            type: "POST",
            url: "/Backoffice/Document/PrintQuotation",
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
    GotPOForBackoffice: function (data, successCallback, errorCallback) {
        var XHR = $.ajax({
            type: "POST",
            url: "/Backoffice/Document/GotPO",
            data: data,
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
    GetCurrentWorkflowStatusForBackoffice: function (id, successCallback, errorCallback) {
        var XHR = $.ajax({
            type: "POST",
            url: "/Backoffice/Document/GetCurrentWorkflowStatus",
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

    CreateDocumentForManager: function (formData, successCallback, errorCallback) {
        var XHR = $.ajax({
            type: "POST",
            url: "/Manager/document/CreateDocument",
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
    CreateDraftDocumentForManager: function (formData, successCallback, errorCallback) {
        var XHR = $.ajax({
            type: "POST",
            url: "/Manager/document/CreateDraftDocument",
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
    UpdateDocumentForManager: function (formData, successCallback, errorCallback) {
        var XHR = $.ajax({
            type: "POST",
            url: "/Manager/document/UpdateDocument",
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
    UpdateDocumentWithCommentsForManager: function (formData, successCallback, errorCallback) {
        var XHR = $.ajax({
            type: "POST",
            url: "/Manager/document/UpdateDocumentWithComments",
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
    GetDocumentDetailForManager: function (id, successCallback, errorCallback) {
        var XHR = $.ajax({
            type: "POST",
            url: "/Manager/document/GetDocumentDetail",
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
    GetDocumentsListBySearchForManager: function (searchBy, keyword, successCallback, errorCallback) {
        var XHR = $.ajax({
            type: "POST",
            url: "/Manager/document/Search",
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
    GetDocumentsListBySearchForManager: function (criteria, successCallback, errorCallback) {
        var XHR = $.ajax({
            type: "POST",
            url: "/Manager/document/Search",
            data: JSON.stringify(criteria),
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
    IsExistingItemForManager: function (itemId, successCallback, errorCallback) {
        var XHR = $.ajax({
            type: "POST",
            url: "/Manager/document/IsExistingItem",
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
    RequestApprovalForManager: function (id, successCallback, errorCallback) {
        var XHR = $.ajax({
            type: "POST",
            url: "/Manager/Document/RequestApprove",
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
    GotPOForManager: function (id, successCallback, errorCallback) {
        var XHR = $.ajax({
            type: "POST",
            url: "/Manager/Document/GotPO",
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
    GetCurrentWorkflowStatusForManager: function (id, successCallback, errorCallback) {
        var XHR = $.ajax({
            type: "POST",
            url: "/Manager/Document/GetCurrentWorkflowStatus",
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

    //Master Data

    //User
    GetUsersList: function (searchBy, keyword, successCallback, errorCallback) {
        var XHR = $.ajax({
            type: "POST",
            url: "/Admin/UserAccount/searchUser",
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
    GetUserById: function (id, successCallback, errorCallback) {
        var XHR = $.ajax({
            type: "POST",
            url: "/Admin/UserAccount/GetUserById",
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

    //Category
    GetCategoriesBySearch: function (searchBy, keyword, successCallback, errorCallback) {
        var XHR = $.ajax({
            type: "POST",
            url: "/Admin/product/SearchCategory",
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
    CreateCategory: function (data, successCallback, errorCallback) {
        var XHR = $.ajax({
            type: "POST",
            url: "/Admin/product/CreateCategory",
            data: data,
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
    GetCategoryById: function (id, successCallback, errorCallback) {
        var XHR = $.ajax({
            type: "POST",
            url: "/Admin/product/GetCategoryById",
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
    UpdateCategory: function (data, successCallback, errorCallback) {
        var XHR = $.ajax({
            type: "POST",
            url: "/Admin/product/UpdateCategory",
            data: data,
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
    DeleteCategory: function (id, successCallback, errorCallback) {
        var XHR = $.ajax({
            type: "POST",
            url: "/Admin/product/DeleteCategory",
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

    //Product
    GetProductsBySearch: function (searchBy, keyword, successCallback, errorCallback) {
        var XHR = $.ajax({
            type: "POST",
            url: "/Admin/product/SearchProduct",
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
    CreateProduct: function (data, successCallback, errorCallback) {
        var XHR = $.ajax({
            type: "POST",
            url: "/Admin/product/CreateProduct",
            data: data,
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
    GetProductById: function (id, successCallback, errorCallback) {
        var XHR = $.ajax({
            type: "POST",
            url: "/Admin/product/GetProductById",
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
    UpdateProduct: function (data, successCallback, errorCallback) {
        var XHR = $.ajax({
            type: "POST",
            url: "/Admin/product/UpdateProduct",
            data: data,
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
    DeleteProduct: function (id, successCallback, errorCallback) {
        var XHR = $.ajax({
            type: "POST",
            url: "/Admin/product/DeleteProduct",
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


    //Product Option
    GetProductOptionsBySearch: function (searchBy, keyword, successCallback, errorCallback) {
        var XHR = $.ajax({
            type: "POST",
            url: "/Admin/product/SearchProductOption",
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
    CreateProductOption: function (data, successCallback, errorCallback) {
        var XHR = $.ajax({
            type: "POST",
            url: "/Admin/product/CreateProductOption",
            data: data,
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
    GetProductOptionById: function (id, successCallback, errorCallback) {
        var XHR = $.ajax({
            type: "POST",
            url: "/Admin/product/GetProductOptionById",
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
    UpdateProductOption: function (data, successCallback, errorCallback) {
        var XHR = $.ajax({
            type: "POST",
            url: "/Admin/product/UpdateProductOption",
            data: data,
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
    DeleteProductOption: function (id, successCallback, errorCallback) {
        var XHR = $.ajax({
            type: "POST",
            url: "/Admin/product/DeleteProductOption",
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

    GetProductUnitBySearch: function (searchBy, keyword, successCallback, errorCallback) {
        var XHR = $.ajax({
            type: "POST",
            url: "/Admin/product/SearchProductUnit",
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
    CreateProductUnit: function (data, successCallback, errorCallback) {
        var XHR = $.ajax({
            type: "POST",
            url: "/Admin/product/CreateProductUnit",
            data: data,
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
    GetProductUnitById: function (id, successCallback, errorCallback) {
        var XHR = $.ajax({
            type: "POST",
            url: "/Admin/product/GetProductUnitById",
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
    UpdateProductUnit: function (data, successCallback, errorCallback) {
        var XHR = $.ajax({
            type: "POST",
            url: "/Admin/product/UpdateProductUnit",
            data: data,
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
    //DeleteCategory: function (id, successCallback, errorCallback) {
    //    var XHR = $.ajax({
    //        type: "POST",
    //        url: "/Admin/product/DeleteCategory",
    //        data: JSON.stringify({ id: id }),
    //        contentType: "application/json; charset=utf-8",
    //        dataType: "json",
    //        success: function (data, textStatus, jqXHR) {
    //            successCallback(data, textStatus, jqXHR);
    //        },
    //        error: function (jqXHR, textStatus, errorThrown) {
    //            if (jqXHR.status == 401) {
    //                Logout();
    //            } else {
    //                errorCallback(jqXHR, textStatus, errorThrown);
    //            }
    //        }
    //    });
    //    return XHR;
    //},
}