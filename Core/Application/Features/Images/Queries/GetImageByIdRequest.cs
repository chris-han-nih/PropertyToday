namespace Application.Features.Images.Queries;

using Application.Models;
using Application.Repositories;
using AutoMapper;
using MediatR;

public class GetImageByIdRequest: IRequest<ImageDto>
{
    public int ImageId { get; set; }
    public GetImageByIdRequest(int imageId)
    {
        ImageId = imageId;
    }    
}

public class GetImageByIdRequestHandler : IRequestHandler<GetImageByIdRequest, ImageDto>
{
    private readonly IImageRepo _imageRepo;
    private readonly IMapper _mapper;
    public GetImageByIdRequestHandler(IImageRepo imageRepo, IMapper mapper)
    {
        _imageRepo = imageRepo;
        _mapper = mapper;
    }

    public async Task<ImageDto> Handle(GetImageByIdRequest request, CancellationToken cancellationToken)
    {
        var image = await _imageRepo.GetByIdAsync(request.ImageId);
        return image == null
                   ? null
                   : _mapper.Map<ImageDto>(image);
    }
}
