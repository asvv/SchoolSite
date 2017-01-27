using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace SchoolSite.Models
{
    public class UserInfoViewModels
    {
    }

    public class ShowInfoViewModel
    {

    }

    public class AssignSubjectViewModel
    {
        [DisplayName("Nazwa przedmiotu")]
       public string SubjectName
        { get; set; }
        [DisplayName("Imie studenta")]
        public string StudentName
        { get; set; }
        [DisplayName("Nazwisko studenta")]
        public string StudentSurname
        { get; set; }


        public List<string> TeacherSubjects
        { get; set; }  


    }


    public class AssignSubjectToTeacherViewModel
    {
        public AssignSubjectToTeacherViewModel()
        {

            AllSubjects = new List<string>();
        }
        public AssignSubjectToTeacherViewModel(AssignSubjectToTeacherViewModel other)
        {
            SubjectName = other.SubjectName;
            TeacherName = other.TeacherName;
            SubjectName = other.SubjectName;
        }
        [DisplayName("Nazwa przedmiotu")]
        public string SubjectName
        { get; set; }
        [DisplayName("Imie nauczyciela")]
        public string TeacherName
        { get; set; }
        [DisplayName("Nazwisko nauczyciela")]
        public string TeacherSurname
        { get; set; }


        public List<string> AllSubjects
        { get; set; }


    }


    public class TeacherListViewModel
    {


    }
}