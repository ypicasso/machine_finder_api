using MachineFinder.Application.Contracts.Persistence;

namespace MachineFinder.Application.Features.Builder.Queries.GetOwners
{
    public class GetOwnersQueryHandler : MediatR.IRequestHandler<GetOwnersQuery, string>
    {
        protected readonly IBuilderRepository repository;

        public GetOwnersQueryHandler(IBuilderRepository repository)
        {
            this.repository = repository;
        }

        public async Task<string> Handle(GetOwnersQuery request, CancellationToken cancellationToken)
        {
            return await repository.GetOwners(request);
        }
    }
}
