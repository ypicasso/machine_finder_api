namespace MachineFinder.Domain.DTO.Auth
{
    public class AuthDTO
    {
        public string? id_usuario { get; set; }
        public string? nom_usuario { get; set; }
        public string? ape_paterno { get; set; }
        public string? ape_materno { get; set; }

        public string? tip_documento { get; set; }
        public string? num_documento { get; set; }
        public string? num_telefono { get; set; }
        public string? fec_nacimiento { get; set; }

        public string? email { get; set; }
        public bool? ind_confirmacion { get; set; }
        public bool? ind_repassword { get; set; }
        public string? token { get; set; }

        public List<AuthPerfilDTO>? perfiles { get; set; }
    }
}
