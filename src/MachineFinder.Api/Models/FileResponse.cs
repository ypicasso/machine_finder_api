namespace MachineFinder.Api.Models
{
    public class FileResponse
    {
        public bool success { get; set; }
        public string? original { get; set; }
        public string? path { get; set; }
        public string? message { get; set; }
    }
}
