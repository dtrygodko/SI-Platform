using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Repositories.Read
{
    public interface IIdeasRepository
    {
        Task<IEnumerable<Idea>> GetIdeasForAuthor(Guid authorId);
        Task<Idea> GetIdea(Guid id);
    }
}