using FastEndpoints;
using FastEndpoints.Swagger;

var builder = WebApplication.CreateBuilder(args);
//Register middleware
builder.Services.AddFastEndpoints();
builder.Services.AddSwaggerDoc();
var app = builder.Build();
//Use middleware
app.UseFastEndpoints();
app.UseOpenApi();
app.UseSwaggerUi3(c => c.ConfigureDefaults());

app.Run();
