using MachineFinder.Application.Features.Common;

namespace MachineFinder.Application.Features.Documento.Commands.Create
{
    public class CreateCommand : AppBaseCommand, MediatR.IRequest<string>
    {
        // Request Properties
        public string? id_perfil { get; set; }
        public string? nom_documento { get; set; }
        public bool? ind_requerido { get; set; }
    }
}
