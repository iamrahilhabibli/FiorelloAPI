using AutoMapper;
using Fiorello.Application.Abstraction.Repository;
using Fiorello.Application.Abstraction.Services;
using Fiorello.Application.DTOs.Blog;
using Fiorello.Domain.Entities;
using Fiorello.Persistence.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Fiorello.Persistence.Implementations.Services;

public class BlogService : IBlogService
{
    private readonly IBlogReadReopsitory _blogReadReopsitory;
    public readonly IBlogWriteReopsitory _blogWriteReopsitory;
    private readonly IBlogImageService _blogImageService;
    private readonly IUploadFile _uploadFile;
    public readonly IMapper _mapper;
    public BlogService(IBlogReadReopsitory blogReadReopsitory,
                       IBlogWriteReopsitory blogWriteReopsitory,
                       IMapper mapper,
                       IBlogImageService blogImageService,
                       IUploadFile uploadFile)
    {
        _blogReadReopsitory = blogReadReopsitory;
        _blogWriteReopsitory = blogWriteReopsitory;
        _mapper = mapper;
        _blogImageService = blogImageService;
        _uploadFile = uploadFile;
    }

    public async Task AddAsync(BlogCreateDTO blogCreateDTO)
    {
        var blog = await _blogReadReopsitory
            .GetByExpressionAsync(x => x.Title.ToLower().Equals(blogCreateDTO.title));
        if (blog is not null) throw new Exception("Dubilcated Catagory Name!");
        Blog NewBlog = _mapper.Map<Blog>(blogCreateDTO);
        if (blogCreateDTO.imagePath != null && blogCreateDTO.imagePath.Length > 0)
        {
            var ImagePath = await _uploadFile.WriteFile(blogCreateDTO.imagePath);
            NewBlog.ImagePath = ImagePath;
        }
        await _blogWriteReopsitory.AddAsync(NewBlog);
        await _blogWriteReopsitory.SaveChangesAsync();

        NewBlogDto newBlogDto = new()
        {
            BlogId = NewBlog.Id,
            ImagePath = NewBlog.ImagePath
        };
        var NewBlogImage = _mapper.Map<BlogImageCreateDTO>(newBlogDto);
        await _blogImageService.AddAsync(NewBlogImage);
    }


    public async Task<List<BlogGetDTO>> GetAllAsync()
    {
        var blogs = await _blogReadReopsitory
                    .GetAll()
                    .Include(x => x.BlogImages)
                    .Include(x => x.Category)
                    .ToListAsync();

        if (blogs is null) throw new Exception("Blog is Null");

        var dtoList = new List<BlogGetDTO>();

        foreach (var blog in blogs)
        {
            var blogGetDTO = new BlogGetDTO
            {
                Id = blog.Id,
                Title = blog.Title,
                Description = blog.Description,
                //ImagePath = blog.ImagePath,
                CatagoryId = blog.CatagoryId,
                BlogImages = new List<BlogImageGetAllDTO>()
            };

            foreach (var blogImage in blog.BlogImages)
            {
                var blogImageGetAllDTO = new BlogImageGetAllDTO
                {
                    Id = blogImage.Id,
                    Image = blogImage.ImagePath,
                    BlogId = blogImage.BlogId
                };

                blogGetDTO.BlogImages.Add(blogImageGetAllDTO);
            }

            dtoList.Add(blogGetDTO);
        }

        return dtoList;
    }


    public async Task<BlogGetDTO> GetByIdAsync(Guid Id)
    {
        var Blogs = await _blogReadReopsitory
                    .GetAll()
                    .Include(x => x.BlogImages)
                    .Include(x => x.Category)
                    .FirstOrDefaultAsync(x => x.Id == Id);
        if (Blogs is null) throw new Exception("Blog is null");
        //var EntityToDto = _mapper.Map<BlogGetDTO>(Blogs);
        var bloggetDto = new BlogGetDTO
        {
            Id = Blogs.Id,
            Title = Blogs.Title,
            Description = Blogs.Description,
            CatagoryId = Blogs.CatagoryId,
            BlogImages = new List<BlogImageGetAllDTO>()
        };
        foreach (var blogImage in Blogs.BlogImages)
        {
            var blogImageGetAllDTO = new BlogImageGetAllDTO
            {
                Id = blogImage.Id,
                Image = blogImage.ImagePath,
                BlogId = blogImage.BlogId
            };
            bloggetDto.BlogImages.Add(blogImageGetAllDTO);
        }
        return bloggetDto;
    }

    public async Task RemoveAsync(Guid Id)
    {
        var ByBlog = await _blogReadReopsitory.GetByIdAsync(Id);
        if (ByBlog is null) throw new Exception("Blog is null");
        var DtoToEntity = _mapper.Map<Blog>(ByBlog);
        _blogWriteReopsitory.Remove(DtoToEntity);
        await _blogWriteReopsitory.SaveChangesAsync();
    }
    public async Task UpdateAsync(Guid Id, BlogUpdateDTo blogUpdateDTo)
    {
        var ByBlog = await _blogReadReopsitory.GetByIdAsync(Id);
        if (ByBlog is null) throw new Exception("Blog is null");
        _mapper.Map(blogUpdateDTo, ByBlog);
        if (blogUpdateDTo.imagePath != null && blogUpdateDTo.imagePath.Length > 0)
        {
            var ImagePath = await _uploadFile.WriteFile(blogUpdateDTo.imagePath);
            ByBlog.ImagePath = ImagePath;
        }
        _blogWriteReopsitory.Update(ByBlog);
        await _blogWriteReopsitory.SaveChangesAsync();

        //await _blogImageService
    }
}
