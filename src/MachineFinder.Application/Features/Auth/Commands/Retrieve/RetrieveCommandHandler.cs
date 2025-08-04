using MachineFinder.Application.Contracts.Persistence;

namespace MachineFinder.Application.Features.Auth.Commands.Retrieve
{
    public class RetrieveCommandHandler : MediatR.IRequestHandler<RetrieveCommand, string>
    {
        protected readonly IAuthRepository repository;

        public RetrieveCommandHandler(IAuthRepository repository)
        {
            this.repository = repository;
        }

        public async Task<string> Handle(RetrieveCommand request, CancellationToken cancellationToken)
        {
            return await repository.Retrieve(request);
        }
    }
}
