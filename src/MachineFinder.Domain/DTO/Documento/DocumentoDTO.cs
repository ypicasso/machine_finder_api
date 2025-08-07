namespace MachineFinder.Domain.DTO.Documento
{
    public class DocumentoDTO
    {
        public string? id_documento { get; set; }
        public string? id_perfil { get; set; }
        public string? nom_perfil { get; set; }
        public string? nom_documento { get; set; }
        public bool? ind_requerido { get; set; }
    }
}
