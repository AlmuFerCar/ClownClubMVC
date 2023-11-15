using System.ComponentModel;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ClownClubMVC.WebApp.Models.ViewModels
{
    public class VMRegister
    {
        [DisplayName("Nombre")]
        public string name { get; set; }
        [DisplayName("Apellido")]
        public string surname { get; set; }
        [DisplayName("Correo electrónico")]
        public string email { get; set; }
        [DisplayName("Nombre usuario")]
        public string nick { get; set; }
        [DisplayName("Contraseña")]
        public string pswdLoggin { get; set; }
        [DisplayName("Tipo de usuario")]
        public string rolePerson { get; set; }
        [DisplayName("Edad")]
        public int age { get; set; }


        public List<SelectListItem> AvailableRoles { get; } = new List<SelectListItem>
        {
            new SelectListItem { Value = "user", Text = "user" },
            new SelectListItem { Value = "administrator", Text = "administrator" }
        };
    }
}