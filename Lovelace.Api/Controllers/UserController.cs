using Lovelace.Core.Entities.Base.Entity;
using Microsoft.AspNetCore.Mvc;
using Lovelace.Core.Services.interfaces.IUser;
using System.Diagnostics.CodeAnalysis;

namespace Lovelace.Api.Controller
{
    /// <summary>
    /// Api do recurso user
    /// </summary>
    [Route("api/user")]
    [ApiController]
    [ExcludeFromCodeCoverage]
    public class UserController 
    {
        private readonly IUserService _userService;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="userService"></param>
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// Busca usuário por id
        /// </summary>
        /// <param name="id"></param>
        [HttpGet("{id}")]
        public ActionResult<User> GetById(long id)
        {
            var user = _userService.GetById(id);
            return user;
        }

    }
}