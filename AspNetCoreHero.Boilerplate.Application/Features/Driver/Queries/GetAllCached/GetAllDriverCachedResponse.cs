using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCoreHero.Boilerplate.Application.Features.Vendors.Queries.GetAllCached
{
    public class GetAllDriverCachedResponse
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Age { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public decimal Pincode{ get; set; }
    }
}
