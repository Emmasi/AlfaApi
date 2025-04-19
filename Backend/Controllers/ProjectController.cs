using Business.Models;
using Business.Services;
using Data.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Backend.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProjectController(IProjectService _projectservice) : ControllerBase
{

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] Data.Entities.Status? status = null, [FromQuery] string order = "desc")
    {
        bool orderByDesc = order.Equals("desc", StringComparison.OrdinalIgnoreCase);
        var result = await _projectservice.GetProjectAsync(status, orderByDesc);
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(string id)
    {
        var result = await _projectservice.GetProjectByIdAsync(id);
        return result == null ? NotFound() : Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create(AddProjectForm form)
    {
        if (!ModelState.IsValid)
            return BadRequest(form);

        var result = await _projectservice.CreateProjectAsync(form);
        return result ? Ok() : BadRequest();
    }

    [HttpPut]
    public async Task<IActionResult> Update(EditProjectForm form)
    {
        if (!ModelState.IsValid)
            return BadRequest(form);

        var result = await _projectservice.UpdateProjectAsync(form);
        return result ? Ok() : NotFound();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        var result = await _projectservice.DeleteProjectAsync(id);
        return result ? Ok() : NotFound();
    }
}

