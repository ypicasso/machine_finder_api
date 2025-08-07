namespace MachineFinder.Domain.Entities
{
    public partial class CatalogoEntity : BaseDomainModel
    {
        public string id_catalogo { get; set; } = string.Empty;
        public string cod_tabla { get; set; } = string.Empty;
        public string cod_campo { get; set; } = string.Empty;
        public string nom_campo { get; set; } = string.Empty;
        public string? ext_campo { get; set; }
        public int? ord_campo { get; set; }
    }
}
