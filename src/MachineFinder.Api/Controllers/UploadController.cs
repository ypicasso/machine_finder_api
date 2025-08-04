using MachineFinder.Api.Models;
using MachineFinder.Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MachineFinder.Api.Controllers
{
    [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class UploadController : ControllerBase
    {
        private readonly IWebHostEnvironment _env;
        private readonly EncryptionService _encryptor;

        private readonly string[] ARR_PATH_IMAGES = ["temp", "images"];
        private readonly string[] ARR_EXT_IMAGES = [".jpg", ".jpeg", ".png"];

        private readonly string[] ARR_PATH_DOCS = ["temp", "docs"];
        private readonly string[] ARR_EXT_DOCS = [".doc", ".docx", ".pdf"];

        public UploadController(IWebHostEnvironment env, EncryptionService encryptor)
        {
            _env = env;
            _encryptor = encryptor;
        }

        [HttpPost("UploadImage")]
        public async Task<string> UploadImage(IFormFile file) => await ProcessFile(file, ARR_PATH_IMAGES, ARR_EXT_IMAGES);

        [HttpPost("UploadImages")]
        public async Task<List<FileResponse>> UploadImages(List<IFormFile> files) => await ProcessFiles(files, ARR_PATH_IMAGES, ARR_EXT_IMAGES);


        [HttpPost("UploadDocument")]
        public async Task<string> UploadDocument(IFormFile file) => await ProcessFile(file, ARR_PATH_DOCS, ARR_EXT_DOCS);

        [HttpPost("UploadDocuments")]
        public async Task<List<FileResponse>> UploadDocument(List<IFormFile> files) => await ProcessFiles(files, ARR_PATH_DOCS, ARR_EXT_DOCS);


        private async Task<List<FileResponse>> ProcessFiles(List<IFormFile> files, string[] tempsPath, string[] validExtensions)
        {
            if (files == null || files.Count == 0)
                throw new Exception("No se han enviado archivos a procesar");

            var images = new List<FileResponse>();

            foreach (var item in files)
            {
                var path = string.Empty;
                var message = string.Empty;

                try
                {
                    path = await ProcessFile(item, ARR_PATH_IMAGES, ARR_EXT_IMAGES);
                }
                catch (Exception ex)
                {
                    message = ex.Message;
                }

                images.Add(new FileResponse
                {
                    original = item.FileName,
                    success = !string.IsNullOrEmpty(path),
                    message = message,
                    path = path
                });
            }

            if (images.Any(w => !string.IsNullOrEmpty(w.message)))
                throw new Exception("No se pudieron cargar todos los archivos");

            return images;
        }

        private async Task<string> ProcessFile(IFormFile file, string[] tempsPath, string[] validExtensions)
        {
            if (file == null)
                throw new Exception("No se ha enviado archivo a procesar");

            var extension = Path.GetExtension(file.FileName).ToLower();

            if (!validExtensions.Contains(extension))
            {
                throw new Exception("Solo se permiten archivos con extensión " + string.Join("", validExtensions.Select((s, i) => (i == validExtensions.Length - 1 ? " o " : ", ") + s)));
            }

            var separator = Path.DirectorySeparatorChar;
            var uploadPath = _env.WebRootPath;
            var paths = new List<string>(tempsPath);

#if !DEBUG
            var contentInfo = new DirectoryInfo(_env.ContentRootPath);

            uploadPath = contentInfo.Parent!.FullName;
            
            paths.Insert(0, "files");
#endif

            foreach (var path in paths)
            {
                uploadPath = Path.Combine(uploadPath, path);

                if (!Directory.Exists(uploadPath))
                    Directory.CreateDirectory(uploadPath);
            }

            string fileName = string.Empty;
            string filePath = string.Empty;

            do
            {
                fileName = $"{Guid.NewGuid().ToString()}{extension}";
                filePath = Path.Combine(uploadPath, fileName);

            } while (System.IO.File.Exists(filePath));

            using var stream = new FileStream(filePath, FileMode.Create);

            await file.CopyToAsync(stream);

            return _encryptor.Encrypt($"{string.Join(separator, paths)}{separator}{fileName}");
        }
    }
}
