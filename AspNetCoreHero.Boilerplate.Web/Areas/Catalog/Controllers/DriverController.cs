using AspNetCoreHero.Boilerplate.Application.Features.Products.Queries.GetAllCached;
using AspNetCoreHero.Boilerplate.Domain.Entities.Catalog;
using AspNetCoreHero.Boilerplate.Web.Areas.Catalog.Models;
using AspNetCoreHero.Boilerplate.Web.Controllers;
using Microsoft.AspNetCore.Mvc;
using Nancy;
using Nancy.Json;
using Nancy.Session;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Org.BouncyCastle.Asn1.Crmf;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using System.Security.Principal;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace AspNetCoreHero.Boilerplate.Web.Areas.Catalog.Controllers
{
    [Area("Catalog")]
    public class DriverController : BaseController<DriverController>
    {
        public IActionResult Index()
        {
            var model = new DriverViewModel();
            return View(model);
        }
        public IActionResult LoadAll()
        {
            /* var response = await _mediator.Send(new GetAllProductsCachedQuery());
             if (response.Succeeded)
             {*/




            /*string Json = "[\r\n{\r\n    \"UserID\": 51468465,\r\n    \"Name\": \"Jane Cooper\",\r\n    \"Job\": \"TN21BA0445\",\r\n    \"MobileNumber\": \"9566251575\",\r\n      \"PreferedLOcation\":\"Chennai-Dehli\",\r\n     \"expertise\":\"Flatbeds\",\r\n      \"Rating\":4,\r\n       \"ActiveStatus\":\"Active\"\r\n\r\n},\r\n{\r\n    \"UserID\": 51468466,\r\n    \"Name\": \"Jane Cooper\",\r\n    \"Job\": \"TN21BA0445\",\r\n    \"MobileNumber\": \"9566251575\",\r\n      \"PreferedLOcation\":\"Chennai-Dehli\",\r\n     \"expertise\":\"Flatbeds\",\r\n      \"Rating\":4,\r\n       \"ActiveStatus\":\"Active\"\r\n},\r\n{\r\n    \"UserID\": 51468467,\r\n    \"Name\": \"Jane Cooper\",\r\n    \"Job\": \"TN21BA0445\",\r\n    \"MobileNumber\": \"9566251575\",\r\n      \"PreferedLOcation\":\"Chennai-Dehli\",\r\n     \"expertise\":\"Flatbeds\",\r\n      \"Rating\":4,\r\n       \"ActiveStatus\":\"Active\"\r\n},\r\n{\r\n    \"UserID\": 51468468,\r\n    \"Name\": \"Jane Cooper\",\r\n    \"Job\": \"TN21BA0445\",\r\n    \"MobileNumber\": \"9566251575\",\r\n      \"PreferedLOcation\":\"Chennai-Dehli\",\r\n     \"expertise\":\"Flatbeds\",\r\n      \"Rating\":4,\r\n       \"ActiveStatus\":\"Active\"\r\n},\r\n{\r\n    \"UserID\": 51468465,\r\n    \"Name\": \"Jane Cooper\",\r\n    \"Job\": \"TN21BA0445\",\r\n    \"MobileNumber\": \"9566251575\",\r\n      \"PreferedLOcation\":\"Chennai-Dehli\",\r\n     \"expertise\":\"Flatbeds\",\r\n      \"Rating\":4,\r\n       \"ActiveStatus\":\"Active\"\r\n\r\n},\r\n{\r\n    \"UserID\": 51468466,\r\n    \"Name\": \"Jane Cooper\",\r\n    \"Job\": \"TN21BA0445\",\r\n    \"MobileNumber\": \"9566251575\",\r\n      \"PreferedLOcation\":\"Chennai-Dehli\",\r\n     \"expertise\":\"Flatbeds\",\r\n      \"Rating\":4,\r\n       \"ActiveStatus\":\"Active\"\r\n},\r\n{\r\n    \"UserID\": 51468467,\r\n    \"Name\": \"Jane Cooper\",\r\n    \"Job\": \"TN21BA0445\",\r\n    \"MobileNumber\": \"9566251575\",\r\n      \"PreferedLOcation\":\"Chennai-Dehli\",\r\n     \"expertise\":\"Flatbeds\",\r\n      \"Rating\":5,\r\n       \"ActiveStatus\":\"Active\"\r\n},\r\n{\r\n    \"UserID\": 51468468,\r\n    \"Name\": \"Jane Cooper\",\r\n    \"Job\": \"TN21BA0445\",\r\n    \"MobileNumber\": \"9566251575\",\r\n      \"PreferedLOcation\":\"Chennai-Dehli\",\r\n     \"expertise\":\"Flatbeds\",\r\n      \"Rating\":5,\r\n       \"ActiveStatus\":\"Active\"\r\n}]";

            var viewModel = _mapper.Map<List<DriverViewModel>>(Json);
            return PartialView("_ViewAll", viewModel);
*/
            /*  var webClient = new WebClient();

              var options = new RestClientOptions("https://mocki.io/v1/840b4ee2-2865-4909-812e-b75e26a36ab4")
              {
                  MaxTimeout = -1,
              };
              var client = new RestClient(options);
              // Console.WriteLine("verify"+"/API/V1/8c62c9be-2623-11ee-addf-0200cd936042/SMS/VERIFY/" + session + "/" + otp);
              var request = new RestRequest("", Method.Get);

              RestResponse response =  client.Execute(request);
            */


            string Json = "[\r\n{\r\n    \"UserID\": 51468465,\r\n    \"Name\": \"Jane Cooper\",\r\n    \"Job\": \"TN21BA0445\",\r\n    \"MobileNumber\": \"9566251575\",\r\n      \"PreferedLOcation\":\"Chennai-Dehli\",\r\n     \"expertise\":\"Flatbeds\",\r\n      \"Rating\":3,\r\n       \"ActiveStatus\":\"Active\"\r\n},\r\n{\r\n    \"UserID\": 51468466,\r\n    \"Name\": \"Wade Warren\",\r\n    \"Job\": \"TN21BA0478\",\r\n    \"MobileNumber\": \"7766251575\",\r\n      \"PreferedLOcation\":\"Chennai-Gujarath\",\r\n     \"expertise\":\"Heavy hauler\",\r\n      \"Rating\":4,\r\n       \"ActiveStatus\":\"Active\"\r\n},\r\n{\r\n    \"UserID\": 51468467,\r\n    \"Name\": \"Esther Haward\",\r\n    \"Job\": \"NOT Assigned\",\r\n    \"MobileNumber\": \"7766251544\",\r\n      \"PreferedLOcation\":\"Delhi-Southindia\",\r\n     \"expertise\":\"Flatbeds\",\r\n      \"Rating\":3,\r\n       \"ActiveStatus\":\"Inactive\"\r\n\r\n},\r\n{\r\n    \"UserID\": 54407554,\r\n    \"Name\": \"carermon Wiliamson\",\r\n    \"Job\": \"TN21BA0445\",\r\n    \"MobileNumber\": \"9566251575\",\r\n      \"PreferedLOcation\":\"kerala-punjab\",\r\n     \"expertise\":\"Eicher 14 feet\",\r\n      \"Rating\":5,\r\n       \"ActiveStatus\":\"Active\"\r\n},\r\n{\r\n    \"UserID\": 12434679,\r\n    \"Name\": \"Brooklyn Simmons\",\r\n    \"Job\": \"NOT Assigned\",\r\n    \"MobileNumber\": \"9586251566\",\r\n      \"PreferedLOcation\":\"chennai-Telangna\",\r\n     \"expertise\":\"Container Truck\",\r\n      \"Rating\":3,\r\n       \"ActiveStatus\":\"Inactive\"\r\n},\r\n{\r\n    \"UserID\": 8451324,\r\n    \"Name\": \"Leslie Alexander\",\r\n    \"Job\": \"TN21BA0448\",\r\n    \"MobileNumber\": \"9984585421\",\r\n      \"PreferedLOcation\":\"odisha-delhi\",\r\n     \"expertise\":\"Container Truck\",\r\n      \"Rating\":3,\r\n       \"ActiveStatus\":\"Inactive\"\r\n},\r\n{\r\n    \"UserID\": 21342164,\r\n    \"Name\": \"Jenny Wilson\",\r\n    \"Job\": \"NOT Assigned\",\r\n    \"MobileNumber\": \"987458544\",\r\n      \"PreferedLOcation\":\"kerala-Assam\",\r\n     \"expertise\":\"Box Truck\",\r\n      \"Rating\":3,\r\n       \"ActiveStatus\":\"Active\"\r\n},\r\n{\r\n    \"UserID\": 04587545,\r\n    \"Name\": \"Guy hawkins\",\r\n    \"Job\": \"TN21BA0412\",\r\n    \"MobileNumber\": \"8566251544\",\r\n      \"PreferedLOcation\":\"Chennai-Haryana\",\r\n     \"expertise\":\"Flatbeds\",\r\n      \"Rating\":3,\r\n       \"ActiveStatus\":\"Active\"\r\n}\r\n]";
            JavaScriptSerializer ser = new JavaScriptSerializer();
            var viewModel = ser.Deserialize<List<DriverViewModel>>(Json);
            // var viewModel = JsonConvert.DeserializeObject<DriverViewModel>(response.Content);
            // var viewModel = JsonSerializer.Deserialize<DriverViewModel>(response.Content);
            return PartialView("_ViewAll", viewModel);


            /* }
             return null;*/
        }
        public IActionResult SendInvite()
        {
            var driverViewModel = new DriverViewModel();
            // return PartialView("_SendInvite", "");
            return new JsonResult(new { isValid = true, html =  _viewRenderer.RenderViewToStringAsync("_SendInvite", driverViewModel) });

        }
    }
}
