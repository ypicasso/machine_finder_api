using MachineFinder.Application.Contracts.Persistence;

namespace MachineFinder.Application.Features.Documento.Commands.Update
{
    public class UpdateCommandHandler : MediatR.IRequestHandler<UpdateCommand, string>
    {
        protected readonly IDocumentoRepository repository;

        public UpdateCommandHandler(IDocumentoRepository repository)
        {
            this.repository = repository;
        }

        public async Task<string> Handle(UpdateCommand request, CancellationToken cancellationToken)
        {
            return await repository.Update(request);
        }
    }
}
