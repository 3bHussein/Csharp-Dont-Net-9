var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.WebApplication4>("webapplication4");

builder.Build().Run();
