namespace TotalMVC.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using TotalMVC.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<TotalMVC.SchoolContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(TotalMVC.SchoolContext context)
        {
            context.Students.AddOrUpdate(s => s.Name,
                new Student
                {
                    Name = "Yangkai",
                    Age = 22,
                    Birth = Convert.ToDateTime("1996-09-23")
                    
                },
                new Student
                {
                    Name = "Songyang",
                    Age = 19,
                    Birth = DateTime.Parse("1996-09-23")
                }
            );
            context.Courses.AddOrUpdate(c => c.CourseID,
                new Course
                {
                    CourseID = 923,
                    Credit = 19,
                    Genre = "Industry"
                },
                new Course
                {
                    CourseID = 283,
                    Credit = 5,
                    Genre = "Literature"
                }
                );

        }
    }
}
