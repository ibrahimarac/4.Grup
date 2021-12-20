using System.Threading.Tasks;
using Uzaktan.Core.Domain.Dto.Identity;
using Uzaktan.Core.Utilities.Results;

namespace Uzaktan.Core.Service
{
    public interface IAccountService
    {
        Task<IResult> AddUser(UserDto user);
        Task<IResult> AddRole(RoleDto role);
        Task<IResult> AddUserToRole(UserInRoleDto userInRole);
        Task<IResult> SignIn(LoginDto login);
    }
}
