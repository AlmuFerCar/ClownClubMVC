using ClownClub.Bussiness.Services;
using ClownClubMVC.Business.Services;
using ClownClubMVC.Models.loggin;
using ClownClubMVC.WebApp.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ClownClubMVC.WebApp.Controllers
{
    public class AccesController : Controller
    {
        private readonly IUsersLogginService _usersLogginService;
        private readonly IPasswordLogginService _passwordLogginService;

        public AccesController(IUsersLogginService userLogServ, IPasswordLogginService passwordLogServ)
        {
            _usersLogginService = userLogServ;
            _passwordLogginService = passwordLogServ;
        }
        public ActionResult Loggin()
        {
            return View();
        }
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Insert([FromBody] VMUsersLoggin modelo, VMPassword modeloPass)
        {
            usersLoggin newModel = new usersLoggin()
            {
                name = modelo.name,
                apellido = modelo.apellido,
                email = modelo.email,
                nick = modelo.nick
            };

            passwordLoggin newPassModel = new passwordLoggin()
            {
                userLoggin_id = modelo.id,
                pswdLoggin = modeloPass.pswdLoggin
            };
            bool answer = await _usersLogginService.Insert(newModel);
            await _passwordLogginService.Insert(newPassModel);
            //return StatusCode(StatusCodes.Status200OK, new { valor = answer });
            return RedirectToAction("Login", "Acces");
        }
        [HttpPost]
        public async Task<ActionResult> Login([FromBody] VMUsersLoggin modelo, VMPassword modeloPass)
        {
            if (modelo.email != null && modeloPass.pswdLoggin != null)
            {
                // Realiza la autenticación comparando el correo y el id
                // y verifica que la contraseña coincida
                bool isAuthenticated = await AuthenticateUser(modelo.email, modelo.id, modeloPass.pswdLoggin);

                if (isAuthenticated)
                {
                    // Usuario autenticado, puedes redirigirlo a la página principal o a otra vista
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    // Autenticación fallida, puedes mostrar un mensaje de error en la vista Login
                    ModelState.AddModelError(string.Empty, "Credenciales incorrectas");
                    return View();
                }
            }
            else
            {
                // Los campos email y pswdLoggin son requeridos, puedes manejar esto en la vista
                ModelState.AddModelError(string.Empty, "Por favor, complete todos los campos requeridos.");
                return View();
            }
        }
        private async Task<bool> AuthenticateUser(string email, int userId, string password)
        {
            // Aquí debes implementar la lógica de autenticación
            // Consulta la base de datos o donde estén almacenados los usuarios y contraseñas
            // para verificar si los datos son correctos
            // Por ejemplo, podrías usar los servicios _usersLogginService y _passwordLogginService

            usersLoggin user = await _usersLogginService.GetUserByEmail(email);
            passwordLoggin pass = await _passwordLogginService.GetPasswordByUserId(userId);

            if (user != null && pass != null && pass.pswdLoggin == password)
            {
                return true; // Autenticación exitosa
            }

            return false; // Autenticación fallida
        }
    }
}
