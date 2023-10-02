using Data.Base;
using Data.DTO;
using Data.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IntegradorSofttekImanolFront.Controllers
{
    [Authorize]
    public class UserController : Controller
    {

        private readonly IHttpClientFactory _httpClient;

        public UserController(IHttpClientFactory httpClient)
        {
            _httpClient = httpClient;
        }

        public IActionResult Index()
        {

            return View();
        }

        public IActionResult DeleteUser(int codUser)
        {
            var token = HttpContext.Session.GetString("Token");
            var baseApi = new BaseApi(_httpClient);

            var usuarios = baseApi.DeleteToApi($"user/{codUser}", new { codUser = codUser }, token);

            return RedirectToAction("Index");
        }

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

        public IActionResult UpdateUser(UserUpdateDto user)
        {
            var token = HttpContext.Session.GetString("Token");
            var baseApi = new BaseApi(_httpClient);

            var usuarios = baseApi.PutToApi($"user/{user.CodUser}", user, token);

            return RedirectToAction("Index");
        }

        public IActionResult CreateUser(UserDto user)
        {
            var token = HttpContext.Session.GetString("Token");
            var baseApi = new BaseApi(_httpClient);
            var usuarios = baseApi.PostToApi("users/register", user, token);

            return RedirectToAction("Index");
        }

    }
}
