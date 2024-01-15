using Aspros.SaaS.System.Application.ViewModel;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aspros.SaaS.System.Application.MessageConsumer
{
    public class TestConsumer : IConsumer<RoleViewModel>
    {

        public async Task Consume(ConsumeContext<RoleViewModel> context)
        {
            await Console.Out.WriteLineAsync(context.Message.Name);
        }
    }
}
