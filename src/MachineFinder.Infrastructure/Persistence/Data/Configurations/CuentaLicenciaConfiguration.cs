using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MachineFinder.Domain.Entities;

namespace MachineFinder.Infrastructure.Persistence.Data.Configurations
{
    public class CuentaLicenciaConfiguration : IEntityTypeConfiguration<CuentaLicenciaEntity>
    {
        public void Configure(EntityTypeBuilder<CuentaLicenciaEntity> builder)
        {
            builder.ToTable("CUENTA_LICENCIA");
            builder.HasKey(e => e.id_cuenta_licencia);

            builder.Property(p => p.id_cuenta_licencia).HasColumnName("id_cuenta_licencia");
            builder.Property(p => p.id_cuenta).HasColumnName("id_cuenta");
            builder.Property(p => p.id_licencia).HasColumnName("id_licencia");
            builder.Property(p => p.tit_licencia).HasColumnName("tit_licencia");
            builder.Property(p => p.can_meses).HasColumnName("can_meses");
            builder.Property(p => p.mas_meses).HasColumnName("mas_meses");
            builder.Property(p => p.val_licencia).HasColumnName("val_licencia");
            builder.Property(p => p.ind_oferta).HasColumnName("ind_oferta");
            builder.Property(p => p.ind_mixto).HasColumnName("ind_mixto");
            builder.Property(p => p.cod_origen).HasColumnName("cod_origen");
            builder.Property(p => p.cod_entorno).HasColumnName("cod_entorno");
            builder.Property(p => p.fec_compra).HasColumnName("fec_compra");
            builder.Property(p => p.fec_expiracion).HasColumnName("fec_expiracion");
            
            builder.SetAudithory();

            builder.HasOne(o => o.cuenta).WithMany(m => m.cuenta_licencias).HasForeignKey(f => f.id_cuenta);
            builder.HasOne(o => o.licencia).WithMany(m => m.cuenta_licencias).HasForeignKey(f => f.id_licencia);
        }
    }
}
