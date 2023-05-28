using EventMaster.Api;
using EventMaster.Application;
using EventMaster.Infrastructure;
using EventMaster.Infrastructure.Middlewares;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services
        .AddPresentation()
        .AddApplication()
        .AddInfrastructure(builder.Configuration);
}

var app = builder.Build();
{
    app.UseExceptionHandler("/error");

    app.UseHttpsRedirection();

    app.UseWhen(
        context => context.Request.Path.StartsWithSegments("/event"),
        appBuilder =>
        {
            appBuilder.UseMiddleware<CustomAuthMiddleware>();
        }
    );

    app.MapControllers();

    app.Run();
}