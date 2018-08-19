﻿using EF6.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF6
{
    internal class Program
    {
        private static int InsertedId;

        private static void Main(string[] args)
        {
            using (var db = new ContosoUniversityEntities())
            {
                Query(db);
                InsertDepartment(db);
                UpdateDepartment(db);
                RemoveDepartment(db);
            }
        }

        private static void RemoveDepartment(ContosoUniversityEntities db)
        {
            db.Department.Remove(db.Department.Find(InsertedId));
            db.SaveChanges();
        }

        private static void UpdateDepartment(ContosoUniversityEntities db)
        {
            var dept = db.Department.Find(InsertedId);
            dept.Name = "John";
            db.SaveChanges();
        }

        public static void InsertDepartment(ContosoUniversityEntities db)
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

        private static void Query(ContosoUniversityEntities db)
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