using System.Collections.Generic;
using System.Threading.Tasks;
using SystemBLL.DTO.Users;
using SystemDAL.Entities.Users;

namespace SystemBLL.Interfaces
{
    public interface IUserService
    {
        Task DeleteUser(string email);
        Task UpdateUser(UserDTO user);

        Task<IEnumerable<User>> GetAllUsers();
        Task<User> GetUserById(string id);
        Task<User> GetCurrentUser(string email);
        Task<string> GetUserId(string email);
    }
}
