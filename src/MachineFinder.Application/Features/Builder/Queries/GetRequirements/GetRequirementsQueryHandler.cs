using MachineFinder.Application.Contracts.Persistence;

namespace MachineFinder.Application.Features.Builder.Queries.GetRequirements
{
    public class GetRequirementsQueryHandler : MediatR.IRequestHandler<GetRequirementsQuery, string>
    {
        protected readonly IBuilderRepository repository;

        public GetRequirementsQueryHandler(IBuilderRepository repository)
        {
            this.repository = repository;
        }

        public async Task<string> Handle(GetRequirementsQuery request, CancellationToken cancellationToken)
        {
            return await repository.GetRequirements(request);
        }
    }
}
