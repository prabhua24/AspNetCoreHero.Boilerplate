
using AspNetCoreHero.Boilerplate.Application.Interfaces.CacheRepositories;
using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;

using System.Threading;
using System.Threading.Tasks;

namespace AspNetCoreHero.Boilerplate.Application.Features.Vendors.Queries.GetAllCached
{
    public class GetAllDriverCachedQuery : IRequest<Result<List<GetAllDriverCachedResponse>>>
    {
        public GetAllDriverCachedQuery()
        {
        }
    }

    public class GetAllVendorCachedQueryHandler : IRequestHandler<GetAllDriverCachedQuery, Result<List<GetAllDriverCachedResponse>>>
    {
        private readonly IDriverrCacheRepository _vendorCache;
        private readonly IMapper _mapper;

        public GetAllVendorCachedQueryHandler(IDriverrCacheRepository vendorCache, IMapper mapper)
        {
            _vendorCache = vendorCache;
            _mapper = mapper;
        }

        public async Task<Result<List<GetAllDriverCachedResponse>>> Handle(GetAllDriverCachedQuery request, CancellationToken cancellationToken)
        {
            var vendorList = await _vendorCache.GetCachedListAsync();
            var mappedvendor = _mapper.Map<List<GetAllDriverCachedResponse>>(vendorList);
            return Result<List<GetAllDriverCachedResponse>>.Success(mappedvendor);
        }
    }
}
