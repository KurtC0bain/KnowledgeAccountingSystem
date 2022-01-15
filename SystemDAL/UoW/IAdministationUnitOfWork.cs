using SystemBLL.Interfaces;

namespace SystemBLL.UoF
{ 
    public interface IAdministationUnitOfWork
    {
        IUserService UserService { get; }
        IRoleService RoleService { get; }
        IAuthService AuthService { get; }
    }
}
