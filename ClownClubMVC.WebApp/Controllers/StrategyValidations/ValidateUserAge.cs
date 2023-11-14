using ClownClubMVC.WebApp.Controllers.Interfaces;

namespace ClownClubMVC.WebApp.Controllers.StrategyValidations
{
    public class ValidateUserAge : IValidateStrategy
    {
        public bool Validate(params string[] inputs)
        {
            if (inputs == null || inputs.Length == 0)
            {
                throw new ArgumentException("No se proporcionaron datos de edad.");
            }

            if (int.TryParse(inputs[0], out int userAge))
            {
                return userAge >= 18;
            }
            else
            {
                throw new ArgumentException("El dato de edad no es un número válido.");
            }
        }

    }
}
