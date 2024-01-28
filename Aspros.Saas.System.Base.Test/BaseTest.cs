using Aspros.Base.Framework.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace Aspros.Saas.System.Base.Test
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
