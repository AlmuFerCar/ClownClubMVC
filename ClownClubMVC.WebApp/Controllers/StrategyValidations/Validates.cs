using ClownClubMVC.WebApp.Controllers.Interfaces;

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
        //public bool CheckUserRepeated(string username, GenericList<User> userlist)
        //{
        //    if (userlist.GetList().Any(user => user.Username == username))
        //    {
        //        Console.WriteLine("The username is already in use.");
        //        return false;
        //    }
        //    return true;
        //}
    }
}
