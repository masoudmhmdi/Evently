using Evently.Module.Events.Infrastructure;
using Evently.Module.Events.Infrastructure.Database.Extension;
using Scalar.AspNetCore;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);


// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApi();

builder.Services.AddEventsModule(builder.Configuration);
WebApplication app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
    app.ApplyMigrations();
}


app.UseHttpsRedirection();

app.MapEventModuleEndpoints();


app.Run();

