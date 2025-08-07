using MachineFinder.Application.Contracts.Persistence;

namespace MachineFinder.Application.Features.Licencia.Commands.Delete
{
    public class DeleteCommandHandler : MediatR.IRequestHandler<DeleteCommand, string>
    {
        protected readonly ILicenciaRepository repository;

        public DeleteCommandHandler(ILicenciaRepository repository)
        {
            this.repository = repository;
        }

        public async Task<string> Handle(DeleteCommand request, CancellationToken cancellationToken)
        {
            return await repository.Delete(request);
        }
    }
}
