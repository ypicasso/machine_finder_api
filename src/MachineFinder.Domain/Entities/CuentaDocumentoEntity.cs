namespace MachineFinder.Domain.Entities
{
    public partial class CuentaDocumentoEntity : BaseDomainModel
    {
        public string id_cuenta_documento { get; set; } = string.Empty;
        public string id_cuenta { get; set; } = string.Empty;
        public string cod_documento { get; set; } = string.Empty;
        public string nom_documento { get; set; } = string.Empty;
        public string ext_documento { get; set; } = string.Empty;
        public string url_documento { get; set; } = string.Empty;
        public bool ind_registro { get; set; }
        public string cod_entorno { get; set; } = string.Empty;
        public CuentaEntity? cuenta { get; set; }
        public List<CuentaDocumentoHistorialEntity>? cuenta_documento_historiales { get; set; }
    }
}
