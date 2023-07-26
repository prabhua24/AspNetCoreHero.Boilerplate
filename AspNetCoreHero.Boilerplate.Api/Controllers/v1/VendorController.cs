using AspNetCoreHero.Boilerplate.API.Controllers;
using AspNetCoreHero.Boilerplate.Application.Features.Vendors.Commands.Create;
using AspNetCoreHero.Boilerplate.Application.Features.Vendors.Commands.Delete;
using AspNetCoreHero.Boilerplate.Application.Features.Vendors.Commands.Update;
using AspNetCoreHero.Boilerplate.Application.Features.Vendors.Queries.GetAllpaged;

using AspNetCoreHero.Boilerplate.Application.Features.Vendors.Queries.GetById;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AspNetCoreHero.Boilerplate.Api.Controllers.v1
{
    public class VendorController : BaseApiController<VendorController>
    {
        [HttpGet]
        public async Task<IActionResult> GetAll(int pageNumber, int pageSize)
        {
            var Vendors = await _mediator.Send(new GetAllVendorQuery(pageNumber, pageSize));
            return Ok(Vendors);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var Vendor = await _mediator.Send(new GetDriverByIdQuery() { Id = id });
            return Ok(Vendor);
        }

        // POST api/<controller>
        [HttpPost]
        public async Task<IActionResult> Post(CreateDriverCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateDriverCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }
            return Ok(await _mediator.Send(command));
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _mediator.Send(new DeleteDriverCommand { Id = id }));
        }
    }
}