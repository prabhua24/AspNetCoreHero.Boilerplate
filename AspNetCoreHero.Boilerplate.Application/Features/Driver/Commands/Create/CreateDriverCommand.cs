using AspNetCoreHero.Boilerplate.Application.Features.Vendors.Commands.Create;
using AspNetCoreHero.Boilerplate.Application.Interfaces.Repositories;
using AspNetCoreHero.Boilerplate.Domain.Entities.Catalog;
using AspNetCoreHero.Results;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AspNetCoreHero.Boilerplate.Application.Features.Vendors.Commands.Create
{
    public class CreateDriverCommand : IRequest<Result<int>>
    {
        public string Name { get; set; }
        public string Age{ get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public string Pincode { get; set; }
    }
    public class CreateVendorCommandHandler : IRequestHandler<CreateDriverCommand, Result<int>>
    {
        private readonly IDriverRepository _vendorRepository;
        private readonly IMapper _mapper;

        private IUnitOfWork _unitOfWork { get; set; }

        public CreateVendorCommandHandler(IDriverRepository vendorRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _vendorRepository = vendorRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<int>> Handle(CreateDriverCommand request, CancellationToken cancellationToken)
        {
            var product = _mapper.Map<Driver>(request);
            await _vendorRepository.InsertAsync(product);
            await _unitOfWork.Commit(cancellationToken);
            return Result<int>.Success(product.Id);
        }
    }
}
