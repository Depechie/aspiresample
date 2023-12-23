using Aspire.Hosting.Utils;

public static class OtlpEndpointExtensions
{
    private const string DashboardOtlpUrlVariableName = "DOTNET_DASHBOARD_OTLP_ENDPOINT_URL";
    private const string DashboardOtlpUrlDefaultValue = "http://localhost:18889";

    // Adds the dashboard OTLP endpoint URL to the environment variables of the resource with the specified name.
    public static IResourceBuilder<T> WithDashboardEndpoint<T>(this IResourceBuilder<T> builder, string name)
        where T : IResourceWithEnvironment
    {
        var configuration = builder.ApplicationBuilder.Configuration;

        return builder.WithEnvironment(context =>
        {
            var url = configuration[DashboardOtlpUrlVariableName] ?? DashboardOtlpUrlDefaultValue;
            context.EnvironmentVariables[name] = builder.Resource is ContainerResource
                ? HostNameResolver.ReplaceLocalhostWithContainerHost(url, configuration)
                : url;
        });
    }
}