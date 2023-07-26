using MediatR;

namespace AspNetCoreHero.Boilerplate.Web.Areas.Catalog.Controllers
{
    internal class GetBrandsByIdQuery : IRequest<object>
    {
        public int Id { get; set; }
    }
}