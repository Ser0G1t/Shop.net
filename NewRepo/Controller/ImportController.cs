using Microsoft.AspNetCore.Mvc;
using NewRepo.Exceptions;
using NewRepo.IService;

namespace NewRepo.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class ImportController : ControllerBase
    {
        private readonly IImportService _importService;
        public ImportController(IImportService importService)
        {
            _importService = importService;
        }

        [HttpPost("import")]
        public async Task<ActionResult> importXLS([FromQuery] string format, [FromForm] IFormFile file)
        {
            if (file is null || file.Length < 0){
                throw new FileIsEmpty("File is empty!");
            }
            await _importService.Import(format, file);
            return Ok($"data from {format} has been imported");
        }
    }
}
