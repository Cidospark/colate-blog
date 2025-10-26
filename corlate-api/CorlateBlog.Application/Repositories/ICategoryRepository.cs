using System.Linq;
using System.Threading.Tasks;
using CorlateBlog.Domain.Entities;

namespace CorlateBlog.Application.Repositories
{
    public interface ICategoryRepository
    {
        Task AddCategoryAsync(PostCategoryTbl category);
        Task<PostCategoryTbl?> GetSingleCategoryAsync(string id);
        Task<IQueryable<PostCategoryTbl>> GetAllCategoriesAsync();
        Task UpdateCategoryAsync(PostCategoryTbl category);
        Task DeleteCategoryAsync(PostCategoryTbl category);
    }
}
