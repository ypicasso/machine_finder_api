using MachineFinder.Application.Contracts.Persistence;

namespace MachineFinder.Application.Features.Builder.Commands.ApproveRequeriment
{
    public class ApproveRequerimentCommandHandler : MediatR.IRequestHandler<ApproveRequerimentCommand, string>
    {
        protected readonly IBuilderRepository repository;

        public ApproveRequerimentCommandHandler(IBuilderRepository repository)
        {
            this.repository = repository;
        }

        public async Task<string> Handle(ApproveRequerimentCommand request, CancellationToken cancellationToken)
        {
            return await repository.ApproveRequeriment(request);
        }
    }
}
