using Bogus;

namespace Api.FunctionalTests.Infrastructure;

public abstract class BaseFunctionalTest : IClassFixture<FunctionalTestWebAppFactory>
{
    protected BaseFunctionalTest(FunctionalTestWebAppFactory factory)
    {
        HttpClient = factory.CreateClient();
        Faker = new Faker();
    }

    protected HttpClient HttpClient { get; set; }

    protected Faker Faker { get; }
}
