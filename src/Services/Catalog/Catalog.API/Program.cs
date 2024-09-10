using Catalog.API.Products.CreateProduct;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(typeof(Program).Assembly);
});

builder.Services.AddCarter(configurator: c =>
{
    c.WithModule<CreateProductEndpoint>(); // Replace "YourCarterModule" with the actual module class name
});

var app = builder.Build();

app.MapCarter();
app.Run();
