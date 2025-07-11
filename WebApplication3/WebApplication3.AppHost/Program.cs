var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.WebApplication3>("webapplication3");

builder.Build().Run();
