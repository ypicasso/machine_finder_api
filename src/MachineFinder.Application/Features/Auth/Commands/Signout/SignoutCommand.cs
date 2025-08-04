namespace MachineFinder.Application.Features.Auth.Commands.Signout
{
    public class SignoutCommand : MediatR.IRequest<bool>
    {
        public string? token { get; set; }

        public SignoutCommand(string? token)
        {
            this.token = token;
        }
    }
}
