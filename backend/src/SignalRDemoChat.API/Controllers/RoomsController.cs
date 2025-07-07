using MediatR;
using Microsoft.AspNetCore.Mvc;
using SignalRDemoChat.Domain.Models;
using SignalRDemoChat.Domain.Requests;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace SignalRDemoChat.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoomsController : ControllerBase
    {
        private readonly ISender _sender;

        public RoomsController(ISender sender)
        {
            _sender = sender;
        }

        [HttpPost]
        public async Task<ActionResult<ApiResponse>> CreateRoom([FromBody] CreateRoomRequest request)
        {
            try
            {
                var response = await _sender.Send(request);

                return Ok(new ApiResponse()
                {
                    IsSuccess = true,
                    Data = response,
                    Message = "Room Created succesfully"
                });
            }catch(Exception ex)
            {
                return Ok(new ApiResponse()
                {
                    IsSuccess = false,
                    Message = ex.Message
                });
            }
        }
    }
}
