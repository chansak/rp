using RP.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RP.Website.Extensions
{
    public static class StatusExtension
    {
        public static string ToWorkFlowStatusName(this WorkflowStatus documentStatus) {
            var documentStatusName = string.Empty;
            switch (documentStatus)
            {
                case WorkflowStatus.Draft:
                    {
                        documentStatusName = WorkflowStatus.Draft.DescriptionAttr();
                        break;
                    }
                case WorkflowStatus.RequestForPrice:
                    {
                        documentStatusName = WorkflowStatus.RequestForPrice.DescriptionAttr();
                        break;
                    }
                case WorkflowStatus.RequestedForApproval:
                    {
                        documentStatusName = WorkflowStatus.RequestedForApproval.DescriptionAttr();
                        break;
                    }
                case WorkflowStatus.Approved:
                    {
                        documentStatusName = WorkflowStatus.Approved.DescriptionAttr();
                        break;
                    }
                case WorkflowStatus.Rejected:
                    {
                        documentStatusName = WorkflowStatus.Rejected.DescriptionAttr();
                        break;
                    }
                case WorkflowStatus.Quotation:
                    {
                        documentStatusName = WorkflowStatus.Quotation.DescriptionAttr();
                        break;
                    }
                case WorkflowStatus.PurchaseOrder:
                    {
                        documentStatusName = WorkflowStatus.PurchaseOrder.DescriptionAttr();
                        break;
                    }
            }
            return documentStatusName;
        }
    }
}