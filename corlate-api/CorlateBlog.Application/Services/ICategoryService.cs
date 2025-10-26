using System.Collections.Generic;
using System.Threading.Tasks;
using CorlateBlog.Application.DTOs.PostCategory.Request;
using CorlateBlog.Application.DTOs.PostCategory.Response;
using CorlateBlog.Application.Abstractions;

namespace CorlateBlog.Application.Services
{
    public interface ICategoryService
    {
        Task<ResponseObject<CategoryResponse>> AddCategoryAsync(CategoryRequest request);
        Task<ResponseObject<CategoryResponse>> GetSingleCategoryAsync(string id);
        Task<ResponseObject<IEnumerable<CategoryResponse>>> GetAllCategoriesAsync(int page, int size);
        Task<ResponseObject<IEnumerable<CategoryResponse>>> GetAllCategoriesAsync();
        Task<ResponseObject<CategoryResponse>> UpdateCategoryAsync(string id, CategoryRequest request);
        Task<ResponseObject<bool>> DeleteCategoryAsync(string id);

    }
}
