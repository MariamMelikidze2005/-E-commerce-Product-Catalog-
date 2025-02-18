using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_commerce.Identity.Models;

namespace E_commerce.Identity.Services.Abstractions
{
    public interface ITokenService
    {
        string GenerateAccessToken(ApplicationUser user);
    }
}
