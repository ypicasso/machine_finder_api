using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MachineFinder.Domain.Entities;

namespace MachineFinder.Infrastructure.Persistence.Data.Configurations
{
    public class CatalogoConfiguration : IEntityTypeConfiguration<CatalogoEntity>
    {
        public void Configure(EntityTypeBuilder<CatalogoEntity> builder)
        {
            builder.ToTable("CATALOGO");
            builder.HasKey(e => e.id_catalogo);

            builder.Property(p => p.id_catalogo).HasColumnName("id_catalogo");
            builder.Property(p => p.cod_tabla).HasColumnName("cod_tabla");
            builder.Property(p => p.cod_campo).HasColumnName("cod_campo");
            builder.Property(p => p.nom_campo).HasColumnName("nom_campo");
            builder.Property(p => p.ext_campo).HasColumnName("ext_campo");
            builder.Property(p => p.ord_campo).HasColumnName("ord_campo");
            
            builder.SetAudithory();

        }
    }
}
