namespace MachineFinder.Domain
{
    public static class Constants
    {
        public const string ID_USUARIO = "ID_USUARIO";
        public const string COD_USUARIO = "COD_USUARIO";
        public const string NOM_USUARIO = "NOM_USUARIO";
        public const string EMA_USUARIO = "EMA_USUARIO";

        public const string COD_ADMIN = "KAMISAMA";

        public const string ACTIVO = "Activo";
        public const string INACTIVO = "Inactivo";

        public const string HEADER_AUTHORIZATION = "Authorization";
        public const string HEADER_IS_MOBILE = "X-MACH-FINDER-MOBILE";
        public const string HEADER_COD_PERFIL = "X-MACH-FINDER-PROFILE";
        public const string HEADER_COD_ENTORNO = "X-MACH-FINDER-ENTORNO";


        public static class TipoUsuario
        {
            public const string BUILDER = "BUILDER";
            public const string OWNER = "OWNER";
            public const string WORKER = "WORKER";
        }

        public static class Tablas
        {
            public const string DOCS = "DOCS";
            public const string ESTMAQ = "ESTMAQ";
            public const string TIPDOC = "TIPDOC";
            public const string TIPUSU = "TIPUSU";
        }
    }
}
