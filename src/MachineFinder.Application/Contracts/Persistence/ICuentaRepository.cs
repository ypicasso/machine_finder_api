using MachineFinder.Application.Features.Cuenta.Commands.ChangePassword;
using MachineFinder.Domain.Entities;

namespace MachineFinder.Application.Contracts.Persistence
{
    public interface ICuentaRepository : IAsyncRepository<UsuarioEntity>
    {
        Task<string> ChangePassword(ChangePasswordCommand request);
    }
}
