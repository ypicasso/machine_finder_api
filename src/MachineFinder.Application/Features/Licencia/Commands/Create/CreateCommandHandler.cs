using MachineFinder.Application.Contracts.Persistence;

namespace MachineFinder.Application.Features.Licencia.Commands.Create
{
    public class CreateCommandHandler : MediatR.IRequestHandler<CreateCommand, string>
    {
        protected readonly ILicenciaRepository repository;

        public CreateCommandHandler(ILicenciaRepository repository)
        {
            this.repository = repository;
        }

        public async Task<string> Handle(CreateCommand request, CancellationToken cancellationToken)
        {
            return await repository.Create(request);
        }
    }
}
