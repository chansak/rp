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
        public IList<AspNetUser> GetSaleUsersList()
        {
            using (var uow = UnitOfWork.Create())
            {
                return uow.AspNetUserRepository.All().ToList();
            }

        }
        public User GetSaleUserById(string id)
        {
            using (var uow = UnitOfWork.Create())
            {
                return uow.UserRepository.GetById(id);
            }
        }
        public bool AddNewUser(ApplicationUser user, string password, string role)
        {
            bool operationResult = false;
            try
            {
                var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(RP.DataAccess.ApplicationDbContext.Create()));
                var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(RP.DataAccess.ApplicationDbContext.Create()));
                var addUserResult = userManager.Create(user, password);
                if (addUserResult.Succeeded)
                {
                    if (roleManager.RoleExists(role))
                    {
                        var createdUser = userManager.FindByName(user.UserName);
                        var addToRoleResult = userManager.AddToRole(createdUser.Id, role);
                        operationResult = true;
                    }
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
