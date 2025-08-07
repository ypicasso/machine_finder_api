using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MachineFinder.Domain.Entities;

namespace MachineFinder.Infrastructure.Persistence.Data.Configurations
{
    public class CuentaConfiguration : IEntityTypeConfiguration<CuentaEntity>
    {
        public void Configure(EntityTypeBuilder<CuentaEntity> builder)
        {
            builder.ToTable("CUENTA");
            builder.HasKey(e => e.id_cuenta);

            builder.Property(p => p.id_cuenta).HasColumnName("id_cuenta");
            builder.Property(p => p.id_usuario).HasColumnName("id_usuario");
            builder.Property(p => p.id_perfil).HasColumnName("id_perfil");
            
            builder.SetAudithory();

            builder.HasOne(o => o.perfil).WithMany(m => m.cuentas).HasForeignKey(f => f.id_perfil);
            builder.HasOne(o => o.usuario).WithMany(m => m.cuentas).HasForeignKey(f => f.id_usuario);
            builder.HasMany(m => m.cuenta_documentos).WithOne(o => o.cuenta).HasForeignKey(f => f.id_cuenta);
            builder.HasMany(m => m.cuenta_licencias).WithOne(o => o.cuenta).HasForeignKey(f => f.id_cuenta);
            builder.HasMany(m => m.cuenta_maquinarias).WithOne(o => o.cuenta).HasForeignKey(f => f.id_cuenta);
        }
    }
}
