using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Repositories.Write
{
    public interface ITransactionsRepository
    {
        Task Add(Transaction transaction);
    }
}