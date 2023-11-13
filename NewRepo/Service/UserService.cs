using Microsoft.AspNetCore.Identity;
using NewRepo.Context;
using NewRepo.DTO;
using NewRepo.Entity;
using NewRepo.IService;

namespace NewRepo.Service
{
    public class UserService : IUserService
    {
        private readonly CoreContext _context;
        private readonly IPasswordHasher<User> _passwordHasher;

        public UserService(CoreContext context, IPasswordHasher<User> passwordHasher)
        {
            _context = context;
            _passwordHasher = passwordHasher;
        }

        public void createUser(CreateUserDTO user)
        {
            var newUser = new User()
            {
                email = user.email,
                firstName = user.firstName,
                lastName = user.lastName,
                address = user.address,
                city = user.city,
                zipCode = user.zipCode,
                roleId = user.roleId,
            };
            var hashPass = _passwordHasher.HashPassword(newUser, user.password);
            newUser.password = hashPass;
            _context.Add(newUser);
            _context.SaveChanges();
        }
    }
}
