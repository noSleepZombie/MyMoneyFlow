namespace MoneyHero.Application.Requests;

public class CreateAccountRequest
{
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; } = string.Empty;
    public decimal InitialBalance { get; set; }
}