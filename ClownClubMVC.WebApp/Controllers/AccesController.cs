﻿using ClownClubMVC.Business.Services.Interfaces.Login;
using ClownClubMVC.Business.Services.Interfaces.Person;
using ClownClubMVC.Models.loggin;
using ClownClubMVC.Models.person;
using ClownClubMVC.WebApp.Controllers.StrategyFactoryPattern;
using ClownClubMVC.WebApp.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ClownClubMVC.WebApp.Controllers
{
    public class AccesController : Controller
    {
        private readonly IUsersLogginService _usersLogginService;
        private readonly IPasswordLogginService _passwordLogginService;
        private readonly IPersonService _personService;
        private readonly StrategyFactory _strategyFactory;
        public AccesController(IUsersLogginService userLogServ, IPasswordLogginService passwordLogServ, IPersonService personServ, StrategyFactory strategyFactory)
        {
            _usersLogginService = userLogServ;
            _passwordLogginService = passwordLogServ;
            _personService = personServ;
            _strategyFactory = strategyFactory;
        }
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult Register()
        {
            var viewModel = new VMRegister();
            return View(viewModel);
        }

        [HttpPost]
        public async Task<ActionResult> Insert(VMRegister modelo)
        {
            bool answeruser = false;
            bool answerPass = false;
            bool answerPerson = false;
            if (ModelState.IsValid)
            {
                if (modelo.email != null && modelo.pswdLoggin != null)
                {
                    try
                    {
                        if (checkDataRegister(modelo) && await IsRepeatEmail(modelo) && await IsRepeatNick(modelo))
                        {
                            usersLoggin newModel = new usersLoggin()
                            {
                                name = modelo.name,
                                surname = modelo.surname,
                                email = modelo.email,
                                nick = modelo.nick
                            };
                            answeruser = await _usersLogginService.Insert(newModel);
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
                            answerPass = await _passwordLogginService.Insert(newModelPass);
                            answerPerson = await _personService.Insert(newModelPerson);
                        }
                        if (answeruser && answerPass && answerPerson)
                        {
                            return RedirectToAction("Login", "Acces");
                        }
                    }
                    catch (Exception ex)
                    {
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
                        return RedirectToAction("ContentView", "Content");
                    }
                    else 
                    {
                        return RedirectToAction("Management", "Management");
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
                    return true;
                }
            }
            return false;
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
        private async Task<bool> IsRepeatNick(VMRegister modelo)
        {
            bool isRepeatNick = false;
            IQueryable<usersLoggin> queryUsersLogginSQL = await _usersLogginService.GetAll();
            usersLoggin usersLoggin = queryUsersLogginSQL.Where(c => c.nick == modelo.nick).FirstOrDefault();
            if (usersLoggin != null)
            {
                ModelState.AddModelError("Nick", "ERROR: The nick is already exist");
                isRepeatNick = true;
            }
            return isRepeatNick;
        }
        private async Task<bool> IsRepeatEmail(VMRegister modelo)
        {
            bool isRepeatEmail = false;
            IQueryable<usersLoggin> queryUsersLogginSQL = await _usersLogginService.GetAll();
            usersLoggin usersLoggin = queryUsersLogginSQL.Where(c => c.email == modelo.email).FirstOrDefault();
            if (usersLoggin != null)
            {
                ModelState.AddModelError("Email", "ERROR: The email is already exist");
                isRepeatEmail = true;
            }
            return isRepeatEmail;
        }

        private bool checkDataRegister(VMRegister modelo)
        {
            bool checkData = true;
            var nameChecker = _strategyFactory.CreateCheckStrategy("NamePattern");
            if (!nameChecker.Validate(modelo.name))
            {
                ModelState.AddModelError("Name", "ERROR: The name cannot contain numbers or special characters and the name cannot exceed 50 characters");
                checkData = false;
            }
            var apellidoChecker = _strategyFactory.CreateCheckStrategy("SurnamePattern");
            if (!apellidoChecker.Validate(modelo.surname))
            {
                ModelState.AddModelError("Apellido", "ERROR: The surname cannot contain numbers or special characters and the surname cannot exceed 100 characters");
                checkData = false;
            }
            var emailLengthChecker = _strategyFactory.CreateCheckStrategy("EmailLength");
            if (!emailLengthChecker.Validate(modelo.email))
            {
                ModelState.AddModelError("Email", "ERROR: Emails longer than 100 characters are not accepted.");
                checkData = false;
            }
            var emailChecker = _strategyFactory.CreateCheckStrategy("UserEmail");
            if (!emailChecker.Validate(modelo.email))
            {
                ModelState.AddModelError("Email", "ERROR: The email doesn't meet the proper format.");
                checkData = false;
            }
            var nickPatternChecker = _strategyFactory.CreateCheckStrategy("NickPattern");
            if (!nickPatternChecker.Validate(modelo.nick))
            {
                ModelState.AddModelError("Nick", "ERROR: The nick must contain at least 1 Capital Letter and 1 Number.");
                checkData = false;
            }
            var passwordLegnthChecker = _strategyFactory.CreateCheckStrategy("PasswordLength");
            if (!passwordLegnthChecker.Validate(modelo.pswdLoggin))
            {
                ModelState.AddModelError("Pass", "ERROR: The password must be at least 10 characters.");
                checkData = false;
            }
            var passwordPatternChecker = _strategyFactory.CreateCheckStrategy("PasswordPattern");
            if (!passwordPatternChecker.Validate(modelo.pswdLoggin))
            {
                ModelState.AddModelError("Pass", "ERROR: The Password must have at least 1 Capital Letter and 1 Number.");
                checkData = false;
            }
            string ageAsString = modelo.age.ToString();
            var AgeChecker = _strategyFactory.CreateCheckStrategy("UserAge");
            if (!AgeChecker.Validate(ageAsString))
            {
                ModelState.AddModelError("Age", "ERROR: You must be at least 18 years old to register.");
                checkData = false;
            }
            return checkData;
        }
    }
}
