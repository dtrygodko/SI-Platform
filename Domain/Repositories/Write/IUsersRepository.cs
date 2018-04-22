using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Repositories.Write
{
    public interface IUsersRepository
    {
        Task Add(User user);
    }
}