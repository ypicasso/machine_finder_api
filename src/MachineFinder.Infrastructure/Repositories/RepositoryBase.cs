using MachineFinder.Application.Contracts.Persistence;
using MachineFinder.Domain;
using MachineFinder.Domain.Entities;
using MachineFinder.Infrastructure.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace MachineFinder.Infrastructure.Repositories
{
    public class RepositoryBase<T> : IAsyncRepository<T> where T : BaseDomainModel
    {
        protected const string BOX_STYLE = "box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px;background-color: #EDEEF0;margin: 50px;padding: 30px;border-radius: 15px;";

        protected readonly AppDBContext _context;
        private readonly SessionStorage? _sessionStorage;

        protected readonly string? ID_USUARIO;
        protected readonly string? COD_USUARIO;
        protected readonly string? NOM_USUARIO;
        protected readonly string? USU_EMAIL;

        protected readonly string? COD_PERFIL;
        protected readonly bool ES_MOBILE;

        public RepositoryBase(AppDBContext context, SessionStorage? sessionStorage)
        {
            _context = context;
            _sessionStorage = sessionStorage;

            if (sessionStorage != null)
            {
                var id_usuario = sessionStorage?.GetUser()?.IdUsuario;

                var userInfo = context.Usuario.FirstOrDefault(w => w.id_usuario == id_usuario);

                if (userInfo != null)
                {
                    ID_USUARIO = userInfo?.id_usuario;
                    COD_USUARIO = userInfo?.cod_usuario;
                    NOM_USUARIO = $"{userInfo?.nom_usuario ?? ""} {userInfo?.ape_paterno ?? ""} {userInfo?.ape_materno ?? ""}".Trim();
                    USU_EMAIL = userInfo?.usu_email;

                    COD_PERFIL = _sessionStorage?.GetUser()?.CodPerfil ?? "";
                    ES_MOBILE = _sessionStorage?.GetUser()?.EsMobile ?? false;
                }
            }
        }

        public static DateTime NOW
        {
            get
            {
                return BaseDomainModel.GetNow();
            }
        }

        public async Task<T> AddAsync(T entity)
        {
            _context.Entry(entity).State = EntityState.Added;
            _context.Set<T>().Add(entity);

            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task DeleteAsync(T entity)
        {
            _context.Entry(entity).State = EntityState.Deleted;

            await _context.SaveChangesAsync();
        }

        public async Task DisableAsync(T entity)
        {
            _context.Entry(entity).State = EntityState.Deleted;

            await _context.SaveChangesAsync();
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<T> UpdateAsync(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.Set<T>().Update(entity);

            await _context.SaveChangesAsync();

            return entity;
        }

        public void ThrowTrue(bool condition, string message)
        {
            if (condition)
            {
                throw new Exception(message);
            }
        }

        public void ThrowTrue(BaseDomainModel? model, string message)
        {
            ThrowTrue(!(model?.cod_estado ?? false), message);
        }

        public void ThrowActive(BaseDomainModel? model, string message)
        {
            ThrowTrue(model != null && model!.cod_estado == true, message);
        }

        public async Task AddEntityAsync<D>(D entity) where D : BaseDomainModel
        {
            _context.Entry(entity).State = EntityState.Added;
            _context.Set<D>().Add(entity);

            await _context.SaveChangesAsync();
        }

        public async Task UpdateEntityAsync<D>(D entity) where D : BaseDomainModel
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.Set<D>().Update(entity);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteEntityAsync<D>(D entity) where D : BaseDomainModel
        {
            _context.Entry(entity).State = EntityState.Deleted;
            // _context.Set<D>().Update(entity);

            await _context.SaveChangesAsync();
        }

        protected string NewGuid() => Guid.NewGuid().ToString();
    }
}
