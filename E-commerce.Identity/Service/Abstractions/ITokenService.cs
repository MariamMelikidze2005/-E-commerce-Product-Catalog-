using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_commerce.Identity.Models;

namespace E_commerce.Identity.Service.Abstractions
{
    public interface ITokenService
    {
        string GenerateAccessTokenFor(ApplicationUser user);

    }
}
