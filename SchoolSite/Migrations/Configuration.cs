namespace SchoolSite.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SchoolSite.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "SchoolSite.Models.ApplicationDbContext";
        }

        protected override void Seed(SchoolSite.Models.ApplicationDbContext context)
        {

           var RoleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            string[] roles =
            {
                "Admin",
                "Teacher",
                "Student"

            };

            foreach (var item in roles)
            {
                if (!RoleManager.RoleExists(item))
                    RoleManager.Create(new IdentityRole(item));
            }



            context.SchoolMembers.AddOrUpdate(p => p.SchoolMemberId,
                new Models.Student()
                {
                    SchoolMemberId = 1,
                    Name = "Michal",
                    Surname = "Durka",
                    YearOfStudies = 3,
                    Description = "Jestem Michal",
                    Specialization = " Programowanie",
                    StudiesName = "Informatyka Stosowana",
                    School = "Uniwersytet Lodzki",
                    //CurrentSubjects = new List<Models.Subject>()
                    // {
                    //     new Models.Subject() {SubjectId = 1},
                    //     new Models.Subject() {SubjectId = 2},
                    //     new Models.Subject() {SubjectId = 3},
                    //     new Models.Subject() {SubjectId = 4},
                    //     new Models.Subject() {SubjectId = 5},
                    //     new Models.Subject() {SubjectId = 6}
                    // }
                },
                new Models.Student()
                {
                    SchoolMemberId = 2,
                    Name = "Jakub",
                    Surname = "Grygloch",
                    YearOfStudies = 3,
                    Description = "Jestem Kuba",
                    Specialization = "Sieci komputerowe",
                    StudiesName = "Informatyka Stosowana",
                    School = "Uniwersytet Lodzki",
                    //CurrentSubjects = new List<Models.Subject>()
                    // {
                    //     new Models.Subject() {SubjectId = 4},
                    //     new Models.Subject() {SubjectId = 5},
                    //     new Models.Subject() {SubjectId = 6}
                    // }
                },
                new Models.Student()
                {
                    SchoolMemberId = 3,
                    Name = "Elzbieta",
                    Surname = "Kanoru",
                    YearOfStudies = 3,
                    Description = "Jestem Elzbieta",
                    Specialization = " Programowanie",
                    StudiesName = "Informatyka Stosowana",
                    School = "Uniwersytet Lodzki",
                    //CurrentSubjects = new List<Models.Subject>()
                    // {
                    //     new Models.Subject() {SubjectId = 1},
                    //     new Models.Subject() {SubjectId = 2},
                    //     new Models.Subject() {SubjectId = 6}
                    // }
                },
                new Models.Student()
                {
                    SchoolMemberId = 4,
                    Name = "Radoslaw",
                    Surname = "Jutwyniok",
                    YearOfStudies = 3,
                    Description = "Jestem Radoslaw",
                    Specialization = "Mobilne",
                    StudiesName = "Informatyka Stosowana",
                    School = "Uniwersytet Lodzki",
                    //CurrentSubjects = new List<Models.Subject>()
                    // {
                    //     new Models.Subject() {SubjectId = 4},
                    //     new Models.Subject() {SubjectId = 5},
                    //     new Models.Subject() {SubjectId = 6}
                    // }
                },
                new Models.Teacher()
                {
                    SchoolMemberId = 5,
                    Name = "Anna",
                    Surname = "Gutrega",
                    Degree = "mgr.inz",
                    Room = "123",
                    TelephoneNumber = "+1235654",
                    //CurrentSubjects = new List<Models.Subject>()
                    // {
                    //     new Models.Subject() {SubjectId = 4},
                    //     new Models.Subject() {SubjectId = 5},
                    //     new Models.Subject() {SubjectId = 6}
                    // }

                },
               new Models.Teacher()
               {
                   SchoolMemberId = 6,
                   Name = "Elzbieta",
                   Surname = "Genarczyk",
                   Degree = "mgr",
                   Room = "172",
                   TelephoneNumber = "+123332654",
                   //CurrentSubjects = new List<Models.Subject>()
                   //  {
                   //      new Models.Subject() {SubjectId = 2},
                   //      new Models.Subject() {SubjectId = 5},
                   //      new Models.Subject() {SubjectId = 6}
                   //  }

               },
               new Models.Teacher()
               {
                   SchoolMemberId = 7,
                   Name = "Zbigniew",
                   Surname = "Wolonszaj",
                   Degree = "dr.hab",
                   Room = "262",
                   TelephoneNumber = "+126548",
                   //CurrentSubjects = new List<Models.Subject>()
                   //  {
                   //      new Models.Subject() {SubjectId = 1},
                   //      new Models.Subject() {SubjectId = 2},
                   //      new Models.Subject() {SubjectId = 3}
                   //  }
               }
                );
            context.SaveChanges();





            context.Subjects.AddOrUpdate(p => p.SubjectName,
                 new Models.Subject() { SubjectId = 1, SubjectName = "Podstawy ASP NET" },
                 new Models.Subject() { SubjectId = 2, SubjectName = "Programowanie" },
                 new Models.Subject() { SubjectId = 3, SubjectName = "Bazd33y danych" },
                 new Models.Subject() { SubjectId = 4, SubjectName = "Sieci" },
                 new Models.Subject() { SubjectId = 5, SubjectName = "Programowanie Klient-Serwer" },
                 new Models.Subject() { SubjectId = 6, SubjectName = "Sztuczna Inteligencja" }
             );
            context.SaveChanges();


            // var UserManager = new UserManager<IdentityUser>(new UserStore<IdentityUser>(context));



            //RoleManager.

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
