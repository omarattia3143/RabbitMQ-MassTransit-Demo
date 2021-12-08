using System;
using System.Threading.Tasks;
using MassTransit;
using MassTransit.Serialization;
using Microsoft.AspNetCore.Mvc;

namespace Publisher.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherController : Controller
    {
        private readonly IBus _bus;

        public WeatherController(IBus bus)
        {
            _bus = bus;
        }

        [HttpPost("send-test")]
        public async Task<IActionResult> SendTest(string message)
        {
            var uri = new Uri("rabbitmq://localhost/send-test");
            var endpoint = await _bus.GetSendEndpoint(uri);

            var envelope = new JsonMessageEnvelope()
            {
                Message = message
            };
            
            await endpoint.Send(envelope);

            return Content("done successfully!");
        }
    }
}