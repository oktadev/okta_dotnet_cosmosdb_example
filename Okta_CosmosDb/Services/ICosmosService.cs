namespace Okta_CosmosDb.Services
{
    public interface ICosmosService
    {
        Task SaveResultAsync(Models.ScrubResult result);
    }
}