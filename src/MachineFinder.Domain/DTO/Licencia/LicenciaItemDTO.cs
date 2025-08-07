namespace MachineFinder.Domain.DTO.Licencia
{
    public class LicenciaItemDTO
    {
        public string? id_licencia { get; set; }
        //public string? id_perfil { get; set; }
        public string? nom_perfil { get; set; }
        public string? tit_licencia { get; set; }
        public int can_meses { get; set; }
        public int? mas_meses { get; set; }
        public decimal val_licencia { get; set; }
        public bool ind_oferta { get; set; }
        public bool ind_mixto { get; set; }
    }
}
