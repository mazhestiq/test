using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;

namespace Cinema.WebApi.Tests;

public class ServerFixture: IDisposable
{
    public TestServer TestServer { get; private set; }

    public ServerFixture()
    {
        TestServer = new TestServer(new WebHostBuilder().UseStartup<TestStartup>());
    }

    public void Dispose()
    {
        TestServer.Dispose();
    }
}