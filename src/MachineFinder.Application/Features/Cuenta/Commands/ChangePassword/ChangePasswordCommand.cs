using MachineFinder.Application.Features.Common;

namespace MachineFinder.Application.Features.Cuenta.Commands.ChangePassword
{
    public class ChangePasswordCommand : AppBaseCommand, MediatR.IRequest<string>
    {
        // Request Properties
        public string? old_password { get; set; }
        public string? new_password { get; set; }
        public string? con_password { get; set; }
    }
}
