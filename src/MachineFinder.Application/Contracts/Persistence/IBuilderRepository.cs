using MachineFinder.Application.Features.Builder.Commands.ApproveRequeriment;
using MachineFinder.Application.Features.Builder.Commands.BuyLicense;
using MachineFinder.Application.Features.Builder.Commands.PreApproveRequeriment;
using MachineFinder.Application.Features.Builder.Commands.RegisterRequirement;
using MachineFinder.Application.Features.Builder.Commands.UploadDocuments;
using MachineFinder.Application.Features.Builder.Queries.GetLicenses;
using MachineFinder.Application.Features.Builder.Queries.GetOwnerDetail;
using MachineFinder.Application.Features.Builder.Queries.GetOwnerMachinary;
using MachineFinder.Application.Features.Builder.Queries.GetOwners;
using MachineFinder.Application.Features.Builder.Queries.GetRequirementDetail;
using MachineFinder.Application.Features.Builder.Queries.GetRequirements;
using MachineFinder.Domain.DTO.Licencia;

namespace MachineFinder.Application.Contracts.Persistence
{
    public interface IBuilderRepository
    {
        Task<string> ApproveRequeriment(ApproveRequerimentCommand request);
        Task<string> BuyLicense(BuyLicenseCommand request);
        Task<List<LicenciaDTO>> GetLicenses(GetLicensesQuery request);
        Task<string> GetOwnerDetail(GetOwnerDetailQuery request);
        Task<string> GetOwnerMachinary(GetOwnerMachinaryQuery request);
        Task<string> GetOwners(GetOwnersQuery request);
        Task<string> GetRequirementDetail(GetRequirementDetailQuery request);
        Task<string> GetRequirements(GetRequirementsQuery request);
        Task<string> PreApproveRequeriment(PreApproveRequerimentCommand request);
        Task<string> RegisterRequirement(RegisterRequirementCommand request);
        Task<string> UploadDocuments(UploadDocumentsCommand request);
    }
}
