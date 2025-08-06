using Microsoft.AspNetCore.Mvc;

namespace DocuWise.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PingController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(new {message = "DocuWise API is up and running."});
    }
}