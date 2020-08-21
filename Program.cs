using Queries.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pluto
{

    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<Course> Courses { get; set; }
    }

    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<Course> Courses { get; set; }
    }

    public enum CourseLevel
    {
        Beginner = 1,
        Intermediate = 2,
        Advanced = 3
    }

    class Program
    {
        static void Main(string[] args)
        {
            var context = new PlutoContext();

            var searchCourse = context.Courses.Find(1);

            var authors = context.Authors.ToList();
            var author = context.Authors.Single(a => a.Id == 1);

            var course = new Course
            {
                Name = "Test Course",
                //Author = new Author {  Id = 1, Name = "John" } //it will generate another register in author table
                //Author = author
                AuthorId = 1 //it'll just use the FK directly
            };

            //add in the DbSet
            context.Courses.Add(course);

            context.SaveChanges();

            //delete
            //var a = context.Authors.Include(a => a.Courses).Single(a => a.Id == 2);
            //context.Courses.RemoveRange(a.Courses);
            //context.Authors.Remove();

            var entries = context.ChangeTracker.Entries();

            foreach (var entry in entries)
            {
                entry.Reload();
                Console.WriteLine(entry.State);
            }

            ///implementing the Repository Pattern
            using (var unitOfWork = new UnitOfWork(new PlutoContext()))
            {
                // Example1
                var course1 = unitOfWork.Courses.Get(1);

                // Example2
                var courses = unitOfWork.Courses.GetCoursesWithAuthors(1, 4);

                // Example3
                var author1 = unitOfWork.Authors.GetAuthorWithCourses(1);
                unitOfWork.Courses.RemoveRange(author1.Courses);
                unitOfWork.Authors.Remove(author1);
                unitOfWork.Complete();
            }
        }
    }
}
