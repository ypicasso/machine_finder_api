using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MachineFinder.Domain.Entities;

namespace MachineFinder.Infrastructure.Persistence.Data.Configurations
{
    public class TipoMaquinariaConfiguration : IEntityTypeConfiguration<TipoMaquinariaEntity>
    {
        public void Configure(EntityTypeBuilder<TipoMaquinariaEntity> builder)
        {
            builder.ToTable("TIPO_MAQUINARIA");
            builder.HasKey(e => e.id_tipo_maquinaria);

            builder.Property(p => p.id_tipo_maquinaria).HasColumnName("id_tipo_maquinaria");
            builder.Property(p => p.cod_tipo_maquina).HasColumnName("cod_tipo_maquina");
            builder.Property(p => p.nom_tipo_maquina).HasColumnName("nom_tipo_maquina");
            builder.Property(p => p.url_imagen).HasColumnName("url_imagen");
            
            builder.SetAudithory();

        }
    }
}
