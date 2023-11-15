namespace ClownClubMVC.WebApp.Controllers.InterfacesStrategy
{
    public interface IValidates
    {
        bool ValidateInput(params string[] inputs);
    }
}
