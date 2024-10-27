namespace Services.Fornecedor;

using Database;
using Entities;
using Microsoft.EntityFrameworkCore;

public static class FornecedorSvc{
    public static async Task<Fornecedor[]> GetAllFornecedor(APIContext context){
        var list = await context.Fornecedores.ToArrayAsync();
        return list;
    }

    public static async Task<Fornecedor?> GetFornecedor(int id, APIContext context){
        var forn = await context.Fornecedores.FindAsync(id);
        return forn;
    }

    public static async Task<bool> CreateFornecedor(FornecedorDTO F, APIContext context){
        var forn = new Fornecedor {
            Nome = F.Nome,
            Email = F.Email
        };
        await context.Fornecedores.AddAsync(forn);
        await context.SaveChangesAsync();
        return true;
    }

    public static async Task<bool> DeleteFornecedor(int id, APIContext context){
        var forn = await context.Fornecedores.FindAsync(id);
        if (forn is null)
            return false;

        context.Fornecedores.Remove(forn);
        await context.SaveChangesAsync();
        return true;
    }

    public static async Task<bool> UpdateFornecedor(int id, FornecedorDTO F, APIContext context){
        var forn = await context.Fornecedores.FindAsync(id);
        if (forn is null)
            return false;

        forn.Nome = F.Nome;
        forn.Email = F.Email;

        await context.SaveChangesAsync();
        return true;
    }
}