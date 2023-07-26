using AspNetCoreHero.Boilerplate.Domain.Entities.Catalog;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AspNetCoreHero.Boilerplate.Application.Interfaces.CacheRepositories
{
    public interface IDriverrCacheRepository
    {
        Task<List<Driver>> GetCachedListAsync();

        Task<Driver> GetByIdAsync(int VendorId);
    }
}