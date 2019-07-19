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
        //For Sale 
        //-------------------------------
        [Description("แบบร่าง")]
        Draft = 0,
        [Description("ขอข้อมุลเพิ่ม")]
        RequestForMoreInfoForSale =10,
        //-------------------------------

        //For Back office
        //-------------------------------
        [Description("ลูกค้าขอราคา")]
        RequestForPrice=20,
        [Description("ขอข้อมูลเพิ่ม")]
        RequestForMoreInfoForBackoffice = 21,
        //-------------------------------

        //For Manager
        //-------------------------------
        [Description("ขออนุมัติ")]
        RequestedForApproval = 30,
        //-------------------------------

        //For Admin
        //-------------------------------
        [Description("ขอให้มอบหมาย")]
        RequestForAssignment = 40,
        //-------------------------------

        //Common
        //-------------------------------
        [Description("อนุมัติแล้ว")]
        Approved =50,
        [Description("ออกใบเสนอราคาแล้ว")]
        Quotation = 51,
        [Description("ได้รับ PO แล้ว")]
        PurchaseOrder = 52,
        //-------------------------------

        [Description("ยกเลิก")]
        Cancelled = 99,
    }
}
