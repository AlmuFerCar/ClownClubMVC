namespace ClownClubMVC.WebApp.Controllers.InterfacesStrategy
{
    public interface IValidateStrategy
    {
        bool Validate(params string[] inputs);
    }
}
