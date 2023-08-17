using Microsoft.EntityFrameworkCore;
using MoneyHero.Data.Interface;
using MoneyHero.Domain.Models;
using System.Linq.Expressions;

namespace MoneyHero.Data.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly MoneyHeroContext _context;
        public AccountRepository(MoneyHeroContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Account entity, CancellationToken cancellationToken)
        {
            entity.CreatedAt = DateTime.Now;
            await _context.AddAsync(entity, cancellationToken);
        }

        public void Delete(Account entity)
        {
            _context.Remove(entity);
        }

        public IQueryable<Account> GetAllAsync()
        {
            return _context.Accounts.AsQueryable();
        }

        public async Task<IEnumerable<Account>> GetAllAsync(Expression<Func<Account, bool>> predicate, CancellationToken cancellationToken)
        {
            return await _context.Accounts.Where(predicate).ToListAsync(cancellationToken);
        }

        public async Task<Account?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _context.Accounts.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }

        public void Update(Account entity)
        {
            entity.UpdatedAt = DateTime.Now;
            _context.Accounts.Update(entity);
        }
    }
}
