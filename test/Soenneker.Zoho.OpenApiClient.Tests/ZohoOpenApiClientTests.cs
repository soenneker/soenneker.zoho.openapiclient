using Soenneker.Tests.FixturedUnit;
using Xunit;

namespace Soenneker.Zoho.OpenApiClient.Tests;

[Collection("Collection")]
public sealed class ZohoOpenApiClientTests : FixturedUnitTest
{
    public ZohoOpenApiClientTests(Fixture fixture, ITestOutputHelper output) : base(fixture, output)
    {
    }

    [Fact]
    public void Default()
    {

    }
}
