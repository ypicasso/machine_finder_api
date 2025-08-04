namespace MachineFinder.Domain.Entities
{
    public partial class ContraseniaEntity : BaseDomainModel
    {
        public int id_contrasenia { get; set; }
        public string id_usuario { get; set; } = string.Empty;
        public string pwd_usuario { get; set; } = string.Empty;
        public UsuarioEntity? usuario { get; set; }
    }
}
