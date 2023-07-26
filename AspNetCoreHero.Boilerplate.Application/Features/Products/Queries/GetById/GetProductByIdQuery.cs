using AspNetCoreHero.Boilerplate.Application.Interfaces.CacheRepositories;
using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AspNetCoreHero.Boilerplate.Application.Features.Products.Queries.GetById
{
    public class GetVendorByIdQuery : IRequest<Result<GetProductsByIdResponse>>
    {
        public int Id { get; set; }

        public class GetProductByIdQueryHandler : IRequestHandler<GetVendorByIdQuery, Result<GetProductsByIdResponse>>
        {
            private readonly IProductCacheRepository _productCache;
            private readonly IMapper _mapper;

            public GetProductByIdQueryHandler(IProductCacheRepository productCache, IMapper mapper)
            {
                _productCache = productCache;
                _mapper = mapper;
            }

            public async Task<Result<GetProductsByIdResponse>> Handle(GetVendorByIdQuery query, CancellationToken cancellationToken)
            {
                var product = await _productCache.GetByIdAsync(query.Id);
                var mappedProduct = _mapper.Map<GetProductsByIdResponse>(product);
                return Result<GetProductsByIdResponse>.Success(mappedProduct); 
            }
        }
    }
}