using MachineFinder.Application.Contracts.Persistence;

namespace MachineFinder.Application.Features.Builder.Commands.RegisterRequirement
{
    public class RegisterRequirementCommandHandler : MediatR.IRequestHandler<RegisterRequirementCommand, string>
    {
        protected readonly IBuilderRepository repository;

        public RegisterRequirementCommandHandler(IBuilderRepository repository)
        {
            this.repository = repository;
        }

        public async Task<string> Handle(RegisterRequirementCommand request, CancellationToken cancellationToken)
        {
            return await repository.RegisterRequirement(request);
        }
    }
}
