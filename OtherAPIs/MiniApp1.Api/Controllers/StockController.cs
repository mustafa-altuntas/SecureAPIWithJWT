using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace MiniApp1.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetStock()
        {
            var userId = HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)!.Value;
            var email = HttpContext.User.Claims.FirstOrDefault(c => c.Type.Contains("email"))!.Value;


            var rnd = new Random();

            return Ok($"Invoice ->\n User Id: {userId}\n Email: {email}\n Stock: {rnd.Next()}");
        }

    }
}
