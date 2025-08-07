using MachineFinder.Application.Features.Common;

namespace MachineFinder.Application.Features.TipoMaquinaria.Commands.Create
{
    public class CreateCommand : AppBaseCommand, MediatR.IRequest<string>
    {
        // Request Properties
        public string? cod_tipo_maquina { get; set; }
        public string? nom_tipo_maquina { get; set; }
        public string? url_imagen { get; set; }
    }
}
