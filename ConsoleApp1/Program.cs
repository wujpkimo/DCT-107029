using ConsoleApp1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace ConsoleApp1
{
    internal class Program
    {
        private static int InsertedId;

        private static void Main(string[] args)
        {
            using (var db = new ContosoUniversityEntities())
            {
                db.Database.Log = Console.WriteLine;

                var c = new Course()
                {
                    Title = "Entity Framework 6.2",
                    Credits = CourseCredits.Better,
                    DepartmentID = 1
                };

                db.Course.Add(c);
                db.SaveChanges();

                var item = db.Course.Find(c.CourseID);

                Console.WriteLine(item.Title + " " + item.Credits.ToString());

                //db.Configuration.LazyLoadingEnabled = false;
                //db.Configuration.ProxyCreationEnabled = false;
                //var dept = db.Department.Find(1);

                //var dept = db.Course.Find(1);
                //dept.Title += "!";
                //db.Entry(dept).State = EntityState.Added;
                //db.SaveChanges();

                //var dept = db.Department.Find(20);
                //dept.Name = "John" + DateTime.Now;
                ////db.Entry(dept).State = EntityState.Added;
                //Console.ReadLine();
                //db.SaveChanges();

                //var department = db.Department.Include(p => p.Course);

                //foreach (var dept in department)
                //{
                //    Console.WriteLine(dept.Name);
                //    foreach (var item in dept.Course)
                //    {
                //        Console.WriteLine("\t" + item.Title);
                //    }
                //}

                //QueryCourse(db);

                //InsertDepartment(db);

                //UpdateDepartment(db);

                //RemoveDepartment(db);

                //var items = db.GetDepartment();

                //foreach (var item in items)
                //{
                //    Console.WriteLine(item.Name);
                //}
            }
        }

        private static void InsertDepartment(ContosoUniversityEntities db)
        {
            var dept = new Department()
            {
                Name = "Will",
                Budget = 100,
                StartDate = DateTime.Now
            };

            db.Department.Add(dept);
            db.SaveChanges();

            InsertedId = dept.DepartmentID;
        }

        private static void UpdateDepartment(ContosoUniversityEntities db)
        {
            var dept = db.Department.Find(InsertedId);
            dept.Name = "John";
            db.SaveChanges();
        }

        private static void RemoveDepartment(ContosoUniversityEntities db)
        {
            db.Department.Remove(db.Department.Find(InsertedId));
            db.SaveChanges();
        }

        private static void QueryCourse(ContosoUniversityEntities db)
        {
            var data = from p in db.Course select p;

            foreach (var item in data)
            {
                Console.WriteLine(item.CourseID);
                Console.WriteLine(item.Title);
                Console.WriteLine();
            }
        }
    }
}