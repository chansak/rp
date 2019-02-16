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
                var users = new List<AspNetUser>();
                var data = uow.AspNetUserRepository.All();
                foreach (var user in users)
                {
                    var role = user.AspNetRoles.FirstOrDefault();
                    if (role.Name.ToLower().Equals("sale"))
                    {
                        users.Add(user);
                    }
                }
                return users;
            }

        }
        public IList<AspNetUser> GetAllUsers(string searchBy, string keyword)
        {
            using (var uow = UnitOfWork.Create())
            {
                var users = uow.AspNetUserRepository.All().AsEnumerable();
                if (!string.IsNullOrWhiteSpace(searchBy) && !string.IsNullOrWhiteSpace(keyword))
                {
                    switch (searchBy)
                    {
                        case "UserName":
                            {
                                users = users.Where(i => i.UserName.ToLower().Contains(keyword.ToLower()));
                                break;
                            }
                        case "DisplayName":
                            {
                                users = users.Where(i => i.DisplayName.ToLower().Contains(keyword.ToLower()));
                                break;
                            }
                        default:
                            {
                                break;
                            }
                    }
                }
                return users.ToList();
            }
        }
        public AspNetUser GetSaleUserById(string id)
        {
            using (var uow = UnitOfWork.Create())
            {
                var sales = this.GetSaleUsersList();
                return sales.First(s => s.Id == id);
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
