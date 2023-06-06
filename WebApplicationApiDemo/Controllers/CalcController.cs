using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplicationApiDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalcController : ControllerBase
    {

        [HttpGet("add")]
        public async Task<double> GetAdd([FromHeader]double a)
        {
           var b = await (new StreamReader(Request.Body)).ReadToEndAsync();


            return a + double.Parse(b);
        }

    }
}
