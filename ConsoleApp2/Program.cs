using Microsoft.Extensions.Hosting;

class Program
{
    static async Task Main(string[] args)
    {
        using (var endpointOneBuilder = ConfigureEndpointOne(Host.CreateDefaultBuilder(args)).Build())
        using (var endpointTwoBuilder = ConfigureEndpointTwo(Host.CreateDefaultBuilder(args)).Build())
        {
            await Task.WhenAll(endpointOneBuilder.StartAsync(), endpointTwoBuilder.StartAsync());
            await Task.WhenAll(endpointOneBuilder.WaitForShutdownAsync(), endpointTwoBuilder.WaitForShutdownAsync());
        }
    }

    static IHostBuilder ConfigureEndpointOne(IHostBuilder builder)
    {
        builder.UseWindowsService();

        return builder;
    }

    static IHostBuilder ConfigureEndpointTwo(IHostBuilder builder)
    {
        builder.UseWindowsService();

        return builder;
    }
}