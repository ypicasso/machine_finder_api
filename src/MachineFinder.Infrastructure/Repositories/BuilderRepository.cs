using MachineFinder.Application.Contracts.Persistence;
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
using MachineFinder.Domain;
using MachineFinder.Domain.DTO.Licencia;
using MachineFinder.Infrastructure.Persistence.Data;
using MachineFinder.Infrastructure.Services;

namespace MachineFinder.Infrastructure.Repositories
{
    public class BuilderRepository : RepositoryBase, IBuilderRepository
    {
        private readonly LicenciaService _licenseService;

        public BuilderRepository(AppDBContext context, SessionStorage? sessionStorage, LicenciaService licenseService) : base(context, sessionStorage)
        {
            _licenseService = licenseService;
        }

        public Task<string> ApproveRequeriment(ApproveRequerimentCommand request)
        {
            throw new NotImplementedException();
        }

        public async Task<string> BuyLicense(BuyLicenseCommand request)
        {
            return await _licenseService.BuyLicense(ID_USUARIO, COD_PERFIL, request.id_licencia, COD_ENTORNO);
        }

        public async Task<List<LicenciaDTO>> GetLicenses(GetLicensesQuery request)
        {
            return await _licenseService.GetLicenses(Constants.TipoUsuario.BUILDER);
        }

        public Task<string> GetOwnerDetail(GetOwnerDetailQuery request)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetOwnerMachinary(GetOwnerMachinaryQuery request)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetOwners(GetOwnersQuery request)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetRequirementDetail(GetRequirementDetailQuery request)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetRequirements(GetRequirementsQuery request)
        {
            throw new NotImplementedException();
        }

        public Task<string> PreApproveRequeriment(PreApproveRequerimentCommand request)
        {
            throw new NotImplementedException();
        }

        public Task<string> RegisterRequirement(RegisterRequirementCommand request)
        {
            throw new NotImplementedException();
        }

        public Task<string> UploadDocuments(UploadDocumentsCommand request)
        {
            throw new NotImplementedException();
        }
    }
}
