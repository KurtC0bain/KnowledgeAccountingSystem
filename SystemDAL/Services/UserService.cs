using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SystemBLL.DTO.Users;
using SystemBLL.Interfaces;
using SystemDAL.Entities.Users;

namespace SystemBLL.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        public UserService(UserManager<User> userManager)
        {
            _userManager = userManager;

            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<UserDTO, User>().ReverseMap();
            });
            _mapper = new Mapper(config);
        }
        public async Task DeleteUser(string email)
        {
            var currentUser = await _userManager.FindByEmailAsync(email);
            var userRoles = await _userManager.GetRolesAsync(currentUser);

            if (userRoles.Count() > 0)
            {
                foreach (var role in userRoles.ToList())
                {
                    var result = await _userManager.RemoveFromRoleAsync(currentUser, role);
                }
            }
            await _userManager.DeleteAsync(currentUser);
        }
        public async Task<User> GetCurrentUser(string email)
        {
            return await _userManager.FindByEmailAsync(email);
        }
        public async Task<IEnumerable<User>> GetAllUsers()
        {
            var result = await _userManager.Users.Include(x => x.Knowledge).ToListAsync();
            return result;
        }
        public async Task<string> GetUserId(string email)
        {
            var user = await _userManager.FindByNameAsync(email);
            return user.Id;
        }
        public async Task<User> GetUserById(string id)
        {
            return await _userManager.FindByIdAsync(id);
        }

        public async Task UpdateUser(UserDTO user)
        {
            var u = await _userManager.FindByEmailAsync(user.Email);
            
            u.Email = user.Email;
            u.FirstName = user.FirstName;
            u.LastName = user.LastName;


            await _userManager.UpdateAsync(u);
        }
    }
}
