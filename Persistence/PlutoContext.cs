using Pluto.EntityConfigurations;
using System.Data.Entity;

namespace Pluto
{
    public class PlutoContext : DbContext
    {
        public DbSet<Course> Courses { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Tag> Tags { get; set; }
        //public virtual DbSet<Category> Categories { get; set; }

        public PlutoContext()
            : base("name=DefaultConnection")
        {
            this.Configuration.LazyLoadingEnabled = false; //lazy-loading will not gonna be used on this context
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            ////Fluent API
            ////modelBuilder.Entity<Course>()
            ////    .Property(t => t.Description)
            ////    .IsRequired();

            //modelBuilder.Entity<Course>()
            //    .HasRequired(c => c.Author)
            //    .WithMany(a => a.Courses)
            //    .HasForeignKey(c => c.AuthorId)
            //    .WillCascadeOnDelete(false);

            //modelBuilder.Entity<Course>()
            //    .HasMany(c => c.Tags)
            //    .WithMany(t => t.Courses)
            //    .Map(m => {
            //        m.ToTable("CourseTags");
            //        m.MapLeftKey("CourseId"); //left is course
            //        m.MapRightKey("TagId");
            //     });

            //modelBuilder.Entity<Course>()
            //    .HasRequired(c => c.Cover)
            //    .WithRequiredPrincipal(c => c.Course); //Course is the parent

            //base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.Add(new CourseConfiguration());
        }
    }
}
