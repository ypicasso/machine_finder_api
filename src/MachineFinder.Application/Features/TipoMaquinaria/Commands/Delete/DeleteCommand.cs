using MachineFinder.Application.Features.Common;

namespace MachineFinder.Application.Features.TipoMaquinaria.Commands.Delete
{
    public class DeleteCommand : AppBaseCommand, MediatR.IRequest<string>
    {
        // Request Properties
        public string? id_tipo_maquinaria { get; set; }
    }
}
