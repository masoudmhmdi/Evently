using Evently.API.Extension;
using Evently.Module.Events.API;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddEventsModule(builder.Configuration);
WebApplication app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.ApplyMigrations();
}

app.UseHttpsRedirection();


// ReSharper disable once InvokeAsExtensionMethod
EventsModule.MapEndpoints(app);


app.Run();

