namespace ClownClubMVC.WebApp.Controllers.Interfaces
{
    public interface IValidateStrategy
    {
        bool Validate(params string[] inputs);
    }
}
