using Microsoft.AspNetCore.Mvc;

namespace SurveyDemo.Controllers
{
    [ApiController]
    public class ErrorController : ControllerBase
    {
        [HttpGet("/Error")]
        public string Error()
        {
            return "Случилась беда";
        }
    }
}