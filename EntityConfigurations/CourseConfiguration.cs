using System.Data.Entity.ModelConfiguration;

namespace Pluto.EntityConfigurations
{
    public class CourseConfiguration : EntityTypeConfiguration<Course>
    {
        public CourseConfiguration()
        {
            // Table overrides
            ToTable("tbl_Course");

            // PK overrides
            HasKey(c => c.Id);

            // Property configurations
            Property(t => t.Description)
            .IsRequired();

            // Relationships
            HasRequired(c => c.Author)
            .WithMany(a => a.Courses)
            .HasForeignKey(c => c.AuthorId)
            .WillCascadeOnDelete(false);
            
            HasRequired(c => c.Cover)
            .WithRequiredPrincipal(c => c.Course); //Course is the parent

            HasMany(c => c.Tags)
            .WithMany(t => t.Courses)
            .Map(m =>
            {
                m.ToTable("CourseTags");
                m.MapLeftKey("CourseId"); //left is course
                m.MapRightKey("TagId");
            });

        }
    }
}
