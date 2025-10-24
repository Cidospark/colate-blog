using System.Collections.Generic;
using System.Threading.Tasks;

namespace CorlateBlog.Application.Repositories.ArchiveRepo
{
    public interface IArchiveRepository
    {
        Task<IEnumerable<object>> GetAllAsync();
    }
}
