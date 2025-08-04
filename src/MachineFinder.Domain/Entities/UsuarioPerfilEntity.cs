namespace MachineFinder.Domain.Entities
{
    public partial class UsuarioPerfilEntity : BaseDomainModel
    {
        public string id_usuario_perfil { get; set; } = string.Empty;
        public string id_usuario { get; set; } = string.Empty;
        public string id_perfil { get; set; } = string.Empty;
        public PerfilEntity? perfil { get; set; }
        public UsuarioEntity? usuario { get; set; }
    }
}
