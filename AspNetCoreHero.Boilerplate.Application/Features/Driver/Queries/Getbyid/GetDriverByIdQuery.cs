using AspNetCoreHero.Boilerplate.Application.Interfaces.CacheRepositories;
using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AspNetCoreHero.Boilerplate.Application.Features.Vendors.Queries.GetById
{
    public class GetDriverByIdQuery : IRequest<Result<GetDriverByIdResponse>>
    {
        public int Id { get; set; }

        public class GetVendorByIdQueryHandler : IRequestHandler<GetDriverByIdQuery, Result<GetDriverByIdResponse>>
        {
            private readonly IDriverrCacheRepository _VendorCache;
            private readonly IMapper _mapper;

            public GetVendorByIdQueryHandler(IDriverrCacheRepository VendorCache, IMapper mapper)
            {
                _VendorCache = VendorCache;
                _mapper = mapper;
            }

            public async Task<Result<GetDriverByIdResponse>> Handle(GetDriverByIdQuery query, CancellationToken cancellationToken)
            {
                var Vendor = await _VendorCache.GetByIdAsync(query.Id);
                var mappedVendor = _mapper.Map<GetDriverByIdResponse>(Vendor);
                return Result<GetDriverByIdResponse>.Success(mappedVendor);
            }
        }
    }
}