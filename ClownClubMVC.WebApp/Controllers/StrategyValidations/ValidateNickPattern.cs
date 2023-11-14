using ClownClubMVC.WebApp.Controllers.Interfaces;
using System.Text.RegularExpressions;

namespace ClownClubMVC.WebApp.Controllers.StrategyValidations
{
    public class ValidateNickPattern : IValidateStrategy
    {
        public bool Validate(params string[] inputs)
        {
            if (!Regex.IsMatch(inputs[0], "^(?=.*[A-Z])(?=.*\\d).{5,}"))
            {
                Console.WriteLine("ERROR: The Username must contain at least 1 Capital Letter and 1 Number.");
                return false;
            }
            return true;
        }
    }
}
