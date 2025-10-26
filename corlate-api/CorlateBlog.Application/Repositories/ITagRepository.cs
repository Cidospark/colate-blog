using CorlateBlog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorlateBlog.Application.Repositories
{
    public interface ITagRepository
    {
        Task<IQueryable<TagTbl>> GetAllTagTblsAsync();
    }
}
