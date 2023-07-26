using AutoMapper;
using Fiorello.Application.Abstraction.Repository;
using Fiorello.Application.Abstraction.Services;
using Fiorello.Application.DTOs.Blog;
using Fiorello.Domain.Entities;

namespace Fiorello.Persistence.Implementations.Services;

public class BlogImageService : IBlogImageService
{
    private readonly IBlogImageReadReopsitory _blogImageReadReopsitory;
    private readonly IBlogImageWriteReopsitory _blogImageWriteReopsitory;
    private readonly IBlogReadReopsitory _blogReadReopsitory;
    private readonly IUploadFile _uploadFile;
    private readonly IMapper _mapper;
    public BlogImageService(IBlogImageReadReopsitory blogImageReadReopsitory,
        IBlogImageWriteReopsitory blogImageWriteReopsitory,
        IBlogReadReopsitory blogReadReopsitory,
        IMapper mapper,
        IUploadFile uploadFile)
    {
        _blogImageReadReopsitory = blogImageReadReopsitory;
        _blogReadReopsitory = blogReadReopsitory;
        _blogImageWriteReopsitory = blogImageWriteReopsitory;
        _mapper = mapper;
        _uploadFile = uploadFile;
    }

    public async Task AddAsync(BlogImageCreateDTO blogImageCreateDTO)
    {
        var BlogImage = _mapper.Map<BlogImage>(blogImageCreateDTO);
        await _blogImageWriteReopsitory.AddAsync(BlogImage);
        await _blogImageWriteReopsitory.SaveChangesAsync();
    }

    public async Task Update(Guid BlogId, BlogImageUpdateDTO blogImageUpdateDTO)
    {
        var blog = await _blogReadReopsitory.GetByIdAsync(BlogId);
        if (blog is null) throw new Exception("Blog is Null");
        var ByBlog = _mapper.Map<BlogImage>(blogImageUpdateDTO);
        _blogImageWriteReopsitory.Update(ByBlog);
        await _blogImageWriteReopsitory.SaveChangesAsync();
    }
}
