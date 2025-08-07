using MachineFinder.Application.Contracts.Persistence;

namespace MachineFinder.Application.Features.Register.Commands.RegisterBuilder
{
    public class RegisterBuilderCommandHandler : MediatR.IRequestHandler<RegisterBuilderCommand, string>
    {
        protected readonly IRegisterRepository repository;

        public RegisterBuilderCommandHandler(IRegisterRepository repository)
        {
            this.repository = repository;
        }

        public async Task<string> Handle(RegisterBuilderCommand request, CancellationToken cancellationToken)
        {
            return await repository.RegisterBuilder(request);
        }
    }
}
