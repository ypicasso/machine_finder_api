using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MachineFinder.Domain.Entities;

namespace MachineFinder.Infrastructure.Persistence.Data.Configurations
{
    public class ContraseniaConfiguration : IEntityTypeConfiguration<ContraseniaEntity>
    {
        public void Configure(EntityTypeBuilder<ContraseniaEntity> builder)
        {
            builder.ToTable("CONTRASENIA");
            builder.HasKey(e => e.id_contrasenia);

            builder.Property(p => p.id_contrasenia).HasColumnName("id_contrasenia");
            builder.Property(p => p.id_usuario).HasColumnName("id_usuario");
            builder.Property(p => p.pwd_usuario).HasColumnName("pwd_usuario");
            
            builder.SetAudithory();

            builder.HasOne(o => o.usuario).WithMany(m => m.contrasenias).HasForeignKey(f => f.id_usuario);
        }
    }
}
