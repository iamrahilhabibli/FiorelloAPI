using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fiorello.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        [HttpGet]
        public string GetAll()
        {
            return "Hello Rahil";
        }
        [HttpPost]
        public string Greet()
        {
            return "Hello P233";
        }
    }
}
