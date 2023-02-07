using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using WebApplication8.Models;

namespace WebApplication8.Repositry
{
    public interface IAccountRepostry
    {
        Task<IdentityResult> CreateUserAsync(SignIn userModel);
        Task<SignInResult> PasswordSignInAsync(Login login);
        Task SignOutAsync();
        Task<IdentityResult> ChangePassword(ChangePassword changePassword);
        Task<IdentityResult> EmailConfirmAsync(string id, string token);
    }
}