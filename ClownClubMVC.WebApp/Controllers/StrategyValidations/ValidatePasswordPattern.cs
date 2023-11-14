using ClownClubMVC.WebApp.Controllers.Interfaces;
using System.Text.RegularExpressions;

namespace ClownClubMVC.WebApp.Controllers.StrategyValidations
{
    public class ValidatePasswordPattern : IValidateStrategy
    {
        public bool Validate(params string[] inputs)
        {
            if (!Regex.IsMatch(inputs[0], @"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)"))
            {
                Console.WriteLine("ERROR: The password must have at least 1 Capital Letter and 1 Number.");
                return false;
            }
            return true;
        }
    }
}
