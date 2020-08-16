namespace Pluto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateAuthorForeignKeyForCourse : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.TagCourses", newName: "CourseTags");
            DropIndex("dbo.Courses", new[] { "Author_Id" });
            RenameColumn(table: "dbo.Courses", name: "Author_Id", newName: "AuthorId");
            DropPrimaryKey("dbo.CourseTags");
            AlterColumn("dbo.Courses", "AuthorId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.CourseTags", new[] { "Course_Id", "Tag_Id" });
            CreateIndex("dbo.Courses", "AuthorId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Courses", new[] { "AuthorId" });
            DropPrimaryKey("dbo.CourseTags");
            AlterColumn("dbo.Courses", "AuthorId", c => c.Int());
            AddPrimaryKey("dbo.CourseTags", new[] { "Tag_Id", "Course_Id" });
            RenameColumn(table: "dbo.Courses", name: "AuthorId", newName: "Author_Id");
            CreateIndex("dbo.Courses", "Author_Id");
            RenameTable(name: "dbo.CourseTags", newName: "TagCourses");
        }
    }
}
