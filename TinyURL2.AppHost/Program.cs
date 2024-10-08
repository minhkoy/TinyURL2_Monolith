var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.TinyURL2_API>("tinyurl-api");
builder.AddNpmApp("tinyurl-client", "../TinyURL2.Web", "dev")
    .WithEndpoint(env: "development", scheme: "http", 
    port: 5173, isExternal:true);
//.WithExternalHttpEndpoints();
//builder.AddServiceDefaults();
builder.Build().Run();
