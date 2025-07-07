using MediatR;
using Microsoft.AspNetCore.Mvc;
using SignalRDemoChat.Domain.Models;
using SignalRDemoChat.Domain.Requests;

namespace SignalRDemoChat.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly ISender _sender;

        public UsersController(ISender sender)
        {
            _sender = sender;
        }

        [HttpPost]
        public async Task<ActionResult<ApiResponse>> CreateUser([FromBody] CreateUserRequest request)
        {
            try
            {
                var response = await _sender.Send(request);

                return Ok(response);
            }catch(Exception ex)
            {
                return Ok(new ApiResponse()
                {
                    IsSuccess = false,
                    Message = ex.Message
                });
            }
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponse>> GetAllUsers()
        {
            try
            {
                var response = await _sender.Send(new GetUsersRequest());

                return Ok(response);
            }
            catch (Exception ex)
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

