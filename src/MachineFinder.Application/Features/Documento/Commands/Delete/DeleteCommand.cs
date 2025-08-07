using MachineFinder.Application.Features.Common;

namespace MachineFinder.Application.Features.Documento.Commands.Delete
{
    public class DeleteCommand : AppBaseCommand, MediatR.IRequest<string>
    {
        // Request Properties
        public string? id { get; set; }
    }
}
