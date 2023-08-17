using Microsoft.EntityFrameworkCore;
using MoneyHero.Data.Interfaces;
using MoneyHero.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MoneyHero.Data.Repositories
{
    public class OperationRepository : IOperationRepository
    {
        private readonly MoneyHeroContext _context;

        public OperationRepository(MoneyHeroContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Operation entity, CancellationToken cancellationToken)
        {
            entity.CreatedAt = DateTime.Now;
            await _context.Operations.AddAsync(entity, cancellationToken);
        }

        public void Delete(Operation entity)
        {
            _context.Operations.Remove(entity);
        }

        public IQueryable<Operation> GetAll()
        {
            return _context.Operations.AsQueryable();
        }

        public async Task<Operation?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _context.Operations.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }
    }
}
