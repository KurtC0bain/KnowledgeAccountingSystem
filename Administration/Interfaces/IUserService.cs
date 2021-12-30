﻿using Administration.Account.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Administration.Interfaces
{
    public interface IUserService
    {
        Task SignUp(SignUp model);
        Task<User> SignIn(SignIn model);
        Task DeleteUser(string email);
        Task<IEnumerable<User>> GetAllUsers();
    }
}
