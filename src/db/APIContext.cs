using Entities;
using Microsoft.EntityFrameworkCore;

namespace Database;

public class APIContext(DbContextOptions<APIContext> options): DbContext(options){
    public DbSet<Fornecedor> Fornecedores {get;set;}
}