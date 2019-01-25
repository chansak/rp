using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RP.Website.Models
{
    public class MobileResponseModel
    {
        public bool Status { get; set; }
        public string ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
        public string MessageId { get; set; }
        public string TimeStamp { get; set; }
        public object Datas { get; set; }
        public MobileResponseModel()
        {
            this.Status = true;
            this.ErrorCode = "";
            this.ErrorMessage = "";
            this.MessageId = Guid.NewGuid().ToString();
            this.TimeStamp = DateTime.Now.ToDateString();
        }
    }
}