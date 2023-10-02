namespace WebApi.Controllers;

using Application.Features.Properties.Commands;
using Application.Features.Properties.Queries;
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

    [HttpGet("{id}")]
    public async Task<IActionResult> GetPropertyById(int id)
    {
        var property = await _sender.Send(new GetPropertyByIdRequest(id));
        return property == null
                   ? NotFound("Property does not exist")
                   : Ok(property);
    }
    
    [HttpGet("all")]
    public async Task<IActionResult> GetAllProperties()
    {
        var properties = await _sender.Send(new GetPropertiesRequest());
        return properties == null
                   ? NotFound("No properties found")
                   : Ok(properties);
    }
}