namespace MachineFinder.Application.Features.Register.Commands.Common
{
    public class RegisterCommand
    {
        public string? nom_usuario { get; set; }
        public string? ape_paterno { get; set; }
        public string? ape_materno { get; set; }
        public string? fec_nacimiento { get; set; }
        public string? tip_documento { get; set; }
        public string? num_documento { get; set; }
        public string? usu_email { get; set; }
        public string? num_telefono { get; set; }
        public string? pwd_usuario { get; set; }

        public List<RegisterDocumentCommand>? documentos { get; set; }
    }
}
