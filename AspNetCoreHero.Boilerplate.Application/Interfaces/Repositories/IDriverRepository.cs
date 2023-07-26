using AspNetCoreHero.Boilerplate.Domain.Entities.Catalog;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreHero.Boilerplate.Application.Interfaces.Repositories
{
    public interface IDriverRepository
    {
        IQueryable<Driver> Vendors { get; }

        Task<List<Driver>> GetListAsync();

        Task<Driver> GetByIdAsync(int vendorId);

        Task<int> InsertAsync(Driver vendor);

        Task UpdateAsync(Driver vendor);

        Task DeleteAsync(Driver vendor);
    }
}