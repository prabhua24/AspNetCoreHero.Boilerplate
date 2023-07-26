
using AspNetCoreHero.Boilerplate.Application.Interfaces.Repositories;
using AspNetCoreHero.Boilerplate.Domain.Entities.Catalog;
using AspNetCoreHero.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AspNetCoreHero.Boilerplate.Application.Extensions;

namespace AspNetCoreHero.Boilerplate.Application.Features.Vendors.Queries.GetAllpaged
{
    public class GetAllVendorQuery : IRequest<PaginatedResult<GetAllDriverResponse>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public GetAllVendorQuery(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
    }
    
    public class GGetAllVendorQueryHandler : IRequestHandler<GetAllVendorQuery, PaginatedResult<GetAllDriverResponse>>
    {
        private readonly IDriverRepository _repository;

        public GGetAllVendorQueryHandler(IDriverRepository repository)
        {
            _repository = repository;
        }

        public async Task<PaginatedResult<GetAllDriverResponse>> Handle(GetAllVendorQuery request, CancellationToken cancellationToken)
        {
            Expression<Func<Driver, GetAllDriverResponse>> expression = e => new GetAllDriverResponse
            {
                Id = e.Id,
                Name = e.Name,
                Age = e.Age,
                CompanyName = e.CompanyName,
                Address = e.Address
            };
            var paginatedList = await _repository.Vendors
                .Select(expression)
                .ToPaginatedListAsync(request.PageNumber, request.PageSize);
            return paginatedList;
        }
    }
}
