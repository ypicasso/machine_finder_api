using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MachineFinder.Domain.Entities;

namespace MachineFinder.Infrastructure.Persistence.Data.Configurations
{
    public class UsuarioPerfilConfiguration : IEntityTypeConfiguration<UsuarioPerfilEntity>
    {
        public void Configure(EntityTypeBuilder<UsuarioPerfilEntity> builder)
        {
            builder.ToTable("USUARIO_PERFIL");
            builder.HasKey(e => e.id_usuario_perfil);

            builder.Property(p => p.id_usuario_perfil).HasColumnName("id_usuario_perfil");
            builder.Property(p => p.id_usuario).HasColumnName("id_usuario");
            builder.Property(p => p.id_perfil).HasColumnName("id_perfil");
            
            builder.SetAudithory();

            builder.HasOne(o => o.perfil).WithMany(m => m.usuario_perfiles).HasForeignKey(f => f.id_perfil);
            builder.HasOne(o => o.usuario).WithMany(m => m.usuario_perfiles).HasForeignKey(f => f.id_usuario);
        }
    }
}
