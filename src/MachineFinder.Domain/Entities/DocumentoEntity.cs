namespace MachineFinder.Domain.Entities
{
    public partial class DocumentoEntity : BaseDomainModel
    {
        public string id_documento { get; set; } = string.Empty;
        public string id_perfil { get; set; } = string.Empty;
        public string nom_documento { get; set; } = string.Empty;
        public bool ind_requerido { get; set; }
        public PerfilEntity? perfil { get; set; }
    }
}
