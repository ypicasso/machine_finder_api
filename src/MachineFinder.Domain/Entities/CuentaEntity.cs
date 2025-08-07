namespace MachineFinder.Domain.Entities
{
    public partial class CuentaEntity : BaseDomainModel
    {
        public string id_cuenta { get; set; } = string.Empty;
        public string id_usuario { get; set; } = string.Empty;
        public string id_perfil { get; set; } = string.Empty;
        public PerfilEntity? perfil { get; set; }
        public UsuarioEntity? usuario { get; set; }
        public List<CuentaDocumentoEntity>? cuenta_documentos { get; set; }
        public List<CuentaLicenciaEntity>? cuenta_licencias { get; set; }
        public List<CuentaMaquinariaEntity>? cuenta_maquinarias { get; set; }
    }
}
