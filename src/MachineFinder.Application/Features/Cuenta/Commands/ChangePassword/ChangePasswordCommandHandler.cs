using MachineFinder.Application.Contracts.Persistence;

namespace MachineFinder.Application.Features.Cuenta.Commands.ChangePassword
{
    public class ChangePasswordCommandHandler : MediatR.IRequestHandler<ChangePasswordCommand, string>
    {
        private readonly ICuentaRepository _repository;

        public ChangePasswordCommandHandler(ICuentaRepository repository)
        {
            _repository = repository;
        }

        public async Task<string> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
        {
            return await _repository.ChangePassword(request);
        }
    }
}
