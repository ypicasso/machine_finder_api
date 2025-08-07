using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MachineFinder.Domain.Entities;

namespace MachineFinder.Infrastructure.Persistence.Data.Configurations
{
    public class LicenciaConfiguration : IEntityTypeConfiguration<LicenciaEntity>
    {
        public void Configure(EntityTypeBuilder<LicenciaEntity> builder)
        {
            builder.ToTable("LICENCIA");
            builder.HasKey(e => e.id_licencia);

            builder.Property(p => p.id_licencia).HasColumnName("id_licencia");
            builder.Property(p => p.id_perfil).HasColumnName("id_perfil");
            builder.Property(p => p.tit_licencia).HasColumnName("tit_licencia");
            builder.Property(p => p.can_meses).HasColumnName("can_meses");
            builder.Property(p => p.mas_meses).HasColumnName("mas_meses");
            builder.Property(p => p.val_licencia).HasColumnName("val_licencia");
            builder.Property(p => p.ind_oferta).HasColumnName("ind_oferta");
            builder.Property(p => p.ind_mixto).HasColumnName("ind_mixto");
            
            builder.SetAudithory();

            builder.HasOne(o => o.perfil).WithMany(m => m.licencias).HasForeignKey(f => f.id_perfil);
            builder.HasMany(m => m.cuenta_licencias).WithOne(o => o.licencia).HasForeignKey(f => f.id_licencia);
        }
    }
}
