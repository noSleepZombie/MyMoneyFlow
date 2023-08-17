using MoneyHero.Application.Requests;
using MoneyHero.Application.Responses;
using System.Linq.Expressions;

namespace MoneyHero.Application.Interfaces;

public interface IAccountService
{
    Task CreateAsync(CreateAccountRequest request, CancellationToken cancellationToken);
    Task<GetAccountResponse> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    IEnumerable<GetAccountResponse> GetAllAsync();
    Task Update(UpdateAccountRequest request, CancellationToken cancellationToken);
    Task Delete(Guid id);
}