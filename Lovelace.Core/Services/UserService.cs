using Lovelace.Core.Entities.Base.Entity;
using Lovelace.Core.Interfaces;
using Lovelace.Core.Services.Base.BaseService;
using Lovelace.Core.Services.interfaces.IUser;
using Microsoft.Extensions.Logging;

namespace Lovelace.Core.Services
{
    public class UserService : BaseService<User>, IUserService
    {
        private readonly IUserRepository _userRepository;
        
        public UserService(IUserRepository userRepository, ILogger<User> logger): base(logger)
        {
            _userRepository = userRepository;
        }
        public User GetById(long id)
        {
            var user =  _userRepository.GetById(id);
            return user;
        }
    }
}