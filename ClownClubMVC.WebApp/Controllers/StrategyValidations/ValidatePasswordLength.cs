using ClownClubMVC.WebApp.Controllers.Interfaces;

namespace ClownClubMVC.WebApp.Controllers.StrategyValidations
{
    public class ValidatePasswordLength : IValidateStrategy
    {
        public bool Validate(params string[] inputs)
        {
            if (inputs[0].Length < 8)
            {
                Console.WriteLine("ERROR: The password must be at least 8 characters.");
                return false;
            }
            return true;
        }
    }
}
