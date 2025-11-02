using CorlateBlog.Application.Repositories;
using CorlateBlog.Application.Services.PostBlogServices;
using CorlateBlog.Domain.Entities;
using Moq;
using AutoMapper;
using CorlateBlog.Application.DTOs.BlogDTO.Response;

namespace CorlateBlogService.Test;

public class BlogServiceTest
{
    [Fact]
    public void Blog_GetBlogPosts_ReturnsAtleastOneValue()
    {
        // Arrange
        int page = 1;
        int size = 10;
        var mockRepository = new Mock<IBlogRepository>();
        var mapperInstance = new Mock<IMapper>();
        var expectValue = new Blog
        {
            Id = "f52dd87a-c689-485d-97dd-534fb39dc9ef",
            PostText = "Simple moq test",
            PostPhotoUrl = "https://picsum.photos/seed/1/800/400",
            CommentCount = 2,
            PostLikesCount = 34,
            PostCategories = new List<PostCategoryTbl>
            {
                new PostCategoryTbl { BlogId = "f52dd87a-c689-485d-97dd-534fb39dc9ef", Id = "603fa1ab-8897-4c78-8c5e-611af7b1a159", PostCategory = "Testing"  }
            },
        };
        var expectedValues = new List<Blog>
        {
            expectValue
        };

        mockRepository.Setup(repo => repo.GetAllBlogsAsync().Result).Returns(expectedValues.AsQueryable());
        //var expectedResponse = new BlogResponse();
        mapperInstance.Setup(mapper => mapper.Map<BlogResponse>(expectValue));

        // or follow this example
        /*
        // Example: Setting up a specific mapping from SourceClass to DestinationClass
    mockMapper.Setup(m => m.Map<DestinationClass>(It.IsAny<SourceClass>()))
              .Returns((SourceClass source) => new DestinationClass {  //populate properties based on source//  });

    // You can also set up specific return values for specific inputs
    var sourceObject = new SourceClass { Id = 1, Name = "Test" };
    var expectedDestination = new DestinationClass { Id = 1, FullName = "Test" };
    mockMapper.Setup(m => m.Map<DestinationClass>(sourceObject))
              .Returns(expectedDestination);
        */

        // Act
        var blogService = new BlogService(mockRepository.Object, mapperInstance.Object);
        var result = blogService.GetAllBlogsAsync(page, size);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(1, result.Result.Data.Count());
        Assert.Equal(expectValue.PostText, "Simple moq test");
    }
}