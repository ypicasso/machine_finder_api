namespace MachineFinder.Domain.Entities
{
    public partial class PerfilEntity : BaseDomainModel
    {
        public string id_perfil { get; set; } = string.Empty;
        public string cod_perfil { get; set; } = string.Empty;
        public string nom_perfil { get; set; } = string.Empty;
        public string url_perfil { get; set; } = string.Empty;
        public List<CuentaEntity>? cuentas { get; set; }
        public List<DocumentoEntity>? documentos { get; set; }
        public List<LicenciaEntity>? licencias { get; set; }
    }
}
