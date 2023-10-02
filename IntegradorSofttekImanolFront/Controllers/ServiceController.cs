using Data.Base;
using Data.DTO;
using Data.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IntegradorSofttekImanolFront.Controllers
{
    [Authorize]
    /// <summary>
    /// Represents a controller for managing services.
    /// </summary>
    public class ServiceController : Controller
    {
        private readonly IHttpClientFactory _httpClient;

        /// <summary>
        /// Initializes a new instance of the ServiceController class.
        /// </summary>
        /// <param name="httpClient">IHttpClientFactory</param>
        public ServiceController(IHttpClientFactory httpClient)
        {
            _httpClient = httpClient;
        }

        /// <summary>
        /// Displays the service index view.
        /// </summary>
        /// <returns>The service index view.</returns>
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Deletes a service with the specified code.
        /// </summary>
        /// <param name="codService">The code of the service to delete.</param>
        /// <returns>Redirects to the service index.</returns>
        public IActionResult DeleteService(int codService)
        {
            var token = HttpContext.Session.GetString("Token");
            var baseApi = new BaseApi(_httpClient);

            var usuarios = baseApi.DeleteToApi($"service/{codService}", new { codService = codService }, token);

            return RedirectToAction("Index");
        }

        /// <summary>
        /// Displays a partial view for adding or updating a service.
        /// </summary>
        /// <param name="service">The service to add or update.</param>
        /// <returns>A partial view for adding or updating a service.</returns>
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

        /// <summary>
        /// Updates a service with the specified details.
        /// </summary>
        /// <param name="service">The service details to update.</param>
        /// <returns>Redirects to the service index.</returns>
        public IActionResult UpdateService(ServiceDto service)
        {
            var token = HttpContext.Session.GetString("Token");
            var baseApi = new BaseApi(_httpClient);

            var services = baseApi.PutToApi($"service/{service.CodService}", service, token);

            return RedirectToAction("Index");
        }

        /// <summary>
        /// Creates a new service with the specified details.
        /// </summary>
        /// <param name="service">The service details to create.</param>
        /// <returns>Redirects to the service index.</returns>
        public IActionResult CreateService(ServiceDto service)
        {
            var token = HttpContext.Session.GetString("Token");
            var baseApi = new BaseApi(_httpClient);
            var services = baseApi.PostToApi("service/register", service, token);

            return RedirectToAction("Index");
        }
    }
}
