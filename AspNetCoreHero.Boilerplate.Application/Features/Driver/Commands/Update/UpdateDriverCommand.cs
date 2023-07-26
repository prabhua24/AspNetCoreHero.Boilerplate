using AspNetCoreHero.Boilerplate.Application.Features.Products.Commands.Update;
using AspNetCoreHero.Boilerplate.Application.Interfaces.Repositories;
using AspNetCoreHero.Boilerplate.Domain.Entities.Catalog;
using AspNetCoreHero.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AspNetCoreHero.Boilerplate.Application.Features.Vendors.Commands.Update
{
    public class UpdateDriverCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Age { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public int Pincode { get; set; }
    }
    public class UpdateVendorCommandHandler : IRequestHandler<UpdateDriverCommand, Result<int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDriverRepository _VendorRepository;

        public UpdateVendorCommandHandler(IDriverRepository VendorRepository, IUnitOfWork unitOfWork)
        {
            _VendorRepository = VendorRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<int>> Handle(UpdateDriverCommand command, CancellationToken cancellationToken)
        {
            var Vendor = await _VendorRepository.GetByIdAsync(command.Id);

            if (Vendor == null)
            {
                return Result<int>.Fail($"Vendor Not Found.");
            }
            else
            {
                Vendor.Name = command.Name ?? Vendor.Name;
                Vendor.Age = command.Age ?? Vendor.Age;
                Vendor.CompanyName = command.CompanyName ?? Vendor.CompanyName;
                Vendor.Address = command.Address ?? Vendor.Address;
                if ((command.Pincode == 0))
                {
                    Vendor.Pincode = Vendor.Pincode;
                }
                else
                {
                    Vendor.Pincode = 0 ;
                }
                await _VendorRepository.UpdateAsync(Vendor);
                await _unitOfWork.Commit(cancellationToken);
                return Result<int>.Success(Vendor.Id);
            }
        }
    }
}
