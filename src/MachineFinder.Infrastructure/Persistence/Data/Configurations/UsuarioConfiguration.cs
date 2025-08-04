using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MachineFinder.Domain.Entities;

namespace MachineFinder.Infrastructure.Persistence.Data.Configurations
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<UsuarioEntity>
    {
        public void Configure(EntityTypeBuilder<UsuarioEntity> builder)
        {
            builder.ToTable("USUARIO");
            builder.HasKey(e => e.id_usuario);

            builder.Property(p => p.id_usuario).HasColumnName("id_usuario");
            builder.Property(p => p.cod_usuario).HasColumnName("cod_usuario");
            builder.Property(p => p.nom_usuario).HasColumnName("nom_usuario");
            builder.Property(p => p.ape_paterno).HasColumnName("ape_paterno");
            builder.Property(p => p.ape_materno).HasColumnName("ape_materno");
            builder.Property(p => p.fec_nacimiento).HasColumnName("fec_nacimiento");
            builder.Property(p => p.tip_documento).HasColumnName("tip_documento");
            builder.Property(p => p.num_documento).HasColumnName("num_documento");
            builder.Property(p => p.usu_email).HasColumnName("usu_email");
            builder.Property(p => p.num_telefono).HasColumnName("num_telefono");
            builder.Property(p => p.pwd_usuario).HasColumnName("pwd_usuario");
            builder.Property(p => p.fec_cese).HasColumnName("fec_cese");
            builder.Property(p => p.obs_cese).HasColumnName("obs_cese");
            builder.Property(p => p.tip_usuario).HasColumnName("tip_usuario");
            builder.Property(p => p.ind_confirmacion).HasColumnName("ind_confirmacion");
            builder.Property(p => p.fec_confirmacion).HasColumnName("fec_confirmacion");
            builder.Property(p => p.ind_repassword).HasColumnName("ind_repassword");
            builder.Property(p => p.fec_repassword).HasColumnName("fec_repassword");
            
            builder.SetAudithory();

            builder.HasMany(m => m.contrasenias).WithOne(o => o.usuario).HasForeignKey(f => f.id_usuario);
            builder.HasMany(m => m.usuario_perfiles).WithOne(o => o.usuario).HasForeignKey(f => f.id_usuario);
        }
    }
}
