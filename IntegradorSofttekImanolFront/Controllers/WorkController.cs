using Data.Base;
using Data.DTO;
using Data.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IntegradorSofttekImanolFront.Controllers
{
    [Authorize]
    public class WorkController : Controller
    {

        private readonly IHttpClientFactory _httpClient;

        public WorkController(IHttpClientFactory httpClient)
        {
            _httpClient = httpClient;
        }

        public IActionResult Index()
        {

            return View();
        }

        public IActionResult DeleteWork(int codWork)
        {
            var token = HttpContext.Session.GetString("Token");
            var baseApi = new BaseApi(_httpClient);

            var works = baseApi.DeleteToApi($"work/{codWork}", new { codWork = codWork }, token);

            return RedirectToAction("Index");
        }

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
                var model = new WorkViewModel();
                return PartialView("~/Views/Work/Partial/WorkAddPartial.cshtml", model);
            }



        }

        public IActionResult UpdateWork(WorkViewModel work)
        {
            var token = HttpContext.Session.GetString("Token");
            var baseApi = new BaseApi(_httpClient);

            var services = baseApi.PutToApi($"work/{work.CodWork}", work, token);

            return RedirectToAction("Index");
        }

        public IActionResult CreateWork(WorkViewModel work)
        {
            var token = HttpContext.Session.GetString("Token");
            var baseApi = new BaseApi(_httpClient);
            var services = baseApi.PostToApi("work/register", work, token);

            return RedirectToAction("Index");
        }

    }
}
