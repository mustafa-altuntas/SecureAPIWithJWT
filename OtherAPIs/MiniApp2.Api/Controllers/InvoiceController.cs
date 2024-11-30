using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace MiniApp2.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetInvoice()
        {
            var userId = HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)!.Value;
            var email = HttpContext.User.Claims.FirstOrDefault(c => c.Type.Contains("email"))!.Value;


            var rnd = new Random();

            return Ok($"Invoice ->\n User Id: {userId}\n Email: {email}\n Invoice: {rnd.Next()}");
        }

    }
}
