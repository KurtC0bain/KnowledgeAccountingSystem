
using EmailService;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SystemDAL.Administration.Account.Models;

namespace SystemDAL.Administration.Interfaces
{
    public interface IUserService
    {
        Task SignUp(SignUp model);
        Task<User> SignIn(SignIn model);
        Task DeleteUser(string email);
        Task<IEnumerable<User>> GetAllUsers();
        Task SignOut();
        Task<Message> ForgotPassword(ForgotPassword model);
        Task<string> ResetPassword(ResetPassword model);
    }
}
