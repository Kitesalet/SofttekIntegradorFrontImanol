using Data.Base;
using Data.DTO;
using Data.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IntegradorSofttekImanolFront.Controllers
{
    [Authorize]
    public class ProjectController : Controller
    {

        private readonly IHttpClientFactory _httpClient;

        public ProjectController(IHttpClientFactory httpClient)
        {
            _httpClient = httpClient;
        }

        public IActionResult Index()
        {

            return View();
        }

        public IActionResult DeleteProject(int codProject)
        {
            var token = HttpContext.Session.GetString("Token");
            var baseApi = new BaseApi(_httpClient);

            var usuarios = baseApi.DeleteToApi($"project/{codProject}", new { codProject = codProject }, token);

            return RedirectToAction("Index");
        }

        public IActionResult ProjectAddPartial(ProjectDto project)
        {
            if (project.CodProject != 0)
            {
                int stateInt = 0;

                if (project.State == "Pendiente")
                {
                    stateInt = 1;
                }
                else if (project.State == "Confirmado")
                {
                    stateInt = 2;
                }
                else
                {
                    stateInt = 3;
                }

                var projectUpdate = new ProjectViewModel()
                {
                    CodProject = project.CodProject,
                    Name = project.Name,
                    Address = project.Address,
                    State = stateInt
                };

                return PartialView("~/Views/Project/Partial/ProjectAddPartial.cshtml", projectUpdate);
            }
            else
            {
                var model = new ProjectViewModel();
                return PartialView("~/Views/Project/Partial/ProjectAddPartial.cshtml", model);
            }



        }

        public IActionResult UpdateProject(ProjectDto project)
        {
            var token = HttpContext.Session.GetString("Token");
            var baseApi = new BaseApi(_httpClient);

            var projects = baseApi.PutToApi($"project/{project.CodProject}", project, token);

            return RedirectToAction("Index");
        }

        public IActionResult CreateProject(ProjectDto project)
        {
            var token = HttpContext.Session.GetString("Token");
            var baseApi = new BaseApi(_httpClient);
            var services = baseApi.PostToApi("project/register", project, token);

            return RedirectToAction("Index");
        }

    }
}
