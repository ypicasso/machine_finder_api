namespace MachineFinder.Domain.Entities
{
    public partial class LicenciaEntity : BaseDomainModel
    {
        public string id_licencia { get; set; } = string.Empty;
        public string id_perfil { get; set; } = string.Empty;
        public string tit_licencia { get; set; } = string.Empty;
        public int can_meses { get; set; }
        public int? mas_meses { get; set; }
        public decimal val_licencia { get; set; }
        public bool ind_oferta { get; set; }
        public bool ind_mixto { get; set; }
        public PerfilEntity? perfil { get; set; }
        public List<CuentaLicenciaEntity>? cuenta_licencias { get; set; }
    }
}
