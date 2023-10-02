namespace Application.Features.Images.Commands;

using Application.Repositories;
using MediatR;

public class DeleteImageRequest: IRequest<bool>
{
    public int ImageId { get; set; }
    public DeleteImageRequest(int imageId)
    {
        ImageId = imageId;
    }
}

public class DeleteImageRequestHandler : IRequestHandler<DeleteImageRequest, bool>
{
    private readonly IImageRepo _imageRepo;
    public DeleteImageRequestHandler(IImageRepo imageRepo)
    {
        _imageRepo = imageRepo;
    }

    public async Task<bool> Handle(DeleteImageRequest request, CancellationToken cancellationToken)
    {
        var image = await _imageRepo.GetByIdAsync(request.ImageId);   
        if (image == null)
        {
            return false;
        }
        await _imageRepo.DeleteAsync(image);
        return true;
    }
}
