using MachineFinder.Domain.DTO.Licencia;

namespace MachineFinder.Application.Features.Licencia.Queries.GetList
{
    public class GetListQuery : MediatR.IRequest<List<LicenciaDTO>>
    {
        // Request Properties
        public string? id_perfil { get; set; }
        public string? tit_licencia { get; set; }
        public int? can_meses { get; set; }
        public int? mas_meses { get; set; }
        public decimal? val_licencia { get; set; }
        public bool? ind_oferta { get; set; }
        public bool? ind_mixto { get; set; }
    }
}
