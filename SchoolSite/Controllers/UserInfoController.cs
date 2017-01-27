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
        [Authorize(Roles="Teacher")]
        public ActionResult AssignSubject(int? id)
        {

            if(id == null)
            {
                return RedirectToAction("Index", "Home");
            }
            var student = db.SchoolMembers.Where(x => x.SchoolMemberId == id).FirstOrDefault();
            var cId = User.Identity.GetUserId();

            var user = db.Users.Where(x => x.Id == cId&&(x.CurrentMember is Teacher)).FirstOrDefault();


            var subjects = (user.CurrentMember as Teacher).CurrentSubjects.ToList();
            var model = new AssignSubjectViewModel();

            model.StudentName = student.Name;
            model.StudentSurname = student.Surname;




            return View(model);
        }
        [Authorize(Roles = "Teacher")]
        [HttpPost]
        public ActionResult AssignSubject(AssignSubjectViewModel item)
        {

            var student = db.SchoolMembers.Include("CurrentSubjects").Where(x => (x is Student) && (x.Name == item.StudentName) && (x.Surname == item.StudentSurname)) as Student;
            var subject = db.Subjects.Where(x => x.SubjectName == item.SubjectName).FirstOrDefault();

            student.CurrentSubjects.Add(subject);

            return View();
        }





        [Authorize(Roles = "Teacher")]
        public ActionResult AssignSubjectToTeacher(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index", "Home");
            }
            var teacher = db.SchoolMembers.Where(x =>(x is Teacher) &&x.SchoolMemberId == id).FirstOrDefault();

            var subjects = db.Subjects.ToList();

            var model = new AssignSubjectToTeacherViewModel();

            model.TeacherName = teacher.Name;
            model.TeacherSurname = teacher.Surname;

            foreach (var item in subjects)
                model.AllSubjects.Add(item.SubjectName);

            return View(model);
        }



        //[Authorize(Roles = "Teacher")]
        //public ActionResult AssignSubjectToTeacher()
        //{
        //    var cId = User.Identity.GetUserId();
        //    //var CurrentUser = db.Users.Where(x => x.Id == cId).FirstOrDefault().CurrentMember;
        //    //var membid = CurrentUser.CurrentMember.SchoolMemberId;



        //    var teacher =  db.Users.Where(x => x.Id == cId).FirstOrDefault().CurrentMember;

        //    var subjects = db.Subjects.ToList();

        //    var model = new AssignSubjectToTeacherViewModel();

        //    model.TeacherName = teacher.Name;
        //    model.TeacherSurname = teacher.Surname;

        //    foreach (var item in subjects)
        //        model.AllSubjects.Add(item.SubjectName);

        //    return View(model);
        //}




        //[Authorize(Roles = "Teacher")]
        [HttpPost]
        public ActionResult AssignSubjectToTeacher(AssignSubjectToTeacherViewModel item)
        {

            var teacher = db.SchoolMembers.Where(x => (x is Teacher) && x.Name == item.TeacherName && x.Surname == item.TeacherSurname)as Teacher;
            var subject = db.Subjects.Where(x => x.SubjectName == item.SubjectName).FirstOrDefault();

            //teacher.CurrentSubjects.Add(subject);

            return RedirectToAction("Index", "Home");
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
        [HttpPost]
        public ActionResult StudentList(string searchstring)
        {
            var list = db.SchoolMembers.Where(x => (x is Student && (x.Name.Contains(searchstring) || x.Surname.Contains(searchstring))));

            List<Student> tlist = new List<Student>();
            foreach (var item in list)
                tlist.Add((Student)item);

            return View(tlist);


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
        [HttpPost]
        public ActionResult TeacherList(string searchstring)
        {

            var list = db.SchoolMembers.Where(x => (x is Teacher && (x.Name.Contains(searchstring) || x.Surname.Contains(searchstring))));

            List<Teacher> tlist = new List<Teacher>();
            foreach (var item in list)
                tlist.Add((Teacher)item);

            return View(tlist);
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