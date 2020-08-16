using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace Queries
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new PlutoContext();

            //LINQ Syntax:
            var query =
                from c in context.Courses
                join a in context.Authors on c.AuthorId equals a.Id
                where c.Name.Contains("c#")
                orderby c.Name
                //select c;
                select new { Name = c.Name, Level = c.Level, 
                    AuthorName = c.Author.Name //navigation property present - implicit inner join
                };

            foreach (var course in query)
            {
                Console.WriteLine(course.Name);
            }

            //Grouping
            var q =
                from c in context.Courses
                group c by c.Level
                into g
                select g;

            foreach (var group in q)
            {
                Console.WriteLine(group.Key);

                foreach (var course in group)
                {
                    Console.WriteLine("\t{0}", course.Name);
                }
            }

            //Group join
            //LINQ Syntax:
            //var query2 =
            //    from a in context.Authors
            //    join c in context.Courses on a.Id equals c.Author into g
            //    select new
            //    {
            //        AuthorName = a.Name,
            //        Courses = g.Count()
            //    };

            var q3 = from a in context.Authors
                     from b in context.Courses
                     select new { AuthorName = a.Name, CourseName = b.Name };

            //Extension Methods (Lambda expressions):
            var courses = context.Courses.Where(c => c.Name.Contains("c#")).OrderBy(c => c.Name);

            foreach (var course in query)
            {
                Console.WriteLine(course.Name);
            }

            //
            var tags = context.Courses.Where(c => c.Level == 1).Select(c => c.Tags);
            var tags2 = context.Courses.Where(c => c.Level == 1).SelectMany(c => c.Tags);

            //Partitioning
            context.Courses.Skip(10).Take(10);

            //Element Operators
            context.Courses.FirstOrDefault(c => c.Level > 10);

            //Quantifying
            context.Courses.All(c => c.FullPrice > 10); // Any | Count


        }
    }
}
