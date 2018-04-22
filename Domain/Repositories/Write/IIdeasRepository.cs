using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Repositories.Write
{
    public interface IIdeasRepository
    {
        Task Add(Idea idea);
    }
}