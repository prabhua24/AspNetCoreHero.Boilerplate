
using AspNetCoreHero.Boilerplate.Application.Interfaces.Repositories;
using AspNetCoreHero.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AspNetCoreHero.Boilerplate.Application.Features.Vendors.Commands.Delete
{
    public class DeleteDriverCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }

        public class DeleteVendorCommandHandler : IRequestHandler<DeleteDriverCommand, Result<int>>
        {
            private readonly IDriverRepository _VendorRepository;
            private readonly IUnitOfWork _unitOfWork;

            public DeleteVendorCommandHandler(IDriverRepository VendorRepository, IUnitOfWork unitOfWork)
            {
                _VendorRepository = VendorRepository;
                _unitOfWork = unitOfWork;
            }

            public async Task<Result<int>> Handle(DeleteDriverCommand command, CancellationToken cancellationToken)
            {
                var vendor = await _VendorRepository.GetByIdAsync(command.Id);
                await _VendorRepository.DeleteAsync(vendor);
                await _unitOfWork.Commit(cancellationToken);
                return Result<int>.Success(vendor.Id);
            }
        }
    }
}
