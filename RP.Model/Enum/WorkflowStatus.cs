using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RP.Model
{
    public enum WorkflowStatus
    {
        [Description("Draft")]
        Draft = 0,

        [Description("ลูกค้าขอราคา")]
        RequestForPrice=1,

        [Description("ขออนุมัติ")]
        RequestedForApproval=2,

        [Description("อนุมัติแล้ว")]
        Approved =3,

        [Description("ขอข้อมูลเพิ่ม")]
        Rejected =4,

        [Description("ออกใบเสนอราคาแล้ว")]
        Quotation = 5,

        [Description("ได้รับ PO แล้ว")]
        PurchaseOrder = 6,

        [Description("ยกเลิก")]
        Cancelled =99,

    }
}
