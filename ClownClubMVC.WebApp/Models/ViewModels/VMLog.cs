using System.ComponentModel;

namespace ClownClubMVC.WebApp.Models.ViewModels
{
    public class VMLog
    {
        [DisplayName("Correo Electrónico")]
        public string email { get; set; }

        [DisplayName("Contraseña")]
        public string pswdLoggin { get; set; }
    }
}
