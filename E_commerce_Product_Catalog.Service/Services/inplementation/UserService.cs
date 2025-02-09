using E_commerce_product_catalog.Abstraction;
using E_commerce_product_catalog.Models;
using E_commerce_Product_Catalog.Service.Commands;
using E_commerce_Product_Catalog.Service.Services.Abstractions;

namespace E_commerce_Product_Catalog.Service.Services.inplementation
{
    public class UserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> RegisterUserAsync(string name, string email, string password)
        {
            var userValidator = new UserRegristrationcommand();

            var validationResult = userValidator.Validate(new User
            {
                Name = name,
                Email = email,
                Password = password
            });

            if (!validationResult.IsValid)
            {
                var errors = string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage));
                throw new ArgumentException($"Validation failed: {errors}");
            }

            // ვამოწმებთ, რომ ელფოსტა უნიკალური იყოს
            var isEmailUnique = await _userRepository.IsEmailUniqueAsync(email);
            if (!isEmailUnique)
            {
                throw new ArgumentException("Email is already in use.");
            }

            var user = new User
            {
                Id = Guid.NewGuid(),
                Name = name,
                Email = email,
                Password = password
            };

            await _userRepository.AddUserAsync(user);
            return user;
        }

        public async Task<User> GetUserByIdAsync(Guid id)
        {
            var user = await _userRepository.GetUserByIdAsync(id);
            if (user == null)
            {
                throw new ArgumentException($"User with ID {id} not found.");
            }
            return user;
        }
    }
}
