using _037_Abstract_Factory_Pattern_DeepDive.StorageProviders.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _037_Abstract_Factory_Pattern_DeepDive.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StorageController : ControllerBase
    {
        private readonly IStorageFactory _storageFactory;

        public StorageController(IStorageFactory storageFactory)
        {
            _storageFactory = storageFactory;
        }

        [HttpPost("upload/{provider}")]
        public async Task<IActionResult> Upload(string provider, IFormFile file)
        {
            var storageClient = _storageFactory.GetStorageClient(provider);

            using var stream = file.OpenReadStream();
            var result = await storageClient.UploadFileAsync(stream, file.FileName);

            return Ok(result);
        }
    }
}
