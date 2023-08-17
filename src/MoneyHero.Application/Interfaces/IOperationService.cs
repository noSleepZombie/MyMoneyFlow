using MoneyHero.Application.Requests;
using MoneyHero.Application.Responses;

namespace MoneyHero.Application.Interfaces;

public interface IOperationService
{
    Task<Guid> Create(CreateOperationRequest request, CancellationToken cancellationToken);
    Task<GetOperationResponse> GetById(Guid id, CancellationToken cancellationToken);
    IEnumerable<GetOperationResponse> GetAll();
    IEnumerable<GetOperationResponse> GetAllByAccountId(Guid accountId);
}