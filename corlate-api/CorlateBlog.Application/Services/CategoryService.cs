using AutoMapper;
using CorlateBlog.Application.Abstractions;
using CorlateBlog.Application.DTOs.PostCategory.Request;
using CorlateBlog.Application.DTOs.PostCategory.Response;
using CorlateBlog.Application.Repositories;
using CorlateBlog.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CorlateBlog.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<ResponseObject<CategoryResponse>> AddCategoryAsync(CategoryRequest request)
        {
            var category = _mapper.Map<PostCategoryTbl>(request);
            await _categoryRepository.AddCategoryAsync(category);

            return new ResponseObject<CategoryResponse>
            {
                StatusCode = 201,
                Message = "Category created successfully!",
                Data = _mapper.Map<CategoryResponse>(category)
            };
        }

        public async Task<ResponseObject<CategoryResponse>> GetSingleCategoryAsync(string id)
        {
            var result = new ResponseObject<CategoryResponse>();
            var category = await _categoryRepository.GetSingleCategoryAsync(id);

            if (category == null)
            {
                result.StatusCode = 404;
                result.Message = "Category not found.";
                return result;
            }

            result.StatusCode = 200;
            result.Message = "Category retrieved successfully.";
            result.Data = _mapper.Map<CategoryResponse>(category);
            return result;
        }

        public async Task<ResponseObject<IEnumerable<CategoryResponse>>> GetAllCategoriesAsync(int page, int size)
        {
            var categories = await _categoryRepository.GetAllCategoriesAsync();
            var data = categories.Skip((page - 1) * size).Take(size)
                                 .Select(c => _mapper.Map<CategoryResponse>(c))
                                 .ToList();

            return new ResponseObject<IEnumerable<CategoryResponse>>
            {
                StatusCode = 200,
                Message = "List of categories retrieved.",
                Data = data
            };
        }

        public async Task<ResponseObject<CategoryResponse>> UpdateCategoryAsync(string id, CategoryRequest request)
        {
            var result = new ResponseObject<CategoryResponse>();
            var category = await _categoryRepository.GetSingleCategoryAsync(id);

            if (category == null)
            {
                result.StatusCode = 404;
                result.Message = "Category not found.";
                return result;
            }

            _mapper.Map(request, category);
            await _categoryRepository.UpdateCategoryAsync(category);

            result.StatusCode = 200;
            result.Message = "Updated successfully!";
            result.Data = _mapper.Map<CategoryResponse>(category);
            return result;
        }

        public async Task<ResponseObject<bool>> DeleteCategoryAsync(string id)
        {
            var result = new ResponseObject<bool>();
            var category = await _categoryRepository.GetSingleCategoryAsync(id);

            if (category == null)
            {
                result.StatusCode = 404;
                result.Message = "Category not found.";
                return result;
            }

            await _categoryRepository.DeleteCategoryAsync(category);
            result.StatusCode = 200;
            result.Message = "Deleted successfully.";
            result.Data = true;
            return result;
        }

        public async Task<ResponseObject<IEnumerable<CategoryResponse>>> GetAllCategoriesAsync()
        {
            var categories = await _categoryRepository.GetAllCategoriesAsync();
            var data = categories.Select(c => _mapper.Map<CategoryResponse>(c)).ToList();

            return new ResponseObject<IEnumerable<CategoryResponse>>
            {
                StatusCode = 200,
                Message = "List of categories retrieved.",
                Data = data
            };
        }
    }
}
