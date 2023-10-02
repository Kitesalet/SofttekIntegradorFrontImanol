using Data.Base;
using Data.DTO;
using Data.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IntegradorSofttekImanolFront.Controllers
{
    [Authorize]
    /// <summary>
    /// Represents a controller for managing work-related tasks.
    /// </summary>
    public class WorkController : Controller
    {
        private readonly IHttpClientFactory _httpClient;

        /// <summary>
        /// Initializes a new instance of the WorkController class.
        /// </summary>
        /// <param name="httpClient">IHttpClientFactory</param>
        public WorkController(IHttpClientFactory httpClient)
        {
            _httpClient = httpClient;
        }

        /// <summary>
        /// Displays the work index view.
        /// </summary>
        /// <returns>The work index view.</returns>
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Deletes a work task with the specified code.
        /// </summary>
        /// <param name="codWork">An int.</param>
        /// <returns>Redirects to the work index.</returns>
        public IActionResult DeleteWork(int codWork)
        {
            var token = HttpContext.Session.GetString("Token");
            var baseApi = new BaseApi(_httpClient);

            var works = baseApi.DeleteToApi($"work/{codWork}", new { codWork = codWork }, token);

            return RedirectToAction("Index");
        }

        /// <summary>
        /// Displays a partial view for adding or updating a work task.
        /// </summary>
        /// <param name="work">WorkDto.</param>
        /// <returns>A partial view for adding or updating a work task.</returns>
        public IActionResult WorkAddPartial(WorkDto work)
        {
            if (work.CodWork != 0)
            {
                var workUpdate = new WorkViewModel()
                {
                    CodWork = work.CodWork,
                    HourQty = work.HourQty,
                    Date = work.Date,
                    CodProject = work.Project.CodProject,
                    CodService = work.Service.CodService
                };

                return PartialView("~/Views/Work/Partial/WorkAddPartial.cshtml", workUpdate);
            }
            else
            {
                var model = new WorkViewModel()
                {
                    Date = DateTime.Now
                };
                return PartialView("~/Views/Work/Partial/WorkAddPartial.cshtml", model);
            }
        }

        /// <summary>
        /// Updates a work task with the specified details.
        /// </summary>
        /// <param name="work">WorkViewModel.</param>
        /// <returns>Redirects to the work index.</returns>
        public IActionResult UpdateWork(WorkViewModel work)
        {
            var token = HttpContext.Session.GetString("Token");
            var baseApi = new BaseApi(_httpClient);

            var services = baseApi.PutToApi($"work/{work.CodWork}", work, token);

            return RedirectToAction("Index");
        }

        /// <summary>
        /// Creates a new work task with the specified details.
        /// </summary>
        /// <param name="work">WorkViewModel.</param>
        /// <returns>Redirects to the work index.</returns>
        public IActionResult CreateWork(WorkViewModel work)
        {
            var token = HttpContext.Session.GetString("Token");
            var baseApi = new BaseApi(_httpClient);
            var services = baseApi.PostToApi("work/register", work, token);

            return RedirectToAction("Index");
        }
    }
}
