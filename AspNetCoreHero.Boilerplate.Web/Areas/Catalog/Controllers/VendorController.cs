using AspNetCoreHero.Boilerplate.Application.Constants;
using AspNetCoreHero.Boilerplate.Application.Features.Vendors.Queries.GetAllCached;
using AspNetCoreHero.Boilerplate.Application.Features.Vendors.Commands.Create;
using AspNetCoreHero.Boilerplate.Domain.Entities.Catalog;
using AspNetCoreHero.Boilerplate.Web.Abstractions;
using AspNetCoreHero.Boilerplate.Web.Areas.Catalog.Models;
using AspNetCoreHero.Boilerplate.Web.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreHero.Boilerplate.Application.Features.Vendors.Commands.Update;
using AspNetCoreHero.Boilerplate.Application.Features.Vendors.Queries.GetAllpaged;
using AspNetCoreHero.Boilerplate.Application.Features.Vendors.Commands.Delete;

namespace AspNetCoreHero.Boilerplate.Web.Areas.Catalog.Controllers
{
    [Area("Catalog")]
    public class VendorController : BaseController<VendorController>
    {
        public IActionResult Index()
        {
            var model = new DriverViewModel();
            return View(model);
        }

        public async Task<IActionResult> LoadAll()
        {
            var response = await _mediator.Send(new GetAllDriverCachedQuery());
            if (response.Succeeded)
            {
                var viewModel = _mapper.Map<List<DriverViewModel>>(response.Data);
                return PartialView("_ViewAll", viewModel);
            }
            return null;
        }

        [Authorize(Policy = Permissions.Users.View)]
        public async Task<JsonResult> OnGetCreateOrEdit(int id = 0)
        {
             var vendorResponse = await _mediator.Send(new GetAllDriverCachedQuery());

            if (id == 0)
            {
                var vendorViewModel = new DriverViewModel();

                return new JsonResult(new { isValid = true, html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEdit", vendorViewModel) });
            }
            
            else
            {
                var vendorresponse = await _mediator.Send(new GetBrandsByIdQuery() { Id = id });
                if (vendorResponse.Succeeded)
                {
                    var vendorViewModel = _mapper.Map<DriverViewModel>(vendorResponse.Data);
                   
                    return new JsonResult(new { isValid = true, html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEdit", vendorViewModel) });
                }
                return null;
            }
           /* return null;*/
        }

        [HttpPost]
        public async Task<JsonResult> OnPostCreateOrEdit(int id, DriverViewModel vendor)
        {
            if (ModelState.IsValid)
            {
                if (id == 0)
                {
                   // var CreateVendorCommand = _mapper.Map<>(vendor);
                    var CreateVendorCommand = _mapper.Map<CreateDriverCommand>(vendor);
                    var result = await _mediator.Send(CreateVendorCommand);
                    if (result.Succeeded)
                    {
                        id = result.Data;
                        _notify.Success($"Vendor with ID {result.Data} Created.");
                    }
                    else _notify.Error(result.Message);
                }
                else
                {
                    var updateVendorCommand = _mapper.Map<UpdateDriverCommand>(vendor);
                    var result = await _mediator.Send(updateVendorCommand);
                    if (result.Succeeded) _notify.Information($"Vendor with ID {result.Data} Updated.");
                }

                var response = await _mediator.Send(new GetAllDriverCachedQuery());
                if (response.Succeeded)
                {
                    var viewModel = _mapper.Map<List<DriverViewModel>>(response.Data);
                    var html = await _viewRenderer.RenderViewToStringAsync("_ViewAll", viewModel);
                    return new JsonResult(new { isValid = true, html = html });
                }
                else
                {
                    _notify.Error(response.Message);
                    return null;
                }
            }
            else
            {
                var html = await _viewRenderer.RenderViewToStringAsync("_CreateOrEdit", vendor);
                return new JsonResult(new { isValid = false, html = html });
            }
            //return null;
        }

        [HttpPost]
        public async Task<JsonResult> OnPostDelete(int id)
        {
            var deleteCommand = await _mediator.Send(new DeleteDriverCommand { Id = id });
            if (deleteCommand.Succeeded)
            {
                _notify.Information($"Product with Id {id} Deleted.");
                var response = await _mediator.Send(new GetAllDriverCachedQuery());
                if (response.Succeeded)
                {
                    var viewModel = _mapper.Map<List<DriverViewModel>>(response.Data);
                    var html = await _viewRenderer.RenderViewToStringAsync("_ViewAll", viewModel);
                    return new JsonResult(new { isValid = true, html = html });
                }
                else
                {
                    _notify.Error(response.Message);
                    return null;
                }
            }
            else
            {
                _notify.Error(deleteCommand.Message);
                return null;
            }
       /*     return null;*/
        }
       

    }
}
