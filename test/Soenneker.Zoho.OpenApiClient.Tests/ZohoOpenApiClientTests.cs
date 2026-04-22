using Soenneker.Tests.HostedUnit;

namespace Soenneker.Zoho.OpenApiClient.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public sealed class ZohoOpenApiClientTests : HostedUnitTest
{
    public ZohoOpenApiClientTests(Host host) : base(host)
    {
    }

    [Test]
    public void Default()
    {

    }
}
