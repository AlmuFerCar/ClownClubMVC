using System.Diagnostics;
using ClownClub.Bussiness.Services;
using ClownClubMVC.Models.loggin;
using ClownClubMVC.WebApp.Models;
using ClownClubMVC.WebApp.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ClownClubMVC.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUsersLogginService _usersLogginService;

        public HomeController(IUsersLogginService userLogServ)
        {
            _usersLogginService = userLogServ;
        }

        // GET: /Movies/
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<ActionResult> List()
        {
            IQueryable<usersLoggin> queryUsersLogginSQL = await _usersLogginService.GetAll();
            List<VMUsersLoggin> list = queryUsersLogginSQL.Select(c => new VMUsersLoggin()
            {
                id = c.id,
                name = c.name,
                apellido = c.apellido,
                email = c.email,
                nick = c.nick
            }).ToList();
            return StatusCode(StatusCodes.Status200OK, list);
        }

        [HttpPost]
        public async Task<ActionResult> Insert([FromBody] VMUsersLoggin modelo)
        {
            usersLoggin newModel = new usersLoggin()
            {
                name = modelo.name,
                apellido = modelo.apellido,
                email = modelo.email,
                nick = modelo.nick
            };
            bool answer = await _usersLogginService.Insert(newModel);
            return StatusCode(StatusCodes.Status200OK, new { valor = answer });
        }

        [HttpPut]
        public async Task<ActionResult> Update([FromBody] VMUsersLoggin modelo)
        {
            usersLoggin newModel = new usersLoggin()
            {
                id = modelo.id,
                name = modelo.name,
                apellido = modelo.apellido,
                email = modelo.email,
                nick = modelo.nick
            };
            bool answer = await _usersLogginService.Update(newModel);
            return StatusCode(StatusCodes.Status200OK, new { valor = answer });
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            bool answer = await _usersLogginService.Delete(id);
            return StatusCode(StatusCodes.Status200OK, new { valor = answer });
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Contacto()
        {
            return View();
        }
        public IActionResult Aficiones()
        {
            return View();
        }
        public IActionResult Presentacion()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}