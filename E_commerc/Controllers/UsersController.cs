﻿using E_commerce.Identity.Responses;
using E_commerce.Identity.Service.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_commerc.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IIdentityService _identityService;
        private readonly ITokenService _tokenService;

        public UsersController(IIdentityService identityService, ITokenService tokenService)
        {
            _identityService = identityService;
            _tokenService = tokenService;
        }

        [HttpPost("authenticate")]
        public async Task<ActionResult<LoginResponse>> AuthenticateAsync([FromBody] LoginRequest request)
        {
            return Ok(await _identityService.AuthenticateAsync(request));
        }

        [HttpPost("register")]
        public async Task<ActionResult<LoginResponse?>> RegisterAsync([FromBody] RegisterRequest request)
        {
            return Ok(await _identityService.RegisterAsync(request));
        }

        [HttpPost("confirm-email")]
        public async Task<ActionResult> ConfirmEmail([FromBody] ConfirmEmailRequest request)
        {
            await _identityService.ConfirmEmailAsync(request);
            return Ok();
        }

        [HttpPost("change-password")]
        public async Task<ActionResult<LoginResponse>> ChangePasswordAsync([FromBody] ChangePasswordRequest request)
        {
            return Ok(await _identityService.ChangePasswordAsync(request));
        }

        [HttpPost("reset-password")]
        public async Task<ActionResult> ResetPasswordAsync([FromBody] ResetPasswordRequest request)
        {
            await _identityService.ResetPasswordAsync(request);
            return Ok();
        }

        [HttpPost("new-password")]
        public async Task<ActionResult<LoginResponse>> NewPasswordAsync([FromBody] NewPasswordRequest request)
        {
            return Ok(await _identityService.NewPasswordAsync(request));
        }

        [HttpPost("refresh-token")]
        public async Task<ActionResult<LoginResponse>> RefreshTokenAsync([FromBody] RefreshTokenRequest request)
        {
            return Ok(await _tokenService.RefreshTokenAsync(request.RefreshToken));
        }
    }
}