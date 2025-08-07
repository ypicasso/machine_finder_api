using MachineFinder.Application.Contracts.Persistence;

namespace MachineFinder.Application.Features.Documento.Commands.Create
{
    public class CreateCommandHandler : MediatR.IRequestHandler<CreateCommand, string>
    {
        protected readonly IDocumentoRepository repository;

        public CreateCommandHandler(IDocumentoRepository repository)
        {
            this.repository = repository;
        }

        public async Task<string> Handle(CreateCommand request, CancellationToken cancellationToken)
        {
            return await repository.Create(request);
        }
    }
}
