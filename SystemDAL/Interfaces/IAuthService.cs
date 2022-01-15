using EmailService;
using System.Threading.Tasks;
using SystemBLL.DTO.Auth;
using SystemDAL.Entities.Users;

namespace SystemBLL.Interfaces
{
    public interface IAuthService
    {
        Task SignUp(SignUp model);
        Task<User> SignIn(SignIn model);
        Task SignOut();
        Task<Message> ForgotPassword(ForgotPassword model);
        Task<string> ResetPassword(ResetPassword model);

    }
}
