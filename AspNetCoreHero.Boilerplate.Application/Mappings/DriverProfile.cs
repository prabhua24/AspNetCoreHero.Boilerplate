using AspNetCoreHero.Boilerplate.Application.Features.Products.Queries.GetById;
using AspNetCoreHero.Boilerplate.Application.Features.Vendors.Commands.Create;
using AspNetCoreHero.Boilerplate.Application.Features.Vendors.Queries.GetAllCached;
using AspNetCoreHero.Boilerplate.Application.Features.Vendors.Queries.GetAllpaged;
using AspNetCoreHero.Boilerplate.Domain.Entities.Catalog;
using AutoMapper;

namespace AspNetCoreHero.Boilerplate.Application.Mappings
{
    internal class DriverProfile : Profile
    {
        public DriverProfile()
        {
            CreateMap<CreateDriverCommand, Driver>().ReverseMap();
            CreateMap<GetProductsByIdResponse, Driver>().ReverseMap();
            CreateMap<GetAllDriverCachedResponse, Driver>().ReverseMap();
            CreateMap<GetAllDriverResponse, Driver>().ReverseMap();
        }
    }
}