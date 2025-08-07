using MachineFinder.Application.Contracts.Persistence;

namespace MachineFinder.Application.Features.Licencia.Commands.Update
{
    public class UpdateCommandHandler : MediatR.IRequestHandler<UpdateCommand, string>
    {
        protected readonly ILicenciaRepository repository;

        public UpdateCommandHandler(ILicenciaRepository repository)
        {
            this.repository = repository;
        }

        public async Task<string> Handle(UpdateCommand request, CancellationToken cancellationToken)
        {
            return await repository.Update(request);
        }
    }
}
