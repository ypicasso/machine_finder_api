namespace MachineFinder.Domain.Entities
{
    public partial class CuentaDocumentoHistorialEntity : BaseDomainModel
    {
        public string id_cuenta_documento_historial { get; set; } = string.Empty;
        public string id_cuenta_documento { get; set; } = string.Empty;
        public string nom_documento { get; set; } = string.Empty;
        public string ext_documento { get; set; } = string.Empty;
        public string url_documento { get; set; } = string.Empty;
        public bool ind_registro { get; set; }
        public string cod_entorno { get; set; } = string.Empty;
        public string usu_aprobacion { get; set; } = string.Empty;
        public DateTime fec_aprobacion { get; set; }
        public CuentaDocumentoEntity? cuenta_documento { get; set; }
    }
}
