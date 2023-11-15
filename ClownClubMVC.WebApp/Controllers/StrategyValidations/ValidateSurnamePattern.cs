using ClownClubMVC.WebApp.Controllers.InterfacesStrategy;
using System.Text.RegularExpressions;

namespace ClownClubMVC.WebApp.Controllers.StrategyValidations
{
    public class ValidateSurnamePattern : IValidateStrategy
    {
        public bool Validate(params string[] inputs)
        {
            string pattern = "^[A-Za-z]{1,100}$";
            if (!Regex.IsMatch(inputs[0], pattern))
            {
                return false;
            }
            return true;
        }
    }
}
