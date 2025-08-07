﻿namespace MachineFinder.Domain.DTO.Auth
{
    public class UserContainerDTO
    {
        public string IdUsuario { get; set; } = string.Empty;
        public string CodUsuario { get; set; } = string.Empty;
        public string NomUsuario { get; set; } = string.Empty;
        public string EmaUsuario { get; set; } = string.Empty;

        public string CodPerfil { get; set; } = string.Empty;
        public string CodEntorno { get; set; } = string.Empty;
        public bool EsMobile { get; set; }
    }
}
