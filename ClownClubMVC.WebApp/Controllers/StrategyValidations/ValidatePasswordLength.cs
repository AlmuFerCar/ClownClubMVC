using ClownClubMVC.WebApp.Controllers.InterfacesStrategy;

namespace ClownClubMVC.WebApp.Controllers.StrategyValidations
{
    public class ValidatePasswordLength : IValidateStrategy
    {
        public bool Validate(params string[] inputs)
        {
            if (inputs[0].Length < 10)
            {
                return false;
            }
            return true;
        }
    }
}
