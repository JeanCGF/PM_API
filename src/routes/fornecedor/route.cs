namespace Routes.Fornecedor;

using Database;
using Entities;
using Services.Fornecedor;
public static class FornecedorRoutes{
    public static void AddFornecedorRoutes(this WebApplication app){
        app.MapGet("/fornecedor", async (APIContext context) => {
            var list = await FornecedorSvc.GetAllFornecedor(context);
            if(list.Length > 0)
                return Results.Ok(list);
            else
                return Results.NotFound("Nenhum Fornecedor encontrado");
        });

        app.MapGet("/fornecedor/{id}", async (int id, APIContext context) => {
            var forn = await FornecedorSvc.GetFornecedor(id, context);
            if(forn != null)
                return Results.Ok(forn);
            else
                return Results.NotFound("Fornecedor com id especificado não encontrado");
        });

        app.MapPost("/fornecedor", async (FornecedorDTO forn, APIContext context) => {
            await FornecedorSvc.CreateFornecedor(forn, context);
            return Results.NoContent();
        });

        app.MapDelete("/fornecedor/{id}", async (int id, APIContext context) => {
            var result = await FornecedorSvc.DeleteFornecedor(id, context);
            if(result)
                return Results.NoContent();
            else
                return Results.NotFound("Fornecedor com id especificado não encontrado");
        });

        app.MapPut("/fornecedor/{id}", async (int id, FornecedorDTO forn, APIContext context) => {
            await FornecedorSvc.UpdateFornecedor(id, forn, context);
            return Results.NoContent();
        });
    }
}