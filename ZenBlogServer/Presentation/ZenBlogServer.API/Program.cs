using Scalar.AspNetCore;
using ZenBlogServer.API.CustomMiddlewares;
using ZenBlogServer.API.EndpointRegistration;
using ZenBlogServer.Application.Extensions;
using ZenBlogServer.Persistence.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplication();
builder.Services.AddPersistence(builder.Configuration);

builder.Services.AddControllers();
builder.Services.AddOpenApi();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseMiddleware<CustomExceptionHandlingMiddleware>();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.MapGroup("/api").RegisterEndpoints();
app.Run();