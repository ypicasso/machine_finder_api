using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MachineFinder.Domain.Entities;

namespace MachineFinder.Infrastructure.Persistence.Data.Configurations
{
    public class CuentaMaquinariaConfiguration : IEntityTypeConfiguration<CuentaMaquinariaEntity>
    {
        public void Configure(EntityTypeBuilder<CuentaMaquinariaEntity> builder)
        {
            builder.ToTable("CUENTA_MAQUINARIA");
            builder.HasKey(e => e.id_cuenta_maquinaria);

            builder.Property(p => p.id_cuenta_maquinaria).HasColumnName("id_cuenta_maquinaria");
            builder.Property(p => p.id_cuenta).HasColumnName("id_cuenta");
            builder.Property(p => p.id_tipo_maquinaria).HasColumnName("id_tipo_maquinaria");
            builder.Property(p => p.cod_marca).HasColumnName("cod_marca");
            builder.Property(p => p.nom_marca).HasColumnName("nom_marca");
            builder.Property(p => p.cod_modelo).HasColumnName("cod_modelo");
            builder.Property(p => p.nom_modelo).HasColumnName("nom_modelo");
            builder.Property(p => p.cod_departamento).HasColumnName("cod_departamento");
            builder.Property(p => p.nom_departamento).HasColumnName("nom_departamento");
            builder.Property(p => p.cod_provincia).HasColumnName("cod_provincia");
            builder.Property(p => p.nom_provincia).HasColumnName("nom_provincia");
            builder.Property(p => p.cod_distrito).HasColumnName("cod_distrito");
            builder.Property(p => p.nom_distrito).HasColumnName("nom_distrito");
            builder.Property(p => p.cod_status).HasColumnName("cod_status");
            builder.Property(p => p.nom_status).HasColumnName("nom_status");
            
            builder.SetAudithory();

            builder.HasOne(o => o.cuenta).WithMany(m => m.cuenta_maquinarias).HasForeignKey(f => f.id_cuenta);
        }
    }
}
