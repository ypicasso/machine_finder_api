namespace MachineFinder.Application.Features.Auth.Commands.Retrieve
{
    public class RetrieveCommand : MediatR.IRequest<string>
    {
        public string? cod_usuario { get; set; }

        public RetrieveCommand(string? cod_usuario)
        {
            this.cod_usuario = cod_usuario;
        }
    }
}
