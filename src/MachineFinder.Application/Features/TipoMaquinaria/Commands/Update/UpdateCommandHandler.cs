using MachineFinder.Application.Contracts.Persistence;

namespace MachineFinder.Application.Features.TipoMaquinaria.Commands.Update
{
    public class UpdateCommandHandler : MediatR.IRequestHandler<UpdateCommand, string>
    {
        protected readonly ITipoMaquinariaRepository repository;

        public UpdateCommandHandler(ITipoMaquinariaRepository repository)
        {
            this.repository = repository;
        }

        public async Task<string> Handle(UpdateCommand request, CancellationToken cancellationToken)
        {
            return await repository.Update(request);
        }
    }
}
