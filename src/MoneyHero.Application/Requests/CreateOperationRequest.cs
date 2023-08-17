using MoneyHero.Domain.Enums;

namespace MoneyHero.Application.Requests;

public class CreateOperationRequest
{
    public Guid AccountId { get; set; }
    public decimal Amount { get; set; }
    public OperationFlowType Flow { get; set; }
    public OperationNature Nature { get; set; }
}