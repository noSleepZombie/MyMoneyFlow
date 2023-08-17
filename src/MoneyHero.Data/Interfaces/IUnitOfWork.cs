using MoneyHero.Data.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyHero.Data.Interfaces
{
    public interface IUnitOfWork
    {
        IAccountRepository Accounts { get; }
        IOperationRepository Operations { get; }
        Task SaveAsync();
    }
}
