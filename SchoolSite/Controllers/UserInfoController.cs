using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolSite.Models
{
    public class UserInfoController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();


        // GET: UserInfo
        public ActionResult Index()
        {


            return View();
        }



        [Authorize]
        public ActionResult Info()
        {
            var cId = User.Identity.GetUserId();
            var CurrentUser = db.Users.Where(x => x.Id == cId).FirstOrDefault();
            if(CurrentUser.CurrentMember is Teacher)
            {
                return RedirectToAction("Teacher",new {id = CurrentUser.CurrentMember.SchoolMemberId } );
            }
            else if(CurrentUser.CurrentMember is Student)
            {
                return RedirectToAction("Student", new { id = CurrentUser.CurrentMember.SchoolMemberId });
            }


            return View();
        }


  
        [Authorize]
        public ActionResult EditInfo()
        {

            var cId = User.Identity.GetUserId();
            var CurrentUser = db.Users.Where(x => x.Id == cId).FirstOrDefault();
            if (CurrentUser.CurrentMember is Teacher)
            {
                return RedirectToAction("EditInfoTeacher");
            }
            else if (CurrentUser.CurrentMember is Student)
            {
                return RedirectToAction("EditInfoStudent");
            }

            return View();
        }

        [Authorize(Roles = "Teacher")]
        public ActionResult StudentsBySubject()
        {
            var cId = User.Identity.GetUserId();
            var CurrentUser = db.Users.Where(x => x.Id == cId).FirstOrDefault();

            var ListSubjects = ((Teacher)CurrentUser.CurrentMember).CurrentSubjects.ToList();

           



            return View();
        }



        [Authorize]
        public ActionResult EditInfoTeacher()
        {
            var cId = User.Identity.GetUserId();
            var CurrentUser = db.Users.Where(x => x.Id == cId).FirstOrDefault();

            return View((Teacher)CurrentUser.CurrentMember);
        }
        [Authorize]
        public ActionResult EditInfoStudent()
        {
            var cId = User.Identity.GetUserId();
            var CurrentUser = db.Users.Where(x => x.Id == cId).FirstOrDefault();

            return View((Student)CurrentUser.CurrentMember);
        }


        [Authorize]
        [HttpPost]
        public ActionResult EditInfoTeacher(Teacher _memb)
        {
            var cId = User.Identity.GetUserId();
            var CurrentUser = db.Users.Where(x => x.Id == cId).FirstOrDefault();
            CurrentUser.CurrentMember = _memb;

            db.SaveChanges();
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult EditInfoStudent(Student _memb)
        {
            var cId = User.Identity.GetUserId();
            var CurrentUser = db.Users.Where(x => x.Id == cId).FirstOrDefault();
            CurrentUser.CurrentMember = _memb;

            db.SaveChanges();
            return View();
        }


        public ActionResult StudentList()
        {
            var list = db.SchoolMembers.Where(x => x is Student).ToList();

            var TeacherList = new List<Student>();
            foreach (var item in list)
                TeacherList.Add((Student)item);

            return View(TeacherList);
        }

        public ActionResult Student(int? id)
        {
            var Student = db.SchoolMembers.Where(x => (x is Teacher && x.SchoolMemberId == id)).FirstOrDefault();

            return View(Student);

        }

        public ActionResult Teacher(int? id)
        {
            var Teacher = db.SchoolMembers.Where(x => (x is Teacher && x.SchoolMemberId == id)).FirstOrDefault();

            return View(Teacher);
        }

        public ActionResult TeacherList()
        {
            

            var list = db.SchoolMembers.Where(x => x is Teacher).ToList();

           var TeacherList = new List<Teacher>();
            foreach (var item in list)
                TeacherList.Add((Teacher)item);

            Teacher tmp = new Models.Teacher();
            ViewBag.Teacher = tmp;

            return View(TeacherList);
        }





        private ApplicationUserManager _userManager;
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
    }
}