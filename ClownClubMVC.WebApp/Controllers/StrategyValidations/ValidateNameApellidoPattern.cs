using System.Text.RegularExpressions;
using ClownClubMVC.WebApp.Controllers.Interfaces;

namespace ClownClubMVC.WebApp.Controllers.StrategyValidations
{
    public class ValidateNameApellidoPattern : IValidateStrategy
    {
        public bool Validate(params string[] inputs)
        {
            string pattern = "^[A-Za-z]{1,40}$"; // De 1 a 40 letras
            if (!Regex.IsMatch(inputs[0], pattern))
            {
                Console.WriteLine("ERROR: The password must only contain uppercase and lowercase letters, and be between 1 and 40 characters long.");
                return false;
            }
            return true;
        }
    }
}

