using MoneyHero.Application.Interfaces;
using MoneyHero.Application.Requests;
using MoneyHero.Application.Responses;
using MoneyHero.Data.Interfaces;
using MoneyHero.Domain.Models;

namespace MoneyHero.Application.Services;

public class AccountService : IAccountService
{
    private readonly IUnitOfWork _unitOfWork;
    public AccountService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task CreateAsync(CreateAccountRequest request, CancellationToken cancellationToken)
    {
        var account = new Account(request.Name, request.InitialBalance, request.Description);

        await _unitOfWork.Accounts.AddAsync(account, cancellationToken);
    }

    public async Task Delete(Guid id)
    {
        var account = await _unitOfWork.Accounts.GetByIdAsync(id, CancellationToken.None);

        if (account is null)
            return;

        _unitOfWork.Accounts.Delete(account);
    }

    public IEnumerable<GetAccountResponse> GetAllAsync()
    {
        var accounts = _unitOfWork.Accounts.GetAllAsync();

        if (!accounts.Any())
            return new List<GetAccountResponse>();

        return accounts.Select(a => new GetAccountResponse
        {
            Id = a.Id,
            Name = a.Name,
            Description = a.Description,
            InitialBalance = a.InitialBalance,
            CreatedAt = a.CreatedAt,
            UpdatedAt = a.UpdatedAt
        }).ToList();
    }

    public async Task<GetAccountResponse> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var account = await _unitOfWork.Accounts.GetByIdAsync(id, cancellationToken);

        if (account is null)
            return new();

        return new GetAccountResponse
        {
            Id = account.Id,
            Name = account.Name,
            Description = account.Description,
            InitialBalance = account.InitialBalance,
            CreatedAt = account.CreatedAt,
            UpdatedAt = account.UpdatedAt
        };
    }

    public async Task Update(UpdateAccountRequest request, CancellationToken cancellationToken)
    {
        var account = await _unitOfWork.Accounts.GetByIdAsync(request.Id, cancellationToken);

        if (account is not null)
        {
            account.Name = request.Name;
            account.Description = request.Description;
            account.SetInitialBalance(request.InitialBalance);

            _unitOfWork.Accounts.Update(account);
        }
    }
}