using Data.Base;
using Data.DTO;
using Data.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IntegradorSofttekImanolFront.Controllers
{
    [Authorize]
    /// <summary>
    /// Represents a controller for managing projects.
    /// </summary>
    public class ProjectController : Controller
    {
        private readonly IHttpClientFactory _httpClient;

        /// <summary>
        /// Initializes a new instance of the ProjectController class.
        /// </summary>
        /// <param name="httpClient">IHttpClientFactory</param>
        public ProjectController(IHttpClientFactory httpClient)
        {
            _httpClient = httpClient;
        }

        /// <summary>
        /// Displays the project index view.
        /// </summary>
        /// <returns>The project index view.</returns>
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Deletes a project with the specified code.
        /// </summary>
        /// <param name="codProject">The code of the project to delete.</param>
        /// <returns>Redirects to the project index.</returns>
        public IActionResult DeleteProject(int codProject)
        {
            var token = HttpContext.Session.GetString("Token");
            var baseApi = new BaseApi(_httpClient);

            var usuarios = baseApi.DeleteToApi($"project/{codProject}", new { codProject = codProject }, token);

            return RedirectToAction("Index");
        }

        /// <summary>
        /// Displays a partial view for adding or updating a project.
        /// </summary>
        /// <param name="project">The project to add or update.</param>
        /// <returns>A partial view for adding or updating a project.</returns>
        public IActionResult ProjectAddPartial(ProjectDto project)
        {
            if (project.CodProject != 0)
            {
                var projectUpdate = new ProjectViewModel()
                {
                    CodProject = project.CodProject,
                    Name = project.Name,
                    Address = project.Address,
                    State = project.State
                };

                return PartialView("~/Views/Project/Partial/ProjectAddPartial.cshtml", projectUpdate);
            }
            else
            {
                var model = new ProjectViewModel();
                return PartialView("~/Views/Project/Partial/ProjectAddPartial.cshtml", model);
            }
        }

        /// <summary>
        /// Updates a project with the specified details.
        /// </summary>
        /// <param name="project">ProjectDto</param>
        /// <returns>Redirects to the project index.</returns>
        public IActionResult UpdateProject(ProjectDto project)
        {
            var token = HttpContext.Session.GetString("Token");
            var baseApi = new BaseApi(_httpClient);

            var projects = baseApi.PutToApi($"project/{project.CodProject}", project, token);

            return RedirectToAction("Index");
        }

        /// <summary>
        /// Creates a new project with the specified details.
        /// </summary>
        /// <param name="project">ProjectDto.</param>
        /// <returns>Redirects to the project index.</returns>
        public IActionResult CreateProject(ProjectDto project)
        {
            var token = HttpContext.Session.GetString("Token");
            var baseApi = new BaseApi(_httpClient);
            var services = baseApi.PostToApi("project/register", project, token);

            return RedirectToAction("Index");
        }
    }
}
