using Microsoft.AspNetCore.Mvc;
namespace cuentamovimiento.Controllers
{
        [ApiController]
        [Route("[controller]")]
        public class HolaMundoController : ControllerBase
        {
            [HttpGet]
            public string Get()
            {
                return "Hola Mundo!";
            }
        }
}
