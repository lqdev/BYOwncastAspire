var builder = DistributedApplication.CreateBuilder(args);

var owncast = builder
    .AddContainer(name: "owncast", image:"owncast/owncast")
    .WithBindMount("./data","/app/data")
    .WithHttpEndpoint(port:8080,targetPort:8080,name:"admin")
    .WithHttpEndpoint(port:1935,targetPort:1935,name:"streaming")
    .WithExternalHttpEndpoints();

builder.AddProject<Projects.BYOwncastAspire_Web>("webfrontend")
    .WithExternalHttpEndpoints();

builder.Build().Run();
