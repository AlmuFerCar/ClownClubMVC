using ClownClubMVC.WebApp.Controllers.InterfacesStrategy;

namespace ClownClubMVC.WebApp.Controllers.StrategyValidations
{
    public class Validates : IValidates
    {
        private IValidateStrategy _checkStrategy;
        public Validates() { }
        public Validates(IValidateStrategy strategy)
        {
            _checkStrategy = strategy;
        }
        public bool ValidateInput(params string[] inputs)
        {
            return _checkStrategy.Validate(inputs);
        }
    }
}
