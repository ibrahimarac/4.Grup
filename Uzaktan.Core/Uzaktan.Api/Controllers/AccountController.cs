using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Uzaktan.Core.Domain.Dto.Identity;
using Uzaktan.Core.Service;

namespace Uzaktan.Api.Controllers
{
    [Route("account")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [Route("token")]
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody]LoginDto login)
        {
            var result = await _accountService.SignIn(login);
            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }

        [Route("user/add")]
        [HttpPost]
        [Authorize(Roles ="admin")]
        public async Task<IActionResult> AddUser([FromBody]UserDto user)
        {
            var result=await _accountService.AddUser(user);
            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }

        [Route("role/add")]
        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> AddRole([FromBody]RoleDto role)
        {
            var result = await _accountService.AddRole(role);
            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }

        [Route("user/add-to-roles")]
        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> AddRole([FromBody]UserInRoleDto userRole)
        {
            var result = await _accountService.AddUserToRole(userRole);
            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }

    }
}
