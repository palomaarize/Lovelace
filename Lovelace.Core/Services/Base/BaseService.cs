using Microsoft.Extensions.Logging;

namespace Lovelace.Core.Services.Base.BaseService
{
    public class BaseService<T> where T : new()
    {
        protected readonly ILogger<T> _logger;

        public BaseService(ILogger<T> logger)
        {
            _logger = logger;
        }
    }
}
