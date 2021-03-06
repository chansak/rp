﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RP.Website.Models
{
    public class MobileHistoryViewModel
    {
        public string Id { get; set; }
        public string DocumentId { get; set; }
        public int HistoryTypeId { get; set; }
        public string UserId { get; set; }
        public string Text { get; set; }
        public string CreatedDate { get; set; }
        public string DisplayName { get; set; }
    }
}