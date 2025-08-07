using MachineFinder.Application.Contracts.Persistence;
using MachineFinder.Domain.DTO.Register;

namespace MachineFinder.Application.Features.Register.Queries.GetParams
{
    public class GetParamsQueryHandler : MediatR.IRequestHandler<GetParamsQuery, RegisterParamsDTO>
    {
        protected readonly IRegisterRepository repository;

        public GetParamsQueryHandler(IRegisterRepository repository)
        {
            this.repository = repository;
        }

        public async Task<RegisterParamsDTO> Handle(GetParamsQuery request, CancellationToken cancellationToken)
        {
            return await repository.GetParams(request);
        }
    }
}
