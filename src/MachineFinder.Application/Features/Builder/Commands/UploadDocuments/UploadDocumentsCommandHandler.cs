using MachineFinder.Application.Contracts.Persistence;

namespace MachineFinder.Application.Features.Builder.Commands.UploadDocuments
{
    public class UploadDocumentsCommandHandler : MediatR.IRequestHandler<UploadDocumentsCommand, string>
    {
        protected readonly IBuilderRepository repository;

        public UploadDocumentsCommandHandler(IBuilderRepository repository)
        {
            this.repository = repository;
        }

        public async Task<string> Handle(UploadDocumentsCommand request, CancellationToken cancellationToken)
        {
            return await repository.UploadDocuments(request);
        }
    }
}
