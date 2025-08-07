using MachineFinder.Application.Contracts.Persistence;

namespace MachineFinder.Application.Features.Builder.Queries.GetOwnerDetail
{
    public class GetOwnerDetailQueryHandler : MediatR.IRequestHandler<GetOwnerDetailQuery, string>
    {
        protected readonly IBuilderRepository repository;

        public GetOwnerDetailQueryHandler(IBuilderRepository repository)
        {
            this.repository = repository;
        }

        public async Task<string> Handle(GetOwnerDetailQuery request, CancellationToken cancellationToken)
        {
            return await repository.GetOwnerDetail(request);
        }
    }
}
