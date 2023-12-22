var builder = DistributedApplication.CreateBuilder(args);

var apiService = builder.AddProject<Projects.aspiresample_ApiService>("apiservice");

builder.AddProject<Projects.aspiresample_Web>("webfrontend")
    .WithReference(apiService);

builder.Build().Run();
