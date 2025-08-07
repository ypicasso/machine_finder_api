using Microsoft.EntityFrameworkCore;
using MachineFinder.Domain;
using MachineFinder.Domain.Entities;

namespace MachineFinder.Infrastructure.Persistence.Data
{
    public class AppDBContext : DbContext
    {
        private readonly SessionStorage session;

        public AppDBContext(DbContextOptions<AppDBContext> options, SessionStorage sessionStorage) : base(options)
        {
            session = sessionStorage;
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<BaseDomainModel>())
            {
                switch (entry.State)
                {
                    case EntityState.Detached:
                        break;
                    case EntityState.Unchanged:
                        break;
                    case EntityState.Deleted:
                        entry.State = EntityState.Modified;

                        entry.Entity.cod_estado = false;
                        entry.Entity.fec_update = BaseDomainModel.GetNow();
                        entry.Entity.usu_update = session?.GetUser()?.CodUsuario;
                        break;
                    case EntityState.Modified:
                        entry.Entity.cod_estado = true;
                        entry.Entity.fec_update = BaseDomainModel.GetNow();
                        entry.Entity.usu_update = session?.GetUser()?.CodUsuario;
                        break;
                    case EntityState.Added:
                        entry.Entity.cod_estado = true;
                        entry.Entity.fec_insert = BaseDomainModel.GetNow();
                        entry.Entity.usu_insert = session?.GetUser()?.CodUsuario;
                        break;
                    default:
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDBContext).Assembly);
        }

        public virtual DbSet<CatalogoEntity> Catalogo { get; set; }
        public virtual DbSet<ContraseniaEntity> Contrasenia { get; set; }
        public virtual DbSet<CuentaEntity> Cuenta { get; set; }
        public virtual DbSet<CuentaDocumentoEntity> CuentaDocumento { get; set; }
        public virtual DbSet<CuentaDocumentoHistorialEntity> CuentaDocumentoHistorial { get; set; }
        public virtual DbSet<CuentaLicenciaEntity> CuentaLicencia { get; set; }
        public virtual DbSet<CuentaMaquinariaEntity> CuentaMaquinaria { get; set; }
        public virtual DbSet<DocumentoEntity> Documento { get; set; }
        public virtual DbSet<LicenciaEntity> Licencia { get; set; }
        public virtual DbSet<PerfilEntity> Perfil { get; set; }
        public virtual DbSet<TipoMaquinariaEntity> TipoMaquinaria { get; set; }
        public virtual DbSet<UsuarioEntity> Usuario { get; set; }
    }
}
