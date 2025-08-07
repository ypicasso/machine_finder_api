using MachineFinder.Application.Features.Common;

namespace MachineFinder.Application.Features.TipoMaquinaria.Commands.Update
{
    public class UpdateCommand : AppBaseCommand, MediatR.IRequest<string>
    {
        // Request Properties
        public string? id_tipo_maquinaria { get; set; }
        public string? cod_tipo_maquina { get; set; }
        public string? nom_tipo_maquina { get; set; }
        public string? url_imagen { get; set; }
        public bool? ind_eliminado { get; set; }
    }
}
