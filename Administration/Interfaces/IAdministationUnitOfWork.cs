using System;
using System.Collections.Generic;
using System.Text;

namespace Administration.Interfaces
{
    public interface IAdministationUnitOfWork
    {
        IUserService UserService { get; }
        IRoleService RoleService { get; }
    }
}
