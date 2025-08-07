using MachineFinder.Application.Contracts.Persistence;

namespace MachineFinder.Application.Features.TipoMaquinaria.Commands.Create
{
    public class CreateCommandHandler : MediatR.IRequestHandler<CreateCommand, string>
    {
        protected readonly ITipoMaquinariaRepository repository;

        public CreateCommandHandler(ITipoMaquinariaRepository repository)
        {
            this.repository = repository;
        }

        public async Task<string> Handle(CreateCommand request, CancellationToken cancellationToken)
        {
            return await repository.Create(request);
        }
    }
}
