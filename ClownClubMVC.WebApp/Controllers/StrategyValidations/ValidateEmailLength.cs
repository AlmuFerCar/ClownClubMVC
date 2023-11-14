using ClownClubMVC.WebApp.Controllers.Interfaces;

namespace ClownClubMVC.WebApp.Controllers.StrategyValidations
{
    public class ValidateEmailLength : IValidateStrategy
    {
        public bool Validate(params string[] inputs)
        {
            if (inputs[0].Length > 40)
            {
                Console.WriteLine("ERROR: Emails longer than 40 characters are not accepted.");
                return false;
            }
            return true;
        }

    }
}
