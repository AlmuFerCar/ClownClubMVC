using ClownClubMVC.Business.Services;
using ClownClubMVC.Models.loggin;
using ClownClubMVC.Models.person;
using ClownClubMVC.WebApp.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ClownClubMVC.WebApp.Controllers
{
    public class AccesController : Controller
    {
        private readonly IUsersLogginService _usersLogginService;
        private readonly IPasswordLogginService _passwordLogginService;
        private readonly IPersonService _personService;

        public AccesController(IUsersLogginService userLogServ, IPasswordLogginService passwordLogServ, IPersonService personServ)
        {
            _usersLogginService = userLogServ;
            _passwordLogginService = passwordLogServ;
            _personService = personServ;
        }
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult Register()
        {
            var viewModel = new VMRegister();
            // Puedes inicializar valores si es necesario
            return View(viewModel);
        }

        [HttpPost]
        public async Task<ActionResult> Insert(VMRegister modelo)
        {
            if (ModelState.IsValid)
            {
                if (modelo.email != null && modelo.pswdLoggin != null)
                {
                    try
                    {
                        usersLoggin newModel = new usersLoggin()
                        {
                            name = modelo.name,
                            apellido = modelo.apellido,
                            email = modelo.email,
                            nick = modelo.nick
                        };
                        bool answeruser = await _usersLogginService.Insert(newModel);
                        usersLoggin dataUser = await _usersLogginService.GetUserByEmail(modelo.email);
                        passwordLoggin newModelPass = new passwordLoggin()
                        {
                            userLoggin_id = dataUser.id,
                            pswdLoggin = modelo.pswdLoggin
                        };
                        person newModelPerson = new person()
                        {
                            userLoggin_id = dataUser.id,
                            rolePerson = modelo.rolePerson,
                            age = modelo.age,
                        };
                        bool answerPass = await _passwordLogginService.Insert(newModelPass);
                        bool answerPerson = await _personService.Insert(newModelPerson);

                        if (answeruser && answerPass && answerPerson)
                        {
                            return RedirectToAction("Login", "Acces");
                        }
                        return StatusCode(StatusCodes.Status200OK, new { valor = answeruser && answerPass && answerPerson });
                    }
                    catch (Exception ex)
                    {
                        // Log de la excepción
                        Console.WriteLine($"Error en la acción Insert: {ex.Message}");
                        return StatusCode(StatusCodes.Status500InternalServerError, new { error = ex.Message });
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Campos requeridos, no pueden estar vacios");
                    return RedirectToAction("Register", "Acces");
                }
            }
            return View("Register", modelo);
        }
        [HttpPost]
        public async Task<ActionResult> Login(VMLog modelo)
        {
            string email = modelo.email;
            string pswdLoggin = modelo.pswdLoggin;

            if (email != null && pswdLoggin != null)
            {
                bool isAuthenticated = await AuthenticateUser(email, pswdLoggin);

                if (isAuthenticated)
                {
                    if (await IsUser(email))
                    {
                        return RedirectToAction("Aficiones", "Home");
                    }
                    else 
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Credenciales incorrectas");
                }
            }
            return View();
        }
        private async Task<bool> AuthenticateUser(string email, string password)
        {
            usersLoggin user = await _usersLogginService.GetUserByEmail(email);
            if (user != null)
            {
                passwordLoggin pass = await _passwordLogginService.GetPasswordByUserId(user.id);
                if (user != null && pass != null && pass.pswdLoggin == password)
                {
                    return true; // Autenticación exitosa
                }
            }
            return false; // Autenticación fallida
        }

        private async Task<bool> IsUser(String email)
        {
            bool isUser = true;
            usersLoggin user = await _usersLogginService.GetUserByEmail(email);
            person rolePerson = await _personService.GetUserByIdLogin(user.id);
            if (rolePerson.rolePerson.Equals("administrator"))
            {
                isUser = false;
            }
            return isUser;
        }
    }
}
