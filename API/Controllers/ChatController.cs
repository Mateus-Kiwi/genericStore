using API.DTOs;
using Microsoft.AspNetCore.Mvc;
using PusherServer;

namespace API.Controllers
{
    [Route("api")]
    [ApiController]
    public class ChatController : Controller
    {
        [HttpPost("messages")]
        public async Task<ActionResult> Message(MessageDto messageDto)
        {
            var options = new PusherOptions
            {
                Cluster = "sa1",
                Encrypted = true
            };

            var pusher = new Pusher(
              "1722932",
              "3cb19a1bd9a88a188c23",
              "bed219a1e59d8813433d",
              options);

            var channelName = $"suporte-{messageDto.Username}";

            await pusher.TriggerAsync(
              channelName,
              "message",
              new
              {
                  username = messageDto.Username,
                  message = messageDto.Message
              });

            return Ok(new string[] { });
        }
    }
}