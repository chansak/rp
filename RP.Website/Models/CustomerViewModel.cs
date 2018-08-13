using System.Collections.Generic;

namespace RP.Website.Models
{
    public class CustomerViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Tel { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string Fax { get; set; }
        public string Address { get; set; }
        public string Remark { get; set; }
        public CustomerType CustomerType { get; set; }
        //public List<ContactViewModel> Contacts { get; set; }
    }
}