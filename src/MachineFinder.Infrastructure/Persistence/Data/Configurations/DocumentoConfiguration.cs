using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MachineFinder.Domain.Entities;

namespace MachineFinder.Infrastructure.Persistence.Data.Configurations
{
    public class DocumentoConfiguration : IEntityTypeConfiguration<DocumentoEntity>
    {
        public void Configure(EntityTypeBuilder<DocumentoEntity> builder)
        {
            builder.ToTable("DOCUMENTO");
            builder.HasKey(e => e.id_documento);

            builder.Property(p => p.id_documento).HasColumnName("id_documento");
            builder.Property(p => p.id_perfil).HasColumnName("id_perfil");
            builder.Property(p => p.nom_documento).HasColumnName("nom_documento");
            builder.Property(p => p.ind_requerido).HasColumnName("ind_requerido");
            
            builder.SetAudithory();

            builder.HasOne(o => o.perfil).WithMany(m => m.documentos).HasForeignKey(f => f.id_perfil);
        }
    }
}
