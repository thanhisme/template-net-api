using HotelBooking.Infrastructure.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace HotelBooking.Application.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AppController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public AppController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        //[Authorize(Policy = "IsAdmin")]
        public async Task<ActionResult<string>> Greeting()
        {
            await _unitOfWork.SaveChangesAsync();

            return Ok("Hello World");
        }
    }
}
