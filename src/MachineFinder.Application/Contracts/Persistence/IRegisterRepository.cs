using MachineFinder.Application.Features.Register.Commands.RegisterBuilder;
using MachineFinder.Application.Features.Register.Commands.RegisterOwner;
using MachineFinder.Application.Features.Register.Commands.RegisterWorker;
using MachineFinder.Application.Features.Register.Queries.GetParams;
using MachineFinder.Domain.DTO.Register;

namespace MachineFinder.Application.Contracts.Persistence
{
    public interface IRegisterRepository
    {
        Task<RegisterParamsDTO> GetParams(GetParamsQuery request);
        Task<string> RegisterBuilder(RegisterBuilderCommand request);
        Task<string> RegisterOwner(RegisterOwnerCommand request);
        Task<string> RegisterWorker(RegisterWorkerCommand request);
    }
}
