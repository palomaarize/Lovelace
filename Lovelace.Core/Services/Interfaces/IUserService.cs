using Lovelace.Core.Entities.Base.Entity;

namespace Lovelace.Core.Services.interfaces.IUser
{
    public interface IUserService
    {
       User GetById(long id);
    }
}
