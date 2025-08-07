using MachineFinder.Application.Contracts.Persistence;

namespace MachineFinder.Application.Features.Builder.Queries.GetOwnerMachinary
{
    public class GetOwnerMachinaryQueryHandler : MediatR.IRequestHandler<GetOwnerMachinaryQuery, string>
    {
        protected readonly IBuilderRepository repository;

        public GetOwnerMachinaryQueryHandler(IBuilderRepository repository)
        {
            this.repository = repository;
        }

        public async Task<string> Handle(GetOwnerMachinaryQuery request, CancellationToken cancellationToken)
        {
            return await repository.GetOwnerMachinary(request);
        }
    }
}
