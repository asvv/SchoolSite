namespace SchoolSite.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SchoolSite.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SchoolSite.Models.ApplicationDbContext context)
        {

            context.SchoolMembers.AddOrUpdate(x => new { x.Name, x.Surname },
              new Models.Teacher
              {
                  Name = "Anna",
                  Surname = "Kowalska",
                  Room = "A123",
                  TelephoneNumber = "+123123",
                  Degree = "mgr.in¿",
                  Description = "Jestem Anna",
                  School = "Uniwersytet Lodzki"


              },
               new Models.Teacher
                        {
                   Name = "Zbigniew",
                   Surname = "Nowa",
                   Room = "A312",
                   TelephoneNumber = "+133333",
                   Degree = "dr.hab",
                   Description = "Jestem Zbigniew",
                   School = "Uniwersytet Lodzki"
               },
               new Models.Teacher
                         {
                   Name = "Adam",
                   Surname = "Kwiatkowski",
                   Room = "A143",
                   TelephoneNumber = "+12783123",
                   Degree = "mgr.",
                   Description = "Jestem Adam",
                   School = "Uniwersytet Lodzki"
               },
                new Models.Student
                          {
                    Name = "Micha³",
                    Surname = "Durka",
                    Description = "Jestem Micha³'",
                    School = "Uniwersytet Lodzki",
                    YearOfStudies = 3,
                    Specialization = "programowanie",
                   
                    

                },
                 new Models.Student
                            {
                     Name = "Katarzyna",
                     Surname = "Biedronka",
                     Description = "Jestem Katarzyna'",
                     School = "Uniwersytet Lodzki",
                     YearOfStudies = 3,
                     Specialization = "Mobilne",
                 },
                  new Models.Student
                              {
                      Name = "Damian",
                      Surname = "Nowak",
                      Description = "Jestem Damian",
                      School = "Uniwersytet Lodzki",
                      YearOfStudies = 3,
                      Specialization = "Sieci",
                  });


            context.Subjects.AddOrUpdate(x => x.SubjectName,
                new Models.Subject
                {
                    SubjectName = "Programowanie Zaawansowane"
                },
                 new Models.Subject
                 {
                  SubjectName = "Podstawy ASP.NET"
                 },
                 new Models.Subject
                  {
                   SubjectName = "Zaawansowane metody obliczeniowie"
                   },
                   new Models.Subject
                  {
                   SubjectName = "Sztuczna inteligencja"
                   }
                );
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
