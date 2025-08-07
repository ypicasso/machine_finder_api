using MachineFinder.Application.Contracts.Persistence;

namespace MachineFinder.Application.Features.Builder.Commands.BuyLicense
{
    public class BuyLicenseCommandHandler : MediatR.IRequestHandler<BuyLicenseCommand, string>
    {
        protected readonly IBuilderRepository repository;

        public BuyLicenseCommandHandler(IBuilderRepository repository)
        {
            this.repository = repository;
        }

        public async Task<string> Handle(BuyLicenseCommand request, CancellationToken cancellationToken)
        {
            return await repository.BuyLicense(request);
        }
    }
}
