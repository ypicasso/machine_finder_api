using MachineFinder.Application.Contracts.Persistence;

namespace MachineFinder.Application.Features.Register.Commands.RegisterWorker
{
    public class RegisterWorkerCommandHandler : MediatR.IRequestHandler<RegisterWorkerCommand, string>
    {
        protected readonly IRegisterRepository repository;

        public RegisterWorkerCommandHandler(IRegisterRepository repository)
        {
            this.repository = repository;
        }

        public async Task<string> Handle(RegisterWorkerCommand request, CancellationToken cancellationToken)
        {
            return await repository.RegisterWorker(request);
        }
    }
}
