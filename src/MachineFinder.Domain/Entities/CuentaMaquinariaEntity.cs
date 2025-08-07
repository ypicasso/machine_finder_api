namespace MachineFinder.Domain.Entities
{
    public partial class CuentaMaquinariaEntity : BaseDomainModel
    {
        public string id_cuenta_maquinaria { get; set; } = string.Empty;
        public string id_cuenta { get; set; } = string.Empty;
        public string id_tipo_maquinaria { get; set; } = string.Empty;
        public string? cod_marca { get; set; }
        public string? nom_marca { get; set; }
        public string? cod_modelo { get; set; }
        public string? nom_modelo { get; set; }
        public string? cod_departamento { get; set; }
        public string? nom_departamento { get; set; }
        public string? cod_provincia { get; set; }
        public string? nom_provincia { get; set; }
        public string? cod_distrito { get; set; }
        public string? nom_distrito { get; set; }
        public string cod_status { get; set; } = string.Empty;
        public string nom_status { get; set; } = string.Empty;
        public CuentaEntity? cuenta { get; set; }
    }
}
