
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Uzaktan.Core.Domain.Dto.Identity;
using Uzaktan.Core.Service;
using Uzaktan.Core.Utilities.Results;

namespace Uzaktan.Services
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IConfiguration _config;

        public AccountService(
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager,
            SignInManager<IdentityUser> signInManager,
            IConfiguration config)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _config = config;
        }

        public async Task<IResult> AddRole(RoleDto role)
        {
            var result=await _roleManager.CreateAsync(new IdentityRole
            {
                Name=role.RoleName,
                NormalizedName=role.Description
            });
            if (result.Succeeded)
                return new Result(true, "");
            else
                return new Result(false, "");
        }

        public async Task<IResult> AddUser(UserDto user)
        {
            var result = await _userManager.CreateAsync(new IdentityUser
            {
                Email = user.Email,
                UserName = user.Username
            }, user.Password);
            if (result.Succeeded)
                return new Result(true, "");
            else
                return new Result(false, "");
        }

        public async Task<IResult> AddUserToRole(UserInRoleDto userInRole)
        {
            var user=await _userManager.FindByEmailAsync(userInRole.Email);
            var result=await _userManager.AddToRolesAsync(user, userInRole.Roles);

            if (result.Succeeded)
                return new Result(true, "");
            else
                return new Result(false, "");
        }


        public async Task<IResult> SignIn(LoginDto login)
        {
            var user = await _userManager.FindByEmailAsync(login.Email);
            var roles = string.Join(',', await _userManager.GetRolesAsync(user));
            var result = await _signInManager.PasswordSignInAsync(user, login.Password, true, false);
            if (result.Succeeded)
            {
                return new DataResult<string>(true, "", GenerateJSONWebToken(roles));
            }                
            else
                return new DataResult<string>(false, "","");
        }

        private string GenerateJSONWebToken(string roles)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Issuer"],
              new Claim[]{
                    new Claim(ClaimTypes.Role,roles)
              },
              expires: DateTime.Now.AddMinutes(10),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}
