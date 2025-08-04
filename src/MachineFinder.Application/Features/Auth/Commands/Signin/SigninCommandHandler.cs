using MachineFinder.Application.Contracts.Persistence;
using MachineFinder.Domain.DTO.Auth;

namespace MachineFinder.Application.Features.Auth.Commands.Signin
{
    public class SigninCommandHandler : MediatR.IRequestHandler<SigninCommand, AuthDTO>
    {
        protected readonly IAuthRepository repository;

        public SigninCommandHandler(IAuthRepository repository)
        {
            this.repository = repository;
        }

        public async Task<AuthDTO> Handle(SigninCommand request, CancellationToken cancellationToken)
        {
            return await repository.Signin(request);
        }
    }
}
