using MoneyHero.Domain.Enums;

namespace MoneyHero.Domain.Models;

public class Operation
{
    public Operation(Guid accountId, decimal amount, OperationFlowType type)
    {
        Id = Guid.NewGuid();
        AccountId = accountId;
        Amount = amount;
        FlowType = type;
    }
    protected Operation() { }

    public Guid Id { get; private set; }
    public Guid AccountId { get; set; }
    public decimal Amount { get; set; }
    public OperationFlowType FlowType { get; set; }
    public OperationNature Nature { get; set; }
    public Guid? ParentId { get; set; }
    public DateTime CreatedAt { get; set; }
    public Operation? Parent { get; set; }
    public virtual Account? Account { get; set; }
}
