using MoneyHero.Application.Interfaces;
using MoneyHero.Application.Requests;
using MoneyHero.Application.Responses;
using MoneyHero.Data.Interfaces;
using MoneyHero.Domain.Models;

namespace MoneyHero.Application.Services;

public class OperationService : IOperationService
{
    private IUnitOfWork _unitOfWork;
    public OperationService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Guid> Create(CreateOperationRequest request, CancellationToken cancellationToken)
    {
        var operationEntity = new Operation(
            request.AccountId,
            request.Amount,
            request.Flow,
            request.Nature);

        await _unitOfWork.Operations.AddAsync(operationEntity, cancellationToken);

        return operationEntity.Id;
    }

    public IEnumerable<GetOperationResponse> GetAll()
    {
        var operations = _unitOfWork.Operations.GetAll();

        if (!operations.Any())
            return new List<GetOperationResponse>();

        return operations.Select(o => new GetOperationResponse
        {
            Id = o.Id,
            Amount = o.Amount,
            AccountId = o.AccountId,
            FlowType = o.FlowType,
            Nature = o.Nature,
            ParentId = o.ParentId,
            CreatedAt = o.CreatedAt
        }).ToList();
    }

    public IEnumerable<GetOperationResponse> GetAllByAccountId(Guid accountId)
    {
        var operations = _unitOfWork.Operations.GetAll();

        if (!operations.Any())
            return new List<GetOperationResponse>();

        return operations
            .Select(o => new GetOperationResponse
            {
                Id = o.Id,
                Amount = o.Amount,
                AccountId = o.AccountId,
                FlowType = o.FlowType,
                Nature = o.Nature,
                ParentId = o.ParentId,
                CreatedAt = o.CreatedAt
            })
            .Where(o => o.Id == accountId)
            .ToList();
    }

    public async Task<GetOperationResponse> GetById(Guid id, CancellationToken cancellationToken)
    {
        var operation = await _unitOfWork.Operations.GetByIdAsync(id, cancellationToken);

        if (operation is null)
            return new();

        return new()
        {
            Id = operation.Id,
            Amount = operation.Amount,
            AccountId = operation.AccountId,
            FlowType = operation.FlowType,
            Nature = operation.Nature,
            ParentId = operation.ParentId,
            CreatedAt = operation.CreatedAt
        };
    }
}