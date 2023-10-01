namespace WebApi.Controllers;

using Application.Features.Properties.Commands;
using Application.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public sealed class PropertiesController: ControllerBase
{
    private readonly ISender _sender;

    public PropertiesController(ISender sender)
    {
        _sender = sender;
    }
    
    [HttpPost("add")]
    public async Task<IActionResult> AddNewProperty([FromBody]NewProperty newPropertyRequest)
    {
        var isSuccessful = await _sender.Send(new CreatePropertyRequest(newPropertyRequest));
        if (isSuccessful)
            return Ok("Property added successfully");
        return BadRequest("Property could not be added");
    }
    
    [HttpPut("update")]
    public async Task<IActionResult> UpdateProperty([FromBody]UpdateProperty updatePropertyRequest)
    {
        var isSuccessful = await _sender.Send(new UpdatePropertyRequest(updatePropertyRequest));
        if (isSuccessful)
            return Ok("Property updated successfully");
        return NotFound("Property does not exist");
    }
}