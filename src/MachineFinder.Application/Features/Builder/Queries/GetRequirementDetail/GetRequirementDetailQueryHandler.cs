using MachineFinder.Application.Contracts.Persistence;

namespace MachineFinder.Application.Features.Builder.Queries.GetRequirementDetail
{
    public class GetRequirementDetailQueryHandler : MediatR.IRequestHandler<GetRequirementDetailQuery, string>
    {
        protected readonly IBuilderRepository repository;

        public GetRequirementDetailQueryHandler(IBuilderRepository repository)
        {
            this.repository = repository;
        }

        public async Task<string> Handle(GetRequirementDetailQuery request, CancellationToken cancellationToken)
        {
            return await repository.GetRequirementDetail(request);
        }
    }
}
