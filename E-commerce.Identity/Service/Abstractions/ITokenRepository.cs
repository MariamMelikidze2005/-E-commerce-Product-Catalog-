using E_commerce.Identity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.Identity.Service.Abstractions
{
    public interface ITokenRepository
    {
        Task<RefreshToken?> GetRefreshTokenAsync(string token);

        Task DeleteRefreshTokenAsync(Guid id);

        Task AddRefreshTokenAsync(RefreshToken refreshToken);

        Task UpdateAsync(RefreshToken refreshToken);
    }
}
