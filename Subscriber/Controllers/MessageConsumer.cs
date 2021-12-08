using System.Threading.Tasks;
using MassTransit;
using MassTransit.Serialization;

namespace Subscriber.Controllers
{
    public class MessageConsumer : IConsumer<JsonMessageEnvelope>
    {
        public async Task Consume(ConsumeContext<JsonMessageEnvelope> context)
        {
            var message = context.Message;
        }
    }
}