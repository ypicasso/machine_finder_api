namespace MachineFinder.Domain.Entities
{
    public partial class CuentaLicenciaEntity : BaseDomainModel
    {
        public string id_cuenta_licencia { get; set; } = string.Empty;
        public string id_cuenta { get; set; } = string.Empty;
        public string id_licencia { get; set; } = string.Empty;
        public string tit_licencia { get; set; } = string.Empty;
        public int can_meses { get; set; }
        public int? mas_meses { get; set; }
        public decimal val_licencia { get; set; }
        public bool ind_oferta { get; set; }
        public bool ind_mixto { get; set; }
        public string cod_origen { get; set; } = string.Empty;
        public string cod_entorno { get; set; } = string.Empty;
        public DateTime fec_compra { get; set; }
        public DateTime fec_expiracion { get; set; }
        public CuentaEntity? cuenta { get; set; }
        public LicenciaEntity? licencia { get; set; }
    }
}
