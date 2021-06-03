using System;
using System.Net.Http;
using BunningsCodingChallengeAPI.Interfaces;
using BunningsCodingChallengeAPI.Tests.Fakes;
using BunningsCodingChallengeAPI.Tests.Infrastructure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Xunit;

namespace BunningsCodingChallengeAPI.Tests.Fixtures
{
    [CollectionDefinition(TestConstants.TestCollection)]
    public class MapperTestCollection : ICollectionFixture<BunningsCodingChallengeFixture>
    {
        // This class has no code, and is never created. Its purpose is simply
        // to be the place to apply [CollectionDefinition]
    }

    public class BunningsCodingChallengeFactory<TEntryPoint> : WebApplicationFactory<TEntryPoint> where TEntryPoint : class
    {
        protected override IWebHostBuilder CreateWebHostBuilder()
        {
            return new WebHostBuilder()
                .UseConfiguration(
                    new ConfigurationBuilder()
                        .Build())
                .UseStartup<TEntryPoint>();
        }
    }

    public class BunningsCodingChallengeFixture : IDisposable
    {
        private TestServer Server;
        public HttpClient Client { get; }

        public BunningsCodingChallengeFixture()
        {
            var factory = new BunningsCodingChallengeFactory<Startup>().WithWebHostBuilder(builder =>
            {
                builder.ConfigureTestServices(services =>
                {
                    services.Replace(ServiceDescriptor.Scoped<ICSVService, FakeCSVService>());
                });
            });

            Client = factory.CreateClient();
            Server = factory.Server;
        }

        public void Dispose()
        {
            Server?.Dispose();
            Client?.Dispose();
        }
    }
}
