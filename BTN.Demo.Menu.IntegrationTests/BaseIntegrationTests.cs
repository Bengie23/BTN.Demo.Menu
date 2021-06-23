using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Hosting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
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

        protected static async Task Initialize()
        {
            var hostBuilder = new HostBuilder()
                .ConfigureWebHost(webHost =>
                {
                    webHost.UseTestServer();
                    webHost.UseEnvironment("Test");
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
