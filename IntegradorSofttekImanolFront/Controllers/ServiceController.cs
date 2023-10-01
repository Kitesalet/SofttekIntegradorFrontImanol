using Data.Base;
using Data.DTO;
using Data.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IntegradorSofttekImanolFront.Controllers
{
    [Authorize]
    public class ServiceController : Controller
    {

        private readonly IHttpClientFactory _httpClient;

        public ServiceController(IHttpClientFactory httpClient)
        {
            _httpClient = httpClient;
        }

        public IActionResult Index()
        {

            return View();
        }

        public IActionResult DeleteService(int codService)
        {
            var token = HttpContext.Session.GetString("Token");
            var baseApi = new BaseApi(_httpClient);

            var usuarios = baseApi.DeleteToApi($"service/{codService}", new { codService = codService }, token);

            return RedirectToAction("Index");
        }

        public IActionResult ServiceAddPartial(ServiceDto service)
        {
            if (service.CodService != 0)
            {

                var serviceUpdate = new ServiceViewModel()
                {
                    CodService = service.CodService,
                    Descr = service.Descr,
                    HourValue = service.HourValue,
                    State = service.State
                };

                return PartialView("~/Views/Service/Partial/ServiceAddPartial.cshtml", serviceUpdate);
            }
            else
            {
                var model = new ServiceViewModel();
                return PartialView("~/Views/Service/Partial/ServiceAddPartial.cshtml", model);
            }



        }

        public IActionResult UpdateService(ServiceDto service)
        {
            var token = HttpContext.Session.GetString("Token");
            var baseApi = new BaseApi(_httpClient);

            var services = baseApi.PutToApi($"service/{service.CodService}", service, token);

            return RedirectToAction("Index");
        }

        public IActionResult CreateProject(ServiceDto service)
        {
            var token = HttpContext.Session.GetString("Token");
            var baseApi = new BaseApi(_httpClient);
            var services = baseApi.PostToApi("service/register", service, token);

            return RedirectToAction("Index");
        }

    }
}
