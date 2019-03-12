using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RP.Website.Models
{
    public class CustomerAndContactViewModel : BaseDocumentViewModel
    {
        public string CustomerId { get; set; }
        public string ContactId { get; set; }
    }
}