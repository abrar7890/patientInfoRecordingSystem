/*
 * ABRoleController
 * Purpose : working with users and roles
 * 
 * Arshdeep Brar
 * 
 * Revision History December 3, 2019
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ABPatients.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;

namespace ABPatients.Controllers
{
    [Authorize]
    public class ABRoleController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public ABRoleController( UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        /// <summary>
        /// list all roles
        /// </summary>
        /// <returns></returns>
        public IActionResult RoleList()
        {
            string loginName = User.Identity.Name;
            if (loginName != null)
            {
                HttpContext.Session.SetString("loginName", loginName);
            }
            var roles = roleManager.Roles.OrderBy(a => a.Name);
            return View(roles);
        }

        /// <summary>
        /// list all users registered
        /// </summary>
        /// <returns></returns>
        public IActionResult AllUsersList()
        {
            var users = userManager.Users.OrderBy(a => a.UserName);
            return View(users);
        }

        /// <summary>
        /// list of users inside a particular role
        /// </summary>
        /// <param name="name">rolename</param>
        /// <returns>users in a role</returns>
        public async Task<IActionResult> UserList(string name)
        {
            //if role name is not null store it in a session variable
            if(name != null)
            {
                HttpContext.Session.SetString("roleName", name);
            }
            else
            {
                //if null, get the value from session variable
                name = HttpContext.Session.GetString("roleName");
            }

            //list of user for rolename passed
            var userListInRole = (await userManager.GetUsersInRoleAsync(name)).ToList();

            //if no users in this role, then return message- no users in role
            if (userListInRole.Count == 0)
            {
                TempData["message"] += $"\nNo user in {name} role";
            }

            //get the list of all users from user manager
            var userList = userManager.Users;

            List<IdentityUser> notInRole = new List<IdentityUser>();

            //check if users are not in role 
            foreach (IdentityUser item in userList)
            {
                if (!userListInRole.Contains(item))
                {
                    notInRole.Add(item);
                }
            }

            ViewData["userLists"] = new SelectList(notInRole, "UserName", "Email");
            ViewData["roleName"] = name;

            return View(userListInRole);
        }

        /// <summary>
        /// remove a user from role
        /// </summary>
        /// <param name="userName">username of the user</param>
        /// <returns>view of user list for that role</returns>
        public async Task<IActionResult> RemoveUserFromRole(string userName)
        {
            string loginName = "";
            string roleName = "";

            if (HttpContext.Session.GetString("loginName") == null)
            {
                ModelState.AddModelError("", "Logged user isn't valid.");
            }
            else if (HttpContext.Session.GetString("loginName") != null)
            {
                loginName = HttpContext.Session.GetString("loginName");
            }

            if (HttpContext.Session.GetString("roleName") == null)
            {
                ModelState.AddModelError("", "Role name doesn't have any value.");
            }
            else if (HttpContext.Session.GetString("roleName") != null)
            {
                roleName = HttpContext.Session.GetString("roleName");
            }

            try
            {
                IdentityUser user = await userManager.FindByNameAsync(userName);

                //if the user you want to delete is the same login user
                if (user.UserName == loginName)
                {
                    //Cannot delete the login user
                    TempData["message"] = $"{userName} cannot delete itself";
                }
                else
                {
                    // Remove user from role
                    IdentityResult removeResult = await userManager.RemoveFromRoleAsync(user, roleName);
                    TempData["message"] = $"{userName} removed from {roleName} successfully";
                }
            }
            catch (Exception ex)
            {
                TempData["message"] =
                    $"Exception removing user '{userName}' {ex.GetBaseException().Message}";
            }

            return RedirectToAction("UserList", new { name = roleName });
        }

        /// <summary>
        /// delete the role 
        /// </summary>
        /// <param name="name">role name</param>
        /// <returns>view of list of roles</returns>
        public async Task<IActionResult> DeleteRole(string name)
        {
            string roleName = name;
            try
            {
                //if role exists, get role object &delete it
                var role = await roleManager.RoleExistsAsync(name);
                if (role)
                {
                    IdentityRole roleToDelete = await roleManager.FindByNameAsync(name);
                    await roleManager.DeleteAsync(roleToDelete);

                    TempData["message"] = $"{name} Role deleted successfully";

                    return RedirectToAction("RoleList");
                }
            }
            catch (Exception ex)
            {
                TempData["message"] =
                    $"Exception deleting Role '{name}' {ex.GetBaseException().Message}";
            }

            return RedirectToAction("RoleList", new { name = roleName });
        }

        /// <summary>
        /// details of users in the role
        /// </summary>
        /// <param name="name">role name</param>
        /// <returns></returns>
        public async Task<IActionResult> Details(string name)
        {
            if (name != null)
            {
                HttpContext.Session.SetString("roleName", name);
            }
            else
            {
                name = HttpContext.Session.GetString("roleName");
            }

            ViewData["roleName"] = name;

            var userListInRole = await userManager.GetUsersInRoleAsync(name);
            string roleName = name;

            //if no user the return back to list of roles
            if (userListInRole.Count == 0)
            {
                return RedirectToAction("RoleList", new { name = roleName });
            }
            else
            {
                //list of users that are not in role
                ViewData["userList"] = new SelectList(userListInRole, "UserName", "Email");
                return View(userListInRole);
            }
        }

        /// <summary>
        /// cancel delete will just revert it back to list of roles
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public IActionResult CancelDelete(string name)
        {
            return RedirectToAction("RoleList");
        }

        /// <summary>
        /// create a new role
        /// </summary>
        /// <param name="roleName">role name</param>
        /// <returns>view of list of roles</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateRole(string roleName)
        {
            if(roleName == null || roleName.Trim() == "")
            {
                TempData["message"] = $"Role Name cannot be null or just blanks";
            }
            if (ModelState.IsValid)
            {
                IdentityRole role = new IdentityRole { Name = roleName };

                IdentityResult result = await roleManager.CreateAsync(role);

                if (result.Succeeded)
                {
                    return RedirectToAction("RoleList");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return RedirectToAction("RoleList"); 
        }

        /// <summary>
        /// add user to a role
        /// </summary>
        /// <param name="userName">user name of user</param>
        /// <returns>view of list of users</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddUserToRole(string userName)
        {
            string name = HttpContext.Session.GetString("roleName");

            var userListInRole = await userManager.GetUsersInRoleAsync(name);

            try
            {
                IdentityUser user = await userManager.FindByNameAsync(userName);

                //checks if user is already on file
                if (await userManager.IsInRoleAsync(user,name)) throw new Exception($"'{userName}' is already on file");
                IdentityResult result = await userManager.AddToRoleAsync(user, name);
                if(!result.Succeeded)
                {
                    throw new Exception(result.Errors.First().Description);
                }

                TempData["message"] = $"user added: '{userName}'";
            }
            catch (Exception ex)
            {
                TempData["message"] = $"Exception while creating user: {ex.GetBaseException().Message}";
            }
            return RedirectToAction("UserList");
        }
    }
}
