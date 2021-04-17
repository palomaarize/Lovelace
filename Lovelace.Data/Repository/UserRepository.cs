using System.Diagnostics.CodeAnalysis;
using Lovelace.Core.Entities.Base.Entity;
using Lovelace.Core.Interfaces;
using Lovelace.Data.Context;
using Lovelace.Data.Repository.Base;
using Microsoft.Extensions.Logging;

namespace Lovelace.Data.Repository.UserRepository
{
    [ExcludeFromCodeCoverage]
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly ILogger<User> _logger;

        public UserRepository(ILogger<User> logger, Contexto contexto) : base(contexto)
        {
            _logger = logger;
        }
    }
}