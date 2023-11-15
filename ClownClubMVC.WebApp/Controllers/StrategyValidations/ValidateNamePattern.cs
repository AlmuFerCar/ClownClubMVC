using System.Text.RegularExpressions;
using ClownClubMVC.WebApp.Controllers.InterfacesStrategy;

namespace ClownClubMVC.WebApp.Controllers.StrategyValidations
{
    public class ValidateNamePattern : IValidateStrategy
    {
        public bool Validate(params string[] inputs)
        {
            string pattern = "^[A-Za-z]{1,50}$";
            if (!Regex.IsMatch(inputs[0], pattern))
            {
                return false;
            }
            return true;
        }
    }
}

