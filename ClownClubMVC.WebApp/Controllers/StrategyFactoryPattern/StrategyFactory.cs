using ClownClubMVC.WebApp.Controllers.InterfacesStrategy;
using ClownClubMVC.WebApp.Controllers.StrategyValidations;

namespace ClownClubMVC.WebApp.Controllers.StrategyFactoryPattern
{
    public class StrategyFactory
    {
        public IValidateStrategy CreateCheckStrategy(string strategyType)
        {
            switch (strategyType)
            {
                case "NamePattern":
                    return new ValidateNamePattern();
                case "SurnamePattern":
                    return new ValidateSurnamePattern();
                case "EmailLength":
                    return new ValidateEmailLength();
                case "PasswordLength":
                    return new ValidatePasswordLength();
                case "PasswordPattern":
                    return new ValidatePasswordPattern();
                case "UserAge":
                    return new ValidateUserAge();
                case "UserEmail":
                    return new ValidateUserEmail();
                case "NickPattern":
                    return new ValidateNickPattern();
                default:
                    throw new ArgumentException("Invalid Strategy.");
            }
        }
    }
}
