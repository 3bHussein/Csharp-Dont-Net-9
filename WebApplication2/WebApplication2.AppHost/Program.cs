var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.WebApplication2>("webapplication2");

builder.Build().Run();
