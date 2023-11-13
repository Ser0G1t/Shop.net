namespace NewRepo.Strategy.ImportStrategy
{
    public interface IImportStrategy
    {
        Task Import(IFormFile file);
    }
}
