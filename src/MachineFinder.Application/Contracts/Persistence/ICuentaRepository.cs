using MachineFinder.Application.Features.Cuenta.Commands.ChangePassword;

namespace MachineFinder.Application.Contracts.Persistence
{
    public interface ICuentaRepository
    {
        Task<string> ChangePassword(ChangePasswordCommand request);
    }
}
