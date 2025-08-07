using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MachineFinder.Domain.Entities;

namespace MachineFinder.Infrastructure.Persistence.Data.Configurations
{
    public class CuentaDocumentoHistorialConfiguration : IEntityTypeConfiguration<CuentaDocumentoHistorialEntity>
    {
        public void Configure(EntityTypeBuilder<CuentaDocumentoHistorialEntity> builder)
        {
            builder.ToTable("CUENTA_DOCUMENTO_HISTORIAL");
            builder.HasKey(e => e.id_cuenta_documento_historial);

            builder.Property(p => p.id_cuenta_documento_historial).HasColumnName("id_cuenta_documento_historial");
            builder.Property(p => p.id_cuenta_documento).HasColumnName("id_cuenta_documento");
            builder.Property(p => p.nom_documento).HasColumnName("nom_documento");
            builder.Property(p => p.ext_documento).HasColumnName("ext_documento");
            builder.Property(p => p.url_documento).HasColumnName("url_documento");
            builder.Property(p => p.ind_registro).HasColumnName("ind_registro");
            builder.Property(p => p.cod_entorno).HasColumnName("cod_entorno");
            builder.Property(p => p.usu_aprobacion).HasColumnName("usu_aprobacion");
            builder.Property(p => p.fec_aprobacion).HasColumnName("fec_aprobacion");
            
            builder.SetAudithory();

            builder.HasOne(o => o.cuenta_documento).WithMany(m => m.cuenta_documento_historiales).HasForeignKey(f => f.id_cuenta_documento);
        }
    }
}
