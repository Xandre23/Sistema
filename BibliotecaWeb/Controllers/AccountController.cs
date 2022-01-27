using BibliotecaWeb.DAO.Account;
using BibliotecaWeb.Models;
using BibliotecaWeb.Security;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;


namespace BibliotecaWeb.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Index()
        {
            return View();
        }
      
     

        [HttpGet]
        public async Task<JsonResult> Get(int userID)
        {
            var accountDAO = new AccountDAO();
            var user = await accountDAO.Get(userID);
            return Json(user);
        }

        [HttpPost]
        public async Task<JsonResult> Create(UserViewModel user)
        {
            try
            {

                var accountDAO = new AccountDAO();
                await accountDAO.Create(user);
                var httpResponse = new HttpResponseViewlModel(Convert.ToInt32(HttpStatusCode.OK), string.Empty);
                return Json(httpResponse);
            }
            catch (Exception ex)
            {
                string message = "Um erro ocorreu, tente novamente mais tarde";
                if (ex.Message.Contains("usuario.email_UNIQUE"))
                {
                    message = "Esse Email já esta sendo utilizado";
                }
                var httpResponse = new HttpResponseViewlModel(Convert.ToInt32(HttpStatusCode.BadRequest), message);
                return Json(httpResponse);
            }

        }

        [HttpPost]
        public async Task<JsonResult> Login(string email, string password)
        {
            
            try
            {
                var hash = new Hash();
                string hashedPassword = hash.GenerateHashSHA512(password);
                var accountDAO = new AccountDAO();
                var user = await accountDAO.Login(email);
                if (user == null)
                {
                    var result = new HttpResponseViewlModel(Convert.ToInt32(HttpStatusCode.BadRequest), "Email não encontrado");
                    return Json(result);
                }
                if (!user.Senha.Equals(hashedPassword) & user.Senha == null)
                {
                    var response = new HttpResponseViewlModel(Convert.ToInt32(HttpStatusCode.BadRequest), "Senha incorreta");
                    return Json(response);
                }
                var claims = new List<Claim>();
                claims.Add(new Claim(ClaimTypes.NameIdentifier, user.ID.ToString()));
                ClaimsIdentity identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                ClaimsPrincipal principal = new ClaimsPrincipal(identity);
                await HttpContext.SignInAsync(principal);
                var httpResponse = new HttpResponseViewlModel(Convert.ToInt32(HttpStatusCode.OK), string.Empty);

                return Json(httpResponse);


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

      }
        
        
    }
}

