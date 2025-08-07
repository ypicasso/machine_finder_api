namespace MachineFinder.Domain.DTO.Common
{
    public class PersonaDTO
    {
        public string? id_usuario { get; set; } = string.Empty;
        public string nom_usuario { get; set; } = string.Empty;
        public string ape_paterno { get; set; } = string.Empty;
        public string? ape_materno { get; set; }
        //public string tip_documento { get; set; } = string.Empty;
        //public string num_documento { get; set; } = string.Empty;
        public string? usu_email { get; set; }
        public string? num_telefono { get; set; }
    }
}
