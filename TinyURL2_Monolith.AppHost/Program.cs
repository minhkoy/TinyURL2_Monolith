var builder = DistributedApplication.CreateBuilder(args);

var tinyUrlApi = builder.AddProject<Projects.TinyURL2_API>("tinyurl2-api");

//var frontend = builder.AddNpmApp("react-fe", "../TinyURL_FE", "start")
//    .WithReference(tinyUrlApi);

builder.Build().Run();
