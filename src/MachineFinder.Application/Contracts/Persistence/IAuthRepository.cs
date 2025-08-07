using MachineFinder.Application.Features.Auth.Commands.Retrieve;
using MachineFinder.Application.Features.Auth.Commands.Signin;
using MachineFinder.Application.Features.Auth.Commands.Signout;
using MachineFinder.Domain.DTO.Auth;
using MachineFinder.Domain.Entities;

namespace MachineFinder.Application.Contracts.Persistence
{
    public interface IAuthRepository
    {
        Task<AuthDTO> Signin(SigninCommand request);
        Task<bool> Signout(SignoutCommand request);
        Task<string> Retrieve(RetrieveCommand request);
        Task<bool> IsActiveUser(string? id);
    }
}
