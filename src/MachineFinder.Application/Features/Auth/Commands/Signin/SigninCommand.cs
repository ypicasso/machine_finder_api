using MachineFinder.Domain.DTO.Auth;

namespace MachineFinder.Application.Features.Auth.Commands.Signin
{
    public class SigninCommand : MediatR.IRequest<AuthDTO>
    {
        public string? username { get; set; }
        public string? password { get; set; }

        private bool? mobileIndicator { get; set; }

        public SigninCommand SetIndicator(bool? mobileIndicator)
        {
            this.mobileIndicator = mobileIndicator;

            return this;
        }

        public bool GetIndicator() => this.mobileIndicator ?? false;
    }
}
