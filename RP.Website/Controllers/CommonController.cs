using RP.Interfaces;
using RP.Website.Enum;
using RP.Website.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RP.Website.Controllers
{
    public class CommonController : Controller
    {
        public ActionResult GetSaleUsers()
        {
            var result = new AjaxResultModel();
            var users = GenericFactory.Business.GetSaleUsersList();
            var data = new List<SaleUserViewModel>();
            data.AddRange(users.Select(u => new SaleUserViewModel
            {
                Id = u.Id.ToString(),
                Name = u.DisplayName,
                Code = u.UserName,
                Branch = u.Department.DepartmentName
            }));
            return new JsonCamelCaseResult(data, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetCustomers()
        {
            var result = new AjaxResultModel();
            var customers = GenericFactory.Business.GetCustomersList();
            var data = new List<CustomerViewModel>();
            data.AddRange(customers.Select(c => new CustomerViewModel
            {
                Id = c.Id.ToString(),
                Name = c.Name,
                HospitalName = c.Name,
                CustomerTypeName = c.CustomerType.CustomerTypeName
            }));
            return new JsonCamelCaseResult(data, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetContactByCustomerId(string id)
        {
            var result = new AjaxResultModel();
            var contacts = GenericFactory.Business.GetContactByCustomerId(id);
            var data = new List<ContactViewModel>();
            data.AddRange(contacts.Select(c => new ContactViewModel
            {
                Id = c.Id.ToString(),
                Name = c.Name,
                Phone = c.Phone,
                Email = c.Email,
                Fax = c.Fax,
                Mobile = c.Mobile
            }));
            return new JsonCamelCaseResult(data, JsonRequestBehavior.AllowGet);
        }
    }
}