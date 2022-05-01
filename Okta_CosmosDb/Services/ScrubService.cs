using Okta_CosmosDb.Models;

namespace Okta_CosmosDb.Services
{
    public class ScrubService : IScrubService
    {
        public async Task<ScrubResult> ScrubAsync(Person person)
        {
            var task = Task.Run(() => { return new ScrubResult(person, new Random().Next(2) == 0); });
            return await task;
        }
    }
}