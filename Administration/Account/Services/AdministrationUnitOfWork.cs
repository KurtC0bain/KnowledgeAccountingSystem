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
        private readonly SignInManager<User> _signInManager;

        private IUserService _userService;
        private IRoleService _roleService;


        public AdministrationUnitOfWork(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }
        public IUserService UserService
        {
            get
            {
                if (_userService == null)
                    _userService = new UserService(_userManager, _signInManager);
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
