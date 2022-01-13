using BibliotecaWeb.DAO.Account;
using BibliotecaWeb.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Security.Policy;
using System.Threading.Tasks;

namespace BibliotecaWeb.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
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


    }
}
