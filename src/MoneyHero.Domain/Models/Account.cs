namespace MoneyHero.Domain.Models;

public class Account
{
    public Account(string name, string description, decimal initialBalance)
    {
        Id = Guid.NewGuid();
        Name = name;
        Description = description;
        InitialBalance = initialBalance;
    }

    protected Account() { }

    public Guid Id { get; private set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal InitialBalance { get; private set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public virtual IEnumerable<Operation> Operations { get; set; } = new List<Operation>();

    public void SetInitialBalance(decimal balance)
    {
        InitialBalance = balance;
    }
}
