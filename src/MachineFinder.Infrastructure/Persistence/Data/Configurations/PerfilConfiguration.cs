using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MachineFinder.Domain.Entities;

namespace MachineFinder.Infrastructure.Persistence.Data.Configurations
{
    public class PerfilConfiguration : IEntityTypeConfiguration<PerfilEntity>
    {
        public void Configure(EntityTypeBuilder<PerfilEntity> builder)
        {
            builder.ToTable("PERFIL");
            builder.HasKey(e => e.id_perfil);

            builder.Property(p => p.id_perfil).HasColumnName("id_perfil");
            builder.Property(p => p.cod_perfil).HasColumnName("cod_perfil");
            builder.Property(p => p.nom_perfil).HasColumnName("nom_perfil");
            builder.Property(p => p.url_perfil).HasColumnName("url_perfil");
            
            builder.SetAudithory();

            builder.HasMany(m => m.usuario_perfiles).WithOne(o => o.perfil).HasForeignKey(f => f.id_perfil);
        }
    }
}
