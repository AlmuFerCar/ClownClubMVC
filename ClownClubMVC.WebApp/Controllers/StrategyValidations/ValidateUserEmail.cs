using ClownClubMVC.WebApp.Controllers.Interfaces;
using System.Text.RegularExpressions;

namespace ClownClubMVC.WebApp.Controllers.StrategyValidations
{
    public class ValidateUserEmail : IValidateStrategy
    {
        public bool Validate(params string[] inputs)
        {
            if (!Regex.IsMatch(inputs[0], @"^\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$"))
            {
                Console.WriteLine("ERROR: The email doesn't meet the proper format");
                return false;
            }
            return true;
        }

    }
}
