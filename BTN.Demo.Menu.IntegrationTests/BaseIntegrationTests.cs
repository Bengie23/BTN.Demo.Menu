using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace BTN.Demo.Menu.IntegrationTests
{
    [TestClass]
    public abstract class BaseIntegrationTests
    {
        protected static IHost host { get; private set; }
        protected static HttpClient client { get; private set; }
        protected static TestServer server { get; private set; }

        protected static Dictionary<string,string> configValues { get; set; }

        protected static async Task Initialize()
        {
            var _configuration = new ConfigurationBuilder()
           .AddJsonFile("appsettings.test.json")
           .AddInMemoryCollection(configValues)
           .Build();

            var hostBuilder = new HostBuilder()
                .ConfigureWebHost(webHost =>
                {

                    webHost.UseTestServer();
                    webHost.UseEnvironment("Test");
                    webHost.UseConfiguration(_configuration);
                    webHost.UseStartup<Startup>();
                });

            host = await hostBuilder.StartAsync();

            client = host.GetTestClient();

            server = host.GetTestServer();
        }

        protected static void Dispose()
        {

            host.Dispose();
            host = null;

            client.Dispose();
            client = null;

            server.Dispose();
            server = null;


        }
    }
}
