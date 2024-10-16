//using Aspros.Base.Framework.Infrastructure;
//using Xr.System.Base.Test;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.DependencyInjection;
//using Xunit;

//namespace Xr.System.Domain.Test
//{
//    public class MenuTest() : BaseTest
//    {
//        private  IUnitOfWork unitOfWork;
//        private  IMenuReporistory menuReporistory;

//        [Fact]
//        public async Task MenuQuery()
//        {
//            var scopedServices = _scope.ServiceProvider;
//            menuReporistory = scopedServices.GetRequiredService<IMenuReporistory>();
//            var menu = await menuReporistory.QueryDetail(1001L).FirstOrDefaultAsync();
//            Assert.NotNull(menu);
//        }

//        [Fact]
//        public async Task MenuAdd()
//        {
//            unitOfWork = ServiceLocator.Instance.GetService<IUnitOfWork>();
//            unitOfWork.BeginTransaction();
//            var menu = new Menu(0L, string.Empty, "测试菜单", MenuType.Root, 0, string.Empty, string.Empty, string.Empty);
//            await unitOfWork.RegisterNew(menu);
//            var result = await unitOfWork.CommitAsync();
//            Assert.True(result);
//        }
//    }
//}
