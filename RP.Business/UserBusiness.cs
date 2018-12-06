using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using RP.Interfaces;
using RP.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Security;

namespace RP.Business
{
    partial class Business : BaseBusiness, IBusiness
    {
        public IList<User> GetSaleUsersList()
        {
            using (var uow = UnitOfWork.Create())
            {
                return uow.UserRepository.All().ToList();
            }
        }
        public User GetSaleUserById(string id)
        {
            using (var uow = UnitOfWork.Create())
            {
                return uow.UserRepository.GetById(id);
            }
        }
        public bool AddNewUser(ApplicationUser user)
        {
            bool operationResult = false;
            try
            {
                var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(RP.DataAccess.ApplicationDbContext.Create()));
                var result = userManager.Create(user, user.Password);
                if (result.Succeeded)
                {
                    Roles.AddUserToRole(user.UserName, user.RoleName);
                    operationResult = true;
                }
                else { }
            }
            catch (Exception ex)
            {

            }
            return operationResult;
        }
    }
}
