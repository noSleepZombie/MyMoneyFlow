using MoneyHero.Data.Interface;
using MoneyHero.Data.Interfaces;
using MoneyHero.Data.Repositories;

namespace MoneyHero.Data;

public class UnitOfWork : IUnitOfWork
{
    private IAccountRepository? _accountRepository;
    private IOperationRepository? _operationRepository;

    protected MoneyHeroContext _context;
    public UnitOfWork (MoneyHeroContext context)
    {
        _context = context;
    }

    public IAccountRepository Accounts
    {
        get
        {
            _accountRepository ??= new AccountRepository(_context);

            return _accountRepository;
        }
    }

    public IOperationRepository Operations
    {
        get
        {
            _operationRepository ??= new OperationRepository(_context);

            return _operationRepository;
        }
    }

    public async Task SaveAsync()
    {
        await _context.SaveChangesAsync();
    }
}