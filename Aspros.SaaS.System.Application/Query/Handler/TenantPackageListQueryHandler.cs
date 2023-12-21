using Aspros.Project.User.Infrastructure.Repository;
using Aspros.SaaS.System.Domain.Domain;
using Aspros.SaaS.System.Domain.Repository;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aspros.SaaS.System.Application.Query.Handler
{
    public class TenantPackageListQueryHandler : IRequestHandler<TenantPackageListQuery, List<TenantPackage>>
    {
        private readonly ITenantPackageRepository _tenantPackageRepository;
        
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public TenantPackageListQueryHandler(ITenantPackageRepository tenantPackageRepository, IServiceScopeFactory serviceScopeFactory)
        {
            _tenantPackageRepository = tenantPackageRepository;
            _serviceScopeFactory = serviceScopeFactory;
        }

        async Task<List<TenantPackage>> IRequestHandler<TenantPackageListQuery, List<TenantPackage>>.Handle(TenantPackageListQuery request, CancellationToken cancellationToken)
        {

            var list = new List<string> {
                "111:111:-1:-1:-1:-1:-1:-1:-1:-1:",
                "111:111:-1:-1:-1:-1:-1:-1:-1:-1:",
                "111:111:-1:-1:-1:-1:-1:-1:-1:-1:",
                "111:111:-1:-1:-1:-1:-1:-1:-1:-1:",
                "111:111:-1:-1:-1:-1:-1:-1:-1:-1:",
                "111:111:-1:-1:-1:-1:-1:-1:-1:-1:",
                "111:111:-1:-1:-1:-1:-1:-1:-1:-1:",
                "111:111:-1:-1:-1:-1:-1:-1:-1:-1:",
                "111:111:-1:-1:-1:-1:-1:-1:-1:-1:",
                "111:111:-1:-1:-1:-1:-1:-1:-1:-1:",
                "111:111:-1:-1:-1:-1:-1:-1:-1:-1:",
                "111:111:-1:-1:-1:-1:-1:-1:-1:-1:",
                "111:111:-1:-1:-1:-1:-1:-1:-1:-1:",
                "111:111:-1:-1:-1:-1:-1:-1:-1:-1:",
                "111:111:-1:-1:-1:-1:-1:-1:-1:-1:",
                "111:111:-1:-1:-1:-1:-1:-1:-1:-1:",
                "111:111:-1:-1:-1:-1:-1:-1:-1:-1:",
                "111:111:-1:-1:-1:-1:-1:-1:-1:-1:",
                "111:111:-1:-1:-1:-1:-1:-1:-1:-1:",
                "111:111:-1:-1:-1:-1:-1:-1:-1:-1:",
                "111:111:-1:-1:-1:-1:-1:-1:-1:-1:",
                "111:111:-1:-1:-1:-1:-1:-1:-1:-1:",
                "111:111:-1:-1:-1:-1:-1:-1:-1:-1:",
                "111:111:-1:-1:-1:-1:-1:-1:-1:-1:",
                "111:111:-1:-1:-1:-1:-1:-1:-1:-1:",
                "111:111:-1:-1:-1:-1:-1:-1:-1:-1:",
                "111:111:-1:-1:-1:-1:-1:-1:-1:-1:",
                "111:111:-1:-1:-1:-1:-1:-1:-1:-1:",
                "111:111:-1:-1:-1:-1:-1:-1:-1:-1:",
                "111:111:-1:-1:-1:-1:-1:-1:-1:-1:",
                "111:111:-1:-1:-1:-1:-1:-1:-1:-1:",
                "111:111:-1:-1:-1:-1:-1:-1:-1:-1:",
                "111:111:-1:-1:-1:-1:-1:-1:-1:-1:",
                "111:111:-1:-1:-1:-1:-1:-1:-1:-1:",
                "111:111:-1:-1:-1:-1:-1:-1:-1:-1:",
                "111:111:-1:-1:-1:-1:-1:-1:-1:-1:",
                "111:111:-1:-1:-1:-1:-1:-1:-1:-1:",
                "111:111:-1:-1:-1:-1:-1:-1:-1:-1:",
                "111:111:-1:-1:-1:-1:-1:-1:-1:-1:",
                "111:111:-1:-1:-1:-1:-1:-1:-1:-1:",
                "111:111:-1:-1:-1:-1:-1:-1:-1:-1:",
                "111:111:-1:-1:-1:-1:-1:-1:-1:-1:",
                "111:111:-1:-1:-1:-1:-1:-1:-1:-1:",
                "111:111:-1:-1:-1:-1:-1:-1:-1:-1:",
                "111:111:-1:-1:-1:-1:-1:-1:-1:-1:",
                "111:111:-1:-1:-1:-1:-1:-1:-1:-1:",
                "111:111:-1:-1:-1:-1:-1:-1:-1:-1:",
                "111:111:-1:-1:-1:-1:-1:-1:-1:-1:",
                "111:111:-1:-1:-1:-1:-1:-1:-1:-1:",
                "111:111:-1:-1:-1:-1:-1:-1:-1:-1:",
                "111:111:-1:-1:-1:-1:-1:-1:-1:-1:",
                "111:111:-1:-1:-1:-1:-1:-1:-1:-1:",
                "111:111:-1:-1:-1:-1:-1:-1:-1:-1:",
                "111:111:-1:-1:-1:-1:-1:-1:-1:-1:",
                "111:111:-1:-1:-1:-1:-1:-1:-1:-1:",
                "111:111:-1:-1:-1:-1:-1:-1:-1:-1:",
                "111:111:-1:-1:-1:-1:-1:-1:-1:-1:",
                "111:111:-1:-1:-1:-1:-1:-1:-1:-1:",
                "111:111:-1:-1:-1:-1:-1:-1:-1:-1:",
                "111:111:-1:-1:-1:-1:-1:-1:-1:-1:",
                "111:111:-1:-1:-1:-1:-1:-1:-1:-1:",
                "111:111:-1:-1:-1:-1:-1:-1:-1:-1:",
                "111:111:-1:-1:-1:-1:-1:-1:-1:-1:",
                "111:111:-1:-1:-1:-1:-1:-1:-1:-1:",
                "111:111:-1:-1:-1:-1:-1:-1:-1:-1:",
                "111:111:-1:-1:-1:-1:-1:-1:-1:-1:",
                "111:111:-1:-1:-1:-1:-1:-1:-1:-1:",
                "111:111:-1:-1:-1:-1:-1:-1:-1:-1:",
                "111:111:-1:-1:-1:-1:-1:-1:-1:-1:",
                "111:111:-1:-1:-1:-1:-1:-1:-1:-1:",
                "111:111:-1:-1:-1:-1:-1:-1:-1:-1:",
                "111:111:-1:-1:-1:-1:-1:-1:-1:-1:",
                "111:111:-1:-1:-1:-1:-1:-1:-1:-1:",
                "111:111:-1:-1:-1:-1:-1:-1:-1:-1:",
                "111:111:-1:-1:-1:-1:-1:-1:-1:-1:",
                "111:111:-1:-1:-1:-1:-1:-1:-1:-1:",
                "111:111:-1:-1:-1:-1:-1:-1:-1:-1:",
                "111:111:-1:-1:-1:-1:-1:-1:-1:-1:",
                "111:111:-1:-1:-1:-1:-1:-1:-1:-1:",
                "111:111:-1:-1:-1:-1:-1:-1:-1:-1:",
                "111:111:-1:-1:-1:-1:-1:-1:-1:-1:",
                "111:111:-1:-1:-1:-1:-1:-1:-1:-1:",
                "111:111:-1:-1:-1:-1:-1:-1:-1:-1:",
                "111:111:-1:-1:-1:-1:-1:-1:-1:-1:",
                "111:111:-1:-1:-1:-1:-1:-1:-1:-1:",
                "111:111:-1:-1:-1:-1:-1:-1:-1:-1:",
                "111:111:-1:-1:-1:-1:-1:-1:-1:-1:",
                "111:111:-1:-1:-1:-1:-1:-1:-1:-1:",
                "111:111:-1:-1:-1:-1:-1:-1:-1:-1:",
                "111:111:-1:-1:-1:-1:-1:-1:-1:-1:",
                "111:111:-1:-1:-1:-1:-1:-1:-1:-1:",
                "111:111:-1:-1:-1:-1:-1:-1:-1:-1:",
                "111:111:-1:-1:-1:-1:-1:-1:-1:-1:",
                "111:111:-1:-1:-1:-1:-1:-1:-1:-1:",
                "111:111:-1:-1:-1:-1:-1:-1:-1:-1:",
                "111:111:-1:-1:-1:-1:-1:-1:-1:-1:",
                "111:111:-1:-1:-1:-1:-1:-1:-1:-1:",
                "111:111:-1:-1:-1:-1:-1:-1:-1:-1:",
                "111:111:-1:-1:-1:-1:-1:-1:-1:-1:",
                "111:111:-1:-1:-1:-1:-1:-1:-1:-1:",
                "111:111:-1:-1:-1:-1:-1:-1:-1:-1:",
                "111:111:-1:-1:-1:-1:-1:-1:-1:-1:",
                "111:111:-1:-1:-1:-1:-1:-1:-1:-1:",
                "111:111:-1:-1:-1:-1:-1:-1:-1:-1:",
                "111:111:-1:-1:-1:-1:-1:-1:-1:-1:",
                "111:111:-1:-1:-1:-1:-1:-1:-1:-1:",
                "111:111:-1:-1:-1:-1:-1:-1:-1:-1:",
                "111:111:-1:-1:-1:-1:-1:-1:-1:-1:",
                "111:111:-1:-1:-1:-1:-1:-1:-1:-1:",
                "111:111:-1:-1:-1:-1:-1:-1:-1:-1:",
                "111:111:-1:-1:-1:-1:-1:-1:-1:-1:",
                "111:111:-1:-1:-1:-1:-1:-1:-1:-1:",
                "111:111:-1:-1:-1:-1:-1:-1:-1:-1:",
                "111:111:-1:-1:-1:-1:-1:-1:-1:-1:",
                "111:111:-1:-1:-1:-1:-1:-1:-1:-1:"};

            await Console.Out.WriteLineAsync("start:" + DateTime.Now + "");
            var result = BuildData(list);
            await Console.Out.WriteLineAsync("end:" + DateTime.Now + "");
            foreach (var item in result)
            {
                await Console.Out.WriteLineAsync(item.Item1 + "|" + item.Item2);
            }
            return await _tenantPackageRepository.QueryList(request.Name).ToListAsync();
        }

        private Queue<Tuple<string, string>> BuildData(List<string> data)
        {
            var scope = _serviceScopeFactory.CreateScope();

            //var  tenantPackageRepository=_serviceProvider.GetService<ITenantPackageRepository>();
            string propsStr, propsName = string.Empty;
            Queue<Tuple<string, string>> queue = new();//队列
            Parallel.ForEach(data, entity =>
            {
                var tenantPackageRepository = scope.ServiceProvider.GetRequiredService<ITenantPackageRepository>();
                var valueList = entity.Split(":");
                var pPid = int.Parse(valueList[0]);
                var pId = int.Parse(valueList[1]);
                var pProp = tenantPackageRepository.QueryDetail(pPid).FirstOrDefault();
                var prop = tenantPackageRepository.QueryDetail(pPid).FirstOrDefault();
                propsStr = $"{pPid}:{pId}:";
                propsName = $"{pProp?.Name}:{prop?.Name}:";
                Parallel.For(2, valueList.Length, async i =>
                {
                    if (valueList[i] == "-1")
                    {
                        propsStr += "-1:";
                        propsName += valueList[i] + ":";
                    }
                    else
                    {
                        var baseValueId = tenantPackageRepository.QueryDetail(pPid).FirstOrDefault();
                        propsStr += baseValueId + ":";
                        propsName += valueList[i] + ":";
                    }
                });
                propsStr = propsStr[..^1];
                propsStr += ";";
                propsName = propsName[..^1];
                propsName += ";";

                var tupleStr = new Tuple<string, string>(propsStr, propsName);
                queue.Enqueue(tupleStr);
            });

            return queue;
        }
    }
}
