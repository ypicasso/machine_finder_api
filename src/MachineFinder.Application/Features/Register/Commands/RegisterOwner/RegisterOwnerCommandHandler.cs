using MachineFinder.Application.Contracts.Persistence;

namespace MachineFinder.Application.Features.Register.Commands.RegisterOwner
{
    public class RegisterOwnerCommandHandler : MediatR.IRequestHandler<RegisterOwnerCommand, string>
    {
        protected readonly IRegisterRepository repository;

        public RegisterOwnerCommandHandler(IRegisterRepository repository)
        {
            this.repository = repository;
        }

        public async Task<string> Handle(RegisterOwnerCommand request, CancellationToken cancellationToken)
        {
            return await repository.RegisterOwner(request);
        }
    }
}
