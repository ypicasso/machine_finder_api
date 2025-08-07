using MachineFinder.Application.Contracts.Persistence;

namespace MachineFinder.Application.Features.Builder.Commands.PreApproveRequeriment
{
    public class PreApproveRequerimentCommandHandler : MediatR.IRequestHandler<PreApproveRequerimentCommand, string>
    {
        protected readonly IBuilderRepository repository;

        public PreApproveRequerimentCommandHandler(IBuilderRepository repository)
        {
            this.repository = repository;
        }

        public async Task<string> Handle(PreApproveRequerimentCommand request, CancellationToken cancellationToken)
        {
            return await repository.PreApproveRequeriment(request);
        }
    }
}
