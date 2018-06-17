using System;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Repositories.Write
{
    public interface IIdeasRepository
    {
        Task Save(Idea idea);

        Task<Idea> Get(Guid id);
    }
}