using Data.Base;
using Data.DTO;
using Data.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IntegradorSofttekImanolFront.Controllers
{
    [Authorize]
    /// <summary>
    /// Represents a controller for managing users.
    /// </summary>
    public class UserController : Controller
    {
        private readonly IHttpClientFactory _httpClient;

        /// <summary>
        /// Initializes a new instance of the UserController class.
        /// </summary>
        /// <param name="httpClient">IHttpClientFactory</param>
        public UserController(IHttpClientFactory httpClient)
        {
            _httpClient = httpClient;
        }

        /// <summary>
        /// Displays the user index view.
        /// </summary>
        /// <returns>The user index view.</returns>
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Deletes a user with the specified code.
        /// </summary>
        /// <param name="codUser">An int.</param>
        /// <returns>Redirects to the user index.</returns>
        public IActionResult DeleteUser(int codUser)
        {
            var token = HttpContext.Session.GetString("Token");
            var baseApi = new BaseApi(_httpClient);

            var usuarios = baseApi.DeleteToApi($"user/{codUser}", new { codUser = codUser }, token);

            return RedirectToAction("Index");
        }

        /// <summary>
        /// Displays a partial view for adding or updating a user.
        /// </summary>
        /// <param name="user">UserDto</param>
        /// <returns>A partial view for adding or updating a user.</returns>
        public IActionResult UsersAddPartial(UserDto user)
        {
            if (user.CodUser != 0)
            {
                if (user.Type == "Consultor")
                {
                    user.TypeNumber = 1;
                }
                else
                {
                    user.TypeNumber = 2;
                }

                user.Password = "***************";

                var userUpdate = new UserViewModel()
                {
                    Type = user.TypeNumber,
                    Dni = user.Dni,
                    Name = user.Name,
                    Password = user.Password,
                    CodUser = user.CodUser
                };

                return PartialView("~/Views/User/Partial/UsersAddPartial.cshtml", userUpdate);
            }
            else
            {
                var model = new UserViewModel()
                {
                    Type = 1
                };
                return PartialView("~/Views/User/Partial/UsersAddPartial.cshtml", model);
            }
        }

        /// <summary>
        /// Updates a user with the specified details.
        /// </summary>
        /// <param name="user">UserUpdateDto</param>
        /// <returns>Redirects to the user index.</returns>
        public IActionResult UpdateUser(UserUpdateDto user)
        {
            var token = HttpContext.Session.GetString("Token");
            var baseApi = new BaseApi(_httpClient);

            var usuarios = baseApi.PutToApi($"user/{user.CodUser}", user, token);

            return RedirectToAction("Index");
        }

        /// <summary>
        /// Creates a new user with the specified details.
        /// </summary>
        /// <param name="user">UserDto.</param>
        /// <returns>Redirects to the user index.</returns>
        public IActionResult CreateUser(UserDto user)
        {
            var token = HttpContext.Session.GetString("Token");
            var baseApi = new BaseApi(_httpClient);
            var usuarios = baseApi.PostToApi("users/register", user, token);

            return RedirectToAction("Index");
        }
    }
}
