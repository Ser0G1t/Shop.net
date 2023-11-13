namespace NewRepo.IService
{
    public interface IImportService
    {
        Task Import(string format, IFormFile file);
    }
}
