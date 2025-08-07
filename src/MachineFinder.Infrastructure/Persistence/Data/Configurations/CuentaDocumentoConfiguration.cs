using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MachineFinder.Domain.Entities;

namespace MachineFinder.Infrastructure.Persistence.Data.Configurations
{
    public class CuentaDocumentoConfiguration : IEntityTypeConfiguration<CuentaDocumentoEntity>
    {
        public void Configure(EntityTypeBuilder<CuentaDocumentoEntity> builder)
        {
            builder.ToTable("CUENTA_DOCUMENTO");
            builder.HasKey(e => e.id_cuenta_documento);

            builder.Property(p => p.id_cuenta_documento).HasColumnName("id_cuenta_documento");
            builder.Property(p => p.id_cuenta).HasColumnName("id_cuenta");
            builder.Property(p => p.cod_documento).HasColumnName("cod_documento");
            builder.Property(p => p.nom_documento).HasColumnName("nom_documento");
            builder.Property(p => p.ext_documento).HasColumnName("ext_documento");
            builder.Property(p => p.url_documento).HasColumnName("url_documento");
            builder.Property(p => p.ind_registro).HasColumnName("ind_registro");
            builder.Property(p => p.cod_entorno).HasColumnName("cod_entorno");
            
            builder.SetAudithory();

            builder.HasOne(o => o.cuenta).WithMany(m => m.cuenta_documentos).HasForeignKey(f => f.id_cuenta);
            builder.HasMany(m => m.cuenta_documento_historiales).WithOne(o => o.cuenta_documento).HasForeignKey(f => f.id_cuenta_documento);
        }
    }
}
