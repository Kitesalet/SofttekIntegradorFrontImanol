using Data.Base;
using Data.DTO;
using Data.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text.Json;

namespace IntegradorSofttekImanolFront.Controllers
{
    public class LoginController : Controller
    {
        private readonly IHttpClientFactory _httpClient;

        public LoginController(IHttpClientFactory httpClient)
        {
            _httpClient = httpClient;
        }


        public IActionResult Login()
        {
            return View();
        }

        public async Task<IActionResult> CloseSession()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Login");
        }

        public async Task<IActionResult> Ingresar(LoginDto login)
        {
            var baseApi = new BaseApi(_httpClient);

            var token = await baseApi.PostToApi("login", login);

            var loginResult = token as OkObjectResult;

            if(loginResult == null)
            {
                ViewData["ErrorLogin"] = "Sus credenciales son incorrectas...";
                return RedirectToAction("Login");
            }

            var resultObject = JsonConvert.DeserializeObject<Login>(loginResult.Value.ToString());

            ViewData["Nombre"] = resultObject.Name;

            var handler = new JwtSecurityTokenHandler();
            var userToken = handler.ReadJwtToken(resultObject.Token);

            var claims = new List<Claim>();

            foreach(var claim in userToken.Claims)
            {
                if(claim.Type == ClaimTypes.Role || claim.Type == ClaimTypes.Name)
                {
                    claims.Add(claim);
                }

            }

            var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme, ClaimTypes.Name, ClaimTypes.Role);

            identity.AddClaims(claims);

            var claimPrincipal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimPrincipal, new AuthenticationProperties
            {
                ExpiresUtc = DateTime.Now.AddHours(1)
            }); ;

            var homeViewModel = new HomeViewModel();
            homeViewModel.Token = resultObject.Token;

            HttpContext.Session.SetString("Token", resultObject.Token);
            return View("~/Views/Home/Index.cshtml", resultObject);
        }


    }
}
