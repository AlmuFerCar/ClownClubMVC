using ClownClubMVC.WebApp.Controllers.InterfacesStrategy;

namespace ClownClubMVC.WebApp.Controllers.StrategyValidations
{
    public class ValidateEmailLength : IValidateStrategy
    {
        public bool Validate(params string[] inputs)
        {
            if (inputs[0].Length > 100)
            {
                return false;
            }
            return true;
        }

    }
}
