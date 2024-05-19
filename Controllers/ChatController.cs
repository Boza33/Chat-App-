using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Chat_App.Services;
using Chat_App.Dtos;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        private readonly ChatServices _chatService;
        public ChatController(ChatServices chatService)
        {
            _chatService = chatService;
        }

        [HttpPost("register-user")]
        public IActionResult RegisterUser(UserDto model)
        {
            if (_chatService.AddUserToList(model.Name))
            {
                return NoContent();
            }
            return BadRequest("Ovo ime je zauzeto, odaberite drugo ime.");
        }

        
            
    }
}
