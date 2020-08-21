using Queries.Core.Domain;
using System.Collections.Generic;

namespace Queries.Core.Repositories
{
    public interface ICourseRepository : IRepository<Pluto.Course>
    {
        IEnumerable<Pluto.Course> GetTopSellingCourses(int count);
        IEnumerable<Pluto.Course> GetCoursesWithAuthors(int pageIndex, int pageSize);
    }
}