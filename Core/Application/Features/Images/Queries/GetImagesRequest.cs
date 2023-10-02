namespace Application.Features.Images.Queries;

using Application.Models;
using Application.Repositories;
using AutoMapper;
using MediatR;

public class GetImagesRequest: IRequest<List<ImageDto>>
{
}

public class GetImageRequestHandler : IRequestHandler<GetImagesRequest, List<ImageDto>>
{
    private readonly IImageRepo _imageRepo;
    private readonly IMapper _mapper;
    public GetImageRequestHandler(IImageRepo imageRepo, IMapper mapper)
    {
        _imageRepo = imageRepo;
        _mapper = mapper;
    }

    public async Task<List<ImageDto>> Handle(GetImagesRequest request, CancellationToken cancellationToken)
    {
        var images = await _imageRepo.GetAllAsync();
        return images == null
                   ? null
                   : _mapper.Map<List<ImageDto>>(images);
    }
}
