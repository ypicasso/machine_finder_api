using MachineFinder.Application.Contracts.Persistence;

namespace MachineFinder.Application.Features.Documento.Commands.Delete
{
    public class DeleteCommandHandler : MediatR.IRequestHandler<DeleteCommand, string>
    {
        protected readonly IDocumentoRepository repository;

        public DeleteCommandHandler(IDocumentoRepository repository)
        {
            this.repository = repository;
        }

        public async Task<string> Handle(DeleteCommand request, CancellationToken cancellationToken)
        {
            return await repository.Delete(request);
        }
    }
}
