namespace Application.Features.Images.Commands;

using Application.Models;
using Application.Repositories;
using AutoMapper;
using Domain;
using MediatR;

public class CreateImageRequest: IRequest<bool>
{
    public NewImage ImageRequestRequest { get; set; }

    public CreateImageRequest(NewImage imageRequestRequest) => ImageRequestRequest = imageRequestRequest;
}

public class CreateImageRequestHandler: IRequestHandler<CreateImageRequest, bool>
{
    private readonly IImageRepo _imageRepo;
    private readonly IMapper _mapper;
    public CreateImageRequestHandler(IImageRepo imageRepo, IMapper mapper)
    {
        _imageRepo = imageRepo;
        _mapper = mapper;
    }

    public async Task<bool> Handle(CreateImageRequest request, CancellationToken cancellationToken)
    {
        var image = _mapper.Map<Image>(request.ImageRequestRequest);
        await _imageRepo.AddNewAsync(image);
        return true;
    }
}
