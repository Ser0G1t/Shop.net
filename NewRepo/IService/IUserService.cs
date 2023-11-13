using NewRepo.DTO;

namespace NewRepo.IService
{
    public interface IUserService
    {
        void createUser(CreateUserDTO user);
    }
}
