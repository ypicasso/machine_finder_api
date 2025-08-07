namespace MachineFinder.Domain.Entities
{
    public partial class UsuarioEntity : BaseDomainModel
    {
        public string id_usuario { get; set; } = string.Empty;
        public string cod_usuario { get; set; } = string.Empty;
        public string nom_usuario { get; set; } = string.Empty;
        public string ape_paterno { get; set; } = string.Empty;
        public string? ape_materno { get; set; }
        public DateTime? fec_nacimiento { get; set; }
        public string tip_documento { get; set; } = string.Empty;
        public string num_documento { get; set; } = string.Empty;
        public string? usu_email { get; set; }
        public string? num_telefono { get; set; }
        public string pwd_usuario { get; set; } = string.Empty;
        public DateTime? fec_cese { get; set; }
        public string? obs_cese { get; set; }
        public string tip_usuario { get; set; } = string.Empty;
        public bool ind_confirmacion { get; set; }
        public DateTime? fec_confirmacion { get; set; }
        public bool ind_repassword { get; set; }
        public DateTime? fec_repassword { get; set; }
        public List<ContraseniaEntity>? contrasenias { get; set; }
        public List<CuentaEntity>? cuentas { get; set; }
    }
}
