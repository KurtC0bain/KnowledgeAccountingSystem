using Administration.Account.Models;
using Administration.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Administration.Account.Services
{
    public class AdministrationUnitOfWork : IAdministationUnitOfWork
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        private IUserService _userService;
        private IRoleService _roleService;


        public AdministrationUnitOfWork(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public IUserService UserService
        {
            get
            {
                if (_userService == null)
                    _userService = new UserService(_userManager);
                return _userService;
            }
        }
        public IRoleService RoleService
        {
            get
            {
                if (_roleService == null)
                    _roleService = new RoleService(_userManager, _roleManager);
                return _roleService;
            }
        }

    }
}
