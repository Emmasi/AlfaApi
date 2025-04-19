using Business.Services;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ClientController (IClientService _clientservice): ControllerBase 
{

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result= await _clientservice.GetClientsAsync();
        return Ok(result);
    }
}
