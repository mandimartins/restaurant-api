using Microsoft.AspNetCore.Identity;
using Restaurant.Data.ViewModel;

namespace Restaurant.Services.Interfaces
{
    public interface IAuthService
    {
        Task<bool> SignUpAsync(AuthViewModel signUp);

        Task<UserInfoViewModel> SignInAsync(AuthViewModel signIn);
    }
}
