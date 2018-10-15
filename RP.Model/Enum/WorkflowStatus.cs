using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RP.Model.Enum
{
    public enum WorkflowStatus
    {
        undefined=0,
        [Description("ลูกค้าขออนุมัติ")]
        RequestedForApproval=1,

        [Description("อนมัติใบเสนอราคาแล้ว")]
        Approved =2,

        [Description("ไม่อนุมัติ/ขอข้อมูลเพิ่ม")]
        Rejected =3,

        [Description("ลูกค้าขออนุมัติ")]
        Cancelled =4,

        [Description("ออกใบเสนอราคาแล้ว")]
        Quotation =5,

        [Description("ได้รับ PO แล้ว")]
        PurchaseOrder =6
    }
}
