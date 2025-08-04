using MachineFinder.Application.Contracts.Persistence;

namespace MachineFinder.Application.Features.Auth.Commands.Signout
{
    public class SignoutCommandHandler : MediatR.IRequestHandler<SignoutCommand, bool>
    {
        protected readonly IAuthRepository repository;

        public SignoutCommandHandler(IAuthRepository repository)
        {
            this.repository = repository;
        }

        public async Task<bool> Handle(SignoutCommand request, CancellationToken cancellationToken)
        {
            return await repository.Signout(request);
        }
    }
}
