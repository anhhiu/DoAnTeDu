using DoAnTedu.Common;
using DoAnTedu.Data;
using DoAnTedu.Dtos.Acccounts;
using DoAnTedu.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;

namespace DoAnTedu.Services
{
    public class AccountService : IAccountService
    {
        private readonly SignInManager<User> signInManager;
        private readonly IConfiguration configuration;
        private readonly UserManager<User> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public AccountService(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, SignInManager<User> signInManager, IConfiguration configuration)
        {
            this.signInManager = signInManager;
            this.configuration = configuration;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        public async Task<IdentityResult?> Register(Register model)
        {
            var use = new User
            {
                UserName = model.UserName,
                Email = model.Email,
                FullName = model.FullName,
            };

            var result = await userManager.CreateAsync(use, model.Password!);

            if (result.Succeeded)
            {
                var role = model.Role ?? AppRole.Employee;


                if (!await roleManager.RoleExistsAsync(role))
                {

                    await roleManager.CreateAsync(new IdentityRole(role));
                }

                await userManager.AddToRoleAsync(use, role);

                return result;
            }

            return null;
        }

        public async Task<string> Login(Login model)
        {
            var user = await userManager.FindByNameAsync(model.UserName!);
            var passwordValid = await userManager.CheckPasswordAsync(user!, model.Password!);

            if (user == null || !passwordValid)
            {
                return string.Empty;
            }

            var authClaim = new List<Claim>
            {
                new Claim(ClaimTypes.Name, model.UserName!),
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var userRoler = await userManager.GetRolesAsync(user);

            foreach (var role in userRoler)
            {
                authClaim.Add(new Claim(ClaimTypes.Role, role.ToString()));
            }
            var skey = configuration["JWT:Secret"];
            var newKeys = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(skey!));

            var token = new JwtSecurityToken(
                issuer: configuration["JWT:ValidIssuer"],
                audience: configuration["JWT:ValidAudience"],
                expires: DateTime.UtcNow.AddMinutes(20),
                claims: authClaim,
                signingCredentials: new SigningCredentials(newKeys, SecurityAlgorithms.HmacSha256Signature)
                );
            var tokenStr = new JwtSecurityTokenHandler().WriteToken(token);
            return tokenStr;
        }

        public async Task<ResponseService<dynamic>> GetUser()
        {
            var response = new ResponseService<dynamic>();

            // Lấy tất cả người dùng
            var users = await userManager.Users.AsNoTracking().ToListAsync();

            var userDtos = new List<UserDto>();

            foreach (var p in users)
            {
                // Lấy các vai trò của người dùng
                var roles = await userManager.GetRolesAsync(p);

                // Tạo đối tượng UserDto với thông tin người dùng và vai trò
                userDtos.Add(new UserDto
                {
                    UserName = p.UserName,
                    Email = p.Email,
                    Phone = p.PhoneNumber,
                    FullName = p.FullName,
                    Role = string.Join(", ", roles) // Vai trò có thể là một danh sách, kết hợp thành chuỗi
                });
            }

            response.Data = userDtos;
            response.Statuscode = (int)HttpStatusCode.OK;
            response.Message = "ok";

            return response;
        }

    }
}
