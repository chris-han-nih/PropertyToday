namespace WebApi.Controllers;

using Application.Features.Images.Commands;
using Application.Features.Images.Queries;
using Application.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class ImagesController: ControllerBase
{
    private readonly ISender _sender;
    public ImagesController(ISender sender)
    {
        _sender = sender;
    }
    
    [HttpPost]
    public async Task<IActionResult> AddNewImage([FromBody] NewImage newImageRequest)
    {
        var isSuccessful = await _sender.Send(new CreateImageRequest(newImageRequest));
        return isSuccessful
                   ? Ok("Image created successfully.")
                   : BadRequest("Failed to create image.");
    }
    
    [HttpPut]
    public async Task<IActionResult> UpdateImage([FromBody] UpdateImage updateImage)
    {
        var isSuccessful = await _sender.Send(new UpdateImageRequest(updateImage));
        return isSuccessful
                   ? Ok("Image updated successfully.")
                   : BadRequest("Failed to update image.");
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteImage(int id)
    {
        var isSuccessful = await _sender.Send(new DeleteImageRequest(id));
        return isSuccessful
                   ? Ok("Image deleted successfully.")
                   : BadRequest("Failed to delete image.");
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetImageById(int id)
    {
        var image = await _sender.Send(new GetImageByIdRequest(id));
        return image == null
                   ? NotFound("Image not found.")
                   : Ok(image);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllImages()
    {
        var images = await _sender.Send(new GetImagesRequest());
        return images == null
                   ? NotFound("No images found.")
                   : Ok(images);
    }
}
