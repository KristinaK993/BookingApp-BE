using API.Dtos.Service;
using API.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ServicesController : ControllerBase
{
    private readonly IServiceManager _serviceManager;

    public ServicesController(IServiceManager serviceManager)
    {
        _serviceManager = serviceManager;
    }

    // GET: api/services
    [HttpGet]
    public async Task<ActionResult<List<ServiceResponse>>> GetAll()
    {
        var services = await _serviceManager.GetAllAsync();
        return Ok(services);
    }

    // GET: api/services/5
    [HttpGet("{id:int}")]
    public async Task<ActionResult<ServiceResponse>> GetById(int id)
    {
        var service = await _serviceManager.GetByIdAsync(id);
        if (service == null)
            return NotFound();

        return Ok(service);
    }

    // POST: api/services
    [HttpPost]
    public async Task<ActionResult<ServiceResponse>> Create(CreateServiceDto request)
    {
        // validering
        if (request.DurationMinutes <= 0)
            return BadRequest("Duration must be greater than 0 (min).");

        if (request.Price < 0)
            return BadRequest("Price can not be negative.");

        var created = await _serviceManager.CreateAsync(request);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    // PUT: api/services/5
    [HttpPut("{id:int}")]
    public async Task<ActionResult<ServiceResponse>> Update(int id, UpdateServiceDto request)
    {
        if (id != request.Id)
            return BadRequest("Route id and body id must match.");

        var updated = await _serviceManager.UpdateAsync(id, request);
        if (updated == null)
            return NotFound();

        return Ok(updated);
    }

    // DELETE: api/services/5
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _serviceManager.DeleteAsync(id);
        if (!deleted)
            return NotFound();

        return NoContent();
    }
}
