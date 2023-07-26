using AspNetCoreHero.Boilerplate.Application.Features.Products.Queries.GetById;
using AspNetCoreHero.Boilerplate.Application.Features.Vendors.Commands.Create;
using AspNetCoreHero.Boilerplate.Application.Features.Vendors.Commands.Update;
using AspNetCoreHero.Boilerplate.Application.Features.Vendors.Queries.GetAllCached;
using AspNetCoreHero.Boilerplate.Web.Areas.Catalog.Models;
using AutoMapper;

namespace AspNetCoreHero.Boilerplate.Web.Areas.Catalog.Mappings
{
    public class VendorProfile : Profile
    {
        public VendorProfile()
        {
            CreateMap<GetAllDriverCachedResponse, DriverViewModel>().ReverseMap();
            CreateMap<GetProductsByIdResponse, DriverViewModel>().ReverseMap();
            CreateMap<CreateDriverCommand, DriverViewModel>().ReverseMap();
            CreateMap<UpdateDriverCommand, DriverViewModel>().ReverseMap();
        }
    }
}
