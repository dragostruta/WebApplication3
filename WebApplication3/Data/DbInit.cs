using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public static class DbInit
    {
        public static void Init(SchoolContext ctx)
        {
            ctx.Database.EnsureCreated();

            if (ctx.Students.Any())
            {
                return;
            }

            AddStudents(ctx);
            AddCourses(ctx);
            AddEnrollments(ctx);
        }

        private static void AddStudents(SchoolContext ctx)
        {
            var students = new List<Student>()
            {
                new Student { Name = "Dan Balan", EnrollmentDate = DateTime.Parse("2020-10-21") },
                new Student { Name = "Ion Beton", EnrollmentDate = DateTime.Parse("2020-10-22") },
                new Student { Name = "Cezar Frezar", EnrollmentDate = DateTime.Parse("2020-10-23") },
                new Student { Name = "Gica Popescu", EnrollmentDate = DateTime.Parse("2020-10-24") },
                new Student { Name = "Stelian", EnrollmentDate = DateTime.Parse("2020-10-25") }
            };
            students.ForEach(x => ctx.Students.Add(x));
            ctx.SaveChanges();
        }

        private static void AddCourses(SchoolContext ctx)
        {
            var courses = new List<Course>()
            {
                new Course { CourseID = 4005, Title = "Chimie", Credits = 3 },
                new Course { CourseID = 4006, Title = "Marketing", Credits = 3 },
                new Course { CourseID = 4012, Title = "Inginerie", Credits = 4 },
                new Course { CourseID = 4065, Title = "Algoritmi", Credits = 5 },
                new Course { CourseID = 7225, Title = "Geografie", Credits = 2 },
            };
            courses.ForEach(x => ctx.Courses.Add(x));
            ctx.SaveChanges();
        }

        private static void AddEnrollments(SchoolContext ctx)
        {
            var enrollments = new List<Enrollment>()
            {
                new Enrollment { StudentID = 1, CourseID = 4005, Grade = Grade.A },
                new Enrollment { StudentID = 1, CourseID = 4006, Grade = Grade.C },
                new Enrollment { StudentID = 1, CourseID = 4065, Grade = Grade.B },
                new Enrollment { StudentID = 2, CourseID = 7225, Grade = Grade.B },
                new Enrollment { StudentID = 2, CourseID = 4012, Grade = Grade.F },
                new Enrollment { StudentID = 2, CourseID = 4065, Grade = Grade.F },
                new Enrollment { StudentID = 3, CourseID = 4065},
                new Enrollment { StudentID = 4, CourseID = 4005},
                new Enrollment { StudentID = 4, CourseID = 4012, Grade = Grade.F },
                new Enrollment { StudentID = 5, CourseID = 7225, Grade = Grade.C },
                new Enrollment { StudentID = 7, CourseID = 4006, Grade = Grade.A },
                new Enrollment { StudentID = 6, CourseID = 7225 },
            };
            enrollments.ForEach(x => ctx.Enrollments.Add(x));
            ctx.SaveChanges();
        }
    }
}
