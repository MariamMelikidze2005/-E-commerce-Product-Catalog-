using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.Identity.Service.Implementations
{

    public sealed class PasswordTokenProvider<TUser> : TotpSecurityStampBasedTokenProvider<TUser> where TUser : IdentityUser
    {
        public override Task<bool> CanGenerateTwoFactorTokenAsync(UserManager<TUser> manager, TUser user)
        {
            return Task.FromResult(!string.IsNullOrWhiteSpace(user.PasswordHash));
        }

        public override async Task<string> GetUserModifierAsync(
            string purpose,
            UserManager<TUser> manager,
            TUser user)
        {
            return "Password:" + purpose + ":" + await manager.GetUserIdAsync(user).ConfigureAwait(false);
        }
    }
}
