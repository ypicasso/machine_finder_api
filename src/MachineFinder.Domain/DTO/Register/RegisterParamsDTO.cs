using MachineFinder.Domain.DTO.Common;

namespace MachineFinder.Domain.DTO.Register
{
    public class RegisterParamsDTO
    {
        public List<CodeTextDTO>? tipos_documentos { get; set; }
        public List<CodeTextDTO>? tipos_usuarios { get; set; }
    }
}
