using Hex.Event.Core.Domain.Entities.Dtos;
using Hex.Event.Core.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace Hex.Event.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscribeController : Controller
    {
        private readonly ICourseService _courseService;
        public SubscribeController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        public IActionResult Index()
        {
            SubscribeInputDto subscribe = new SubscribeInputDto { Course = "Curso 1", Name = "Dumorro", Email = "Email" };
            _courseService.Resgister(subscribe);
            return Ok();
        }
    }
}