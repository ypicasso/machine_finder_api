using MachineFinder.Application.Features.Common;

namespace MachineFinder.Application.Features.Licencia.Commands.Delete
{
    public class DeleteCommand : AppBaseCommand, MediatR.IRequest<string>
    {
        // Request Properties
        public string? id_licencia { get; set; }
    }
}
