using Microsoft.EntityFrameworkCore;
using WebAPI.Map;
using WebAPI.Models;

namespace WebAPI.Data;

public class UsuariosContext : DbContext
{
    public DbSet<UsuariosModel> Usuarios { get; set; }
    public UsuariosContext(DbContextOptions<UsuariosContext> options) 
        : base(options) 
    { 
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UsuariosMap());
        base.OnModelCreating(modelBuilder);
    }
}
