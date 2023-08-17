using MoneyHero.Domain.Models;
using System.Linq.Expressions;

namespace MoneyHero.Data.Interfaces;

public interface IOperationRepository
{
    Task<Operation?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    IQueryable<Operation> GetAll();
    Task AddAsync(Operation entity, CancellationToken cancellationToken);
    void Delete(Operation entity);
}