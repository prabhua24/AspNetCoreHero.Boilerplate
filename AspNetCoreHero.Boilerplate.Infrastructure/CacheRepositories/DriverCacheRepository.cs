using AspNetCoreHero.Boilerplate.Application.Interfaces.CacheRepositories;
using AspNetCoreHero.Boilerplate.Application.Interfaces.Repositories;
using AspNetCoreHero.Boilerplate.Domain.Entities.Catalog;
using AspNetCoreHero.Boilerplate.Infrastructure.CacheKeys;
using AspNetCoreHero.Extensions.Caching;
using AspNetCoreHero.ThrowR;
using Microsoft.Extensions.Caching.Distributed;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AspNetCoreHero.Boilerplate.Infrastructure.CacheRepositories
{
    public class DriverCacheRepository : IDriverrCacheRepository
    {
        private readonly IDistributedCache _distributedCache;
        private readonly IDriverRepository _VendorRepository;

        public DriverCacheRepository(IDistributedCache distributedCache, IDriverRepository VendorRepository)
        {
            _distributedCache = distributedCache;
            _VendorRepository = VendorRepository;
        }

        public async Task<Driver> GetByIdAsync(int VendorId)
        {
            string cacheKey = DriverCacheKeys.GetKey(VendorId);
            var Vendor = await _distributedCache.GetAsync<Driver>(cacheKey);
            if (Vendor == null)
            {
                Vendor = await _VendorRepository.GetByIdAsync(VendorId);
                Throw.Exception.IfNull(Vendor, "Vendor", "No Vendor Found");
                await _distributedCache.SetAsync(cacheKey, Vendor);
            }
            return Vendor;
        }

        public async Task<List<Driver>> GetCachedListAsync()
        {
            string cacheKey = DriverCacheKeys.ListKey;
            var VendorList = await _distributedCache.GetAsync<List<Driver>>(cacheKey);
            if (VendorList == null)
            {
                VendorList = await _VendorRepository.GetListAsync();
                await _distributedCache.SetAsync(cacheKey, VendorList);
            }
            return VendorList;
        }
    }
}