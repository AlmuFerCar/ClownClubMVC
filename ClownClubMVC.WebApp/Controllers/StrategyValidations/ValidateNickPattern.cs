using ClownClubMVC.WebApp.Controllers.InterfacesStrategy;
using System.Text.RegularExpressions;

namespace ClownClubMVC.WebApp.Controllers.StrategyValidations
{
    public class ValidateNickPattern : IValidateStrategy
    {
        public bool Validate(params string[] inputs)
        {
            if (!Regex.IsMatch(inputs[0], "^(?=.*[A-Z])(?=.*\\d).{5,}"))
            {
                return false;
            }
            return true;
        }
    }
}
