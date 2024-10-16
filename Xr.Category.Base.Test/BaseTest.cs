using Aspros.Base.Framework.Infrastructure;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;

namespace Xr.System.Base.Test
{
    public class BaseTest
    {
        public readonly IServiceScope _scope;
        public BaseTest()
        {
            var application = new WebApplicationFactory<Program>();
            _scope = application.Services.CreateScope();
            ServiceLocator.Instance = _scope.ServiceProvider;
        }
    }
}
