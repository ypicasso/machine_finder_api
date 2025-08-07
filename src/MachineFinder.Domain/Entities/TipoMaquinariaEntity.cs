namespace MachineFinder.Domain.Entities
{
    public partial class TipoMaquinariaEntity : BaseDomainModel
    {
        public string id_tipo_maquinaria { get; set; } = string.Empty;
        public string cod_tipo_maquina { get; set; } = string.Empty;
        public string nom_tipo_maquina { get; set; } = string.Empty;
        public string url_imagen { get; set; } = string.Empty;
    }
}
