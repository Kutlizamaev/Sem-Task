using CarFleet.HOST.Configuration;
using CarFleet.HOST.LoggingException;

var builder = WebApplication.CreateBuilder(args);

builder.Services.IdentityRegister(builder.Configuration);
builder.Services.DataBaseRegister(builder.Configuration);
builder.Services.SwaggerRegister();
builder.Services.ServicesRegister();
builder.Services.CorsRegister();

var app = builder.Build();

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.SwaggerConfigure();
app.CorsConfigure();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();