using Routes.Fornecedor;
using Microsoft.OpenApi.Models;
using Database;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "Playmove API", Description = "Teste utilizando .Net 8.0", Version = "0.0.1" });
    });
builder.Services.AddDbContextPool<APIContext>(options => {
    options.UseNpgsql(builder.Configuration.GetConnectionString("PostgreSQL"));
});
//Missing Authentication/Authorization

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Playmove API Docs");
    c.RoutePrefix = "docs";
});
app.UsePathBase(new PathString("/api"));

app.AddFornecedorRoutes();

app.Run();
