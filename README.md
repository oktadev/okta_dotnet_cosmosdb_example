# Seure PII using Azure Cosmos DB

This repository shows you how to build a web application with ASP.NET Core with a Cosmos DB backend and secure any PII that you may have.  Please read [Secure PII In Azure Cosmos DB][blog] to see how it was created.

**Prerequisites:**

- [Visual Studio 2022](https://visualstudio.microsoft.com/downloads/)
- [.NET 6](https://dotnet.microsoft.com/en-us/download/dotnet/6.0)
- An [Okta Developer Account](https://developer.okta.com/) (free forever, to handle your OAuth needs)
- [Okta CLI](https://cli.okta.com)
- An [Azure account with a subscription](https://azure.microsoft.com/en-us/)

* [Getting Started](#getting-started)
* [Links](#links)
* [Help](#help)
* [License](#license)

## Getting Started

To pull this example, first create an empty github repo.  Next run the following commands:

```bash
git clone https://github.com/nickolasfisher/Okta_Cosmos.git
cd Okta_Cosmos
```

### Create an OIDC Application in Okta

Create a free developer account with the following command using the [Okta CLI](https://cli.okta.com):

```shell
okta register
```
If you already have a developer account, use `okta login` to integrate it with the Okta CLI. 
Create a client application in Okta with the following command:

```shell
okta apps create
```

You will be prompted to select the following options:
- Application name: Azure-Static-App
- Type of Application: **Webz8*
- Callback: `http://localhost:5001/authorization-code/callback`
- Post Logout Redirect URI: `http://localhost:5001/signout/callback`

The application configuration will be printed to a file called `.okta.env`. 

### Create an Azure CosmosDB account

Navigate to [the Azure portal](https://portal.azure.com) and select **Create a resource**.  Search for `Azure Cosmos DB` and select the option.  Follow the prompt and select **Create** on the Azure Cosmos DB marketing page.

Next, you will see a page asking which API best suits your workload.  Find *Core (SQL) - Recommended* and press **Create**.  

The *Create Azure Cosmos DB Account - Core (SQL)* page provides the details about your subscription and resource group.  Make sure you select `Apply` under the *Apply Free Tier Discount* then press **Review + create**.

### Update the values in your project

Create a copy of `appsettings.json` named `appsettings.Development.json`.  Replace the settings in `Okta` with the values in `.okta.env`.

Replace the empty values in `CosmosDb` with those found in your Azure portal.   To find your Cosmos values navigate to your Cosmos DB account page and open the `Settings > Keys` tab.  Here you will find the `URI`, `PRIMARY KEY`, and other values you may need down the line.

You can now run your application locally.

## Links

This example uses the following open source libraries from Okta:

* [Okta with ASP.NET](https://github.com/okta/okta-aspnet)
* [Okta CLI](https://github.com/okta/okta-cli)

## Help

Please post any questions as comments on the [blog post][blog], or visit our [Okta Developer Forums](https://devforum.okta.com/).

## License

Apache 2.0, see [LICENSE](LICENSE).

[blog]: https://developer.okta.com/blog/2021/xyz
