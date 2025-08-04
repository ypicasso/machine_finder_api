using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace MachineFinder.Infrastructure.Services
{
    public class FileProcessor
    {
        private readonly IWebHostEnvironment _env;
        private readonly IHttpContextAccessor _http;
        private readonly EncryptionService _encryptor;

        public FileProcessor(IWebHostEnvironment env, IHttpContextAccessor http, EncryptionService encryptor)
        {
            _env = env;
            _http = http;
            _encryptor = encryptor;
        }

        public string ProcesarUrl(string encryptedUrl, params string[] paths)
        {
            var imageName = _encryptor.Decrypt(encryptedUrl);
            var sourcePath = _env.WebRootPath;
            var destinyPath = _env.WebRootPath;

            var folders = new List<string>();

#if DEBUG
            folders.Add("wwwroot");
#else
            folders.Add("files");

            var contentInfo = new DirectoryInfo(_env.ContentRootPath);

            sourcePath = contentInfo.Parent!.FullName;
            destinyPath = contentInfo.Parent!.FullName;
#endif

            var sourceInfo = new FileInfo(Path.Combine(sourcePath, imageName));

            folders.AddRange(paths);
            folders.Add(sourceInfo.Name);

            foreach (var name in folders)
            {
                destinyPath = Path.Combine(destinyPath, name);

                if (folders.Last().Equals(name)) continue;

                if (!Directory.Exists(destinyPath))
                    Directory.CreateDirectory(destinyPath);
            }

            sourceInfo.CopyTo(destinyPath);

            var newName = string.Join(@"/", folders.Skip(1));

            return newName;
        }

        public string GetBaseUrl()
        {
            var req = _http.HttpContext?.Request;
            var extra = "";

            var scheme = req?.Scheme;
            var host = req?.Host.ToString();

#if !DEBUG

extra = "files/";

#endif

#if DEBUG
            scheme = "http";
            host = host!.Split(":").First() + ":5026";
#endif

            return req == null
                ? ""
                : $"{scheme}://{host}/{extra}";
        }
    }
}
