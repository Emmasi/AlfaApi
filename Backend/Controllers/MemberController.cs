using Business.Models;
using Business.Services;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MemberController(IMemberService _memberservice) : ControllerBase
{

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _memberservice.GetMembersAsync();
        return Ok(result);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(string id)
    {
        var result = await _memberservice.GetMemberByMemberIdAsync(id);
        return result == null ? NotFound() : Ok(result);
    }
}



