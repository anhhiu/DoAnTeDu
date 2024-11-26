using DoAnTedu.Common;
using DoAnTedu.Dtos.Acccounts;
using Microsoft.AspNetCore.Identity;

namespace DoAnTedu.Interfaces
{
    public interface IAccountService
    {
        Task<string> Login(Login model);
        Task<IdentityResult?> Register(Register model);
        Task<ResponseService<dynamic>> GetUser();
    }
}

