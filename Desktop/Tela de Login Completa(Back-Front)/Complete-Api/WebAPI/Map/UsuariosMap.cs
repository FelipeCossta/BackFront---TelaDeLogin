using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebAPI.Models;

namespace WebAPI.Map
{
    public class UsuariosMap : IEntityTypeConfiguration<UsuariosModel>
    {
        public void Configure(EntityTypeBuilder<UsuariosModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Password).IsRequired().HasMaxLength(1000);
            builder.Property(x => x.Email).IsRequired().HasMaxLength(150);
        }
    }
}
