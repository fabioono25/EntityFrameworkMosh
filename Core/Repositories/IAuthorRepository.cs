using Queries.Core.Domain;

namespace Queries.Core.Repositories
{
    public interface IAuthorRepository : IRepository<Pluto.Author>
    {
        Pluto.Author GetAuthorWithCourses(int id);
    }
}