namespace Application.Features.Images.Commands;

using Application.Models;
using Application.Repositories;
using MediatR;

public class UpdateImageRequest: IRequest<bool>
{
   public UpdateImage UpdateImage { get; set; } 
   public UpdateImageRequest(UpdateImage updateImage)
   {
      UpdateImage = updateImage;
   }
}

public class UpdateImageRequestHandler : IRequestHandler<UpdateImageRequest, bool>
{
   private readonly IImageRepo _imageRepo;
   public UpdateImageRequestHandler(IImageRepo imageRepo)
   {
      _imageRepo = imageRepo;
   }

   public async Task<bool> Handle(UpdateImageRequest request, CancellationToken cancellationToken)
   {
      var image = await _imageRepo.GetByIdAsync(request.UpdateImage.Id);
      if (image == null) return false;
      
      image.Name = request.UpdateImage.Name;
      image.Path = request.UpdateImage.Path;
      await _imageRepo.UpdateAsync(image);

      return true;
   }
}