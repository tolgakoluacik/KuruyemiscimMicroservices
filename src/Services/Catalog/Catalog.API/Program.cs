var builder = WebApplication.CreateBuilder(args);

//Add services to the container. For Dependency Injection
builder.Services.AddCarter();
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(typeof(Program).Assembly);
});
builder.Services.AddMarten(opts =>
{
    opts.Connection(builder.Configuration.GetConnectionString("Database")!);
})
.UseLightweightSessions();

var app = builder.Build();

//Configure HTTP requests pipeline. 

app.MapCarter();

app.Run();

