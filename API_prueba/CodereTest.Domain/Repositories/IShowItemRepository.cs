using CodereTest.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodereTest.Domain.Repositories
{
    public interface IShowItemRepository
    {
        Task<bool> Exists(int id, CancellationToken cancellationToken);
        Task<ShowItem> GetById(int id, CancellationToken cancellationToken);
        Task Delete(int id, CancellationToken cancellationToken);
        Task<ShowItem> Save(ShowItem showItem, CancellationToken cancellationToken);
        Task<List<ShowItem>> GetAll(CancellationToken cancellationToken);
    }
}
