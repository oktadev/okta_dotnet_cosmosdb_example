namespace Okta_CosmosDb.Services
{
    public interface IScrubService
    {
        Task<Models.ScrubResult> ScrubAsync(Models.Person person);
    }
}