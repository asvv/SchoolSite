using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace SchoolSite.Models
{

    public enum MemberType
    {
        Admin,
        Teacher,
        Student,
        Undefined

    }
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            
            return userIdentity;
        }

       
        public MemberType CurrentType
        {
            get;set;
        }
        public virtual SchoolMember CurrentMember
        { get; set; }

        public void AssignType()
        {
            if (CurrentType == MemberType.Student)
                CurrentMember = new Student();
            else if (CurrentType == MemberType.Teacher)
                CurrentMember = new Teacher();
        }

    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
      


      public  DbSet<SchoolMember> SchoolMembers
        { get; set; }

        public DbSet<Subject> Subjects
        { get; set; }

        public DbSet<Grade> Grades
        { get; set; }
    }
}