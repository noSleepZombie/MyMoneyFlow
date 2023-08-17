using MoneyHero.Domain.Models;
using System.Linq.Expressions;

namespace MoneyHero.Data.Interface;

public interface IAccountRepository
{
    Task<Account?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    IQueryable<Account> GetAllAsync();
    Task<IEnumerable<Account>> GetAllAsync(Expression<Func<Account, bool>> predicate, CancellationToken cancellationToken);
    Task AddAsync(Account entity, CancellationToken cancellationToken);
    void Update(Account entity);
    void Delete(Account entity);
}