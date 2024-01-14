using CodereTest.Domain.Entities;
using CodereTest.Domain.Repositories;
using CodereTest.Infrastructure.Context;
using ISF.FAF_RF.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace CodereTest.Infrastructure.Repositories
{
    public class ShowItemRepository : IShowItemRepository
    {
        private readonly CodereTestContext _context;

        public ShowItemRepository(CodereTestContext context)
        {
            _context = context;
        }

        public async Task Delete(int id, CancellationToken cancellationToken)
        {
            var showItem = await _context.ShowItems.FindAsync(id, cancellationToken);
            if (showItem == null) throw new AppException(CustomError.IdError);

            _context.ShowItems.Remove(showItem);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<List<ShowItem>> GetAll(CancellationToken cancellationToken)
        {
            return await _context.ShowItems
                .Include(x => x.Rating)
                .Include(x => x.Network).ThenInclude(x => x.Country)
                .Include(x => x.Externals)
                .Include(x => x.Image)
                .Include(x => x.Schedule)
                .AsNoTracking().ToListAsync(cancellationToken);
        }

        public async Task<ShowItem> GetById(int id, CancellationToken cancellationToken)
        {
            return 
                await _context.ShowItems.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id, cancellationToken) 
                ?? throw new AppException(CustomError.IdError);
        }

        public async Task<bool> Exists(int id, CancellationToken cancellationToken)
        {
            var showItem = await _context.ShowItems.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

            return showItem != null ? true : false;
        }

        public async Task<ShowItem> Save(ShowItem showItem, CancellationToken cancellationToken)
        {
            await _context.ShowItems.AddAsync(showItem, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return showItem;
        }
    }
}
