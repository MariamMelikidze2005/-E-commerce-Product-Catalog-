using E_commerce.Identity.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.Identity.Service.Abstractions
{
    public interface IIdentityService
    {
        Task<LoginResponse> AuthenticateAsync(LoginRequest request);

        Task<LoginResponse?> RegisterAsync(RegisterRequest request);

        Task ConfirmEmailAsync(ConfirmEmailRequest request);

        Task<LoginResponse> ChangePasswordAsync(ChangePasswordRequest request);

        Task ResetPasswordAsync(ResetPasswordRequest request);

        Task<LoginResponse> NewPasswordAsync(NewPasswordRequest request);
    }

    public sealed class LoginRequest
    {
        public required string Email { get; set; }
        public required string Password { get; set; }
    }
    public sealed class RegisterRequest
    {
        public required string Email { get; set; }
        public required string Password { get; set; }
    }

    public sealed class ConfirmEmailRequest
    {
        public required string Email { get; set; }
        public required string Otp { get; set; }
    }
    public sealed class ChangePasswordRequest
    {
        public required string Email { get; set; }
        public required string CurrentPassword { get; set; }
        public required string NewPassword { get; set; }
    }
    public sealed class ResetPasswordRequest
    {
        public required string Email { get; set; }
    }
    public sealed class NewPasswordRequest
    {
        public required string Email { get; set; }
        public required string NewPassword { get; set; }
        public required string Otp { get; set; }
    }
    public sealed class RefreshTokenRequest
    {
        public required string RefreshToken { get; set; }
    }
}
