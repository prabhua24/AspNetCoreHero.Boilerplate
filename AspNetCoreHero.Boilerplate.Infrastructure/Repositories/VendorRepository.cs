using AspNetCoreHero.Boilerplate.Application.Interfaces.Repositories;
using AspNetCoreHero.Boilerplate.Domain.Entities.Catalog;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreHero.Boilerplate.Infrastructure.Repositories
{
    public class VendorRepository : IDriverRepository
    {
        private readonly IRepositoryAsync<Driver> _repository;
        private readonly IDistributedCache _distributedCache;

        public VendorRepository(IDistributedCache distributedCache, IRepositoryAsync<Driver> repository)
        {
            _distributedCache = distributedCache;
            _repository = repository;
        }

        public IQueryable<Driver> Vendors => _repository.Entities;

        public async Task DeleteAsync(Driver Vendor)
        {
            await _repository.DeleteAsync(Vendor);
            await _distributedCache.RemoveAsync(CacheKeys.DriverCacheKeys.ListKey);
            await _distributedCache.RemoveAsync(CacheKeys.DriverCacheKeys.GetKey(Vendor.Id));
        }

        public async Task<Driver> GetByIdAsync(int VendorId)
        {
            return await _repository.Entities.Where(p => p.Id == VendorId).FirstOrDefaultAsync();
        }

        public async Task<List<Driver>> GetListAsync()
        {
            return await _repository.Entities.ToListAsync();
        }

        public async Task<int> InsertAsync(Driver vendor)
        {
            await _repository.AddAsync(vendor);
            await _distributedCache.RemoveAsync(CacheKeys.DriverCacheKeys.ListKey);
            return vendor.Id;
        }

        public async Task UpdateAsync(Driver Vendor)
        {
            await _repository.UpdateAsync(Vendor);
            await _distributedCache.RemoveAsync(CacheKeys.DriverCacheKeys.ListKey);
            await _distributedCache.RemoveAsync(CacheKeys.DriverCacheKeys.GetKey(Vendor.Id));
        }
    }
}