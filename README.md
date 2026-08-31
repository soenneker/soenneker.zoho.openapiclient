[![](https://img.shields.io/nuget/v/soenneker.zoho.openapiclient.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.zoho.openapiclient/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.zoho.openapiclient/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.zoho.openapiclient/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.zoho.openapiclient.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.zoho.openapiclient/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.zoho.openapiclient/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.zoho.openapiclient/actions/workflows/codeql.yml)

# ![](https://user-images.githubusercontent.com/4441470/224455560-91ed3ee7-f510-4041-a8d2-3fc093025112.png) Soenneker.Zoho.OpenApiClient

A Kiota-generated .NET client for Zoho CRM v8, with typed request builders and response models.

## Installation

```shell
dotnet add package Soenneker.Zoho.OpenApiClient
```

## Usage

The generated client requires a Kiota request adapter, a Zoho OAuth access token, and the CRM API domain for the account's data center:

```csharp
using Microsoft.Kiota.Abstractions.Authentication;
using Microsoft.Kiota.Http.HttpClientLibrary;
using Soenneker.Zoho.OpenApiClient;
using Soenneker.Zoho.OpenApiClient.Users;
using System.Net.Http.Headers;

using var httpClient = new HttpClient();
httpClient.DefaultRequestHeaders.Authorization =
    new AuthenticationHeaderValue("Zoho-oauthtoken", accessToken);

var adapter = new HttpClientRequestAdapter(
    new AnonymousAuthenticationProvider(),
    httpClient: httpClient)
{
    BaseUrl = "https://www.zohoapis.com/crm/v8"
};

var client = new ZohoOpenApiClient(adapter);

var response = await client.Users.GetAsync(request =>
{
    request.QueryParameters.Type = GetTypeQueryParameterType.AllUsers;
    request.QueryParameters.PerPage = 25;
}, cancellationToken);

foreach (var user in response?.Users ?? [])
    Console.WriteLine($"{user.FullName} ({user.Email})");
```

Use the `api_domain` returned by Zoho's token endpoint. For example, EU accounts use `https://www.zohoapis.eu/crm/v8`. The package sends requests but does not obtain or refresh access tokens.

Request builders are rooted at the versioned CRM URL, so the generated `client.Users` builder calls `/crm/v8/users`.
