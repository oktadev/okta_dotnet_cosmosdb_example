using Okta_CosmosDb.Models;
using Microsoft.Azure.Cosmos;

namespace Okta_CosmosDb.Services
{
    public class CosmosService : ICosmosService
    {
        private Container _container; 
        
        public CosmosService(
            CosmosClient dbClient,
            string databaseName,
            string containerName)
        {
            this._container = dbClient.GetContainer(databaseName, containerName);
        }

        /// <summary>
        /// Creates a Cosmos DB database and a container with the specified partition key. 
        /// </summary>
        /// <returns></returns>
        public static async Task<CosmosService> InitializeCosmosClientInstanceAsync(IConfigurationSection configurationSection)
        {
            string databaseName = configurationSection.GetSection("DatabaseName").Value;
            string containerName = configurationSection.GetSection("ContainerName").Value;
            string account = configurationSection.GetSection("Account").Value;
            string key = configurationSection.GetSection("Key").Value;

            CosmosClient client = new CosmosClient(account, key);
            CosmosService cosmosDbService = new CosmosService(client, databaseName, containerName);
            DatabaseResponse database = await client.CreateDatabaseIfNotExistsAsync(databaseName);
            await database.Database.CreateContainerIfNotExistsAsync(containerName, "/id");

            return cosmosDbService;
        }

        public async Task SaveResultAsync(ScrubResult result)
        {
            await this._container.CreateItemAsync<ScrubResult>(result, new PartitionKey(result.Id));
        }
    }
}