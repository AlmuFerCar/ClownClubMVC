using ClownClubMVC.WebApp.Controllers.InterfacesStrategy;
using System.Text.RegularExpressions;

namespace ClownClubMVC.WebApp.Controllers.StrategyValidations
{
    public class ValidateUserEmail : IValidateStrategy
    {
        public bool Validate(params string[] inputs)
        {
            if (!Regex.IsMatch(inputs[0], @"^\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$"))
            {
                return false;
            }
            return true;
        }
    }
}
