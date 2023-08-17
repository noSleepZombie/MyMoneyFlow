using MoneyHero.Domain.Enums;

namespace MoneyHero.Application.Responses;

public class GetOperationResponse
{
    public Guid Id { get; set; }
    public Guid AccountId { get; set; }
    public decimal Amount { get; set; }
    public OperationFlowType FlowType { get; set; }
    public OperationNature Nature { get; set; }
    public Guid? ParentId { get; set; }
    public DateTime CreatedAt { get; set; }
}