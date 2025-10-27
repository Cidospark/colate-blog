using System.Collections.Generic;
using System.Threading.Tasks;



namespace CorlateBlog.Application.Interfaces
{
    public interface IArchiveRepository
    {
        Task<IEnumerable<object>> GetAllAsync();
    }
}
