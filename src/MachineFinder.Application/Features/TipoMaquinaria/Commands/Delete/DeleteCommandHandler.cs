using MachineFinder.Application.Contracts.Persistence;

namespace MachineFinder.Application.Features.TipoMaquinaria.Commands.Delete
{
    public class DeleteCommandHandler : MediatR.IRequestHandler<DeleteCommand, string>
    {
        protected readonly ITipoMaquinariaRepository repository;

        public DeleteCommandHandler(ITipoMaquinariaRepository repository)
        {
            this.repository = repository;
        }

        public async Task<string> Handle(DeleteCommand request, CancellationToken cancellationToken)
        {
            return await repository.Delete(request);
        }
    }
}
